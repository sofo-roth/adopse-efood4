namespace ShopResults
{
    partial class MainForm
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
            this.EFoodLabel = new System.Windows.Forms.Label();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.DescriptionTasty = new System.Windows.Forms.Label();
            this.DescriptionTasty2 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.UseUserAddressButton = new System.Windows.Forms.Button();
            this.DescriptionTasty3 = new System.Windows.Forms.Label();
            this.UserStrip = new System.Windows.Forms.MenuStrip();
            this.UserOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.UserStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // EFoodLabel
            // 
            this.EFoodLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EFoodLabel.AutoSize = true;
            this.EFoodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EFoodLabel.Location = new System.Drawing.Point(254, 24);
            this.EFoodLabel.Name = "EFoodLabel";
            this.EFoodLabel.Size = new System.Drawing.Size(215, 73);
            this.EFoodLabel.TabIndex = 0;
            this.EFoodLabel.Text = "e-food";
            // 
            // AddressBox
            // 
            this.AddressBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddressBox.Location = new System.Drawing.Point(183, 291);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.Size = new System.Drawing.Size(286, 20);
            this.AddressBox.TabIndex = 1;
            // 
            // DescriptionTasty
            // 
            this.DescriptionTasty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescriptionTasty.AutoSize = true;
            this.DescriptionTasty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTasty.Location = new System.Drawing.Point(102, 114);
            this.DescriptionTasty.Name = "DescriptionTasty";
            this.DescriptionTasty.Size = new System.Drawing.Size(562, 25);
            this.DescriptionTasty.TabIndex = 2;
            this.DescriptionTasty.Text = "Vres panw apo 1.000 katasthmata konta sthn perioxh sou";
            this.DescriptionTasty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DescriptionTasty2
            // 
            this.DescriptionTasty2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescriptionTasty2.AutoSize = true;
            this.DescriptionTasty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTasty2.Location = new System.Drawing.Point(73, 139);
            this.DescriptionTasty2.Name = "DescriptionTasty2";
            this.DescriptionTasty2.Size = new System.Drawing.Size(622, 18);
            this.DescriptionTasty2.TabIndex = 3;
            this.DescriptionTasty2.Text = "Epelekse ta katasthmata pou se endiaferoun me vash tis kathgories proiontwn pou d" +
    "iathetoun";
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchButton.Location = new System.Drawing.Point(475, 291);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 20);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Anazhthsh";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // UseUserAddressButton
            // 
            this.UseUserAddressButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UseUserAddressButton.Location = new System.Drawing.Point(304, 329);
            this.UseUserAddressButton.Name = "UseUserAddressButton";
            this.UseUserAddressButton.Size = new System.Drawing.Size(107, 23);
            this.UseUserAddressButton.TabIndex = 5;
            this.UseUserAddressButton.Text = "Use my address";
            this.UseUserAddressButton.UseVisualStyleBackColor = true;
            this.UseUserAddressButton.Click += new System.EventHandler(this.UseUserAddressButton_Click);
            // 
            // DescriptionTasty3
            // 
            this.DescriptionTasty3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DescriptionTasty3.AutoSize = true;
            this.DescriptionTasty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionTasty3.Location = new System.Drawing.Point(152, 239);
            this.DescriptionTasty3.Name = "DescriptionTasty3";
            this.DescriptionTasty3.Size = new System.Drawing.Size(434, 24);
            this.DescriptionTasty3.TabIndex = 6;
            this.DescriptionTasty3.Text = "Plhktrologise thn diefthunsh sou gia na ksekinhseis";
            // 
            // UserStrip
            // 
            this.UserStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UserOptions});
            this.UserStrip.Location = new System.Drawing.Point(0, 0);
            this.UserStrip.Name = "UserStrip";
            this.UserStrip.Size = new System.Drawing.Size(800, 24);
            this.UserStrip.TabIndex = 7;
            this.UserStrip.Text = "menuStrip1";
            // 
            // UserOptions
            // 
            this.UserOptions.Name = "UserOptions";
            this.UserOptions.Size = new System.Drawing.Size(61, 20);
            this.UserOptions.Text = "Options";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DescriptionTasty3);
            this.Controls.Add(this.UseUserAddressButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DescriptionTasty2);
            this.Controls.Add(this.DescriptionTasty);
            this.Controls.Add(this.AddressBox);
            this.Controls.Add(this.EFoodLabel);
            this.Controls.Add(this.UserStrip);
            this.MainMenuStrip = this.UserStrip;
            this.Name = "MainForm";
            this.Text = "e-food";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.UserStrip.ResumeLayout(false);
            this.UserStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EFoodLabel;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Label DescriptionTasty;
        private System.Windows.Forms.Label DescriptionTasty2;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button UseUserAddressButton;
        private System.Windows.Forms.Label DescriptionTasty3;
        private System.Windows.Forms.MenuStrip UserStrip;
        private System.Windows.Forms.ToolStripMenuItem UserOptions;
    }
}