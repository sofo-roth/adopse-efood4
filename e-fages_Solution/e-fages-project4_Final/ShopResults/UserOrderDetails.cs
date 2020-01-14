using Domain.Infrastructure;
using Domain.Services;
using System;
using System.Windows.Forms;

namespace ShopResults
{
    public partial class UserOrderDetails : Form
    {
        private readonly IUserAccountService _service;
        private readonly int _id;


        public UserOrderDetails(int id)
        {
            _id = id;
            _service = new UserAccountService();

            InitializeComponent();
        }

        private void UserOrderDetails_Load(object sender, EventArgs e)
        {
            var details = _service.GetOrderItems(_id);

            var detailsExpandable = new ListViewExtended();
            this.Controls.Add(detailsExpandable);
            detailsExpandable.Dock = DockStyle.Fill;
            detailsExpandable.View = View.Tile;
            
            var count = 0;
            foreach (var orderitem in details)
            {
                var text = orderitem.Name.ToString() + " - " + orderitem.Price.ToString() + "€";
                detailsExpandable.Groups[count] = detailsExpandable.Groups.Add(count.ToString(), text);
                foreach (var itemingredient in orderitem.FoodIngredients)
                {
                    ListViewItem lvi = detailsExpandable.Items.Add($"{itemingredient.Name} - {itemingredient.Price}€");
                    lvi.Group = detailsExpandable.Groups[count];
                }

                count++;
            }

        }


    }
}
