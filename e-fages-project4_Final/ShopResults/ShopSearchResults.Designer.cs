namespace ShopResults
{
    partial class ShopSearchResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("All");
            this.shopResultsGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.UserOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.StoreNameSearchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ShopsFound = new System.Windows.Forms.Label();
            this.ShopCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.shopResultsGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shopResultsGridView
            // 
            this.shopResultsGridView.AllowUserToAddRows = false;
            this.shopResultsGridView.AllowUserToDeleteRows = false;
            this.shopResultsGridView.AllowUserToResizeRows = false;
            this.shopResultsGridView.BackgroundColor = System.Drawing.Color.Moccasin;
            this.shopResultsGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.shopResultsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shopResultsGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shopResultsGridView.Location = new System.Drawing.Point(231, 137);
            this.shopResultsGridView.MultiSelect = false;
            this.shopResultsGridView.Name = "shopResultsGridView";
            this.shopResultsGridView.ReadOnly = true;
            this.shopResultsGridView.RowHeadersVisible = false;
            this.shopResultsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shopResultsGridView.Size = new System.Drawing.Size(620, 499);
            this.shopResultsGridView.TabIndex = 2;
            this.shopResultsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShopClicked);
            this.shopResultsGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.ShopResultsGridView_DataBindingComplete);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserOptions});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // UserOptions
            // 
            this.UserOptions.Name = "UserOptions";
            this.UserOptions.Size = new System.Drawing.Size(61, 20);
            this.UserOptions.Text = "Options";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Moccasin;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 137);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Root";
            treeNode1.Text = "All";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(170, 499);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCheck);
            // 
            // StoreNameSearchBox
            // 
            this.StoreNameSearchBox.Location = new System.Drawing.Point(231, 68);
            this.StoreNameSearchBox.Name = "StoreNameSearchBox";
            this.StoreNameSearchBox.Size = new System.Drawing.Size(620, 20);
            this.StoreNameSearchBox.TabIndex = 5;
            this.StoreNameSearchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StoreNameSearchBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Categories";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Store name:";
            // 
            // ShopsFound
            // 
            this.ShopsFound.AutoSize = true;
            this.ShopsFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShopsFound.Location = new System.Drawing.Point(12, 69);
            this.ShopsFound.Name = "ShopsFound";
            this.ShopsFound.Size = new System.Drawing.Size(91, 16);
            this.ShopsFound.TabIndex = 8;
            this.ShopsFound.Text = "Shops Found:";
            // 
            // ShopCount
            // 
            this.ShopCount.AutoSize = true;
            this.ShopCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShopCount.Location = new System.Drawing.Point(100, 69);
            this.ShopCount.Name = "ShopCount";
            this.ShopCount.Size = new System.Drawing.Size(45, 16);
            this.ShopCount.TabIndex = 9;
            this.ShopCount.Text = "count";
            // 
            // ShopSearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(966, 636);
            this.Controls.Add(this.ShopCount);
            this.Controls.Add(this.ShopsFound);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StoreNameSearchBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.shopResultsGridView);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShopSearchResults";
            this.Text = "e-food";
            this.Load += new System.EventHandler(this.Efood_Load);
            this.Shown += new System.EventHandler(this.FormShown);
            ((System.ComponentModel.ISupportInitialize)(this.shopResultsGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView shopResultsGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem UserOptions;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox StoreNameSearchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ShopsFound;
        private System.Windows.Forms.Label ShopCount;
    }
}

