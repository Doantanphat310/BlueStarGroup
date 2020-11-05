namespace BSClient
{
    partial class Login
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
            this.Login_Button = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.UserId_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Password_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.Exit_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.UserId_TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_TextBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Login_Button
            // 
            this.Login_Button.Location = new System.Drawing.Point(42, 131);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(75, 23);
            this.Login_Button.TabIndex = 0;
            this.Login_Button.Text = "Đăng nhập";
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(42, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "User";
            // 
            // UserId_TextBox
            // 
            this.UserId_TextBox.EditValue = "admin";
            this.UserId_TextBox.Location = new System.Drawing.Point(79, 54);
            this.UserId_TextBox.Name = "UserId_TextBox";
            this.UserId_TextBox.Size = new System.Drawing.Size(108, 20);
            this.UserId_TextBox.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(42, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Pass";
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.EditValue = "Ab123456";
            this.Password_TextBox.Location = new System.Drawing.Point(79, 80);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Properties.PasswordChar = '*';
            this.Password_TextBox.Size = new System.Drawing.Size(108, 20);
            this.Password_TextBox.TabIndex = 2;
            // 
            // Exit_Button
            // 
            this.Exit_Button.Location = new System.Drawing.Point(123, 131);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(75, 23);
            this.Exit_Button.TabIndex = 0;
            this.Exit_Button.Text = "Thoát";
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 189);
            this.Controls.Add(this.Password_TextBox);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.UserId_TextBox);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Login_Button);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.UserId_TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_TextBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Login_Button;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit UserId_TextBox;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit Password_TextBox;
        private DevExpress.XtraEditors.SimpleButton Exit_Button;
    }
}