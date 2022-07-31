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
    public partial class NaslovnaStrana : Form
    {
        int id_dela;
        public NaslovnaStrana(int KeyD)
        {
            InitializeComponent();
            this.id_dela = KeyD;
            ucitajSliku();
            fd.InitialDirectory = "c://";
            fd.FileOk += fd_FileOK;

        }

        //za slike

        private OpenFileDialog fd = new OpenFileDialog();
        private FileStream fs;
        byte[] buffer = null;
        MySqlConnection con = new MySqlConnection("server = localhost; database = e_biblioteka; username = root; password =; SSL Mode = None");

        public void ucitajSliku()
        {
            String query = "SELECT naslovna_strana FROM dela WHERE delo_ID= " + id_dela + " AND naslovna_strana IS NOT NULL";
            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
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
        }


        //  ZA SLIKE

        private void fd_FileOK(Object sender, EventArgs e)
        {
            if ((fs = (FileStream)fd.OpenFile()) != null)
            {
                byte[] buffer;
                buffer = new byte[fs.Length];

                fs.ReadAsync(buffer, 0, (int)fs.Length);
                String name = fs.Name;

                String[] n = name.Split('\\');
                String fileName = n[n.Length - 1];
                String[] ext = fileName.Split('.');
                String fileExtention = ext[ext.Length - 1];
                String fileSavename = ext[0];

                UploadMaterial(fileSavename, fileExtention, buffer);
            }
            else MessageBox.Show("Nije izabran fajl");
        }


        private void UploadMaterial(String name, String ext, byte[] buffer)
        {
            String query = "UPDATE dela SET naslovna_strana=@sadrzaj, tip_naslovne_strane='" + ext + "', naziv_naslovne_strane='" + name + "' WHERE delo_ID=" + id_dela + "";

            try
            {
                con.Open();
                MySqlCommand command = new MySqlCommand();
                MySqlParameter param = command.Parameters.Add("@sadrzaj", MySqlDbType.LongBlob);
                param.Value = buffer;
                MySqlTransaction transaction = con.BeginTransaction();
                command.Connection = con;
                command.Transaction = transaction;
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Fajl je dodat");
                transaction.Commit();
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



        private void promeniBtn_Click(object sender, EventArgs e)
        {
            fd.ShowDialog();
            ucitajSliku();

        }

        private void zatvoriBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
