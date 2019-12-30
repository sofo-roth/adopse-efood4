using System;
using System.Collections.Generic;
using Domain.Services;
using System.Windows.Forms;
using ValueModels;
using Domain.Infrastructure;
using System.Linq;

namespace ShopResults
{
    public partial class ShopResults : Form
    {


        private readonly DispatcherObserver _dispatcher;

        private readonly ShopResultsService _service;

        public Dictionary<int, string> foodCategories;

        private static string _address;

        private IEnumerable<ShopGridViewModel> _shops;



        public ShopResults(string address)
        {
            InitializeComponent();

            _service = new ShopResultsService();

            _dispatcher = new DispatcherObserver();

            foodCategories = new Dictionary<int, string>();

            _address = address;

                                 
        }

        private void PopulateDataGrid()
        {

            var addr = _address;
            


            _shops = _service.Read(_address, ref foodCategories);

            //var mock = new List<ShopGridViewModel>(); todo: this list will be replaced with database data based on the address
            //mock.Add(new ShopGridViewModel()        
            //{
            //    Address = "meeeeemsseos",            
            //    ShopName = "shop1",
            //    Distance = 3.3,
            //    Id = 0
            //});

            //mock.Add(new ShopGridViewModel()
            //{
            //    Address = "fgedgebfdffscrgrwegwe",
            //    ShopName = "shop153",
            //    Distance = 352.3,
            //    Id = 1
            //});

            //var binding = new BindingSource();
            //binding.DataSource = mock;



            var bindingList = new SortableBindingList<ShopGridViewModel>(_shops);

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


        private void SetDataGridViewOptions()
        {
            shopResultsGridView.Columns["Id"].Visible = false;

            shopResultsGridView.Columns["ShopName"].HeaderText = "Onoma";

            foreach (DataGridViewColumn column in shopResultsGridView.Columns)
            {

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //shopResultsGridView.Dock = DockStyle.Fill;
                       
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void helloWorldLabel_Click(object sender, EventArgs e)
        {

        }

        private void efood_Load(object sender, EventArgs e)
        {
            PopulateDataGrid();

            SetDataGridViewOptions();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void shopResultsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            shopResultsGridView.Rows[0].Selected = false;
        }


        private void shopClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //var id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.Columns["Id"].Index].Value;
            var id = (int)shopResultsGridView.CurrentRow.Cells[shopResultsGridView.Columns["Id"].Index].Value;
            _service.RecordClick(id);

            MessageBox.Show("shop id selected: " + id); //var storeform = new StoreForm(id);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void shopResultsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void enableControls(bool enabled)
        {
            this.Enabled = enabled;
        }

        
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckParents(TreeNode node)
        {
            if (node.Parent != null)
            {
                node.Parent.Checked = true;
                CheckParents(node.Parent);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Action != TreeViewAction.ByMouse && e.Action != TreeViewAction.ByKeyboard) return;
            


            CheckAllNodes(e.Node.Nodes, e.Node.Checked);
            if (e.Node.Index > 0)
                e.Node.Parent.Checked = e.Node.Checked;

            CheckParents(e.Node);

            List<string> uncheckedNodes = GetUncheckedNodes(treeView1.Nodes);
            var storeSearch = StoreNameSearchBox.Text;


            //1.na MHN iparxei shop pou oles oi kathgories tou na vriskontai sthn lista twn unchecked nodes
            //2.to keimeno tou store name search box na einai meros tou onomatos tou store
            IEnumerable<ShopGridViewModel> bindingData = new List<ShopGridViewModel>();
            if (!uncheckedNodes.Contains("All"))
                bindingData = _shops?.Where(x => (!x.Categories?.All(y => uncheckedNodes.Contains(foodCategories[y])) ?? false) && (x.ShopName.Contains(storeSearch)));
            
            

            var bindingList = new SortableBindingList<ShopGridViewModel>(bindingData);

            var dataBinding = new BindingSource(bindingList, null);


            shopResultsGridView.DataSource = dataBinding;

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //_dispatcher.Debounce(24, x=> SetDataGridViewOptions());
        }

        private void StoreNameSearchBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
