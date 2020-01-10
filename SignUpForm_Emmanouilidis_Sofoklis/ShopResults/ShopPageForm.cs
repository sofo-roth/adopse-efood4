using Domain.Infrastructure;
using Domain.Services;
using Domain.ValueModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        }

        private void PrintShopInfo()
        {
            ShopNameLabel.Text = _model.Info.Name;

            ShopAddress.Text = _model.Info.Address + " - Tilefono epikoinonias " + _model.Info.Phone;

            Elaxisti.Text = "Elaxisth timh: " + _model.Info.Elaxisti;

            Rating.Text = "Krhtikh: " + _model.Info.Rating;

        }

        private void FormShown(object sender, EventArgs e)
        {
            CategoriesGrid.ClearSelection();
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

        private void CategoryClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //var id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.Columns["Id"].Index].Value;
            var category = CategoriesGrid.CurrentRow.Cells[CategoriesGrid.Columns["Category"].Index].Value.ToString();

            var foodItems = _model.FoodItems[category];

            var bindingList = new SortableBindingList<FoodItemViewModel>(foodItems);

            var dataBinding = new BindingSource(bindingList, null);


            FoodItemsGrid.DataSource = dataBinding;


            FoodItemsGrid.Columns["ItemId"].Visible = false;
            FoodItemsGrid.Columns["CategoryId"].Visible = false;

            FoodItemsGrid.Columns["Price"].Width = 50;

            FoodItemsGrid.Columns["ItemName"].HeaderText = "Food items";

        }

        private void FoodItemClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //var id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.Columns["Id"].Index].Value;
            var category = CategoriesGrid.CurrentRow.Cells[CategoriesGrid.Columns["Category"].Index].Value.ToString();

            var itemId = (int)FoodItemsGrid.CurrentRow.Cells[FoodItemsGrid.Columns["ItemId"].Index].Value;

            var ingredients = _model.FoodItems[category].FirstOrDefault(x=> x.ItemId == itemId).FoodIngredients; 

            var bindingList = new SortableBindingList<FoodItemIngredientViewModel>(ingredients);

            var dataBinding = new BindingSource(bindingList, null);


            IngredientsGrid.DataSource = dataBinding;

            IngredientsGrid.Columns["IngId"].Visible = false;
            IngredientsGrid.Columns["CategoryId"].Visible = false;

            IngredientsGrid.Columns["IName"].HeaderText = "Ingredients";

        }

        private void IngredientClicked(object sender, DataGridViewCellEventArgs e)
        {
            var value = IngredientsGrid.CurrentRow.Cells["chk"].Value;

            IngredientsGrid.CurrentRow.Cells["chk"].Value = !Convert.ToBoolean(value);

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
