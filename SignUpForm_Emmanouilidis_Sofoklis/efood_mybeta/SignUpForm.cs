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
    public partial class SignUpForm : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=efoodusers");
        public SignUpForm()
        {
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

            if (fname.Trim() == "" || lname.Trim() == "" || email.Trim() == "" || address.Trim() == "" || phone.Trim() == "" || usrn.Trim() == "" || passwd.Trim() == "")
            {
                MessageBox.Show("PLEASE FILL ALL NECESSARY FIELDS");
            }
            else if(!(passwd.Equals(cpasswd)))
            {
                MessageBox.Show("PASSWORDS DO NOT MATCH PLEASE TRY AGAIN");
            }
            else if(usernameExists(usrn))
            {
                MessageBox.Show("USERNAME: "+usrn+" ALREADY EXISTS");
            }
            else
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("INSERT INTO `userstable`(`fname`, `lname`, `email`, `address`, `phone`, `username`, `passwd`) VALUES (@fname,@lname,@email,@addr,@phone,@usrn,@passwd)", conn);
                com.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fname;
                com.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lname;
                com.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                com.Parameters.Add("@addr", MySqlDbType.VarChar).Value = address;
                com.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                com.Parameters.Add("@usrn", MySqlDbType.VarChar).Value = usrn;
                com.Parameters.Add("@passwd", MySqlDbType.VarChar).Value = passwd;

                if(com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("SIGN UP WAS SUCCESSFULL");
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
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `userstable` WHERE `username` = @usrn",conn);
            comm.Parameters.Add("@usrn", MySqlDbType.VarChar).Value = usernameTxt.Text;
            adapt.SelectCommand=comm;
            adapt.Fill(table);

            if(table.Rows.Count > 0)
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
    }
 }
