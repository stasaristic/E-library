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
    public partial class MenuBibliotekar : Form
    {
        public static string korisnickoIme = Login.korisnickoIme;
        public MenuBibliotekar()
        {
            InitializeComponent();
            setVrsteDela();
            PrikaziStudente();
            PrikaziZahteve();
            delaDgv.DataSource = loadDela();
            delaDgv.AutoResizeColumns();
            dosijeDgv.DataSource=loadDosije();
            dosijeDgv.AutoResizeColumns();
            rezervacijeDgv.DataSource = loadRezervacije();
            rezervacijeDgv.AutoResizeColumns();
            PrikaziObavestenja();
            obavestenjaStudentDgv.AutoResizeColumns();
        }
        static string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=e_biblioteka; SSL Mode = None";
        MySqlConnection databaseConnection = new MySqlConnection(MenuBibliotekar.MySQLConnectionString);
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();


        private void odjaviSeBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }


        //promenljiva koja se koristi za hvatanje ID-a
        int Key = 0;
        int KeyD = 0; // za dela

        // funkcija za prikazivanje studenata u tabeli
        private void PrikaziStudente(string searchQuery = "SELECT korisnik_ID, korisnicko_ime, lozinka, ime, prezime FROM korisnik where tip_korisnika='student'")
        {
            this.databaseConnection.Open();
            da = new MySqlDataAdapter(searchQuery, databaseConnection);
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            studentiDvg.DataSource = ds.Tables[0];
            this.databaseConnection.Close();
        }

        // provera da li su sva polja za studente popunjena
        bool ProveriPoljaStud()
        {
            if (imeStudentTb.Text == "" || prezimeStudentTb.Text == ""
                || korisnickoImeStudentTb.Text == "" || lozinkaStudentTb.Text == "")
            {
                return true;
            }
            else { return false; }
        }

        // funkcija koja prazni polja na student panelu
        private void ResetStudents()
        {
            Key = 0;
            imeStudentTb.Text = "";
            prezimeStudentTb.Text = "";
            korisnickoImeStudentTb.Text = "";
            lozinkaStudentTb.Text = "";
        }

        // funkcija koja omogucava da klikom na studenta popunimo polja
        // ova funkcija ce omoguciti selektovanje studenta zbog njegovog uklanjanja iz tabele
        // ili zbog izmene podataka o studentu
        private void studentiDvg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            korisnickoImeStudentTb.Text = studentiDvg.SelectedRows[0].Cells[1].Value.ToString();
            lozinkaStudentTb.Text = studentiDvg.SelectedRows[0].Cells[2].Value.ToString();
            imeStudentTb.Text = studentiDvg.SelectedRows[0].Cells[3].Value.ToString();
            prezimeStudentTb.Text = studentiDvg.SelectedRows[0].Cells[4].Value.ToString();

            if (imeStudentTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(studentiDvg.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        // funkcija koja klikom da dugme dodajStudBtn omogucava dodavanje novih studenata
        private void dodajStudBtn_Click(object sender, EventArgs e)
        {
            if (ProveriPoljaStud() == true)
            {
                MessageBox.Show("Nisu uneti svi podaci!", "Dodavanje studenta neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.databaseConnection.Open();

                    // hvatanje unetih podataka
                    // unosenje tih podataka u bazu
                    string query = "INSERT INTO korisnik(korisnicko_ime, lozinka, tip_korisnika, ime, prezime) VALUES (@korisnicko_ime, @lozinka, @tip_korisnika, @ime, @prezime)";
                    cmd = new MySqlCommand(query, this.databaseConnection);

                    cmd.Parameters.AddWithValue("@korisnicko_ime", korisnickoImeStudentTb.Text);
                    cmd.Parameters.AddWithValue("@lozinka", lozinkaStudentTb.Text);
                    // automatski se stavlja da je tip korisnika student jer se nalazimo
                    // na panelu za dodavanje studenta
                    cmd.Parameters.AddWithValue("@tip_korisnika", "student");
                    cmd.Parameters.AddWithValue("@ime", imeStudentTb.Text);
                    cmd.Parameters.AddWithValue("@prezime", prezimeStudentTb.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uspešno ste dodali studenta!", "Dodavanje studenta uspešno!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.databaseConnection.Close();

                    // kada se konekcija sa bazom zatvori
                    // refreshujemo tabelu studenata da se vidi novi dodati student funkcijom DisplayStudents()
                    // praznimo polja koja smo prethodno popunjavali funkcijom Reset()
                    PrikaziStudente();
                    ResetStudents();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    this.databaseConnection.Close();
                }
            }
        }

        // izmeniStudBtn menja podatke o selektovanom studentu
        private void izmeniStudBtn_Click(object sender, EventArgs e)
        {
            if (ProveriPoljaStud() == true)
            {
                MessageBox.Show("Nisu uneti svi podaci!", "Izmena podataka studenta neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.databaseConnection.Open();

                    string query = "UPDATE korisnik SET korisnicko_ime = @korisnicko_ime, lozinka = @lozinka, ime = @ime, prezime = @prezime WHERE korisnik.korisnik_id = @Key";
                    cmd = new MySqlCommand(query, this.databaseConnection);
                    cmd.Parameters.AddWithValue("@korisnicko_ime", korisnickoImeStudentTb.Text);
                    cmd.Parameters.AddWithValue("@lozinka", lozinkaStudentTb.Text);
                    cmd.Parameters.AddWithValue("@ime", imeStudentTb.Text);
                    cmd.Parameters.AddWithValue("@prezime", prezimeStudentTb.Text);
                    cmd.Parameters.AddWithValue("@Key", Key);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uspešno promenili informacije o studentu!", "Dodavanje studenta uspešno!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.databaseConnection.Close();
                    PrikaziStudente();
                    ResetStudents();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    this.databaseConnection.Close();
                }
            }
        }

        private void obrisiStudBtn_Click(object sender, EventArgs e)
        {
            if (ProveriPoljaStud() == true)
            {
                MessageBox.Show("Selektujte studenta kog želite da uklonite", "Uklanjanje studenta neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (Key == 0)
                    {
                        MessageBox.Show("Selektujte studenta kog želite da uklonite", "Uklanjanje studenta neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.databaseConnection.Open();

                        string query = "DELETE FROM korisnik WHERE korisnik_ID = @Key";
                        cmd = new MySqlCommand(query, this.databaseConnection);
                        cmd.Parameters.AddWithValue("@Key", Key);

                        cmd.ExecuteNonQuery();

                        this.databaseConnection.Close();
                        PrikaziStudente();
                        ResetStudents();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    this.databaseConnection.Close();
                }

            }
        }

        // otkaziStudBtn prazni polja na panelu studenti
        private void otkaziStudBtn_Click(object sender, EventArgs e)
        {
            ResetStudents();
            PrikaziStudente();
        }

        private string SelectQueryStud()
        {
            string selectQuery = "SELECT korisnik_ID, korisnicko_ime, lozinka, ime, " +
                "prezime FROM korisnik where tip_korisnika = 'student'";

            if (imeStudentTb.Text != "" & prezimeStudentTb.Text != "")
            {
                string ime = imeStudentTb.Text;
                string prezime = prezimeStudentTb.Text;

                selectQuery = "SELECT korisnik_ID, korisnicko_ime, lozinka, ime, " +
                    "prezime FROM korisnik where tip_korisnika='student' AND ime='"
                    + ime + "'" + "AND prezime='" + prezime + "'";
            }
            else if ((imeStudentTb.Text == "" & prezimeStudentTb.Text != "") || (imeStudentTb.Text != "" & prezimeStudentTb.Text == ""))
            {
                MessageBox.Show("Unesite puno ime i prezime studenta\n" +
                    "ili izvršite pretragu samo po korisničkom imenu", "Pretraga nije izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (korisnickoImeStudentTb.Text != "" & imeStudentTb.Text == "" & prezimeStudentTb.Text == "")
            {
                string korisnicko_ime = korisnickoImeStudentTb.Text;
                selectQuery = "SELECT korisnik_ID, korisnicko_ime, lozinka, ime, " +
                    "prezime FROM korisnik where tip_korisnika='student' AND korisnicko_ime='"
                    + korisnicko_ime + "'";
            }
            else if (korisnickoImeStudentTb.Text != "" & ((imeStudentTb.Text == "" & prezimeStudentTb.Text != "") || (imeStudentTb.Text != "" & prezimeStudentTb.Text == "")))
            {
                MessageBox.Show("Studenta možete pretražiti ili koristeći njegovo puno ime i prezime\n" +
                    "ili koristeći korisničko ime", "Pretraga nije izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return selectQuery;
        }

        private void pretraziStudBtn_Click(object sender, EventArgs e)
        {
            string searchQuery = SelectQueryStud();
            PrikaziStudente(searchQuery);
            ResetStudents();
        }

        private void MenuBibliotekar_Load(object sender, EventArgs e)
        {
            string ime = Login.ime;
            string prezime = Login.prezime;
            ImeBibLbl.Text = "Dobrodošli, " + ime + " " + prezime + "!";

            string rola = Login.rola;
            rolaBibLbl.Text = "Vaša rola je " + rola + ".";

        }

        private void potvrdiPromenuBtn_Click(object sender, EventArgs e)
        {
            string staraLozinka = staraLozinkaBibTb.Text;
            string novaLoz = novaLozBibTb.Text;
            string potNovaLoz = potNovaLozBibTb.Text;
            if (novaLoz == potNovaLoz)
            {
                this.databaseConnection.Open();
                string query = "UPDATE korisnik SET lozinka=@novaLoz where korisnicko_ime=@korisnickoIme and lozinka=@staraLozinka";
                cmd = new MySqlCommand(query, this.databaseConnection);
                cmd.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                cmd.Parameters.AddWithValue("@staraLozinka", staraLozinka);
                cmd.Parameters.AddWithValue("@novaLoz", novaLoz);

                cmd.ExecuteNonQuery();
                this.databaseConnection.Close();
                MessageBox.Show("Uspešno ste promenili loziku!", "Promena lozinke uspešna!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nova lozinka i potvrda lozinke se ne slaze!", "Izmena lozinke nije izvršena!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void otkaziPromenuBtn_Click(object sender, EventArgs e)
        {
            staraLozinkaBibTb.Text = "";
            novaLozBibTb.Text = "";
            potNovaLozBibTb.Text = "";
        }

        // funkcija za prikazivanje zahteva za registraciju
        private void PrikaziZahteve()
        {
            this.databaseConnection.Open();
            string query = "SELECT zahtev_ID, ime, prezime, korisnicko_ime, lozinka FROM zahtevi_za_registraciju";
            da = new MySqlDataAdapter(query, databaseConnection);
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            zahteviZaRegDgv.DataSource = ds.Tables[0];
            this.databaseConnection.Close();
        }
        // promenljive neophodne za manipulisanje zahtevima
        private int zahtev_ID;
        private string zahtevKorisnickoIme, zahtevLozinka, zahtevIme, zahtevPrezime;



        private void zahteviZaRegDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            zahtev_ID = Convert.ToInt32(zahteviZaRegDgv.SelectedRows[0].Cells[0].Value.ToString());
            zahtevIme = zahteviZaRegDgv.SelectedRows[0].Cells[1].Value.ToString();
            zahtevPrezime = zahteviZaRegDgv.SelectedRows[0].Cells[2].Value.ToString();
            zahtevKorisnickoIme = zahteviZaRegDgv.SelectedRows[0].Cells[3].Value.ToString();
            zahtevLozinka = zahteviZaRegDgv.SelectedRows[0].Cells[4].Value.ToString();
        }
        private void odbijBtn_Click(object sender, EventArgs e)
        {
            if (zahtev_ID == 0)
            {
                MessageBox.Show("Nije selektovan zahtev za odobravanje", "Odobravanje zahteva studenta neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.databaseConnection.Open();

                    // uklanjanje zahteva koji je odobren
                    string query = "DELETE FROM zahtevi_za_registraciju WHERE zahtev_ID = @zahtev_ID";
                    cmd = new MySqlCommand(query, this.databaseConnection);
                    cmd.Parameters.AddWithValue("@zahtev_ID", zahtev_ID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uspešno ste odbili zahtev studenta!", "Odbijanje zahteva studenta uspešno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.databaseConnection.Close();

                    // kada se konekcija sa bazom zatvori
                    // refreshujemo tabelu studenata da se vidi novi dodati student funkcijom DisplayStudents()
                    // praznimo polja koja smo prethodno popunjavali funkcijom Reset()
                    PrikaziStudente();
                    PrikaziZahteve();
                    ResetStudents();
                    zahtev_ID = 0;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    this.databaseConnection.Close();
                }
            }
        }
        private void odobriBtn_Click(object sender, EventArgs e)
        {
            if (zahtev_ID == 0)
            {
                MessageBox.Show("Nije selektovan zahtev za odobravanje", "Odobravanje zahteva studenta neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.databaseConnection.Open();

                    // hvatanje unetih podataka
                    // unosenje tih podataka u bazu
                    string query = "INSERT INTO korisnik(korisnicko_ime, lozinka, tip_korisnika, ime, prezime) VALUES (@korisnicko_ime, @lozinka, @tip_korisnika, @ime, @prezime)";
                    cmd = new MySqlCommand(query, this.databaseConnection);

                    cmd.Parameters.AddWithValue("@korisnicko_ime", zahtevKorisnickoIme);
                    cmd.Parameters.AddWithValue("@lozinka", zahtevLozinka);
                    // automatski se stavlja da je tip korisnika student jer se nalazimo
                    // na panelu za dodavanje studenta
                    cmd.Parameters.AddWithValue("@tip_korisnika", "student");
                    cmd.Parameters.AddWithValue("@ime", zahtevIme);
                    cmd.Parameters.AddWithValue("@prezime", zahtevPrezime);

                    cmd.ExecuteNonQuery();

                    // uklanjanje zahteva koji je odobren
                    query = "DELETE FROM zahtevi_za_registraciju WHERE zahtev_ID = @zahtev_ID";
                    cmd = new MySqlCommand(query, this.databaseConnection);
                    cmd.Parameters.AddWithValue("@zahtev_ID", zahtev_ID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uspešno ste prihvatili zahtev studenta!", "Odobravanje zahteva studenta uspešno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.databaseConnection.Close();

                    // kada se konekcija sa bazom zatvori
                    // refreshujemo tabelu studenata da se vidi novi dodati student funkcijom DisplayStudents()
                    // praznimo polja koja smo prethodno popunjavali funkcijom Reset()
                    PrikaziStudente();
                    PrikaziZahteve();
                    ResetStudents();
                    zahtev_ID = 0;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    this.databaseConnection.Close();
                }
            }

        }


// -------------------------------------------------TAB DELA--------------------
        private BindingSource loadDela()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmdd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            string sql = "SELECT delo_ID as ID, naziv_dela, godina_izdanja , izdavac, dela.vrsta_dela_ID as ID_vrste, v.naziv_vrste_dela, ISBN_broj as ISBN, broj_dostupnih, ukupan_broj FROM dela inner join vrsta_dela as v on dela.vrsta_dela_ID=v.vrsta_dela_ID";

            cmdd = new MySqlCommand(sql, this.databaseConnection);

            adapter.SelectCommand = cmdd;
            adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            return bs;
        }

  

        // provera da li su sva polja za dela popunjena
        bool ProveriPoljaDela()
        {
            if (nazivDelaTb.Text == "" || isbnTb.Text == ""  || ukupnoDostupnihTb.Text == "" || izdavacTb.Text == ""
                || brojDostupnihDelaTb.Text == "" || vrstaDelaCb.Text == "" || godinaIzdanjaTb.Text == "" 
                || ( mentoriTb.Text == "" && editoriTb.Text == ""
                && autoriTb.Text == "" && (autoriPoglavljaTb.Text == "" || naziviPoglavljaTb.Text == "")))
            {
                return true;
            }
            else { return false; }
        }


        // funkcija koja prazni polja na dela panelu
        private void ResetDela()
        {
            KeyD = 0;
            nazivDelaTb.Text = "";
            isbnTb.Text = "";
            mentoriTb.Text = "";
            editoriTb.Text = "";
            autoriTb.Text = "";
            izdavacTb.Text = "";
            autoriPoglavljaTb.Text = "";
            naziviPoglavljaTb.Text = "";
            ukupnoDostupnihTb.Text = "";
            brojDostupnihDelaTb.Text = "";
            vrstaDelaCb.Text = "";
            godinaIzdanjaTb.Text = "";
        }


        private void otkaziDeloBtn_Click(object sender, EventArgs e)
        {
            ResetDela();
        }

        private void delaDgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ResetDela();
            nazivDelaTb.Text = delaDgv.SelectedRows[0].Cells[1].Value.ToString();
            godinaIzdanjaTb.Text = delaDgv.SelectedRows[0].Cells[2].Value.ToString();
            izdavacTb.Text = delaDgv.SelectedRows[0].Cells[3].Value.ToString();
            vrstaDelaCb .Text = delaDgv.SelectedRows[0].Cells[5].Value.ToString();
            isbnTb.Text = delaDgv.SelectedRows[0].Cells[6].Value.ToString();
            brojDostupnihDelaTb.Text = delaDgv.SelectedRows[0].Cells[7].Value.ToString();
            ukupnoDostupnihTb.Text = delaDgv.SelectedRows[0].Cells[8].Value.ToString();

            if (nazivDelaTb.Text == "")
            {
                KeyD = 0;
            }
            else
            {
                KeyD = Convert.ToInt32(delaDgv.SelectedRows[0].Cells[0].Value.ToString());
                
            }


            MySqlConnection con = new MySqlConnection("server = localhost; database = e_biblioteka; username = root; password =; SSL Mode = None");
            try
            {
                
                con.Open();
                String query = "SELECT delo_ID, ime_prezime, naziv_poglavlja, zanimanje FROM dela_ljudi where delo_ID='"+KeyD+"'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[3].ToString()=="autor") 
                    {
                        autoriTb.Text += dr[1].ToString()+ "\r\n";
                        
                    }
                    if (dr[3].ToString() == "editor")
                    {
                        editoriTb.Text += dr[1].ToString() + "\r\n";
                    }
                    if (dr[3].ToString() == "mentor")
                    {
                        mentoriTb.Text += dr[1].ToString() + "\r\n";
                    }
                    if (dr[3].ToString() == "autor_poglavlja")
                    {
                        autoriPoglavljaTb.Text += dr[1].ToString() + "\r\n";
                        naziviPoglavljaTb.Text += dr[2].ToString() + "\r\n";
                    }

                 
                }
                dr.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally { con.Close(); }


        }



        private void obrisiDeloBtn_Click(object sender, EventArgs e)
        {
            if (ProveriPoljaDela() == true)
            {
                MessageBox.Show("Selektujte delo kog želite da uklonite", "Uklanjanje dela neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (KeyD == 0)
                    {
                        MessageBox.Show("Selektujte delo kog želite da uklonite", "Uklanjanje dela neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.databaseConnection.Open();

                        string query = "DELETE d,lj FROM dela d INNER JOIN dela_ljudi lj ON d.delo_ID=lj.delo_ID WHERE d.delo_ID=@KeyD";
                        
                        cmd = new MySqlCommand(query, this.databaseConnection);
                        cmd.Parameters.AddWithValue("@KeyD", KeyD);

                        cmd.ExecuteNonQuery();

                        this.databaseConnection.Close();
                        delaDgv.DataSource = loadDela();
                        ResetDela();
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    this.databaseConnection.Close();
                }

            }
        }

        private void novaVrstaBtn_Click(object sender, EventArgs e)
        {
            Form dodajVrstu = new novaVrstaDela();
            dodajVrstu.Show();
        }

     

        private void izmeniDeloBtn_Click(object sender, EventArgs e)
        {
            if (ProveriPoljaDela() == true)
            {
                MessageBox.Show("Nisu uneti svi podaci!", "Izmena podataka dela neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.databaseConnection.Open();

                    string query = "UPDATE dela SET naziv_dela = @naziv_dela, ISBN_broj = @ISBN_broj, ukupan_broj = @ukupan_broj, broj_dostupnih = @broj_dostupnih, izdavac=@izdavac, godina_izdanja=@godina_izdanja, vrsta_dela_ID=(select v.vrsta_dela_ID from vrsta_dela v where v.naziv_vrste_dela=@naziv_vrste_dela) WHERE delo_ID =@KeyD";
                    cmd = new MySqlCommand(query, this.databaseConnection);
                    cmd.Parameters.AddWithValue("@naziv_dela", nazivDelaTb.Text);
                    cmd.Parameters.AddWithValue("@ISBN_broj", isbnTb.Text);
                    cmd.Parameters.AddWithValue("@ukupan_broj", ukupnoDostupnihTb.Text);
                    cmd.Parameters.AddWithValue("@broj_dostupnih", brojDostupnihDelaTb.Text);
                    cmd.Parameters.AddWithValue("@izdavac", izdavacTb.Text);
                    cmd.Parameters.AddWithValue("@godina_izdanja", godinaIzdanjaTb.Text);
                    cmd.Parameters.AddWithValue("@naziv_vrste_dela", vrstaDelaCb.Text);
                    cmd.Parameters.AddWithValue("@KeyD", KeyD);
                    cmd.ExecuteNonQuery();


                    string q3;
                    MySqlCommand cmd3 = new MySqlCommand();

                    if (!(autoriTb.Text.Trim().Equals("")))
                    {

                        q3 = "UPDATE dela_ljudi SET ime_prezime=@ime_prezime where zanimanje='autor' and delo_ID =" + KeyD;
                        cmd3 = new MySqlCommand(q3, this.databaseConnection);
                        cmd3.Parameters.AddWithValue("@ime_prezime", autoriTb.Text);
                        cmd3.ExecuteNonQuery();
                    }


                    if (!(editoriTb.Text.Trim().Equals("")))
                    {
                        q3 = "UPDATE dela_ljudi SET ime_prezime=@ime_prezime where zanimanje='editor' and delo_ID =" + KeyD;
                        cmd3 = new MySqlCommand(q3, this.databaseConnection);
                        cmd3.Parameters.AddWithValue("@ime_prezime", editoriTb.Text);
                        cmd3.ExecuteNonQuery();
                    }

                    if (!(mentoriTb.Text.Trim().Equals("")))
                    {
                        q3 = "UPDATE dela_ljudi SET ime_prezime=@ime_prezime where zanimanje='mentor' and delo_ID =" + KeyD;
                        cmd3 = new MySqlCommand(q3, this.databaseConnection);
                        cmd3.Parameters.AddWithValue("@ime_prezime", mentoriTb.Text);
                        cmd3.ExecuteNonQuery();
                    }

                    if (!(autoriPoglavljaTb.Text.Trim().Equals("")))
                    {
                        q3 = "UPDATE dela_ljudi SET ime_prezime=@ime_prezime, naziv_poglavlja=@naziv_poglavlja where zanimanje='autor_poglavlja' and delo_ID =" + KeyD;
                        cmd3 = new MySqlCommand(q3, this.databaseConnection);
                        cmd3.Parameters.AddWithValue("@ime_prezime", autoriPoglavljaTb.Text);
                        cmd3.Parameters.AddWithValue("@naziv_poglavlja", naziviPoglavljaTb.Text);
                        cmd3.ExecuteNonQuery();
                    }
     

                    MessageBox.Show("Uspešno promenili informacije o delu!", "Dodavanje dela uspešno!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.databaseConnection.Close();
                    delaDgv.DataSource = loadDela();
                    ResetDela();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    this.databaseConnection.Close();
                }
            }
        }


        int id; //za id nove knjige
        private void dodajDeloBtn_Click(object sender, EventArgs e)
        {
            if (ProveriPoljaDela() == true)
            {
                MessageBox.Show("Nisu uneti svi podaci!", "Dodavanje studenta neuspešno!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    this.databaseConnection.Open();
                    
                    string query = "INSERT INTO dela(delo_ID, naziv_dela,ISBN_broj, ukupan_broj, broj_dostupnih, izdavac, godina_izdanja, vrsta_dela_ID) VALUES (@delo_ID,@naziv_dela,@ISBN_broj, @ukupan_broj, @broj_dostupnih, @izdavac, @godina_izdanja, (select v.vrsta_dela_ID from vrsta_dela v where v.naziv_vrste_dela=@naziv_vrste_dela))";
                    string query1 = "SELECT * FROM dela ORDER BY delo_id DESC LIMIT 1"; //za ID nove knjige
                    MySqlCommand cmd1 = new MySqlCommand(query1, this.databaseConnection);
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    while (dr.Read())
                    {
                        id=Convert.ToInt32(dr[0].ToString());
                        id++;
                    }
                    dr.Close();

                    cmd = new MySqlCommand(query, this.databaseConnection);
                    cmd.Parameters.AddWithValue("@naziv_dela", nazivDelaTb.Text);
                    cmd.Parameters.AddWithValue("@ISBN_broj", isbnTb.Text);
                    cmd.Parameters.AddWithValue("@ukupan_broj", ukupnoDostupnihTb.Text);
                    cmd.Parameters.AddWithValue("@broj_dostupnih", brojDostupnihDelaTb.Text);
                    cmd.Parameters.AddWithValue("@izdavac", izdavacTb.Text);
                    cmd.Parameters.AddWithValue("@godina_izdanja", godinaIzdanjaTb.Text);
                    cmd.Parameters.AddWithValue("@naziv_vrste_dela", vrstaDelaCb.Text);
                    cmd.Parameters.AddWithValue("@delo_ID", id);
                    cmd.ExecuteNonQuery();
                    

                    string q3;
                    MySqlCommand cmd3 = new MySqlCommand();

                    if (!(autoriTb.Text.Trim().Equals("")))
                    {
                        q3 = "INSERT INTO dela_ljudi (delo_ID, ime_prezime, zanimanje) VALUES (" + id + ",@ime_prezime, 'autor')";
                        cmd3 = new MySqlCommand(q3, this.databaseConnection);
                        cmd3.Parameters.AddWithValue("@ime_prezime", autoriTb.Text);
                        cmd3.ExecuteNonQuery();
                    }


                    if (!(editoriTb.Text.Trim().Equals("")))
                    {
                        q3 = "INSERT INTO dela_ljudi (delo_ID, ime_prezime, zanimanje) VALUES (" + id + ",@ime_prezime, 'editor')";
                        cmd3 = new MySqlCommand(q3, this.databaseConnection);
                        cmd3.Parameters.AddWithValue("@ime_prezime", editoriTb.Text);
                        cmd3.ExecuteNonQuery();
                    }

                    if (!(mentoriTb.Text.Trim().Equals("")))
                    {
                        q3 = "INSERT INTO dela_ljudi (delo_ID, ime_prezime, zanimanje) VALUES (" + id + ",@ime_prezime, 'mentor')";
                        cmd3 = new MySqlCommand(q3, this.databaseConnection);
                        cmd3.Parameters.AddWithValue("@ime_prezime", mentoriTb.Text);
                        cmd3.ExecuteNonQuery();
                    }

                    if (!(autoriPoglavljaTb.Text.Trim().Equals("")))
                    {
                        q3 = "INSERT INTO dela_ljudi (delo_ID, ime_prezime, zanimanje, naziv_poglavlja) VALUES (" + id + ",@ime_prezime, 'autor_poglavlja', @naziv_poglavlja)";
                        cmd3 = new MySqlCommand(q3, this.databaseConnection);
                        cmd3.Parameters.AddWithValue("@ime_prezime", autoriPoglavljaTb.Text);
                        cmd3.Parameters.AddWithValue("@naziv_poglavlja", naziviPoglavljaTb.Text);
                        cmd3.ExecuteNonQuery();
                    }



                    MessageBox.Show("Uspešno ste dodali delo!", "Dodavanje dela uspešno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.databaseConnection.Close();

                    delaDgv.DataSource = loadDela();
                    ResetDela();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    this.databaseConnection.Close();
                }
            }
        }




//------------------------------------------TAB DOSIJE------------------------------------------

        private void dosijeDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private BindingSource loadDosije()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmdd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            string sql="SELECT pozajmica_ID, korisnicko_ime, ime, prezime, ISBN_broj as ISBN, naziv_dela, datum_uzimanja, vraceno from pozajmica p inner join dela on p.knjiga_ID=delo_ID inner join korisnik k on k.korisnik_ID=p.korisnik_ID WHERE 1=1 ";

            //za pretragu (ukoliko je nepopunjeno svakako stampa sva dela)
            if (!(imeStudDosijeTb.Text.Trim().Equals("")))
            {
                sql += " AND ime LIKE '%" + imeStudDosijeTb.Text.Trim() + "%'";
            }
            if (!(prezimeStudDosijeTb.Text.Trim().Equals("")))
            {
                sql += " AND prezime LIKE '%" + prezimeStudDosijeTb.Text.Trim() + "%'";
            }
            if (!(korisnickoImeStudDosijeTb.Text.Trim().Equals("")))
            {
                sql += " AND korisnicko_ime LIKE '%" + korisnickoImeStudDosijeTb.Text.Trim() + "%'";
            }
            if (!(nazivDelaStudDosijeTb.Text.Trim().Equals("")))
            {
                sql += " AND naziv_dela LIKE '%" + nazivDelaStudDosijeTb.Text.Trim() + "%'";
            }

            if (!(isbnStudDosijeTb.Text.Trim().Equals("")))
            {
                sql += " AND ISBN_broj LIKE '%" + isbnStudDosijeTb.Text.Trim() + "%'";
            }

            sql += " order by datum_uzimanja";


            cmdd = new MySqlCommand(sql, this.databaseConnection);

            adapter.SelectCommand = cmdd;
            adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            return bs;
        }


        private void pretraziDosijeBtn_Click(object sender, EventArgs e)
        {

            dosijeDgv.DataSource = loadDosije();
        }

        private void otkaziDosijeBtn_Click(object sender, EventArgs e)
        {
            imeStudDosijeTb.Text = "";
            prezimeStudDosijeTb.Text = "";
            korisnickoImeStudDosijeTb.Text = "";
            nazivDelaStudDosijeTb.Text = "";
            isbnStudDosijeTb.Text = "";
        }


        private void delaTab_Click(object sender, EventArgs e)
        {
            vrstaDelaCb.Items.Clear();
            setVrsteDela();
        }

        private BindingSource loadRezervacije()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmdd;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            string sql = "SELECT rezervacija_ID, korisnicko_ime, ime, prezime, knjiga_ID, naziv_dela, vreme_rezervacije from rezervacija r inner join dela on knjiga_ID=delo_ID inner join korisnik k on k.korisnik_ID=r.korisnik_ID";


            cmdd = new MySqlCommand(sql, this.databaseConnection);

            adapter.SelectCommand = cmdd;
            adapter.Fill(ds);

            bs.DataSource = ds.Tables[0];
            return bs;
        }

        //--------------------------------------------OBAVESTENJA ZA ISTEK REZERVACIJE

        private void PrikaziObavestenja()
        {
            MySqlConnection con = new MySqlConnection("server = localhost; database =e_biblioteka; username = root; password =; SSL Mode = None");
            con.Open();
            string query = "SELECT pozajmica_ID, korisnicko_ime, ime, prezime, knjiga_ID, naziv_dela, datum_uzimanja from pozajmica p inner join dela on knjiga_ID=delo_ID inner join korisnik k where k.korisnik_ID=p.korisnik_ID and isteklo='Da' and seen_bibliotekar=0 ";

            MySqlDataAdapter da = new MySqlDataAdapter();
            da = new MySqlDataAdapter(query, con);
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            obavestenjaStudentDgv.DataSource = ds.Tables[0];
            string query1 = "UPDATE pozajmica set seen_bibliotekar=1 where isteklo='Da' ";
            MySqlCommand cmd1 = new MySqlCommand(query1, con);
            cmd1.ExecuteNonQuery();
            con.Close();
        }



        //citanje vrste dela iz baze -> zbog dodavanja novih vrsta dela!
        MySqlConnection con = new MySqlConnection("server = localhost; database =e_biblioteka; username = root; password =; SSL Mode = None");

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


        private void naslovnaStranaBtn_Click(object sender, EventArgs e)
        {
            if (KeyD == 0)
            {
                MessageBox.Show("Izaberite delo!");
            }
            else
            {
                NaslovnaStrana naslovna = new NaslovnaStrana(KeyD);
                naslovna.Show();
            }
        }

    }
}
