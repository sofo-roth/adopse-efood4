using Domain.Infrastructure;
using Domain.Services;
using Domain.ValueModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using WindowsFormsApp4;
using Rating = Fivestar.Rating;

namespace ShopResults
{
    public partial class ShopPageForm : Form
    {
        private readonly int _id;
        private ShopFormViewModel _model;
        private readonly IShopFormService _service;

        public ShopPageForm(int id)
        {
            _id = id;
            _service = new ShopFormService();
            InitializeComponent();
        }

        private void ShopPageForm_Load(object sender, EventArgs e)
        {
            _model = _service.Read(_id);

            PrintShopInfo();

            PopulateCategoriesGrid();

            RateShop.Enabled = _model.UserRating.isAllowed;

            PopulateMenuStrip();

        }

        private void FormShown(object sender, EventArgs e)
        {
            CategoriesGrid.ClearSelection();
        }

        private void PrintShopInfo()
        {
            ShopNameLabel.Text = _model.Info.Name;

            ShopAddress.Text += _model.Info.Address;

            Phone.Text += _model.Info.Phone; 

            Elaxisti.Text += _model.Info.Elaxisti;

            Rating.Text += _model.Info.Rating;

        }
        

        private void PopulateCategoriesGrid()
        {
            var categories = new List<string>();
            CategoriesGrid.Columns.Add("Category", "Category");
            foreach (var category in _model.FoodItems.Keys)
            {
                CategoriesGrid.Rows.Add(category);
            }


        }

        private void PopulateMenuStrip()
        {
            var cartMenuItem = new ToolStripMenuItem("View my cart");
            cartMenuItem.Click += new EventHandler(OpenCart);

            UserOptions.DropDownItems.Add(cartMenuItem);

            if (_service.UserInfo.UserId <= 0) return;

            var ordersMenuItem = new ToolStripMenuItem("View my orders");
            ordersMenuItem.Click += new EventHandler(OpenUserOrders);

            UserOptions.DropDownItems.Add(ordersMenuItem);

            var updateUserMenuItem = new ToolStripMenuItem("Update my info");
            updateUserMenuItem.Click += new EventHandler(OpenUserUpdate);

            UserOptions.DropDownItems.Add(updateUserMenuItem);

            var logoutMenuItem = new ToolStripMenuItem("Logout");
            logoutMenuItem.Click += new EventHandler((sender, e) => { _service.LogoutUser(); this.Close(); });

            UserOptions.DropDownItems.Add(logoutMenuItem);
        }

        private void OpenUserUpdate(object sender, EventArgs e)
        {
            var next = new UserInfoUpdate();
            next.ShowDialog();
        }

        private void OpenCart(object sender, EventArgs e)
        {
            var next = new cart();
            next.ShowDialog();
        }

        private void OpenUserOrders(object sender, EventArgs e)
        {
            var next = new UserOrders();
            next.ShowDialog();
        }

        private void RateShop_Click(object sender, EventArgs e)
        {

            //new MainWindow(_model.UserRating.StarRating); (make constructor accept this)
            //todo: verify that this opens the form

            
            var nextForm = new Rating();
            var w = new Window
            {
                Content = nextForm,
                Width = 500,
                Height = 100
            };
            w.Show();
            
        }

        private void CategoryClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var category = CategoriesGrid.CurrentRow.Cells[CategoriesGrid.Columns["Category"].Index].Value.ToString();

            var foodItems = _model.FoodItems[category];

            var bindingList = new SortableBindingList<FoodItemViewModel>(foodItems);

            var dataBinding = new BindingSource(bindingList, null);


            FoodItemsGrid.DataSource = dataBinding;


            FoodItemsGrid.Columns["ItemId"].Visible = false;
            FoodItemsGrid.Columns["CategoryId"].Visible = false;

            FoodItemsGrid.Columns["Price"].Width = 50;

            FoodItemsGrid.Columns["ItemName"].HeaderText = "Food items";

            AddToCart.Enabled = false; 

            IngredientsGrid.DataSource = null;


        }

        private void FoodItemClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            

            var category = CategoriesGrid.CurrentRow.Cells[CategoriesGrid.Columns["Category"].Index].Value.ToString();

            var itemId = (int)FoodItemsGrid.CurrentRow.Cells[FoodItemsGrid.Columns["ItemId"].Index].Value;

            var ingredients = _model.FoodItems[category].FirstOrDefault(x=> x.ItemId == itemId).FoodIngredients; 

            var bindingList = new SortableBindingList<FoodItemIngredientViewModel>(ingredients);

            var dataBinding = new BindingSource(bindingList, null);


            IngredientsGrid.DataSource = dataBinding;

            IngredientsGrid.Columns["IngId"].Visible = false;
            IngredientsGrid.Columns["CategoryId"].Visible = false;

            IngredientsGrid.Columns["IName"].HeaderText = "Ingredients";

            AddToCart.Enabled = IngredientsGrid.RowCount == 0;

        }

        private void IngredientClicked(object sender, DataGridViewCellEventArgs e)
        {
            var value = IngredientsGrid.CurrentRow.Cells["chk"].Value;

            IngredientsGrid.CurrentRow.Cells["chk"].Value = !Convert.ToBoolean(value);

            AddToCart.Enabled = GetIngredients().Count() > 0;

        }

        private void DeselectFoodItem(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FoodItemsGrid.ClearSelection();
        }

        private void DeselectFoodIngredient(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            IngredientsGrid.ClearSelection(); 
        }

        private void AddToCart_Click(object sender, EventArgs e)
        {
            var ingredients = GetIngredients().ToList();

            var row = FoodItemsGrid.CurrentRow;
            var item = new CartItem
            {
                Quantity = (int)ItemQuantity.Value,
                Ingredients = ingredients,
                FoodItemId = (int)row.Cells["ItemId"].Value,
                Name = row.Cells["ItemName"].Value.ToString(),
                ShopId = _model.Info.ShopId,
                Price = (double)row.Cells["Price"].Value
            };

            _service.Cart.Add(item);

            ItemQuantity.Value = 1;
            AddToCart.Enabled = false;

            IngredientsGrid.DataSource = null;
            FoodItemsGrid.DataSource = null;
            CategoriesGrid.ClearSelection();

            var currentPrice = double.Parse(Price.Text);
            var itemPrice =  item.Quantity * (item.Price + item.Ingredients.Sum(y => y.Price));

            var finalPrice = currentPrice + itemPrice;
            Price.Text = finalPrice.ToString();
        }

        private IEnumerable<CartItemIngredient> GetIngredients()
        {
            for (int i = 0; i < IngredientsGrid.RowCount; i++)
            {
                var row = IngredientsGrid.Rows[i];
                var isSelected = Convert.ToBoolean(row.Cells["chk"].Value);
                if (!isSelected) continue;
                var ingredient = new CartItemIngredient
                {
                    IngId = (int?)row.Cells["IngId"].Value,
                    Name = row.Cells["IName"].Value.ToString(),
                    Price = (double)row.Cells["Price"].Value
                };

                yield return ingredient;
            }
        }

    }
}
