using System;
using System.Collections.Generic;
using Domain.Services;
using System.Windows.Forms;
using Domain.Infrastructure;
using System.Linq;
using Domain.ValueModels;

namespace ShopResults
{
    public partial class ShopSearchResults : Form
    {


        private readonly DispatcherObserver _dispatcher;

        private readonly IShopResultsService _service;

        public Dictionary<int, string> foodCategories;

        private static string _address;

        private IEnumerable<ShopGridViewModel> _shops;



        public ShopSearchResults(string address) 
        {
            InitializeComponent();

            _service = new ShopResultsService();

            _dispatcher = new DispatcherObserver();

            foodCategories = new Dictionary<int, string>();

            _address = address;


        }

        private void Efood_Load(object sender, EventArgs e)
        {
            FetchData();

            PopulateMenuStrip();

            PopulateTreeView();

            PopulateDataGrid();

            SetDataGridViewOptions();
        }

        private void FetchData()
        {
            _shops = _service.Read(_address, ref foodCategories);
        }

        private void PopulateDataGrid()
        {

            var bindingList = new SortableBindingList<ShopGridViewModel>(_shops.Where(x => x.Categories.Count>0));

            var dataBinding = new BindingSource(bindingList, null);


            shopResultsGridView.DataSource = dataBinding;


        }

        private void PopulateTreeView()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (var item in foodCategories.Values)
            {
                nodes[0].Nodes.Add(item);

            }

            CheckAllNodes(nodes, true);
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
            
        }

        private void OpenCart(object sender, EventArgs e)
        {
            
        }

        private void OpenUserOrders(object sender, EventArgs e)
        {
            var next = new UserOrders();
            next.ShowDialog();
        }

        private void SetDataGridViewOptions()
        {
            shopResultsGridView.Columns["Id"].Visible = false;

            shopResultsGridView.Columns["Latitude"].Visible = false;

            shopResultsGridView.Columns["Longitude"].Visible = false;

            shopResultsGridView.Columns["ShopName"].HeaderText = "Onoma";

            foreach (DataGridViewColumn column in shopResultsGridView.Columns)
            {

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //shopResultsGridView.Dock = DockStyle.Fill;

        }


        private void ShopResultsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            shopResultsGridView.ClearSelection();
        }

        private void FormShown(object sender, EventArgs e)
        {
            shopResultsGridView.ClearSelection();
        }


        private void ShopClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var id = (int)shopResultsGridView.CurrentRow.Cells[shopResultsGridView.Columns["Id"].Index].Value;
            _service.RecordClick(id);


            var nextForm = new ShopPageForm(id);
            this.Hide();
            nextForm.ShowDialog();
            this.Close();
        }


        private void CheckAllNodes(TreeNodeCollection rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode)
            {
                CheckAllNodes(node.Nodes, isChecked);
                node.Checked = isChecked;
            }

        }

        private List<string> GetUncheckedNodes(TreeNodeCollection rootNode)
        {
            if (rootNode.Count < 1) return new List<string>();

            var uncheckedNodes = new List<string>();
            foreach (TreeNode node in rootNode)
            {
                var uncheckedChildren = GetUncheckedNodes(node.Nodes);
                if (!node.Checked)
                    uncheckedNodes.Add(node.Text);
                uncheckedNodes.AddRange(uncheckedChildren);
            }

            return uncheckedNodes;
        }

        private void EnableControls(bool enabled)
        {
            this.Enabled = enabled;
        }



        private void CheckParents(TreeNode node)
        {
            if (node.Parent != null)
            {
                node.Parent.Checked = true;
                CheckParents(node.Parent);
            }
        }

        private void FilterDataGrid(object sender)
        {
            using (new CursorWait())
            {
                List<string> uncheckedNodes = GetUncheckedNodes(treeView1.Nodes);
                var storeSearch = StoreNameSearchBox.Text;

                //1.na MHN iparxei shop pou oles oi kathgories tou na vriskontai sthn lista twn unchecked nodes
                //2.to keimeno tou store name search box na einai meros tou onomatos tou store
                IEnumerable<ShopGridViewModel> bindingData = new List<ShopGridViewModel>();
                bindingData = _shops?.Where(x => !x.Categories.All(y => uncheckedNodes.Contains(foodCategories[y])) && x.ShopName.Contains(storeSearch));

                var bindingList = new SortableBindingList<ShopGridViewModel>(bindingData);
                var dataBinding = new BindingSource(bindingList, null);

                shopResultsGridView.DataSource = dataBinding;
            }

        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.ByMouse && e.Action != TreeViewAction.ByKeyboard) return;
            CheckAllNodes(e.Node.Nodes, e.Node.Checked);

            _dispatcher.Debounce(400, x => FilterDataGrid(sender));
        }

        private void StoreNameSearchBox_KeyUp(object sender, EventArgs e)
        {
            _dispatcher.Debounce(1000, x => FilterDataGrid(sender));
        }
    }
}
