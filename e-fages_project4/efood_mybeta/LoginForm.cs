using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Domain.Infrastructure;
using Domain.Services;
using ShopResults;

namespace efood_mybeta
{
    public partial class LoginForm : Form
    {
        IUserAccountService _service;

        public LoginForm()
        {
            _service = new UserAccountService();
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are You Sure You Want To Exit App", "LEAVING SO SOON? :/", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm sn = new SignUpForm();
            sn.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(!_service.LoginUser(usernameTxt.Text,passwdTxt.Text))
            {
                MessageBox.Show("Invalid username or password");
            }
            else
            {
                MessageBox.Show("LOGGED IN");
                this.Hide();
                var next = new MainForm();
                next.ShowDialog();
                this.Close();
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

        private void fPassLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            PasswordRecoveryForm ps = new PasswordRecoveryForm();
            ps.ShowDialog();
            this.Close();
        }
    }
}
