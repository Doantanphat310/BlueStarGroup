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
            this.UserRole_GridControl = new DevExpress.XtraGrid.GridControl();
            this.UserRole_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Main_Table = new System.Windows.Forms.TableLayoutPanel();
            this.User_Group = new DevExpress.XtraEditors.GroupControl();
            this.Users_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Users_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UserButton_Panel = new System.Windows.Forms.Panel();
            this.UserDelete_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserCancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserSave_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserRole_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.UserRole_Panel = new System.Windows.Forms.Panel();
            this.UserRole_LayoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.UserRole_ComboBox = new DevExpress.XtraEditors.LookUpEdit();
            this.UserID_TextBox = new DevExpress.XtraEditors.TextEdit();
            this.CompanyID_LookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.UserRole_LayoutGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Role_UserName_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.UserRole_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.CompanyID_Label = new DevExpress.XtraLayout.LayoutControlItem();
            this.UserRole_Button_Panel = new System.Windows.Forms.Panel();
            this.UserRoleCancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserRoleSave_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserRoleAddNew_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserRoleDelete_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_GridView)).BeginInit();
            this.Main_Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.User_Group)).BeginInit();
            this.User_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Users_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Users_GridView)).BeginInit();
            this.UserButton_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_GroupControl)).BeginInit();
            this.UserRole_GroupControl.SuspendLayout();
            this.UserRole_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_LayoutControl)).BeginInit();
            this.UserRole_LayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_ComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserID_TextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyID_LookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_LayoutGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_UserName_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyID_Label)).BeginInit();
            this.UserRole_Button_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserRole_GridControl
            // 
            this.UserRole_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRole_GridControl.Location = new System.Drawing.Point(389, 39);
            this.UserRole_GridControl.MainView = this.UserRole_GridView;
            this.UserRole_GridControl.Name = "UserRole_GridControl";
            this.UserRole_GridControl.Size = new System.Drawing.Size(502, 151);
            this.UserRole_GridControl.TabIndex = 1;
            this.UserRole_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.UserRole_GridView});
            // 
            // UserRole_GridView
            // 
            this.UserRole_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.UserRole_GridView.GridControl = this.UserRole_GridControl;
            this.UserRole_GridView.Name = "UserRole_GridView";
            this.UserRole_GridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.UserRole_GridView_RowDeleted);
            this.UserRole_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.UserRole_GridView_RowUpdated);
            // 
            // Main_Table
            // 
            this.Main_Table.ColumnCount = 1;
            this.Main_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_Table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Main_Table.Controls.Add(this.User_Group, 0, 0);
            this.Main_Table.Controls.Add(this.UserRole_GroupControl, 0, 1);
            this.Main_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Table.Location = new System.Drawing.Point(0, 0);
            this.Main_Table.Name = "Main_Table";
            this.Main_Table.RowCount = 2;
            this.Main_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_Table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.Main_Table.Size = new System.Drawing.Size(899, 523);
            this.Main_Table.TabIndex = 2;
            // 
            // User_Group
            // 
            this.User_Group.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("User_Group.CaptionImageOptions.Image")));
            this.User_Group.Controls.Add(this.Users_GridControl);
            this.User_Group.Controls.Add(this.UserButton_Panel);
            this.User_Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.User_Group.Location = new System.Drawing.Point(3, 3);
            this.User_Group.Name = "User_Group";
            this.User_Group.Size = new System.Drawing.Size(893, 319);
            this.User_Group.TabIndex = 6;
            this.User_Group.Text = "Danh mục người dùng";
            // 
            // Users_GridControl
            // 
            this.Users_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Users_GridControl.Location = new System.Drawing.Point(2, 39);
            this.Users_GridControl.MainView = this.Users_GridView;
            this.Users_GridControl.Name = "Users_GridControl";
            this.Users_GridControl.Size = new System.Drawing.Size(889, 232);
            this.Users_GridControl.TabIndex = 2;
            this.Users_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Users_GridView});
            // 
            // Users_GridView
            // 
            this.Users_GridView.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.Users_GridView.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Users_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.Users_GridView.GridControl = this.Users_GridControl;
            this.Users_GridView.Name = "Users_GridView";
            this.Users_GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.Users_GridView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.Users_GridView_ShowingEditor);
            this.Users_GridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.Users_GridView_FocusedRowChanged);
            this.Users_GridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.Users_GridView_InvalidRowException);
            this.Users_GridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.Users_GridView_RowDeleted);
            this.Users_GridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.Users_GridView_ValidateRow);
            this.Users_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Users_GridView_RowUpdated);
            // 
            // UserButton_Panel
            // 
            this.UserButton_Panel.Controls.Add(this.UserDelete_Button);
            this.UserButton_Panel.Controls.Add(this.UserCancel_Button);
            this.UserButton_Panel.Controls.Add(this.UserSave_Button);
            this.UserButton_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserButton_Panel.Location = new System.Drawing.Point(2, 271);
            this.UserButton_Panel.Name = "UserButton_Panel";
            this.UserButton_Panel.Size = new System.Drawing.Size(889, 46);
            this.UserButton_Panel.TabIndex = 5;
            // 
            // UserDelete_Button
            // 
            this.UserDelete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserDelete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserDelete_Button.ImageOptions.Image")));
            this.UserDelete_Button.Location = new System.Drawing.Point(604, 6);
            this.UserDelete_Button.Name = "UserDelete_Button";
            this.UserDelete_Button.Size = new System.Drawing.Size(90, 35);
            this.UserDelete_Button.TabIndex = 6;
            this.UserDelete_Button.Text = "Xóa";
            this.UserDelete_Button.Click += new System.EventHandler(this.UserDelete_Button_Click);
            // 
            // UserCancel_Button
            // 
            this.UserCancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserCancel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserCancel_Button.ImageOptions.Image")));
            this.UserCancel_Button.Location = new System.Drawing.Point(796, 6);
            this.UserCancel_Button.Name = "UserCancel_Button";
            this.UserCancel_Button.Size = new System.Drawing.Size(90, 35);
            this.UserCancel_Button.TabIndex = 7;
            this.UserCancel_Button.Text = "Hủy";
            this.UserCancel_Button.Click += new System.EventHandler(this.UserCancel_Button_Click);
            // 
            // UserSave_Button
            // 
            this.UserSave_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserSave_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserSave_Button.ImageOptions.Image")));
            this.UserSave_Button.Location = new System.Drawing.Point(700, 6);
            this.UserSave_Button.Name = "UserSave_Button";
            this.UserSave_Button.Size = new System.Drawing.Size(90, 35);
            this.UserSave_Button.TabIndex = 7;
            this.UserSave_Button.Text = "Lưu";
            this.UserSave_Button.Click += new System.EventHandler(this.UserSave_Button_Click);
            // 
            // UserRole_GroupControl
            // 
            this.UserRole_GroupControl.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserRole_GroupControl.CaptionImageOptions.Image")));
            this.UserRole_GroupControl.Controls.Add(this.UserRole_GridControl);
            this.UserRole_GroupControl.Controls.Add(this.UserRole_Panel);
            this.UserRole_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRole_GroupControl.Location = new System.Drawing.Point(3, 328);
            this.UserRole_GroupControl.Name = "UserRole_GroupControl";
            this.UserRole_GroupControl.Size = new System.Drawing.Size(893, 192);
            this.UserRole_GroupControl.TabIndex = 7;
            this.UserRole_GroupControl.Text = "Phân quyền Người dùng theo Công ty";
            // 
            // UserRole_Panel
            // 
            this.UserRole_Panel.Controls.Add(this.UserRole_LayoutControl);
            this.UserRole_Panel.Controls.Add(this.UserRole_Button_Panel);
            this.UserRole_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserRole_Panel.Location = new System.Drawing.Point(2, 39);
            this.UserRole_Panel.Name = "UserRole_Panel";
            this.UserRole_Panel.Size = new System.Drawing.Size(387, 151);
            this.UserRole_Panel.TabIndex = 5;
            // 
            // UserRole_LayoutControl
            // 
            this.UserRole_LayoutControl.Controls.Add(this.UserRole_ComboBox);
            this.UserRole_LayoutControl.Controls.Add(this.UserID_TextBox);
            this.UserRole_LayoutControl.Controls.Add(this.CompanyID_LookUpEdit);
            this.UserRole_LayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRole_LayoutControl.Location = new System.Drawing.Point(0, 0);
            this.UserRole_LayoutControl.Name = "UserRole_LayoutControl";
            this.UserRole_LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(653, 0, 650, 400);
            this.UserRole_LayoutControl.Root = this.UserRole_LayoutGroup;
            this.UserRole_LayoutControl.Size = new System.Drawing.Size(387, 105);
            this.UserRole_LayoutControl.TabIndex = 3;
            this.UserRole_LayoutControl.Text = "Role";
            // 
            // UserRole_ComboBox
            // 
            this.UserRole_ComboBox.Location = new System.Drawing.Point(87, 60);
            this.UserRole_ComboBox.Name = "UserRole_ComboBox";
            this.UserRole_ComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.UserRole_ComboBox.Size = new System.Drawing.Size(288, 20);
            this.UserRole_ComboBox.StyleController = this.UserRole_LayoutControl;
            this.UserRole_ComboBox.TabIndex = 6;
            // 
            // UserID_TextBox
            // 
            this.UserID_TextBox.Location = new System.Drawing.Point(87, 36);
            this.UserID_TextBox.Name = "UserID_TextBox";
            this.UserID_TextBox.Properties.ReadOnly = true;
            this.UserID_TextBox.Size = new System.Drawing.Size(288, 20);
            this.UserID_TextBox.StyleController = this.UserRole_LayoutControl;
            this.UserID_TextBox.TabIndex = 5;
            // 
            // CompanyID_LookUpEdit
            // 
            this.CompanyID_LookUpEdit.Location = new System.Drawing.Point(87, 12);
            this.CompanyID_LookUpEdit.Name = "CompanyID_LookUpEdit";
            this.CompanyID_LookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CompanyID_LookUpEdit.Size = new System.Drawing.Size(288, 20);
            this.CompanyID_LookUpEdit.StyleController = this.UserRole_LayoutControl;
            this.CompanyID_LookUpEdit.TabIndex = 5;
            this.CompanyID_LookUpEdit.EditValueChanged += new System.EventHandler(this.CompanyID_LookUpEdit_EditValueChanged);
            // 
            // UserRole_LayoutGroup
            // 
            this.UserRole_LayoutGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Role_UserName_Label,
            this.UserRole_Label,
            this.CompanyID_Label});
            this.UserRole_LayoutGroup.Name = "Root";
            this.UserRole_LayoutGroup.Size = new System.Drawing.Size(387, 105);
            this.UserRole_LayoutGroup.TextVisible = false;
            // 
            // Role_UserName_Label
            // 
            this.Role_UserName_Label.Control = this.UserID_TextBox;
            this.Role_UserName_Label.Location = new System.Drawing.Point(0, 24);
            this.Role_UserName_Label.Name = "Role_UserName_Label";
            this.Role_UserName_Label.Size = new System.Drawing.Size(367, 24);
            this.Role_UserName_Label.Text = "Tên đăng nhập";
            this.Role_UserName_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // UserRole_Label
            // 
            this.UserRole_Label.Control = this.UserRole_ComboBox;
            this.UserRole_Label.Location = new System.Drawing.Point(0, 48);
            this.UserRole_Label.Name = "UserRole_Label";
            this.UserRole_Label.Size = new System.Drawing.Size(367, 37);
            this.UserRole_Label.Text = "Phân quyền";
            this.UserRole_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // CompanyID_Label
            // 
            this.CompanyID_Label.Control = this.CompanyID_LookUpEdit;
            this.CompanyID_Label.Location = new System.Drawing.Point(0, 0);
            this.CompanyID_Label.Name = "CompanyID_Label";
            this.CompanyID_Label.Size = new System.Drawing.Size(367, 24);
            this.CompanyID_Label.Text = "Công ty";
            this.CompanyID_Label.TextSize = new System.Drawing.Size(72, 13);
            // 
            // UserRole_Button_Panel
            // 
            this.UserRole_Button_Panel.Controls.Add(this.UserRoleCancel_Button);
            this.UserRole_Button_Panel.Controls.Add(this.UserRoleSave_Button);
            this.UserRole_Button_Panel.Controls.Add(this.UserRoleAddNew_Button);
            this.UserRole_Button_Panel.Controls.Add(this.UserRoleDelete_Button);
            this.UserRole_Button_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserRole_Button_Panel.Location = new System.Drawing.Point(0, 105);
            this.UserRole_Button_Panel.Name = "UserRole_Button_Panel";
            this.UserRole_Button_Panel.Size = new System.Drawing.Size(387, 46);
            this.UserRole_Button_Panel.TabIndex = 4;
            // 
            // UserRoleCancel_Button
            // 
            this.UserRoleCancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserRoleCancel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserRoleCancel_Button.ImageOptions.Image")));
            this.UserRoleCancel_Button.Location = new System.Drawing.Point(292, 6);
            this.UserRoleCancel_Button.Name = "UserRoleCancel_Button";
            this.UserRoleCancel_Button.Size = new System.Drawing.Size(90, 35);
            this.UserRoleCancel_Button.TabIndex = 4;
            this.UserRoleCancel_Button.Text = "Hủy";
            this.UserRoleCancel_Button.Click += new System.EventHandler(this.UserRoleCancel_Button_Click);
            // 
            // UserRoleSave_Button
            // 
            this.UserRoleSave_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserRoleSave_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserRoleSave_Button.ImageOptions.Image")));
            this.UserRoleSave_Button.Location = new System.Drawing.Point(196, 6);
            this.UserRoleSave_Button.Name = "UserRoleSave_Button";
            this.UserRoleSave_Button.Size = new System.Drawing.Size(90, 35);
            this.UserRoleSave_Button.TabIndex = 4;
            this.UserRoleSave_Button.Text = "Lưu";
            this.UserRoleSave_Button.Click += new System.EventHandler(this.UserRoleSave_Button_Click);
            // 
            // UserRoleAddNew_Button
            // 
            this.UserRoleAddNew_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserRoleAddNew_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserRoleAddNew_Button.ImageOptions.Image")));
            this.UserRoleAddNew_Button.Location = new System.Drawing.Point(4, 6);
            this.UserRoleAddNew_Button.Name = "UserRoleAddNew_Button";
            this.UserRoleAddNew_Button.Size = new System.Drawing.Size(90, 35);
            this.UserRoleAddNew_Button.TabIndex = 1;
            this.UserRoleAddNew_Button.Text = "Thêm";
            this.UserRoleAddNew_Button.Click += new System.EventHandler(this.UserRoleAddNew_Button_Click);
            // 
            // UserRoleDelete_Button
            // 
            this.UserRoleDelete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UserRoleDelete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserRoleDelete_Button.ImageOptions.Image")));
            this.UserRoleDelete_Button.Location = new System.Drawing.Point(100, 6);
            this.UserRoleDelete_Button.Name = "UserRoleDelete_Button";
            this.UserRoleDelete_Button.Size = new System.Drawing.Size(90, 35);
            this.UserRoleDelete_Button.TabIndex = 2;
            this.UserRoleDelete_Button.Text = "Xóa";
            this.UserRoleDelete_Button.Click += new System.EventHandler(this.UserRoleDelete_Button_Click);
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main_Table);
            this.Name = "UserList";
            this.Size = new System.Drawing.Size(899, 523);
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_GridView)).EndInit();
            this.Main_Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.User_Group)).EndInit();
            this.User_Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Users_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Users_GridView)).EndInit();
            this.UserButton_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_GroupControl)).EndInit();
            this.UserRole_GroupControl.ResumeLayout(false);
            this.UserRole_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_LayoutControl)).EndInit();
            this.UserRole_LayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_ComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserID_TextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyID_LookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_LayoutGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Role_UserName_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRole_Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyID_Label)).EndInit();
            this.UserRole_Button_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl UserRole_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView UserRole_GridView;
        private System.Windows.Forms.TableLayoutPanel Main_Table;
        private DevExpress.XtraGrid.GridControl Users_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Users_GridView;
        private DevExpress.XtraLayout.LayoutControl UserRole_LayoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup UserRole_LayoutGroup;
        private DevExpress.XtraEditors.LookUpEdit CompanyID_LookUpEdit;
        private DevExpress.XtraLayout.LayoutControlItem CompanyID_Label;
        private DevExpress.XtraEditors.TextEdit UserID_TextBox;
        private DevExpress.XtraLayout.LayoutControlItem Role_UserName_Label;
        private System.Windows.Forms.Panel UserRole_Button_Panel;
        private DevExpress.XtraEditors.SimpleButton UserRoleAddNew_Button;
        private DevExpress.XtraEditors.SimpleButton UserRoleDelete_Button;
        private System.Windows.Forms.Panel UserButton_Panel;
        private DevExpress.XtraEditors.SimpleButton UserDelete_Button;
        private DevExpress.XtraEditors.SimpleButton UserSave_Button;
        private DevExpress.XtraEditors.LookUpEdit UserRole_ComboBox;
        private DevExpress.XtraLayout.LayoutControlItem UserRole_Label;
        private DevExpress.XtraEditors.SimpleButton UserCancel_Button;
        private DevExpress.XtraEditors.GroupControl User_Group;
        private DevExpress.XtraEditors.SimpleButton UserRoleCancel_Button;
        private DevExpress.XtraEditors.SimpleButton UserRoleSave_Button;
        private DevExpress.XtraEditors.GroupControl UserRole_GroupControl;
        private System.Windows.Forms.Panel UserRole_Panel;
    }
}
