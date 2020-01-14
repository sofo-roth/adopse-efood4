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
using System.Net;
using System.Net.Mail;

namespace efood_mybeta
{
    public partial class PasswordRecoveryForm : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=e-efages");
        MySqlDataReader mdr;
        String randomCode;
        public static string to;
        public PasswordRecoveryForm()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand comm = new MySqlCommand("SELECT email from userstable where email = @email", conn);
            comm.Parameters.Add("@email", MySqlDbType.VarChar).Value = rEmailTxt.Text;

            MySqlDataAdapter adapt = new MySqlDataAdapter(comm);
            DataTable table = new DataTable();
            adapt.Fill(table);


            mdr = comm.ExecuteReader();

            if (table.Rows.Count == 0)
            {
                if(rEmailTxt.Text=="")
                {
                    MessageBox.Show("Please Fill In All Neseccary Fields");
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("This email address does not match to any user");
                    conn.Close();
                }
            }
            else
            {
                conn.Close();
                conn.Open();
                comm = new MySqlCommand("SELECT passwd from userstable where email = @email", conn);
                comm.Parameters.Add("@email", MySqlDbType.VarChar).Value = rEmailTxt.Text;


                mdr = comm.ExecuteReader();


                if (mdr.Read())
                {
                    MessageBox.Show("Account Exists..Iniciating Reset Code Email Tranfer");
                    String from, pass, messageBody;
                    Random rand = new Random();
                    randomCode = (rand.Next(999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = (rEmailTxt.Text).ToString();
                    from = "projectefoodtest@gmail.com";
                    pass = "letseat123";
                    messageBody = "your reset code is " + randomCode;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "password reseting code";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Recovery Code Sent Succesfully Please Check Email");
                        resetCodeTxt.Enabled = true;
                        resetCodeTxt.Visible = true;
                        resetLabel.Visible = true;
                        rCodeB.Visible = true;
                        rCodeB.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("This Email Address Doesn't Match With Any Existing Account Please Insert Existing Email OR SIGN UP");
                }
                conn.Close();
            }
        }
    


            
        
    

        private void rCodeB_Click(object sender, EventArgs e)
        {
            if(randomCode==(resetCodeTxt.Text).ToString())
            {
                to = rEmailTxt.Text;
                this.Hide();
                ResetPasswordForm res = new ResetPasswordForm(rEmailTxt.Text);
                res.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Reset Password INCORRECT");
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm sn = new LoginForm();
            sn.ShowDialog();
            this.Close();
        }
    }
}
