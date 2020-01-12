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
using Domain.Cart;


namespace WindowsFormsApp4
{
    public partial class cart : Form
    {
       private readonly IUserCartService _service;
        int leftcontrol = 1;
        double total = 0;
        public cart()
            {
            _service = new UserCartService();
            InitializeComponent();
            

            
            
            }

       

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
            {
           
           
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

        private void s_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <_service.Cart.Count(); i++)
            {
                TextBox t1 = new TextBox();
                this.Controls.Add(t1);
                t1.Width = 400;
                t1.Top = leftcontrol * 25;
                t1.Left = 100;

                var price = _service.Cart[i].Price;
                price += _service.Cart[i].Ingredients.Sum(x => x.Price);
                price *= _service.Cart[i].Quantity;

                t1.Text = _service.Cart[i].Quantity + " " + _service.Cart[i].Name + ": " + price;
                leftcontrol = leftcontrol + 1;

            }
           
            for (int j = 0; j < _service.Cart.Count(); j++)
            {
                double x = _service.Cart[j].Price;
                total = total + x;
            }
            timi.Text = total+" ευρώ";
            s.Hide();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = _service.Cart.Count();
            _service.Cart.RemoveAt(index);
        }
    }
    }
