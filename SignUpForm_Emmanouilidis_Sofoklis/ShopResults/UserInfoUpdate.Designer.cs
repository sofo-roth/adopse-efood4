using System.Windows.Forms;

namespace ShopResults
{
    partial class UserInfoUpdate : Form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cads = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cemailTxt = new System.Windows.Forms.TextBox();
            this.cpassTxt = new System.Windows.Forms.TextBox();
            this.cuserTxt = new System.Windows.Forms.TextBox();
            this.ppassLabel = new System.Windows.Forms.Label();
            this.puserLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.addLabel = new System.Windows.Forms.Label();
            this.peLabel = new System.Windows.Forms.Label();
            this.lnameLabel = new System.Windows.Forms.Label();
            this.fnameLabel = new System.Windows.Forms.Label();
            this.cphoneTxt = new System.Windows.Forms.TextBox();
            this.caddTxt = new System.Windows.Forms.TextBox();
            this.clnameTxt = new System.Windows.Forms.TextBox();
            this.cfnameTxt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Firebrick;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("Nina", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(765, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(35, 33);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.Controls.Add(this.cads);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cemailTxt);
            this.panel2.Controls.Add(this.cpassTxt);
            this.panel2.Controls.Add(this.cuserTxt);
            this.panel2.Controls.Add(this.ppassLabel);
            this.panel2.Controls.Add(this.puserLabel);
            this.panel2.Controls.Add(this.phoneLabel);
            this.panel2.Controls.Add(this.addLabel);
            this.panel2.Controls.Add(this.peLabel);
            this.panel2.Controls.Add(this.lnameLabel);
            this.panel2.Controls.Add(this.fnameLabel);
            this.panel2.Controls.Add(this.cphoneTxt);
            this.panel2.Controls.Add(this.caddTxt);
            this.panel2.Controls.Add(this.clnameTxt);
            this.panel2.Controls.Add(this.cfnameTxt);
            this.panel2.Location = new System.Drawing.Point(94, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 426);
            this.panel2.TabIndex = 0;
            // 
            // cads
            // 
            this.cads.AutoSize = true;
            this.cads.Location = new System.Drawing.Point(123, 370);
            this.cads.Name = "cads";
            this.cads.Size = new System.Drawing.Size(211, 30);
            this.cads.TabIndex = 30;
            this.cads.Text = "Επιτρέπω την χρήση δεδομένων μου \r\nγια στοχοθετημένες διαφημίσεις";
            this.cads.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(368, 363);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 43);
            this.button1.TabIndex = 29;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label15.Location = new System.Drawing.Point(423, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 16);
            this.label15.TabIndex = 28;
            this.label15.Text = "New Last Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label14.Location = new System.Drawing.Point(423, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 16);
            this.label14.TabIndex = 27;
            this.label14.Text = "New Email";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label13.Location = new System.Drawing.Point(423, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "New Address";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label12.Location = new System.Drawing.Point(423, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 16);
            this.label12.TabIndex = 25;
            this.label12.Text = "New Phone";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label11.Location = new System.Drawing.Point(423, 286);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "New Username";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label10.Location = new System.Drawing.Point(423, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "New Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label9.Location = new System.Drawing.Point(423, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "New First Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Olive;
            this.label8.Location = new System.Drawing.Point(114, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(357, 50);
            this.label8.TabIndex = 21;
            this.label8.Text = "User Info Update";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label7.Location = new System.Drawing.Point(189, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 24);
            this.label7.TabIndex = 20;
            this.label7.Text = "------------->";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.Location = new System.Drawing.Point(189, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "------------->";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label5.Location = new System.Drawing.Point(189, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 24);
            this.label5.TabIndex = 18;
            this.label5.Text = "------------->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(189, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "------------->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(189, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "------------->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(189, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "------------->";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(189, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "------------->";
            // 
            // cemailTxt
            // 
            this.cemailTxt.Location = new System.Drawing.Point(317, 151);
            this.cemailTxt.Name = "cemailTxt";
            this.cemailTxt.Size = new System.Drawing.Size(100, 20);
            this.cemailTxt.TabIndex = 13;
            // 
            // cpassTxt
            // 
            this.cpassTxt.Location = new System.Drawing.Point(317, 318);
            this.cpassTxt.Name = "cpassTxt";
            this.cpassTxt.Size = new System.Drawing.Size(100, 20);
            this.cpassTxt.TabIndex = 12;
            // 
            // cuserTxt
            // 
            this.cuserTxt.Location = new System.Drawing.Point(317, 280);
            this.cuserTxt.Name = "cuserTxt";
            this.cuserTxt.Size = new System.Drawing.Size(100, 20);
            this.cuserTxt.TabIndex = 11;
            // 
            // ppassLabel
            // 
            this.ppassLabel.AutoSize = true;
            this.ppassLabel.Location = new System.Drawing.Point(116, 325);
            this.ppassLabel.Name = "ppassLabel";
            this.ppassLabel.Size = new System.Drawing.Size(61, 13);
            this.ppassLabel.TabIndex = 10;
            this.ppassLabel.Text = "*Password*";
            // 
            // puserLabel
            // 
            this.puserLabel.AutoSize = true;
            this.puserLabel.Location = new System.Drawing.Point(116, 280);
            this.puserLabel.Name = "puserLabel";
            this.puserLabel.Size = new System.Drawing.Size(35, 13);
            this.puserLabel.TabIndex = 9;
            this.puserLabel.Text = "label6";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Location = new System.Drawing.Point(116, 238);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(35, 13);
            this.phoneLabel.TabIndex = 8;
            this.phoneLabel.Text = "label5";
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Location = new System.Drawing.Point(116, 194);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(35, 13);
            this.addLabel.TabIndex = 7;
            this.addLabel.Text = "label4";
            // 
            // peLabel
            // 
            this.peLabel.AutoSize = true;
            this.peLabel.Location = new System.Drawing.Point(116, 151);
            this.peLabel.Name = "peLabel";
            this.peLabel.Size = new System.Drawing.Size(35, 13);
            this.peLabel.TabIndex = 6;
            this.peLabel.Text = "label3";
            // 
            // lnameLabel
            // 
            this.lnameLabel.AutoSize = true;
            this.lnameLabel.Location = new System.Drawing.Point(116, 108);
            this.lnameLabel.Name = "lnameLabel";
            this.lnameLabel.Size = new System.Drawing.Size(35, 13);
            this.lnameLabel.TabIndex = 5;
            this.lnameLabel.Text = "label2";
            // 
            // fnameLabel
            // 
            this.fnameLabel.AutoSize = true;
            this.fnameLabel.Location = new System.Drawing.Point(116, 65);
            this.fnameLabel.Name = "fnameLabel";
            this.fnameLabel.Size = new System.Drawing.Size(47, 13);
            this.fnameLabel.TabIndex = 4;
            this.fnameLabel.Text = "usrLabel";
            // 
            // cphoneTxt
            // 
            this.cphoneTxt.Location = new System.Drawing.Point(317, 238);
            this.cphoneTxt.Name = "cphoneTxt";
            this.cphoneTxt.Size = new System.Drawing.Size(100, 20);
            this.cphoneTxt.TabIndex = 3;
            // 
            // caddTxt
            // 
            this.caddTxt.Location = new System.Drawing.Point(317, 194);
            this.caddTxt.Name = "caddTxt";
            this.caddTxt.Size = new System.Drawing.Size(100, 20);
            this.caddTxt.TabIndex = 2;
            // 
            // clnameTxt
            // 
            this.clnameTxt.Location = new System.Drawing.Point(317, 105);
            this.clnameTxt.Name = "clnameTxt";
            this.clnameTxt.Size = new System.Drawing.Size(100, 20);
            this.clnameTxt.TabIndex = 1;
            // 
            // cfnameTxt
            // 
            this.cfnameTxt.Location = new System.Drawing.Point(317, 65);
            this.cfnameTxt.Name = "cfnameTxt";
            this.cfnameTxt.Size = new System.Drawing.Size(100, 20);
            this.cfnameTxt.TabIndex = 0;
            // 
            // UserInfoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserInfoUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserInfoUpdateForm";
            this.Load += new System.EventHandler(this.LoadForm);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox clnameTxt;
        private System.Windows.Forms.TextBox cfnameTxt;
        private System.Windows.Forms.Label puserLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.Label peLabel;
        private System.Windows.Forms.Label lnameLabel;
        private System.Windows.Forms.Label fnameLabel;
        private System.Windows.Forms.TextBox cphoneTxt;
        private System.Windows.Forms.TextBox caddTxt;
        private System.Windows.Forms.TextBox cemailTxt;
        private System.Windows.Forms.TextBox cpassTxt;
        private System.Windows.Forms.TextBox cuserTxt;
        private System.Windows.Forms.Label ppassLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cads;
        private System.Windows.Forms.Button exitButton;
    }
}