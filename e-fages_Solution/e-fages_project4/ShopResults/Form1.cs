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
    public partial class ShopResults : Form
    {
        DispatcherObserver _d = new DispatcherObserver();

        //UserAccountService _account = new UserAccountService();

        static List<string> mockIngredients = new List<string> { "vas", "vasilia2s" };

        List<ShopCol> mock = new List<ShopCol>
        {
            new ShopCol() {Address = "meeeeemsseos", ShopName = "shop1", distance = 3.3, Id = 0,ingrad = mockIngredients},
            new ShopCol()
            {
                Address = "fgedgebfdffscrgrwegwe", ShopName = "shop153", distance = 352.3, Id = 1
            }
        };          //todo: this list will be replaced with database data based on the address


        public ShopResults(string address)
        {
            InitializeComponent();

            PopulateDataGrid(address);

            SetDataGridViewOptions();
            
        }

        private void PopulateDataGrid(string address)
        {

            


            var mock2 = new string[2];
            mock2[0] = "vas";
            mock2[1]= "vasilia2s";

            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (var item in mock2)
            {
                nodes[0].Nodes.Add(item);
                
            }

            CheckAllNodes(nodes,true);



            var mockdata = mock.Select(x => new ShopGridViewModel()
            {
                ShopName = x.ShopName,
                Address = x.Address,
                distance = x.distance,
                Id = x.Id
                
            });

            var binding = new BindingSource {DataSource = mockdata};

           
            shopResultsGridView.DataSource = binding;

            
        }

       

        private void SetDataGridViewOptions()
        {
            shopResultsGridView.Columns["Id"].Visible = false;

            shopResultsGridView.Columns["ShopName"].HeaderText = "kalhspersaa";

            foreach (DataGridViewColumn column in shopResultsGridView.Columns)
            {

                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            //shopResultsGridView.Dock = DockStyle.Fill;



        }
       


        private void CheckAllNodes(TreeNodeCollection rootNode,bool isChecked)
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
               var uncheckedChildren= GetUncheckedNodes(node.Nodes);
                if(!node.Checked)
                    uncheckedNodes.Add(node.Text);
                uncheckedNodes.AddRange(uncheckedChildren);
            }

            return uncheckedNodes;
        }

        private void enableControls(bool enabled)
        {
             this.Enabled = enabled;
        }

        private async void WaitAsync(double seconds)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            var milliseconds = (int)(seconds * 100);
            await Task.Delay(milliseconds);
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void efood_Load(object sender, EventArgs e)
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
            if(e.RowIndex<0) return;

            //var id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.Columns["Id"].Index].Value;
            var id = shopResultsGridView.CurrentRow.Cells[shopResultsGridView.Columns["Id"].Index].Value;
            MessageBox.Show("shop id selected: " + id ); //var storeform = new StoreForm(id);
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

            _d.Debounce(2000, x => Dostuff(sender,e));
        }



        private void Dostuff(object sender, TreeViewEventArgs e)
        {
            
            
            WaitAsync(2.5);
            

            
            //if(e.Node.Index>0)
            //    e.Node.Parent.Checked = e.Node.Checked;

            //CheckParents(e.Node);

            List<string> uncheckedNodes = GetUncheckedNodes(treeView1.Nodes);

            var bindingData = new List<ShopCol>();
            if (!uncheckedNodes.Contains("All"))
                bindingData = mock?.Where(x => !x.ingrad?.All(y => uncheckedNodes.Contains(y)) ?? false).ToList();

            var mockdata = bindingData?.Select(x => new ShopGridViewModel()
            {
                ShopName = x.ShopName,
                Address = x.Address,
                distance = x.distance,
                Id = x.Id

            });

            var binding = new BindingSource { DataSource = mockdata };


            shopResultsGridView.DataSource = binding;
            
        }

        private void shopResultsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
