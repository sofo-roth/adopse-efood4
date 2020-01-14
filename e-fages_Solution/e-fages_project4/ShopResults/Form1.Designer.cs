namespace ShopResults
{
    partial class ShopResults
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Pizza");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Burger");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Sandwitch");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Beverage");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("All", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.shopResultsGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMyInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMyOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
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
            this.shopResultsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shopClicked);
            this.shopResultsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.shopResultsGridView_CellContentClick);
            this.shopResultsGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.shopResultsGridView_DataBindingComplete);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(966, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMyInfoToolStripMenuItem,
            this.viewMyOrdersToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // editMyInfoToolStripMenuItem
            // 
            this.editMyInfoToolStripMenuItem.Name = "editMyInfoToolStripMenuItem";
            this.editMyInfoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.editMyInfoToolStripMenuItem.Text = "Edit my info";
            // 
            // viewMyOrdersToolStripMenuItem
            // 
            this.viewMyOrdersToolStripMenuItem.Name = "viewMyOrdersToolStripMenuItem";
            this.viewMyOrdersToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.viewMyOrdersToolStripMenuItem.Text = "View my orders";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Moccasin;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(12, 137);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Pizza";
            treeNode1.Text = "Pizza";
            treeNode2.Name = "Burger";
            treeNode2.Text = "Burger";
            treeNode3.Name = "Sandwitch";
            treeNode3.Text = "Sandwitch";
            treeNode4.Name = "Beverage";
            treeNode4.Text = "Beverage";
            treeNode5.Name = "Root";
            treeNode5.Text = "All";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(170, 499);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // ShopResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(966, 636);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.shopResultsGridView);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShopResults";
            this.Text = "FoodE";
            this.Load += new System.EventHandler(this.efood_Load);
            ((System.ComponentModel.ISupportInitialize)(this.shopResultsGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView shopResultsGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMyInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMyOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
    }
}

