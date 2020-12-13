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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Login_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserID_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.Main_LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.Password_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.Company_LookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.UserName_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.Password_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.Company_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.Exit_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Bottom_Panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.UserID_TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_LayoutControl)).BeginInit();
            this.Main_LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Password_TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_LookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Label)).BeginInit();
            this.Bottom_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login_Button
            // 
            this.Login_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Login_Button.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Button.Appearance.Options.UseFont = true;
            this.Login_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Login_Button.ImageOptions.Image")));
            this.Login_Button.Location = new System.Drawing.Point(204, 11);
            this.Login_Button.Name = "Login_Button";
            this.Login_Button.Size = new System.Drawing.Size(105, 35);
            this.Login_Button.TabIndex = 1;
            this.Login_Button.Text = "Đăng nhập";
            this.Login_Button.Click += new System.EventHandler(this.Login_Button_Click);
            // 
            // UserID_TextBox
            // 
            this.UserID_TextBox.EditValue = "admin";
            this.UserID_TextBox.Location = new System.Drawing.Point(60, 25);
            this.UserID_TextBox.Name = "UserID_TextBox";
            this.UserID_TextBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserID_TextBox.Properties.Appearance.Options.UseFont = true;
            this.UserID_TextBox.Size = new System.Drawing.Size(354, 26);
            this.UserID_TextBox.StyleController = this.Main_LayoutControl;
            this.UserID_TextBox.TabIndex = 0;
            // 
            // Main_LayoutControl
            // 
            this.Main_LayoutControl.Controls.Add(this.Password_TextBox);
            this.Main_LayoutControl.Controls.Add(this.UserID_TextBox);
            this.Main_LayoutControl.Controls.Add(this.Company_LookUpEdit);
            this.Main_LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_LayoutControl.Location = new System.Drawing.Point(0, 0);
            this.Main_LayoutControl.Name = "Main_LayoutControl";
            this.Main_LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(342, 0, 650, 400);
            this.Main_LayoutControl.Root = this.Root;
            this.Main_LayoutControl.Size = new System.Drawing.Size(439, 148);
            this.Main_LayoutControl.TabIndex = 0;
            this.Main_LayoutControl.Text = "layoutControl1";
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.EditValue = "Ab123456";
            this.Password_TextBox.Location = new System.Drawing.Point(60, 61);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_TextBox.Properties.Appearance.Options.UseFont = true;
            this.Password_TextBox.Properties.PasswordChar = '*';
            this.Password_TextBox.Size = new System.Drawing.Size(354, 26);
            this.Password_TextBox.StyleController = this.Main_LayoutControl;
            this.Password_TextBox.TabIndex = 1;
            // 
            // Company_LookUpEdit
            // 
            this.Company_LookUpEdit.Location = new System.Drawing.Point(60, 97);
            this.Company_LookUpEdit.Name = "Company_LookUpEdit";
            this.Company_LookUpEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Company_LookUpEdit.Properties.Appearance.Options.UseFont = true;
            this.Company_LookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Company_LookUpEdit.Properties.NullText = "Chọn công ty";
            this.Company_LookUpEdit.Size = new System.Drawing.Size(354, 24);
            this.Company_LookUpEdit.StyleController = this.Main_LayoutControl;
            this.Company_LookUpEdit.TabIndex = 2;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.UserName_Label,
            this.Password_Label,
            this.Company_Label});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(20, 20, 20, 20);
            this.Root.Size = new System.Drawing.Size(439, 148);
            this.Root.TextVisible = false;
            // 
            // UserName_Label
            // 
            this.UserName_Label.Control = this.UserID_TextBox;
            this.UserName_Label.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserName_Label.ImageOptions.Image")));
            this.UserName_Label.Location = new System.Drawing.Point(0, 0);
            this.UserName_Label.Name = "UserName_Label";
            this.UserName_Label.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.UserName_Label.ShowInCustomizationForm = false;
            this.UserName_Label.Size = new System.Drawing.Size(399, 36);
            this.UserName_Label.Text = " ";
            this.UserName_Label.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.UserName_Label.TextSize = new System.Drawing.Size(30, 24);
            this.UserName_Label.TextToControlDistance = 5;
            // 
            // Password_Label
            // 
            this.Password_Label.Control = this.Password_TextBox;
            this.Password_Label.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Password_Label.ImageOptions.Image")));
            this.Password_Label.Location = new System.Drawing.Point(0, 36);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.Password_Label.Size = new System.Drawing.Size(399, 36);
            this.Password_Label.Text = " ";
            this.Password_Label.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Password_Label.TextSize = new System.Drawing.Size(30, 24);
            this.Password_Label.TextToControlDistance = 5;
            // 
            // Company_Label
            // 
            this.Company_Label.Control = this.Company_LookUpEdit;
            this.Company_Label.Enabled = false;
            this.Company_Label.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Company_Label.ImageOptions.Image")));
            this.Company_Label.Location = new System.Drawing.Point(0, 72);
            this.Company_Label.Name = "Company_Label";
            this.Company_Label.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.Company_Label.Size = new System.Drawing.Size(399, 36);
            this.Company_Label.Text = " ";
            this.Company_Label.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.Company_Label.TextSize = new System.Drawing.Size(30, 24);
            this.Company_Label.TextToControlDistance = 5;
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_Button.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_Button.Appearance.Options.UseFont = true;
            this.Exit_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Exit_Button.ImageOptions.Image")));
            this.Exit_Button.Location = new System.Drawing.Point(322, 11);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(105, 35);
            this.Exit_Button.TabIndex = 2;
            this.Exit_Button.Text = "Thoát";
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Bottom_Panel
            // 
            this.Bottom_Panel.Controls.Add(this.Login_Button);
            this.Bottom_Panel.Controls.Add(this.Exit_Button);
            this.Bottom_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottom_Panel.Location = new System.Drawing.Point(0, 148);
            this.Bottom_Panel.Name = "Bottom_Panel";
            this.Bottom_Panel.Size = new System.Drawing.Size(439, 55);
            this.Bottom_Panel.TabIndex = 1;
            // 
            // Login
            // 
            this.AcceptButton = this.Login_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 203);
            this.Controls.Add(this.Main_LayoutControl);
            this.Controls.Add(this.Bottom_Panel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            ((System.ComponentModel.ISupportInitialize)(this.UserID_TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_LayoutControl)).EndInit();
            this.Main_LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Password_TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_LookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_Label)).EndInit();
            this.Bottom_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Login_Button;
        private DevExpress.XtraEditors.TextEdit UserID_TextBox;
        private DevExpress.XtraEditors.TextEdit Password_TextBox;
        private DevExpress.XtraEditors.SimpleButton Exit_Button;
        private DevExpress.XtraLayout.LayoutControl Main_LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem UserName_Label;
        private DevExpress.XtraLayout.LayoutControlItem Password_Label;
        private System.Windows.Forms.Panel Bottom_Panel;
        private DevExpress.XtraLayout.LayoutControlItem Company_Label;
        private DevExpress.XtraEditors.LookUpEdit Company_LookUpEdit;
    }
}