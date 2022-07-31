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

namespace E_biblioteka
{
    public partial class MenuStudent : Form
    {
        int korisnik_ID;
        public static string korisnickoIme = Login.korisnickoIme;
        public MenuStudent(int korisnik_ID)
        {
            InitializeComponent();
            this.korisnik_ID = korisnik_ID;
            setVrsteDela();
            delaDgv.DataSource = load();
            delaDgv.AutoResizeColumns();
            rezervacijeDgv.DataSource = loadRezervacije();
            rezervacijeDgv.AutoResizeColumns();
            pozajmljenoDgv.DataSource=loadPozajmice();
            pozajmljenoDgv.AutoResizeColumns();
            PrikaziObavestenja();

        }
        MySqlConnection con = new MySqlConnection("server = localhost; database =e_biblioteka; username = root; password =; SSL Mode = None");
        int id = 0; //ID DELA

        private void odjaviSeBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void potvrdiPromenuBtn_Click(object sender, EventArgs e)
        {
            string staraLozinka = staraLozStudTb.Text;
            string novaLoz = novaLozStudTb.Text;
            string potNovaLoz = potNovaLozStudTb.Text;
            if (novaLoz == potNovaLoz)
            {
                this.con.Open();
                string query = "UPDATE korisnik SET lozinka=@novaLoz where korisnicko_ime=@korisnickoIme and lozinka=@staraLozinka";
                MySqlCommand cmd = new MySqlCommand(query, this.con);
                cmd.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                cmd.Parameters.AddWithValue("@staraLozinka", staraLozinka);
                cmd.Parameters.AddWithValue("@novaLoz", novaLoz);

                cmd.ExecuteNonQuery();
                this.con.Close();
                MessageBox.Show("Uspešno ste promenili loziku!", "Promena lozinke uspešna!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nova lozinka i potvrda lozinke se ne slaze!", "Izmena lozinke nije izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delaTab_Click(object sender, EventArgs e)
        {
            delaDgv.DataSource = load();
            rezervacijeDgv.DataSource = loadRezervacije();
        }


        //citanje vrste dela iz baze -> zbog dodavanja novih vrsta dela!

        public void setVrsteDela()
        {
             try
            {
                con.Open();
                String query = "SELECT DISTINCT naziv_vrste_dela FROM vrsta_dela";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    vrstaDelaCb.Items.Add(dr[0].ToString());
                }
                dr.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally { con.Close(); }
        }





        private BindingSource load()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmdd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            

            string sql = "SELECT delo_ID as ID, naziv_dela, godina_izdanja , izdavac,  v.naziv_vrste_dela, ISBN_broj as ISBN, broj_dostupnih FROM dela inner join vrsta_dela as v on dela.vrsta_dela_ID=v.vrsta_dela_ID";


            //za pretragu (ukoliko je nepopunjeno svakako stampa sva dela)
            if (!(nazivDelaTb.Text.Trim().Equals("")))
            {
                sql += " AND naziv_dela LIKE '%" + nazivDelaTb.Text.Trim() + "%'";
            }
            if (vrstaDelaCb.SelectedItem != null)
            {
                sql += " AND v.naziv_vrste_dela='" + vrstaDelaCb.SelectedItem.ToString() + "'";
            }

            cmdd = new MySqlCommand(sql, con);

            adapter.SelectCommand = cmdd;

            adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            return bs;
        }

        private void pozajmljenaTab_Click(object sender, EventArgs e)
        {

        }

        private void pretraziDelaBtn_Click(object sender, EventArgs e)
        {
            delaDgv.DataSource = load(); //if delovi se odnose na pretragu
        }


        private void vrstaDelaCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

//dupli klik na neko delo otvara prozor sa vise inf o tom delu -> tu se delo rezervise
        private void delaDgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            id=Convert.ToInt32(delaDgv.SelectedRows[0].Cells[0].Value.ToString());

            if (id != 0)
            {
                string query = "select dela.delo_ID, naziv_dela, v.naziv_vrste_dela, izdavac, godina_izdanja, ISBN_broj, zanimanje, naziv_poglavlja, ime_prezime, broj_dostupnih from dela inner join dela_ljudi on dela.delo_ID=dela_ljudi.delo_ID inner join vrsta_dela as v on v.vrsta_dela_ID=dela.vrsta_dela_ID and dela.delo_ID=" + id + " order by naziv_poglavlja";
                Delo delo = new Delo(query, korisnik_ID);
                delo.Show();
            }
            
            

        }

        private void nazivDelaTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void otkaziPromenuLozAdmin_Click(object sender, EventArgs e)
        {

        }

        private void obavestenjaAdminDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MenuStudent_Load(object sender, EventArgs e)
        {
            string ime = Login.ime;
            string prezime = Login.prezime;
            imeStudLbl.Text = "Dobrodošli, " + ime + " " + prezime + "!";

            string rola = Login.rola;
            rolaStudLbl.Text = "Vaša rola je " + rola + ".";

        }

        private void otkaziPromenuBtn_Click(object sender, EventArgs e)
        {
            staraLozStudTb.Text = "";
            novaLozStudTb.Text = "";
            potNovaLozStudTb.Text = "";
        }

        private void delaDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

//-----------------------------------------tab DELA
        private BindingSource loadRezervacije()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmdd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            string sql = "SELECT rezervacija_ID, knjiga_ID, naziv_dela, vreme_rezervacije from rezervacija inner join dela on knjiga_ID=delo_ID where korisnik_ID='"+korisnik_ID+"'";
            cmdd = new MySqlCommand(sql, con);


 //BRISANJE REZERVACIJE ---> NAKON 24H SE BRISE
            con.Open();
            string query2 = "DELETE from rezervacija where hour(timediff(now(),vreme_rezervacije))>23 and korisnik_ID='" + korisnik_ID + "'";
            MySqlCommand cmd2 = new MySqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            con.Close();

            adapter.SelectCommand = cmdd;
            adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            return bs;
        }


        int idRezervacije, idKnjige;

        private void rezervacijeDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idRezervacije = Convert.ToInt32(rezervacijeDgv.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
            idKnjige = Convert.ToInt32(rezervacijeDgv.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());

        }

        private void potrvdiRezBtn_Click(object sender, EventArgs e)
        {
            if (idRezervacije == 0)
            {
                MessageBox.Show("Nije selektovana rezervacija", "Potvrda rezervacije neuspešna!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    string query = "DELETE from rezervacija where rezervacija_ID="+idRezervacije;
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    string query1 = "INSERT INTO pozajmica(knjiga_ID, korisnik_ID, vraceno) VALUES ('" + idKnjige + "','" + korisnik_ID + "','Ne')";
                    MySqlCommand cmd1 = new MySqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Uspešno ste potvrdili rezervaciju!", "Potvrda rezervacije uspešna!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    delaDgv.DataSource = load();
                    rezervacijeDgv.DataSource = loadRezervacije();
                    pozajmljenoDgv.DataSource = loadPozajmice();

                    idRezervacije = 0;

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    con.Close();
                }
            }

        }



        private void odbijRezBtn_Click(object sender, EventArgs e)
        {
            if (idRezervacije == 0)
            {
                MessageBox.Show("Nije selektovana rezervacija", "Neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    string query = "DELETE from rezervacija where rezervacija_ID=" + idRezervacije;
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    
//pri odbijanju rezervacije broj dostupnih knjiga se povecava za 1
                    string query2 = "UPDATE dela SET broj_dostupnih=broj_dostupnih+1 where delo_ID= " + idKnjige + "";
                    MySqlCommand cmd2 = new MySqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    

                    MessageBox.Show("Uspešno ste odbili rezervaciju!", "Rezervacije je uspešno odbijena!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    delaDgv.DataSource = load();
                    rezervacijeDgv.DataSource = loadRezervacije();

                    idRezervacije = 0;

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    con.Close();
                }
            }
        }

        private void profilTab_Click(object sender, EventArgs e)
        {

        }


        //------------------------------------------tab pozajmljena dela

        private BindingSource loadPozajmice()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmdd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            string sql = "SELECT pozajmica_ID, knjiga_ID, naziv_dela, datum_uzimanja from pozajmica inner join dela on knjiga_ID=delo_ID where korisnik_ID='" + korisnik_ID + "' and vraceno='Ne' ";
            

            //za pretragu (ukoliko je nepopunjeno svakako stampa sva dela)
            if (!(nazivDelaPozTb.Text.Trim().Equals("")))
            {
                sql += " AND naziv_dela LIKE '%" + nazivDelaPozTb.Text.Trim() + "%'";
            }

            cmdd = new MySqlCommand(sql, con);


            
//BRISANJE POZAJMICE---> NAKON 30 dana SE BRISE, vraceno nije da, jer student nije vratio!!!
            con.Open();
            string query2 = "UPDATE pozajmica set  isteklo='Da', seen_student=0,seen_bibliotekar=0 where datediff(now(),datum_uzimanja)>30 and korisnik_ID='" + korisnik_ID + "' and vraceno='Ne'";
            MySqlCommand cmd2 = new MySqlCommand(query2, con);
            cmd2.ExecuteNonQuery();
            con.Close();

            adapter.SelectCommand = cmdd;
            adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            return bs;
        }



        private void pretraziPozBtn_Click(object sender, EventArgs e)
        {
            pozajmljenoDgv.DataSource = loadPozajmice();
        }

//----------------------------------------obavestenja za studenta----------------------

        private void PrikaziObavestenja()
        {
            con.Open();
            string query = "SELECT pozajmica_ID, knjiga_ID, naziv_dela, datum_uzimanja from pozajmica inner join dela on knjiga_ID=delo_ID where korisnik_ID='" + korisnik_ID + "' and isteklo='Da' and seen_student=0 ";

            MySqlDataAdapter da = new MySqlDataAdapter();
            da = new MySqlDataAdapter(query, con);
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            obavestenjaStudentDgv.DataSource = ds.Tables[0];
            string query1 = "UPDATE pozajmica set seen_student=1 where korisnik_ID='" + korisnik_ID + "' and isteklo='Da' ";
            MySqlCommand cmd1 = new MySqlCommand(query1, con);
            cmd1.ExecuteNonQuery();

            con.Close();
        }
    }
}
