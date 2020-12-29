namespace BSClient.Views
{
    partial class ItemList
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions5 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions6 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemList));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions4 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.ItemType_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.ItemType_GridControl = new DevExpress.XtraGrid.GridControl();
            this.ItemType_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemType_ButtonGroup_Panel = new DevExpress.XtraEditors.PanelControl();
            this.ItemType_Delete_Button = new DevExpress.XtraEditors.SimpleButton();
            this.ItemType_Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.ItemType_Save_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Items_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.Items_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Items_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Items_ButtonGroup_Panel = new DevExpress.XtraEditors.PanelControl();
            this.Items_Add_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Items_Delete_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Items_Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Items_Save_Button = new DevExpress.XtraEditors.SimpleButton();
            this.ItemUnit_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.ItemUnit_GridControl = new DevExpress.XtraGrid.GridControl();
            this.ItemUnit_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ItemConpany_Button_Panel = new System.Windows.Forms.Panel();
            this.ItemUnit_Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.ItemUnit_Save_Button = new DevExpress.XtraEditors.SimpleButton();
            this.ItemUnit_Delete_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Main_TablePanel = new DevExpress.Utils.Layout.TablePanel();
            ((System.ComponentModel.ISupportInitialize)(this.ItemType_GroupControl)).BeginInit();
            this.ItemType_GroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemType_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemType_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemType_ButtonGroup_Panel)).BeginInit();
            this.ItemType_ButtonGroup_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Items_GroupControl)).BeginInit();
            this.Items_GroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Items_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Items_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Items_ButtonGroup_Panel)).BeginInit();
            this.Items_ButtonGroup_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemUnit_GroupControl)).BeginInit();
            this.ItemUnit_GroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemUnit_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemUnit_GridView)).BeginInit();
            this.ItemConpany_Button_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Main_TablePanel)).BeginInit();
            this.Main_TablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemType_GroupControl
            // 
            this.Main_TablePanel.SetColumn(this.ItemType_GroupControl, 0);
            this.ItemType_GroupControl.Controls.Add(this.ItemType_GridControl);
            this.ItemType_GroupControl.Controls.Add(this.ItemType_ButtonGroup_Panel);
            buttonImageOptions5.Image = global::BSClient.Properties.Resources.excelimport;
            buttonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions6.Image")));
            this.ItemType_GroupControl.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Import", false, buttonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Nhập dữ liệu từ excel", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Export", false, buttonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Xuất dữ liệu ra excel", -1, true, null, true, false, true, null, -1)});
            this.ItemType_GroupControl.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.ItemType_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemType_GroupControl.Location = new System.Drawing.Point(3, 3);
            this.ItemType_GroupControl.Name = "ItemType_GroupControl";
            this.Main_TablePanel.SetRow(this.ItemType_GroupControl, 0);
            this.ItemType_GroupControl.Size = new System.Drawing.Size(337, 267);
            this.ItemType_GroupControl.TabIndex = 0;
            this.ItemType_GroupControl.Text = "Danh Mục Loại Sản Phẩm";
            this.ItemType_GroupControl.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.ItemType_GroupControl_CustomButtonClick);
            // 
            // ItemType_GridControl
            // 
            this.ItemType_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemType_GridControl.Location = new System.Drawing.Point(2, 45);
            this.ItemType_GridControl.MainView = this.ItemType_GridView;
            this.ItemType_GridControl.Name = "ItemType_GridControl";
            this.ItemType_GridControl.Size = new System.Drawing.Size(333, 175);
            this.ItemType_GridControl.TabIndex = 0;
            this.ItemType_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ItemType_GridView});
            // 
            // ItemType_GridView
            // 
            this.ItemType_GridView.GridControl = this.ItemType_GridControl;
            this.ItemType_GridView.Name = "ItemType_GridView";
            this.ItemType_GridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.ItemType_GridView_FocusedRowChanged);
            this.ItemType_GridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.ItemType_GridView_InvalidRowException);
            this.ItemType_GridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.ItemType_GridView_RowDeleted);
            this.ItemType_GridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.ItemType_GridView_ValidateRow);
            this.ItemType_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.ItemType_GridView_RowUpdated);
            // 
            // ItemType_ButtonGroup_Panel
            // 
            this.ItemType_ButtonGroup_Panel.Controls.Add(this.ItemType_Delete_Button);
            this.ItemType_ButtonGroup_Panel.Controls.Add(this.ItemType_Cancel_Button);
            this.ItemType_ButtonGroup_Panel.Controls.Add(this.ItemType_Save_Button);
            this.ItemType_ButtonGroup_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ItemType_ButtonGroup_Panel.Location = new System.Drawing.Point(2, 220);
            this.ItemType_ButtonGroup_Panel.Name = "ItemType_ButtonGroup_Panel";
            this.ItemType_ButtonGroup_Panel.Size = new System.Drawing.Size(333, 45);
            this.ItemType_ButtonGroup_Panel.TabIndex = 1;
            // 
            // ItemType_Delete_Button
            // 
            this.ItemType_Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemType_Delete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemType_Delete_Button.ImageOptions.Image")));
            this.ItemType_Delete_Button.Location = new System.Drawing.Point(47, 5);
            this.ItemType_Delete_Button.Name = "ItemType_Delete_Button";
            this.ItemType_Delete_Button.Size = new System.Drawing.Size(90, 35);
            this.ItemType_Delete_Button.TabIndex = 0;
            this.ItemType_Delete_Button.Text = "Xóa";
            this.ItemType_Delete_Button.Click += new System.EventHandler(this.ItemType_Delete_Button_Click);
            // 
            // ItemType_Cancel_Button
            // 
            this.ItemType_Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemType_Cancel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemType_Cancel_Button.ImageOptions.Image")));
            this.ItemType_Cancel_Button.Location = new System.Drawing.Point(238, 5);
            this.ItemType_Cancel_Button.Name = "ItemType_Cancel_Button";
            this.ItemType_Cancel_Button.Size = new System.Drawing.Size(90, 35);
            this.ItemType_Cancel_Button.TabIndex = 2;
            this.ItemType_Cancel_Button.Text = "Hủy";
            this.ItemType_Cancel_Button.Click += new System.EventHandler(this.ItemType_Cancel_Button_Click);
            // 
            // ItemType_Save_Button
            // 
            this.ItemType_Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemType_Save_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemType_Save_Button.ImageOptions.Image")));
            this.ItemType_Save_Button.Location = new System.Drawing.Point(142, 5);
            this.ItemType_Save_Button.Name = "ItemType_Save_Button";
            this.ItemType_Save_Button.Size = new System.Drawing.Size(90, 35);
            this.ItemType_Save_Button.TabIndex = 1;
            this.ItemType_Save_Button.Text = "Lưu";
            this.ItemType_Save_Button.Click += new System.EventHandler(this.ItemType_Save_Button_Click);
            // 
            // Items_GroupControl
            // 
            this.Main_TablePanel.SetColumn(this.Items_GroupControl, 1);
            this.Items_GroupControl.Controls.Add(this.Items_GridControl);
            this.Items_GroupControl.Controls.Add(this.Items_ButtonGroup_Panel);
            buttonImageOptions1.Image = global::BSClient.Properties.Resources.excelimport;
            buttonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions2.Image")));
            this.Items_GroupControl.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Import", false, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Nhập dữ liệu từ excel", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Export", false, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Xuất dữ liệu ra excel", -1, true, null, true, false, true, null, -1)});
            this.Items_GroupControl.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.Items_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Items_GroupControl.Location = new System.Drawing.Point(346, 3);
            this.Items_GroupControl.Name = "Items_GroupControl";
            this.Main_TablePanel.SetRow(this.Items_GroupControl, 0);
            this.Main_TablePanel.SetRowSpan(this.Items_GroupControl, 2);
            this.Items_GroupControl.Size = new System.Drawing.Size(670, 539);
            this.Items_GroupControl.TabIndex = 1;
            this.Items_GroupControl.Text = "Danh Mục Sản Phẩm";
            this.Items_GroupControl.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.Items_GroupControl_CustomButtonClick);
            // 
            // Items_GridControl
            // 
            this.Items_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Items_GridControl.Location = new System.Drawing.Point(2, 45);
            this.Items_GridControl.MainView = this.Items_GridView;
            this.Items_GridControl.Name = "Items_GridControl";
            this.Items_GridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.Items_GridControl.Size = new System.Drawing.Size(666, 447);
            this.Items_GridControl.TabIndex = 0;
            this.Items_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Items_GridView});
            // 
            // Items_GridView
            // 
            this.Items_GridView.GridControl = this.Items_GridControl;
            this.Items_GridView.Name = "Items_GridView";
            this.Items_GridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.Items_GridView_InvalidRowException);
            this.Items_GridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.Items_GridView_RowDeleted);
            this.Items_GridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.Items_GridView_ValidateRow);
            this.Items_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Items_GridView_RowUpdated);
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // Items_ButtonGroup_Panel
            // 
            this.Items_ButtonGroup_Panel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Items_ButtonGroup_Panel.Appearance.Options.UseBackColor = true;
            this.Items_ButtonGroup_Panel.Controls.Add(this.Items_Add_Button);
            this.Items_ButtonGroup_Panel.Controls.Add(this.Items_Delete_Button);
            this.Items_ButtonGroup_Panel.Controls.Add(this.Items_Cancel_Button);
            this.Items_ButtonGroup_Panel.Controls.Add(this.Items_Save_Button);
            this.Items_ButtonGroup_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Items_ButtonGroup_Panel.Location = new System.Drawing.Point(2, 492);
            this.Items_ButtonGroup_Panel.Name = "Items_ButtonGroup_Panel";
            this.Items_ButtonGroup_Panel.Size = new System.Drawing.Size(666, 45);
            this.Items_ButtonGroup_Panel.TabIndex = 1;
            // 
            // Items_Add_Button
            // 
            this.Items_Add_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Items_Add_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Items_Add_Button.ImageOptions.Image")));
            this.Items_Add_Button.Location = new System.Drawing.Point(283, 6);
            this.Items_Add_Button.Name = "Items_Add_Button";
            this.Items_Add_Button.Size = new System.Drawing.Size(90, 35);
            this.Items_Add_Button.TabIndex = 0;
            this.Items_Add_Button.Text = "Thêm";
            this.Items_Add_Button.Click += new System.EventHandler(this.Items_Add_Button_Click);
            // 
            // Items_Delete_Button
            // 
            this.Items_Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Items_Delete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Items_Delete_Button.ImageOptions.Image")));
            this.Items_Delete_Button.Location = new System.Drawing.Point(379, 6);
            this.Items_Delete_Button.Name = "Items_Delete_Button";
            this.Items_Delete_Button.Size = new System.Drawing.Size(90, 35);
            this.Items_Delete_Button.TabIndex = 1;
            this.Items_Delete_Button.Text = "Xóa";
            this.Items_Delete_Button.Click += new System.EventHandler(this.Items_Delete_Button_Click);
            // 
            // Items_Cancel_Button
            // 
            this.Items_Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Items_Cancel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Items_Cancel_Button.ImageOptions.Image")));
            this.Items_Cancel_Button.Location = new System.Drawing.Point(571, 6);
            this.Items_Cancel_Button.Name = "Items_Cancel_Button";
            this.Items_Cancel_Button.Size = new System.Drawing.Size(90, 35);
            this.Items_Cancel_Button.TabIndex = 3;
            this.Items_Cancel_Button.Text = "Hủy";
            this.Items_Cancel_Button.Click += new System.EventHandler(this.Items_Cancel_Button_Click);
            // 
            // Items_Save_Button
            // 
            this.Items_Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Items_Save_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Items_Save_Button.ImageOptions.Image")));
            this.Items_Save_Button.Location = new System.Drawing.Point(475, 6);
            this.Items_Save_Button.Name = "Items_Save_Button";
            this.Items_Save_Button.Size = new System.Drawing.Size(90, 35);
            this.Items_Save_Button.TabIndex = 2;
            this.Items_Save_Button.Text = "Lưu";
            this.Items_Save_Button.Click += new System.EventHandler(this.Items_Save_Button_Click);
            // 
            // ItemUnit_GroupControl
            // 
            this.Main_TablePanel.SetColumn(this.ItemUnit_GroupControl, 0);
            this.ItemUnit_GroupControl.Controls.Add(this.ItemUnit_GridControl);
            this.ItemUnit_GroupControl.Controls.Add(this.ItemConpany_Button_Panel);
            buttonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions3.Image")));
            buttonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions4.Image")));
            this.ItemUnit_GroupControl.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Import", false, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Nhập dữ liệu từ excel", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Export", false, buttonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Xuất dữ liệu ra excel", -1, true, null, true, false, true, null, -1)});
            this.ItemUnit_GroupControl.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.ItemUnit_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemUnit_GroupControl.Location = new System.Drawing.Point(3, 276);
            this.ItemUnit_GroupControl.Name = "ItemUnit_GroupControl";
            this.Main_TablePanel.SetRow(this.ItemUnit_GroupControl, 1);
            this.ItemUnit_GroupControl.Size = new System.Drawing.Size(337, 266);
            this.ItemUnit_GroupControl.TabIndex = 2;
            this.ItemUnit_GroupControl.Text = "Danh Mục Đơn Vị Tính";
            this.ItemUnit_GroupControl.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.ItemUnit_GroupControl_CustomButtonClick);
            // 
            // ItemUnit_GridControl
            // 
            this.ItemUnit_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemUnit_GridControl.Location = new System.Drawing.Point(2, 45);
            this.ItemUnit_GridControl.MainView = this.ItemUnit_GridView;
            this.ItemUnit_GridControl.Name = "ItemUnit_GridControl";
            this.ItemUnit_GridControl.Size = new System.Drawing.Size(333, 171);
            this.ItemUnit_GridControl.TabIndex = 1;
            this.ItemUnit_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ItemUnit_GridView});
            // 
            // ItemUnit_GridView
            // 
            this.ItemUnit_GridView.GridControl = this.ItemUnit_GridControl;
            this.ItemUnit_GridView.Name = "ItemUnit_GridView";
            this.ItemUnit_GridView.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.ItemUnit_GridView_ShowingEditor);
            this.ItemUnit_GridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.ItemUnit_GridView_RowDeleted);
            this.ItemUnit_GridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.ItemUnit_GridView_ValidateRow);
            this.ItemUnit_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.ItemUnit_GridView_RowUpdated);
            // 
            // ItemConpany_Button_Panel
            // 
            this.ItemConpany_Button_Panel.Controls.Add(this.ItemUnit_Cancel_Button);
            this.ItemConpany_Button_Panel.Controls.Add(this.ItemUnit_Save_Button);
            this.ItemConpany_Button_Panel.Controls.Add(this.ItemUnit_Delete_Button);
            this.ItemConpany_Button_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ItemConpany_Button_Panel.Location = new System.Drawing.Point(2, 216);
            this.ItemConpany_Button_Panel.Name = "ItemConpany_Button_Panel";
            this.ItemConpany_Button_Panel.Size = new System.Drawing.Size(333, 48);
            this.ItemConpany_Button_Panel.TabIndex = 2;
            // 
            // ItemUnit_Cancel_Button
            // 
            this.ItemUnit_Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemUnit_Cancel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemUnit_Cancel_Button.ImageOptions.Image")));
            this.ItemUnit_Cancel_Button.Location = new System.Drawing.Point(238, 6);
            this.ItemUnit_Cancel_Button.Name = "ItemUnit_Cancel_Button";
            this.ItemUnit_Cancel_Button.Size = new System.Drawing.Size(90, 35);
            this.ItemUnit_Cancel_Button.TabIndex = 3;
            this.ItemUnit_Cancel_Button.Text = "Hủy";
            this.ItemUnit_Cancel_Button.Click += new System.EventHandler(this.ItemUnit_Cancel_Button_Click);
            // 
            // ItemUnit_Save_Button
            // 
            this.ItemUnit_Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemUnit_Save_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemUnit_Save_Button.ImageOptions.Image")));
            this.ItemUnit_Save_Button.Location = new System.Drawing.Point(142, 6);
            this.ItemUnit_Save_Button.Name = "ItemUnit_Save_Button";
            this.ItemUnit_Save_Button.Size = new System.Drawing.Size(90, 35);
            this.ItemUnit_Save_Button.TabIndex = 2;
            this.ItemUnit_Save_Button.Text = "Lưu";
            this.ItemUnit_Save_Button.Click += new System.EventHandler(this.ItemUnit_Save_Button_Click);
            // 
            // ItemUnit_Delete_Button
            // 
            this.ItemUnit_Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemUnit_Delete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemUnit_Delete_Button.ImageOptions.Image")));
            this.ItemUnit_Delete_Button.Location = new System.Drawing.Point(47, 6);
            this.ItemUnit_Delete_Button.Name = "ItemUnit_Delete_Button";
            this.ItemUnit_Delete_Button.Size = new System.Drawing.Size(90, 35);
            this.ItemUnit_Delete_Button.TabIndex = 1;
            this.ItemUnit_Delete_Button.Text = "Xóa";
            this.ItemUnit_Delete_Button.Click += new System.EventHandler(this.ItemUnit_Delete_Button_Click);
            // 
            // Main_TablePanel
            // 
            this.Main_TablePanel.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 343F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.Main_TablePanel.Controls.Add(this.Items_GroupControl);
            this.Main_TablePanel.Controls.Add(this.ItemUnit_GroupControl);
            this.Main_TablePanel.Controls.Add(this.ItemType_GroupControl);
            this.Main_TablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TablePanel.Location = new System.Drawing.Point(0, 0);
            this.Main_TablePanel.Name = "Main_TablePanel";
            this.Main_TablePanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.Main_TablePanel.Size = new System.Drawing.Size(1019, 545);
            this.Main_TablePanel.TabIndex = 0;
            // 
            // ItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main_TablePanel);
            this.Name = "ItemList";
            this.Size = new System.Drawing.Size(1019, 545);
            ((System.ComponentModel.ISupportInitialize)(this.ItemType_GroupControl)).EndInit();
            this.ItemType_GroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemType_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemType_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemType_ButtonGroup_Panel)).EndInit();
            this.ItemType_ButtonGroup_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Items_GroupControl)).EndInit();
            this.Items_GroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Items_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Items_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Items_ButtonGroup_Panel)).EndInit();
            this.Items_ButtonGroup_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemUnit_GroupControl)).EndInit();
            this.ItemUnit_GroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemUnit_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemUnit_GridView)).EndInit();
            this.ItemConpany_Button_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Main_TablePanel)).EndInit();
            this.Main_TablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl ItemType_GroupControl;
        private DevExpress.XtraEditors.PanelControl ItemType_ButtonGroup_Panel;
        private DevExpress.XtraGrid.GridControl ItemType_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView ItemType_GridView;
        private DevExpress.XtraEditors.GroupControl Items_GroupControl;
        private DevExpress.XtraEditors.PanelControl Items_ButtonGroup_Panel;
        private DevExpress.XtraGrid.GridControl Items_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Items_GridView;
        private DevExpress.XtraEditors.GroupControl ItemUnit_GroupControl;
        private DevExpress.XtraGrid.GridControl ItemUnit_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView ItemUnit_GridView;
        private DevExpress.Utils.Layout.TablePanel Main_TablePanel;
        private DevExpress.XtraEditors.SimpleButton Items_Delete_Button;
        private DevExpress.XtraEditors.SimpleButton Items_Cancel_Button;
        private DevExpress.XtraEditors.SimpleButton Items_Save_Button;
        private DevExpress.XtraEditors.SimpleButton ItemType_Delete_Button;
        private DevExpress.XtraEditors.SimpleButton ItemType_Cancel_Button;
        private DevExpress.XtraEditors.SimpleButton ItemType_Save_Button;
        private DevExpress.XtraEditors.SimpleButton Items_Add_Button;
        private System.Windows.Forms.Panel ItemConpany_Button_Panel;
        private DevExpress.XtraEditors.SimpleButton ItemUnit_Cancel_Button;
        private DevExpress.XtraEditors.SimpleButton ItemUnit_Save_Button;
        private DevExpress.XtraEditors.SimpleButton ItemUnit_Delete_Button;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    }
}
