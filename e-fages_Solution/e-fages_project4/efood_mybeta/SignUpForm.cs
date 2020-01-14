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
using Domain.Infrastructure;
using Domain.Services;
namespace efood_mybeta
{
    public partial class SignUpForm : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=efoodusers");
        int ads = 0;
        IUserAccountService _service;
        public SignUpForm()
        {
            _service = new UserAccountService();
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String fname = fnameTxt.Text;
            String lname = lnameTxt.Text;
            String email = emailTxt.Text;
            String address = addrTxt.Text;
            String phone = phoneTxt.Text;
            String usrn = usernameTxt.Text;
            String passwd = passwdTxt.Text;
            String cpasswd = c_passwdTxt.Text;
            int allowdatausage = ads;

            if (fname.Trim() == "" || lname.Trim() == "" || email.Trim() == "" || address.Trim() == "" || phone.Trim() == "" || usrn.Trim() == "" || passwd.Trim() == "")
            {
                MessageBox.Show("PLEASE FILL ALL NECESSARY FIELDS");
            }
            else if (!(passwd.Equals(cpasswd)))
            {
                MessageBox.Show("PASSWORDS DO NOT MATCH PLEASE TRY AGAIN");
                eLabel.ForeColor = Color.Black;
                userLabel.ForeColor = Color.Black;
                cPassLabel.ForeColor = Color.Red;
                cPassLabel.Text = "*Confirm Password";
                c_passwdTxt.Focus();
                c_passwdTxt.Text = "";
            }
            else if (usernameExists(usrn))
            {
                MessageBox.Show("USERNAME: " + usrn + " ALREADY EXISTS");
                eLabel.ForeColor = Color.Black;
                userLabel.ForeColor = Color.Red;
                cPassLabel.ForeColor = Color.Black;
                userLabel.Text = "*Username";
                usernameTxt.Focus();
                usernameTxt.Text = "";

            }
            if (usernameExists(usrn))
            {
                MessageBox.Show("USERNAME: " + usrn + " ALREADY EXISTS");
                eLabel.ForeColor = Color.Red;
                userLabel.ForeColor = Color.Black;
                cPassLabel.ForeColor = Color.Black;
                eLabel.Text = "*Email";
                emailTxt.Focus();
                emailTxt.Text = "";
            }
            else
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO `userstable`(`fname`, `lname`, `email`, `address`, `phone`, `username`, `passwd`,`allowDataUsage`) VALUES (@fname,@lname,@email,@addr,@phone,@usrn,@passwd,@allowDataUsage)", conn);
                com.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fname;
                com.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lname;
                com.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                com.Parameters.Add("@addr", MySqlDbType.VarChar).Value = address;
                com.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                com.Parameters.Add("@usrn", MySqlDbType.VarChar).Value = usrn;
                com.Parameters.Add("@passwd", MySqlDbType.VarChar).Value = _service.RetrieveHash(passwd);
                com.Parameters.Add("@allowDataUsage", MySqlDbType.VarChar).Value = allowdatausage;


                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("SIGN UP WAS SUCCESSFULL");
                    this.Hide();
                    LoginForm login = new LoginForm();
                    login.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("SIGN UP FAILED PLEASE TRY AGAIN");
                }

                conn.Close();


            }
        }

        private bool usernameExists(string username)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `userstable` WHERE `username` = @usrn", conn);
            comm.Parameters.Add("@usrn", MySqlDbType.VarChar).Value = usernameTxt.Text;
            adapt.SelectCommand = comm;
            adapt.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool emailExists(string email)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `userstable` WHERE `email` = @email", conn);
            comm.Parameters.Add("@email", MySqlDbType.VarChar).Value = emailTxt.Text;
            adapt.SelectCommand = comm;
            adapt.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void clearTxts()
        {
            fnameTxt.Text = lnameTxt.Text = emailTxt.Text = addrTxt.Text = phoneTxt.Text = usernameTxt.Text = passwdTxt.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm sn = new LoginForm();
            sn.ShowDialog();
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are You Sure You Want To Exit App", "LEAVING SO SOON? :/", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ads == 0)
            {
                ads = 1;
            }
            else
            {
                ads = 0;
            }
        }
    }
}
