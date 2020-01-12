using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Infrastructure;
using Domain.Services;


namespace WindowsFormsApp4
{
    public partial class cart : Form
    {
       private readonly IUserCartService _service;

        public cart()
            {
                InitializeComponent();
            _service = new UserCartService();

            
            
            }

       

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
            {
            string a = _service.Cart.ToString();
            show.Text = a;
           
            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void button2_Click(object sender, EventArgs e)
            {
            Form1 frm1 = new Form1();
            {
                frm1.ShowDialog();
            }
        }
        }
    }
