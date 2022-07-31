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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e_biblioteka; SSL Mode = None";
        MySqlConnection databaseConnection = new MySqlConnection(Register.MySQLConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();


        private void clear()
        {
            imeTb.Text = "";
            prezimeTb.Text = "";
            korisnickoImeTb.Text = "";
            LozinkaTb.Text = "";
            potLozinkaTb.Text = "";
        }

        private void potvrdiBtn_Click(object sender, EventArgs e)
        {
            if (imeTb.Text == "" || prezimeTb.Text == "" || korisnickoImeTb.Text == "" || LozinkaTb.Text == "" || potLozinkaTb.Text == "")
            {
                MessageBox.Show("Popunite sva prazna polja!", "Registracija nije uspela!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //clear();
            }
            else if (LozinkaTb.Text != potLozinkaTb.Text)
            {
                MessageBox.Show("Potvrdna lozinka se ne poklapa sa unetom lozinkom!", "Registracija nije uspela!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LozinkaTb.Text = "";
                potLozinkaTb.Text = "";
            }
            else
            {
                databaseConnection.Open();
                string register = "INSERT INTO zahtevi_za_registraciju(korisnicko_ime, lozinka, ime, prezime) VALUES (@korisnicko_ime, @lozinka, @ime, @prezime)";
                cmd = new MySqlCommand(register, this.databaseConnection);
                cmd.Parameters.AddWithValue("@korisnicko_ime", korisnickoImeTb.Text);
                cmd.Parameters.AddWithValue("@lozinka", LozinkaTb.Text);
                cmd.Parameters.AddWithValue("@ime", imeTb.Text);
                cmd.Parameters.AddWithValue("@prezime", prezimeTb.Text);

                cmd.ExecuteNonQuery();

                databaseConnection.Close();
                MessageBox.Show("Uspešno ste poslali zahtev za registraciju!\nMolimo sačekajte potvrdu registracije!", "Uspešna registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
        }

        private void otkaziBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void prikaziSifruCb_CheckedChanged(object sender, EventArgs e)
        {
            if (prikaziSifruCb.Checked)
            {
                LozinkaTb.PasswordChar = '\0';
                potLozinkaTb.PasswordChar = '\0';
            }
            else 
            {
                LozinkaTb.PasswordChar = '•';
                potLozinkaTb.PasswordChar = '•';
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
