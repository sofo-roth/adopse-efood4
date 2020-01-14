using Domain.Infrastructure;
using Domain.Services;
using Domain.ValueModels;
using System;
using System.Windows.Forms;

namespace ShopResults
{
    public partial class UserOrders : Form
    {
        private readonly IUserAccountService _service;


        public UserOrders()
        {
            _service = new UserAccountService();

            InitializeComponent();
        }

        private void UserOrders_Load(object sender, EventArgs e)
        {
            var orders = _service.GetUserOrders();

            var bindingList = new SortableBindingList<OrderDetailsGridViewModel>(orders);

            var dataBinding = new BindingSource(bindingList, null);


            OrdersGrid.DataSource = dataBinding;

            OrdersGrid.Columns["Name"].Visible = false;
            OrdersGrid.Columns["Surname"].Visible = false;
            OrdersGrid.Columns["Phone"].Visible = false;
            OrdersGrid.Columns["OrderId"].Visible = false;
            OrdersGrid.Columns["ShopId"].Visible = false;


            foreach (DataGridViewColumn column in OrdersGrid.Columns)
            {

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }


        }

        private void UserOrders_Shown(object sender, EventArgs e)
        {
            OrdersGrid.ClearSelection();
        }

        private void OrderClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = (int)OrdersGrid.CurrentRow.Cells[OrdersGrid.Columns["OrderId"].Index].Value;



            using(var nextForm = new UserOrderDetails(id))
            {
                nextForm.ShowDialog();
            };
            
            
            this.Show();
        }
    }
}
