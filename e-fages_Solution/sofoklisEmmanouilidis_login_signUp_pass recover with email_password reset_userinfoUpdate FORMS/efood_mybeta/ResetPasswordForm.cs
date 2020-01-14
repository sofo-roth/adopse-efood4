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

namespace efood_mybeta
{
    public partial class ResetPasswordForm : Form
    {
        private MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=e-efages");
        private MySqlCommand comm;
        String reEmail;
        public ResetPasswordForm(string rEmail)
        {
            InitializeComponent();
            reEmail = rEmail;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm sn = new LoginForm();
            sn.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nPasswd = nPasswdTxt.Text;
            String cPasswd = confPasswd.Text;
            conn.Open();
            comm = new MySqlCommand("UPDATE userstable set Passwd=@passwd where Email=@email",conn);
            comm.Parameters.Add("@email", MySqlDbType.VarChar).Value = reEmail;
            comm.Parameters.Add("@passwd", MySqlDbType.VarChar).Value = nPasswdTxt.Text;

            if (nPasswd.Trim() == "" || cPasswd.Trim() == "")
            {
                MessageBox.Show("PLEASE FILL ALL THE BLANK FIELDS");
            }
            else 
            { 
                if (confPasswd.Text != nPasswdTxt.Text)
                {
                    MessageBox.Show("PASSWORDS DO NOT MATCH");
                }
                else
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("PASSWORD HAS CHANGED SUCCESSFULLY");
                        this.Hide();
                        LoginForm login = new LoginForm();
                        login.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("AN ERROR OCCURED PLEASE TRY AGAIN");
                    }
                }
            }
            conn.Close();

        }

    }
}
