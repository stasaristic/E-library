using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace E_biblioteka
{
    public partial class Delo : Form
    {
        string query;
        int korisnik_ID;
        int id; //id dela
        int broj_dostupnih;
        private OpenFileDialog fd = new OpenFileDialog();
        private FileStream fs;
        byte[] buffer = null;

        public Delo(string query, int korisnik_ID)
        {
            InitializeComponent();
            this.query = query;
            this.korisnik_ID = korisnik_ID;
            ExecuteQuery(query);
            autoriDgv.DataSource = load();
            autoriDgv.AutoResizeColumns();
        }
        MySqlConnection con = new MySqlConnection("server = localhost; database = e_biblioteka; username = root; password =; SSL Mode = None");


        public void ExecuteQuery(string query)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        //dr[broj] - broj kolone iz query upita, upit zapisan u MenuStudent
                        naslov_godinaLbl.Text = dr[1].ToString() + " (" + dr[4].ToString() + ")";
                        vrsta_izdavacLbl.Text = dr[2].ToString() + "  |  " + dr[3].ToString();
                        isbnLbl.Text = dr[5].ToString();
                        dostupnaLbl.Text = dr[9].ToString();
                        broj_dostupnih = Convert.ToInt32(dr[9].ToString());
                        id = Convert.ToInt32(dr[0].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Nije pronadjen nijedan rezultat pretrage");
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private BindingSource load()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmdd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            string sql = "SELECT zanimanje, ime_prezime, naziv_poglavlja from dela_ljudi where delo_ID= " + id + " order by naziv_poglavlja ";

            
            String query1 = "SELECT naslovna_strana FROM dela WHERE delo_ID= " + id + " AND naslovna_strana IS NOT NULL";
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query1, con);
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read())

                {
                    var len = dr.GetBytes(0, 0, null, 0, 0);
                    byte[] slika = new byte[len];
                    dr.GetBytes(0, 0, slika, 0, slika.Length);

                    MemoryStream ms = new MemoryStream(slika);
                    Bitmap bm = new Bitmap(ms, false);
                    pictureBox.Image = bm;

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                con.Close();
            }



            cmdd = new MySqlCommand(sql, con);

            adapter.SelectCommand = cmdd;
            adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            return bs;

        }


        private void Delo_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void zatvoriBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void rezervisiBtn_Click(object sender, EventArgs e)
        {
           
            if (broj_dostupnih>0)
            {
                con.Open();
                string query = "INSERT INTO rezervacija(knjiga_ID, korisnik_ID) VALUES ('" + id + "','" + korisnik_ID + "')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();

//i pri rezervaciji broj dostupnih knjiga se smanji za 1
                string query1 = "UPDATE dela SET broj_dostupnih=broj_dostupnih-1 where delo_ID= " + id + "";
                MySqlCommand cmd1 = new MySqlCommand(query1, con);
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Uspešno ste rezervisali delo!", "Rezervacija dela uspešna!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                con.Close();
                this.Close();
                
            }
            else MessageBox.Show("Nemoguća rezervacija!");
            
        }


    }
}
