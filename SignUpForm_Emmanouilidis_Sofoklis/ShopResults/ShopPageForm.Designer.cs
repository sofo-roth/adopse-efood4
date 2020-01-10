namespace ShopResults
{
    partial class ShopPageForm
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
            this.CategoriesGrid = new System.Windows.Forms.DataGridView();
            this.ShopNameLabel = new System.Windows.Forms.Label();
            this.ShopAddress = new System.Windows.Forms.Label();
            this.Elaxisti = new System.Windows.Forms.Label();
            this.Rating = new System.Windows.Forms.Label();
            this.FoodItemsGrid = new System.Windows.Forms.DataGridView();
            this.IngredientsGrid = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.AddToCart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoodItemsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // CategoriesGrid
            // 
            this.CategoriesGrid.AllowUserToAddRows = false;
            this.CategoriesGrid.AllowUserToDeleteRows = false;
            this.CategoriesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CategoriesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CategoriesGrid.Location = new System.Drawing.Point(41, 136);
            this.CategoriesGrid.Name = "CategoriesGrid";
            this.CategoriesGrid.RowHeadersVisible = false;
            this.CategoriesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CategoriesGrid.Size = new System.Drawing.Size(151, 205);
            this.CategoriesGrid.TabIndex = 0;
            this.CategoriesGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CategoryClicked);
            this.CategoriesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ShopNameLabel
            // 
            this.ShopNameLabel.AutoSize = true;
            this.ShopNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShopNameLabel.Location = new System.Drawing.Point(312, 21);
            this.ShopNameLabel.Name = "ShopNameLabel";
            this.ShopNameLabel.Size = new System.Drawing.Size(82, 33);
            this.ShopNameLabel.TabIndex = 1;
            this.ShopNameLabel.Text = "Shop";
            // 
            // ShopAddress
            // 
            this.ShopAddress.AutoSize = true;
            this.ShopAddress.Location = new System.Drawing.Point(335, 69);
            this.ShopAddress.Name = "ShopAddress";
            this.ShopAddress.Size = new System.Drawing.Size(35, 13);
            this.ShopAddress.TabIndex = 2;
            this.ShopAddress.Text = "label1";
            // 
            // Elaxisti
            // 
            this.Elaxisti.AutoSize = true;
            this.Elaxisti.Location = new System.Drawing.Point(225, 109);
            this.Elaxisti.Name = "Elaxisti";
            this.Elaxisti.Size = new System.Drawing.Size(35, 13);
            this.Elaxisti.TabIndex = 3;
            this.Elaxisti.Text = "label1";
            // 
            // Rating
            // 
            this.Rating.AutoSize = true;
            this.Rating.Location = new System.Drawing.Point(447, 109);
            this.Rating.Name = "Rating";
            this.Rating.Size = new System.Drawing.Size(35, 13);
            this.Rating.TabIndex = 4;
            this.Rating.Text = "label1";
            // 
            // FoodItemsGrid
            // 
            this.FoodItemsGrid.AllowUserToAddRows = false;
            this.FoodItemsGrid.AllowUserToDeleteRows = false;
            this.FoodItemsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FoodItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FoodItemsGrid.Location = new System.Drawing.Point(248, 137);
            this.FoodItemsGrid.Name = "FoodItemsGrid";
            this.FoodItemsGrid.ReadOnly = true;
            this.FoodItemsGrid.RowHeadersVisible = false;
            this.FoodItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FoodItemsGrid.Size = new System.Drawing.Size(224, 204);
            this.FoodItemsGrid.TabIndex = 5;
            this.FoodItemsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FoodItemClicked);
            // 
            // IngredientsGrid
            // 
            this.IngredientsGrid.AllowUserToAddRows = false;
            this.IngredientsGrid.AllowUserToDeleteRows = false;
            this.IngredientsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IngredientsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IngredientsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk});
            this.IngredientsGrid.Location = new System.Drawing.Point(528, 136);
            this.IngredientsGrid.Name = "IngredientsGrid";
            this.IngredientsGrid.ReadOnly = true;
            this.IngredientsGrid.RowHeadersVisible = false;
            this.IngredientsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IngredientsGrid.Size = new System.Drawing.Size(240, 204);
            this.IngredientsGrid.TabIndex = 6;
            this.IngredientsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IngredientClicked);
            // 
            // chk
            // 
            this.chk.HeaderText = " ";
            this.chk.Name = "chk";
            this.chk.ReadOnly = true;
            // 
            // ItemQuantity
            // 
            this.ItemQuantity.Location = new System.Drawing.Point(707, 354);
            this.ItemQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ItemQuantity.Name = "ItemQuantity";
            this.ItemQuantity.Size = new System.Drawing.Size(40, 20);
            this.ItemQuantity.TabIndex = 7;
            this.ItemQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(652, 356);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(49, 13);
            this.QuantityLabel.TabIndex = 8;
            this.QuantityLabel.Text = "Quantity:";
            // 
            // AddToCart
            // 
            this.AddToCart.Location = new System.Drawing.Point(655, 380);
            this.AddToCart.Name = "AddToCart";
            this.AddToCart.Size = new System.Drawing.Size(75, 23);
            this.AddToCart.TabIndex = 9;
            this.AddToCart.Text = "Add to cart";
            this.AddToCart.UseVisualStyleBackColor = true;
            this.AddToCart.Click += new System.EventHandler(this.button1_Click);
            // 
            // ShopPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddToCart);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.ItemQuantity);
            this.Controls.Add(this.IngredientsGrid);
            this.Controls.Add(this.FoodItemsGrid);
            this.Controls.Add(this.Rating);
            this.Controls.Add(this.Elaxisti);
            this.Controls.Add(this.ShopAddress);
            this.Controls.Add(this.ShopNameLabel);
            this.Controls.Add(this.CategoriesGrid);
            this.Name = "ShopPageForm";
            this.Text = "ShopPageForm";
            this.Load += new System.EventHandler(this.ShopPageForm_Load);
            this.Shown += new System.EventHandler(this.FormShown);
            ((System.ComponentModel.ISupportInitialize)(this.CategoriesGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FoodItemsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IngredientsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CategoriesGrid;
        private System.Windows.Forms.Label ShopNameLabel;
        private System.Windows.Forms.Label ShopAddress;
        private System.Windows.Forms.Label Elaxisti;
        private System.Windows.Forms.Label Rating;
        private System.Windows.Forms.DataGridView FoodItemsGrid;
        private System.Windows.Forms.DataGridView IngredientsGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.NumericUpDown ItemQuantity;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Button AddToCart;
    }
}