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
    public partial class novaVrstaDela : Form
    {
        public novaVrstaDela()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server = localhost; database = e_biblioteka; username = root; password =; SSL Mode = None");


        private void dodajBtn_Click(object sender, EventArgs e)
        {
            string vrsta_dela = dodajVrstuTb.Text;
            con.Open();
            string query = "INSERT INTO vrsta_dela(naziv_vrste_dela) VALUES ('"+vrsta_dela+"')";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
         
            MessageBox.Show("Uspešno ste dodali novu vrstu dela!", "Dodavanje vrste dela uspešno!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();
            this.Close();
        }

        private void zatvoriBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
