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
    public partial class Login : Form
    {
        public static string korisnickoIme, ime, prezime, rola;
        public Login()
        {
            InitializeComponent();
        }
        static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e_biblioteka; SSL Mode = None";
        MySqlConnection databaseConnection = new MySqlConnection(Login.MySQLConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            korisnickoImeTb.Text = "";
            LozinkaTb.Text = "";
        }

        private void potvrdiBtn_Click(object sender, EventArgs e)
        {
            string  korisnicko_ime, lozinka, tip_korisnika;
            int korisnik_ID;

            if (korisnickoImeTb.Text == "" || LozinkaTb.Text == "")
            {
                MessageBox.Show("Unesite korisničko ime i lozinku!", "Prijava nije uspela!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (korisnickoImeTb.Text != "" & LozinkaTb.Text != "")
            {
                string login = "SELECT * FROM korisnik WHERE korisnicko_ime= '" + korisnickoImeTb.Text + "' and lozinka= '" + LozinkaTb.Text + "'";
                cmd = new MySqlCommand(login, this.databaseConnection);

                try
                {
                    this.databaseConnection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read() == true)
                    {
                            
                        // korisnik ima korisnik_ID, korisnicko_ime, lozinka, tip_korisnika, ime, prezime
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5) };

                        korisnik_ID = Convert.ToInt32(row[0]);
                        korisnicko_ime = row[1];
                        lozinka = row[2];
                        tip_korisnika = row[3];
                        Console.WriteLine(tip_korisnika);
                        korisnickoIme = korisnickoImeTb.Text;
                        ime = row[4];
                        prezime = row[5];
                        rola = tip_korisnika;
                        if (tip_korisnika == "admin")
                        {
                            MenuAdmin meniAdmina = new MenuAdmin(korisnik_ID);
                            meniAdmina.Show();
                            this.Hide();
                        }
                        else if (tip_korisnika == "student")
                        {
                            MenuStudent meniStudenta = new MenuStudent(korisnik_ID);
                            meniStudenta.Show();
                            this.Hide();
                        }
                       else if (tip_korisnika == "bibliotekar")
                       {
                            MenuBibliotekar meniBibliotekara = new MenuBibliotekar();
                            meniBibliotekara.Show();
                            this.Hide();
                       }
                  
                        cmd.Dispose();
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Pogrešno korisničko ime ili lozinka!\nMolimo pokušajte ponovo!", "Prijava nije uspela!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clear();
                        cmd.Dispose();
                        reader.Close();
                    }
                    this.databaseConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }  

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void otkaziBtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void prikaziSifruCb_CheckedChanged_1(object sender, EventArgs e)
        {
            if (prikaziSifruCb.Checked)
            {
                LozinkaTb.PasswordChar = '\0';
            }
            else
            {
                LozinkaTb.PasswordChar = '•';                
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }
    }
}
