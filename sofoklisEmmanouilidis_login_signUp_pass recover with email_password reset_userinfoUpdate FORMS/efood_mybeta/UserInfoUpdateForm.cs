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
    public partial class UserInfoUpdateForm : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=e-efages");
        int cadds = 0;
        public UserInfoUpdateForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            String fname = cfnameTxt.Text;
            String lname = clnameTxt.Text;
            String email = cemailTxt.Text;
            String address = caddTxt.Text;
            String phone = cphoneTxt.Text;
            String usrn = cuserTxt.Text;
            String passwd = cpassTxt.Text;
            int allowdatausage = cadds;

            if (usernameExists(usrn))
            {
                MessageBox.Show("USERNAME: " + usrn + " ALREADY EXISTS");
                cuserTxt.Focus();
                cuserTxt.Text = "";
            }
            else if (emailExists(usrn))
            {
                MessageBox.Show("EMAIL: " + email + " ALREADY EXISTS");
                cemailTxt.Focus();
                cemailTxt.Text = "";
            }
            else
            {
                conn.Open();
                MySqlCommand com = new MySqlCommand("UPDATE userstable SET fname = @fname, lname = @lname, email = @email, address = @addr, phone = @phone, username = @usrn, passwd = @passwd, allowdatausage = @allowDataUsage", conn);
                com.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fname;
                com.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lname;
                com.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                com.Parameters.Add("@addr", MySqlDbType.VarChar).Value = address;
                com.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                com.Parameters.Add("@usrn", MySqlDbType.VarChar).Value = usrn;
                com.Parameters.Add("@passwd", MySqlDbType.VarChar).Value = passwd;
                com.Parameters.Add("@allowDataUsage", MySqlDbType.VarChar).Value = allowdatausage;

                if (com.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("YOUR INFO UPDATE WAS SUCCESSFULL");
                    this.Hide();
                    LoginForm login = new LoginForm();
                    login.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("INFO UPDATE FAILED PLEASE TRY AGAIN");
                }

                conn.Close();
            }
        }

        private bool usernameExists(string username)
        {
            DataTable table = new DataTable();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            MySqlCommand comm = new MySqlCommand("SELECT * FROM `userstable` WHERE `username` = @usrn", conn);
            comm.Parameters.Add("@usrn", MySqlDbType.VarChar).Value = cuserTxt.Text;
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
            comm.Parameters.Add("@email", MySqlDbType.VarChar).Value = cemailTxt.Text;
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
        private void cads_CheckedChanged(object sender, EventArgs e)
        {
            if (cadds == 0)
            {
                cadds = 1;
            }
            else
            {
                cadds = 0;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are You Sure You Want To Exit App", "LEAVING SO SOON? :/", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
