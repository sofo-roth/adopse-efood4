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
        public ShopResults(string address)
        {
            InitializeComponent();

            PopulateDataGrid(address);

            SetDataGridViewOptions();



        }

        private void PopulateDataGrid(string address)
        {
            

            var mock = new List<ShopGridViewModel>(); //todo: this list will be replaced with database data based on the address

            mock.Add(new ShopGridViewModel()        
            {
                Address = "meeeeemsseos",            
                ShopName = "shop1",
                distance = 3.3,
                Id = 0
            });

            mock.Add(new ShopGridViewModel()
            {
                Address = "fgedgebfdffscrgrwegwe",
                ShopName = "shop153",
                distance = 352.3,
                Id = 1
            });

            var binding = new BindingSource();
            binding.DataSource = mock;


            
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

        
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void helloWorldLabel_Click(object sender, EventArgs e)
        {

        }

        private void efood_Load(object sender, EventArgs e)
        {

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
            if(e.RowIndex<0) return;

            //var id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[dataGridView1.Columns["Id"].Index].Value;
            var id = shopResultsGridView.CurrentRow.Cells[shopResultsGridView.Columns["Id"].Index].Value;
            MessageBox.Show("shop id selected: " + id ); //var storeform = new StoreForm(id);
        }


    }
}
