using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (credit.Checked)
            {
                if (number.Text == string.Empty || name.Text == string.Empty)
                {
                    error.Text = "* πρέπει όλα τα πεδία να είναι συμπληρωμένα ";
                }
            }
            else
            {

                Form2 frm2 = new Form2();
                {
                    frm2.ShowDialog();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            error.Text = "";
            name.Text = "";
            number.Text = "";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
