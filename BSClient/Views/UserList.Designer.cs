namespace BSClient.Views
{
    partial class UserList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions4 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions5 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions6 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.Role_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Role_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Main_Table = new System.Windows.Forms.TableLayoutPanel();
            this.User_GridControl = new DevExpress.XtraGrid.GridControl();
            this.User_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.User_LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.UserName_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.FullName_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.Password_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.User_LayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.FullName_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.UserName_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.Password_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.Role_LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.CompanyID_ComboBox = new DevExpress.XtraEditors.LookUpEdit();
            this.UserRole_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.Role_LayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.UserRole_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.CompanyID_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.Role_UserName_TexBox = new DevExpress.XtraEditors.TextEdit();
            this.Role_UserName_Label = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.Role_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_GridView)).BeginInit();
            this.Main_Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_LayoutControl)).BeginInit();
            this.User_LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserName_TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullName_TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullName_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_LayoutControl)).BeginInit();
            this.Role_LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyID_ComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyID_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_UserName_TexBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_UserName_Label)).BeginInit();
            this.SuspendLayout();
            // 
            // Role_GridControl
            // 
            this.Role_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Role_GridControl.Location = new System.Drawing.Point(417, 202);
            this.Role_GridControl.MainView = this.Role_GridView;
            this.Role_GridControl.Name = "Role_GridControl";
            this.Role_GridControl.Size = new System.Drawing.Size(408, 303);
            this.Role_GridControl.TabIndex = 1;
            this.Role_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Role_GridView});
            // 
            // Role_GridView
            // 
            this.Role_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.Role_GridView.GridControl = this.Role_GridControl;
            this.Role_GridView.Name = "Role_GridView";
            this.Role_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Customer_GridView_RowUpdated);
            // 
            // Main_Table
            // 
            this.Main_Table.ColumnCount = 2;
            this.Main_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Main_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Main_Table.Controls.Add(this.Role_GridControl, 1, 1);
            this.Main_Table.Controls.Add(this.User_GridControl, 0, 1);
            this.Main_Table.Controls.Add(this.User_LayoutControl, 0, 0);
            this.Main_Table.Controls.Add(this.Role_LayoutControl, 1, 0);
            this.Main_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Table.Location = new System.Drawing.Point(0, 0);
            this.Main_Table.Name = "Main_Table";
            this.Main_Table.RowCount = 2;
            this.Main_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.17323F));
            this.Main_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.82677F));
            this.Main_Table.Size = new System.Drawing.Size(828, 508);
            this.Main_Table.TabIndex = 2;
            // 
            // User_GridControl
            // 
            this.User_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.User_GridControl.Location = new System.Drawing.Point(3, 202);
            this.User_GridControl.MainView = this.User_GridView;
            this.User_GridControl.Name = "User_GridControl";
            this.User_GridControl.Size = new System.Drawing.Size(408, 303);
            this.User_GridControl.TabIndex = 2;
            this.User_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.User_GridView});
            // 
            // User_GridView
            // 
            this.User_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.User_GridView.GridControl = this.User_GridControl;
            this.User_GridView.Name = "User_GridView";
            // 
            // User_LayoutControl
            // 
            this.User_LayoutControl.Controls.Add(this.UserName_TextBox);
            this.User_LayoutControl.Controls.Add(this.FullName_TextBox);
            this.User_LayoutControl.Controls.Add(this.Password_TextBox);
            this.User_LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.User_LayoutControl.Location = new System.Drawing.Point(3, 3);
            this.User_LayoutControl.Name = "User_LayoutControl";
            this.User_LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(422, 0, 650, 400);
            this.User_LayoutControl.Root = this.User_LayoutGroup;
            this.User_LayoutControl.Size = new System.Drawing.Size(408, 193);
            this.User_LayoutControl.TabIndex = 0;
            this.User_LayoutControl.Text = "User";
            // 
            // UserName_TextBox
            // 
            this.UserName_TextBox.Location = new System.Drawing.Point(87, 79);
            this.UserName_TextBox.Name = "UserName_TextBox";
            this.UserName_TextBox.Size = new System.Drawing.Size(309, 20);
            this.UserName_TextBox.StyleController = this.User_LayoutControl;
            this.UserName_TextBox.TabIndex = 5;
            // 
            // FullName_TextBox
            // 
            this.FullName_TextBox.Location = new System.Drawing.Point(87, 55);
            this.FullName_TextBox.Name = "FullName_TextBox";
            this.FullName_TextBox.Size = new System.Drawing.Size(309, 20);
            this.FullName_TextBox.StyleController = this.User_LayoutControl;
            this.FullName_TextBox.TabIndex = 4;
            // 
            // Password_TextBox
            // 
            this.Password_TextBox.Location = new System.Drawing.Point(87, 103);
            this.Password_TextBox.Name = "Password_TextBox";
            this.Password_TextBox.Size = new System.Drawing.Size(309, 20);
            this.Password_TextBox.StyleController = this.User_LayoutControl;
            this.Password_TextBox.TabIndex = 5;
            // 
            // User_LayoutGroup
            // 
            this.User_LayoutGroup.AppearanceGroup.Options.UseTextOptions = true;
            this.User_LayoutGroup.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.User_LayoutGroup.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("User_LayoutGroup.CaptionImageOptions.Image")));
            buttonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions1.Image")));
            buttonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions2.Image")));
            buttonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions3.Image")));
            this.User_LayoutGroup.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Thêm", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Xóa", true, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Sửa", true, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.User_LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.FullName_Label,
            this.UserName_Label,
            this.Password_Label});
            this.User_LayoutGroup.Name = "Root";
            this.User_LayoutGroup.Size = new System.Drawing.Size(408, 193);
            this.User_LayoutGroup.Text = "Thông tin người dùng";
            // 
            // FullName_Label
            // 
            this.FullName_Label.Control = this.FullName_TextBox;
            this.FullName_Label.Location = new System.Drawing.Point(0, 0);
            this.FullName_Label.Name = "FullName_Label";
            this.FullName_Label.Size = new System.Drawing.Size(388, 24);
            this.FullName_Label.Text = "Họ và tên";
            this.FullName_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // UserName_Label
            // 
            this.UserName_Label.Control = this.UserName_TextBox;
            this.UserName_Label.Location = new System.Drawing.Point(0, 24);
            this.UserName_Label.Name = "UserName_Label";
            this.UserName_Label.Size = new System.Drawing.Size(388, 24);
            this.UserName_Label.Text = "Tên đăng nhập";
            this.UserName_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // Password_Label
            // 
            this.Password_Label.Control = this.Password_TextBox;
            this.Password_Label.CustomizationFormText = "Tên đăng nhập";
            this.Password_Label.Location = new System.Drawing.Point(0, 48);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(388, 82);
            this.Password_Label.Text = "Mật khẩu";
            this.Password_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // Role_LayoutControl
            // 
            this.Role_LayoutControl.Controls.Add(this.Role_UserName_TexBox);
            this.Role_LayoutControl.Controls.Add(this.CompanyID_ComboBox);
            this.Role_LayoutControl.Controls.Add(this.UserRole_TextBox);
            this.Role_LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Role_LayoutControl.Location = new System.Drawing.Point(417, 3);
            this.Role_LayoutControl.Name = "Role_LayoutControl";
            this.Role_LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(654, 0, 650, 400);
            this.Role_LayoutControl.Root = this.Role_LayoutGroup;
            this.Role_LayoutControl.Size = new System.Drawing.Size(408, 193);
            this.Role_LayoutControl.TabIndex = 3;
            this.Role_LayoutControl.Text = "Role";
            // 
            // CompanyID_ComboBox
            // 
            this.CompanyID_ComboBox.Location = new System.Drawing.Point(87, 103);
            this.CompanyID_ComboBox.Name = "CompanyID_ComboBox";
            this.CompanyID_ComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CompanyID_ComboBox.Size = new System.Drawing.Size(309, 20);
            this.CompanyID_ComboBox.StyleController = this.Role_LayoutControl;
            this.CompanyID_ComboBox.TabIndex = 5;
            // 
            // UserRole_TextBox
            // 
            this.UserRole_TextBox.Location = new System.Drawing.Point(87, 79);
            this.UserRole_TextBox.Name = "UserRole_TextBox";
            this.UserRole_TextBox.Size = new System.Drawing.Size(309, 20);
            this.UserRole_TextBox.StyleController = this.Role_LayoutControl;
            this.UserRole_TextBox.TabIndex = 4;
            // 
            // Role_LayoutGroup
            // 
            this.Role_LayoutGroup.AppearanceGroup.Options.UseTextOptions = true;
            this.Role_LayoutGroup.AppearanceGroup.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Role_LayoutGroup.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Role_LayoutGroup.CaptionImageOptions.Image")));
            buttonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions4.Image")));
            buttonImageOptions5.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions5.Image")));
            buttonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions6.Image")));
            this.Role_LayoutGroup.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Thêm", true, buttonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Xóa", true, buttonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Cập nhật", true, buttonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.Role_LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.UserRole_Label,
            this.CompanyID_Label,
            this.Role_UserName_Label});
            this.Role_LayoutGroup.Name = "Root";
            this.Role_LayoutGroup.Size = new System.Drawing.Size(408, 193);
            this.Role_LayoutGroup.Text = "Phân quyền";
            // 
            // UserRole_Label
            // 
            this.UserRole_Label.Control = this.UserRole_TextBox;
            this.UserRole_Label.Location = new System.Drawing.Point(0, 24);
            this.UserRole_Label.Name = "UserRole_Label";
            this.UserRole_Label.Size = new System.Drawing.Size(388, 24);
            this.UserRole_Label.Text = "Quyền";
            this.UserRole_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // CompanyID_Label
            // 
            this.CompanyID_Label.Control = this.CompanyID_ComboBox;
            this.CompanyID_Label.Location = new System.Drawing.Point(0, 48);
            this.CompanyID_Label.Name = "CompanyID_Label";
            this.CompanyID_Label.Size = new System.Drawing.Size(388, 82);
            this.CompanyID_Label.Text = "Công ty";
            this.CompanyID_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // Role_UserName_TexBox
            // 
            this.Role_UserName_TexBox.Location = new System.Drawing.Point(87, 55);
            this.Role_UserName_TexBox.Name = "Role_UserName_TexBox";
            this.Role_UserName_TexBox.Size = new System.Drawing.Size(309, 20);
            this.Role_UserName_TexBox.StyleController = this.Role_LayoutControl;
            this.Role_UserName_TexBox.TabIndex = 5;
            // 
            // Role_UserName_Label
            // 
            this.Role_UserName_Label.Control = this.Role_UserName_TexBox;
            this.Role_UserName_Label.Location = new System.Drawing.Point(0, 0);
            this.Role_UserName_Label.Name = "Role_UserName_Label";
            this.Role_UserName_Label.Size = new System.Drawing.Size(388, 24);
            this.Role_UserName_Label.Text = "Tên đăng nhập";
            this.Role_UserName_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 508);
            this.Controls.Add(this.Main_Table);
            this.Name = "UserList";
            this.Text = "Danh sách người dùng";
            ((System.ComponentModel.ISupportInitialize)(this.Role_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_GridView)).EndInit();
            this.Main_Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.User_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_LayoutControl)).EndInit();
            this.User_LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserName_TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullName_TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullName_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserName_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Password_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_LayoutControl)).EndInit();
            this.Role_LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyID_ComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyID_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_UserName_TexBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_UserName_Label)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Role_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Role_GridView;
        private System.Windows.Forms.TableLayoutPanel Main_Table;
        private DevExpress.XtraGrid.GridControl User_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView User_GridView;
        private DevExpress.XtraLayout.LayoutControl User_LayoutControl;
        private DevExpress.XtraEditors.TextEdit FullName_TextBox;
        private DevExpress.XtraLayout.LayoutControlGroup User_LayoutGroup;
        private DevExpress.XtraLayout.LayoutControlItem FullName_Label;
        private DevExpress.XtraEditors.TextEdit UserName_TextBox;
        private DevExpress.XtraLayout.LayoutControlItem UserName_Label;
        private DevExpress.XtraEditors.TextEdit Password_TextBox;
        private DevExpress.XtraLayout.LayoutControlItem Password_Label;
        private DevExpress.XtraLayout.LayoutControl Role_LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup Role_LayoutGroup;
        private DevExpress.XtraEditors.TextEdit UserRole_TextBox;
        private DevExpress.XtraLayout.LayoutControlItem UserRole_Label;
        private DevExpress.XtraEditors.LookUpEdit CompanyID_ComboBox;
        private DevExpress.XtraLayout.LayoutControlItem CompanyID_Label;
        private DevExpress.XtraEditors.TextEdit Role_UserName_TexBox;
        private DevExpress.XtraLayout.LayoutControlItem Role_UserName_Label;
    }
}
