namespace BSClient
{
    partial class VoucherControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoucherControl));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.ACE_Them = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControl2 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.ACE_delete = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ACE_CapNhat = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.gridControlVoucher = new DevExpress.XtraGrid.GridControl();
            this.gridViewVoucher = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSummaryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRowID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).BeginInit();
            this.stackPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACE_CapNhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVoucher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.stackPanel1);
            this.panelControl1.Controls.Add(this.gridControlVoucher);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(940, 507);
            this.panelControl1.TabIndex = 0;
            // 
            // stackPanel1
            // 
            this.stackPanel1.Controls.Add(this.accordionControl1);
            this.stackPanel1.Controls.Add(this.accordionControl2);
            this.stackPanel1.Controls.Add(this.ACE_CapNhat);
            this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.stackPanel1.Location = new System.Drawing.Point(2, 2);
            this.stackPanel1.Name = "stackPanel1";
            this.stackPanel1.Size = new System.Drawing.Size(936, 46);
            this.stackPanel1.TabIndex = 5;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ACE_Them});
            this.accordionControl1.Location = new System.Drawing.Point(3, 2);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl1.Size = new System.Drawing.Size(98, 42);
            this.accordionControl1.TabIndex = 3;
            this.accordionControl1.Text = "accordionControl1";
            // 
            // ACE_Them
            // 
            this.ACE_Them.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.ACE_Them.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ACE_Them.ImageOptions.Image")));
            this.ACE_Them.Name = "ACE_Them";
            this.ACE_Them.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ACE_Them.Text = "Thêm";
            this.ACE_Them.Click += new System.EventHandler(this.ACE_Them_Click);
            // 
            // accordionControl2
            // 
            this.accordionControl2.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ACE_delete});
            this.accordionControl2.Location = new System.Drawing.Point(107, 2);
            this.accordionControl2.Name = "accordionControl2";
            this.accordionControl2.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionControl2.Size = new System.Drawing.Size(98, 42);
            this.accordionControl2.TabIndex = 4;
            this.accordionControl2.Text = "accordionControl2";
            // 
            // ACE_delete
            // 
            this.ACE_delete.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.ACE_delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ACE_delete.ImageOptions.Image")));
            this.ACE_delete.Name = "ACE_delete";
            this.ACE_delete.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ACE_delete.Text = "Xóa";
            this.ACE_delete.Click += new System.EventHandler(this.ACE_delete_Click);
            // 
            // ACE_CapNhat
            // 
            this.ACE_CapNhat.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1});
            this.ACE_CapNhat.Location = new System.Drawing.Point(211, 2);
            this.ACE_CapNhat.Name = "ACE_CapNhat";
            this.ACE_CapNhat.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.ACE_CapNhat.Size = new System.Drawing.Size(117, 42);
            this.ACE_CapNhat.TabIndex = 6;
            this.ACE_CapNhat.Text = "ACE_CapNhat";
            this.ACE_CapNhat.Click += new System.EventHandler(this.ACE_CapNhat_Click);
            this.ACE_CapNhat.Leave += new System.EventHandler(this.ACE_CapNhat_Leave);
            this.ACE_CapNhat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ACE_CapNhat_MouseClick);
            this.ACE_CapNhat.MouseHover += new System.EventHandler(this.ACE_CapNhat_MouseHover);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accordionControlElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("accordionControlElement1.ImageOptions.Image")));
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Text = "Lưu";
            this.accordionControlElement1.Click += new System.EventHandler(this.accordionControlElement1_Click);
            // 
            // gridControlVoucher
            // 
            //this.gridControlVoucher.DataSource = typeof(DXBlueStarGroup_V3.VouchersType);
            this.gridControlVoucher.Location = new System.Drawing.Point(5, 52);
            this.gridControlVoucher.MainView = this.gridViewVoucher;
            this.gridControlVoucher.Name = "gridControlVoucher";
            this.gridControlVoucher.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemComboBox1});
            this.gridControlVoucher.Size = new System.Drawing.Size(400, 200);
            this.gridControlVoucher.TabIndex = 0;
            this.gridControlVoucher.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewVoucher});
            // 
            // gridViewVoucher
            // 
            this.gridViewVoucher.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewVoucher.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewVoucher.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Blue;
            this.gridViewVoucher.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewVoucher.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.gridViewVoucher.Appearance.TopNewRow.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.gridViewVoucher.Appearance.TopNewRow.BackColor2 = System.Drawing.SystemColors.ButtonFace;
            this.gridViewVoucher.Appearance.TopNewRow.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.gridViewVoucher.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridViewVoucher.Appearance.TopNewRow.Options.UseForeColor = true;
            this.gridViewVoucher.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colSummaryName,
            this.colRowID});
            this.gridViewVoucher.GridControl = this.gridControlVoucher;
            this.gridViewVoucher.Name = "gridViewVoucher";
            this.gridViewVoucher.NewItemRowText = "Click here to add a new item";
            this.gridViewVoucher.OptionsMenu.ShowFooterItem = true;
            this.gridViewVoucher.OptionsPrint.EnableAppearanceOddRow = true;
            this.gridViewVoucher.OptionsSelection.MultiSelect = true;
            this.gridViewVoucher.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewVoucher.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridViewVoucher.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewVoucher.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewVoucher.OptionsView.RowAutoHeight = true;
            this.gridViewVoucher.OptionsView.ShowAutoFilterRow = true;
            this.gridViewVoucher.OptionsView.ShowFooter = true;
            this.gridViewVoucher.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewVoucher_InitNewRow);
            this.gridViewVoucher.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewVoucher_RowUpdated);
            this.gridViewVoucher.RowCountChanged += new System.EventHandler(this.gridViewVoucher_RowCountChanged);
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colSummaryName
            // 
            this.colSummaryName.FieldName = "SummaryName";
            this.colSummaryName.Name = "colSummaryName";
            this.colSummaryName.Visible = true;
            this.colSummaryName.VisibleIndex = 2;
            // 
            // colRowID
            // 
            this.colRowID.FieldName = "RowID";
            this.colRowID.Name = "colRowID";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // VoucherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "VoucherControl";
            this.Size = new System.Drawing.Size(940, 507);
            this.Load += new System.EventHandler(this.VoucherControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stackPanel1)).EndInit();
            this.stackPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ACE_CapNhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewVoucher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlVoucher;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewVoucher;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSummaryName;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_Them;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_delete;
        private DevExpress.XtraBars.Navigation.AccordionControl ACE_CapNhat;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraGrid.Columns.GridColumn colRowID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}
