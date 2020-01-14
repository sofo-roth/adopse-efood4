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
using 

namespace efood_mybeta
{
    public partial class LoginForm : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=efoodusers");
        public LoginForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand("SELECT `username`,`passwd` from userstable where username = @username and passwd = @passwd",conn);
            comm.Parameters.Add("@username", MySqlDbType.VarChar).Value = usernameTxt.Text;
            comm.Parameters.Add("@passwd", MySqlDbType.VarChar).Value = passwdTxt.Text;

            MySqlDataAdapter adapt = new MySqlDataAdapter(comm);
            DataTable table = new DataTable();
            adapt.Fill(table);

            if(table.Rows.Count == 0)
            {
                MessageBox.Show("Invalid username or password");
            }
            else
            {
                
            }
        }

        private void passwdTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void showpassCB_CheckedChanged(object sender, EventArgs e)
        {
            if(passwdTxt.UseSystemPasswordChar == true)
            {
                passwdTxt.UseSystemPasswordChar = false;
            }
            else
            {
                passwdTxt.UseSystemPasswordChar = true;
            }
        }
    }
}
