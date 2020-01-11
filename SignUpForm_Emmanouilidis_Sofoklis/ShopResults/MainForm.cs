using System;
using Domain.Services;
using Domain.Infrastructure;
using System.Windows.Forms;

namespace ShopResults
{
    public partial class MainForm : Form
    {
        IUserCartService _service;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _service = new UserCartService();

            UseUserAddressButton.Enabled = _service.UserInfo.UserId > 0;

            PopulateMenuStrip();
        }

        private void UseUserAddressButton_Click(object sender, EventArgs e)
        {
            AddressBox.Text = _service.UserInfo.Address;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var address = AddressBox.Text;
            if (address == string.Empty)
            {
                MessageBox.Show("Please enter your address");
                return;
            }

            this.Hide();
            var next = new ShopSearchResults(address);
            next.ShowDialog();
            this.Close();
        }

        private void PopulateMenuStrip()
        {
            var cartMenuItem = new ToolStripMenuItem("View my cart");
            cartMenuItem.Click += new EventHandler(OpenCart);

            UserOptions.DropDownItems.Add(cartMenuItem);

            if (_service.UserInfo.UserId <= 0) return;

            var logoutMenuItem = new ToolStripMenuItem("Logout");
            logoutMenuItem.Click += new EventHandler((sender, e) => _service.LogoutUser());

            UserOptions.DropDownItems.Add(logoutMenuItem);

            var updateUserMenuItem = new ToolStripMenuItem("Update my info");
            updateUserMenuItem.Click += new EventHandler(OpenUserUpdate);

            UserOptions.DropDownItems.Add(updateUserMenuItem);

            var ordersMenuItem = new ToolStripMenuItem("View my orders");
            ordersMenuItem.Click += new EventHandler(OpenUserOrders);

            UserOptions.DropDownItems.Add(ordersMenuItem);
        }

        private void OpenUserUpdate(object sender, EventArgs e)
        {

        }

        private void OpenCart(object sender, EventArgs e)
        {

        }

        private void OpenUserOrders(object sender, EventArgs e)
        {
            //todo
        }
    }
}
