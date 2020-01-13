namespace ShopResults
{
    partial class UserOrders
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
            this.OrdersGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersGrid
            // 
            this.OrdersGrid.AllowUserToAddRows = false;
            this.OrdersGrid.AllowUserToDeleteRows = false;
            this.OrdersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdersGrid.Location = new System.Drawing.Point(0, 0);
            this.OrdersGrid.Name = "OrdersGrid";
            this.OrdersGrid.ReadOnly = true;
            this.OrdersGrid.RowHeadersVisible = false;
            this.OrdersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersGrid.Size = new System.Drawing.Size(800, 450);
            this.OrdersGrid.TabIndex = 0;
            this.OrdersGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderClicked);
            // 
            // UserOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OrdersGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UserOrders";
            this.Text = "UserOrders";
            this.Load += new System.EventHandler(this.UserOrders_Load);
            this.Shown += new System.EventHandler(this.UserOrders_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView OrdersGrid;
    }
}