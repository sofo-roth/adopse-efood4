using System;
using System.Data;
using System.Windows.Forms;
using Domain.Infrastructure;
using Domain.Services;
using Domain.ValueModels;
using MySql.Data.MySqlClient;

namespace ShopResults
{
    public partial class UserInfoUpdate : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=efoodusers");


        IUserAccountService _service;

        UserInformation _info;
        public UserInfoUpdate()
        {
            _service = new UserAccountService();
            InitializeComponent();
        }

        private void LoadForm(object sender, EventArgs e)
        {
            _info = _service.UserInfo;

            cfnameTxt.Text =_info.FName;
            clnameTxt.Text = _info.LName;
            cemailTxt.Text = _info.Email; 
            caddTxt.Text = _info.Address;
            cphoneTxt.Text = _info.Phone;
            cuserTxt.Text = _info.Username;
            cads.Checked = _info.AllowDataUsage;

            fnameLabel.Text = _info.FName;
            lnameLabel.Text = _info.LName;
            peLabel.Text = _info.Email;
            addLabel.Text = _info.Address;
            phoneLabel.Text = _info.Phone;
            puserLabel.Text = _info.Username;

            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var isOldMail = _info.Email == cemailTxt.Text;
            _info.FName = cfnameTxt.Text;
            _info.LName = clnameTxt.Text;
            _info.Email = cemailTxt.Text;
            _info.Address = caddTxt.Text;
            _info.Phone = cphoneTxt.Text;
            _info.Username = cuserTxt.Text;
            _info.Passwd = cpassTxt.Text;
            _info.AllowDataUsage = cads.Checked;


            if (emailExists(_info.Email) && !isOldMail)
            {
                MessageBox.Show("EMAIL: " + _info.Email + " ALREADY EXISTS");
                cemailTxt.Focus();
                cemailTxt.Text = "";
            }
            else
            {
                _service.UpdateWithNewPassword(_info);
                this.Close();
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //private void exitButton_Click(object sender, EventArgs e)
        //{
        //    DialogResult dialog = MessageBox.Show("Are You Sure You Want To Exit App", "LEAVING SO SOON? :/", MessageBoxButtons.YesNo);
        //    if (dialog == DialogResult.Yes)
        //    {
        //        Application.Exit();
        //    }
        //}
    }
}
