namespace BSClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Content = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ACE_Voucher = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Company_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Custommers_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.AccountList_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ItemList_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.UserList_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.NhapSoDuaccordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.WarehouseList_accordionControlElement = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Report_Group = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.BaoCaoKeToanToanTap_MenuItem = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.BangCanDoiSoPhatSinh_Item = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Content.Appearance.Options.UseBackColor = true;
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(222, 27);
            this.Content.Margin = new System.Windows.Forms.Padding(2);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(792, 736);
            this.Content.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement4,
            this.Report_Group});
            this.accordionControl1.Location = new System.Drawing.Point(0, 27);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(2);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Auto;
            this.accordionControl1.Size = new System.Drawing.Size(222, 736);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ACE_Voucher});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Công việc mỗi ngày";
            // 
            // ACE_Voucher
            // 
            this.ACE_Voucher.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.ACE_Voucher.Name = "ACE_Voucher";
            this.ACE_Voucher.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ACE_Voucher.Text = "Nhập chứng từ";
            this.ACE_Voucher.Click += new System.EventHandler(this.ACE_Voucher_Click);
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Company_Button,
            this.Custommers_Button,
            this.AccountList_Button,
            this.ItemList_Button,
            this.UserList_Button,
            this.NhapSoDuaccordionControlElement,
            this.WarehouseList_accordionControlElement});
            this.accordionControlElement4.Expanded = true;
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Text = "Quản trị hệ thống";
            // 
            // Company_Button
            // 
            this.Company_Button.Name = "Company_Button";
            this.Company_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Company_Button.Text = "Thông tin doanh nghiệp";
            this.Company_Button.Click += new System.EventHandler(this.Company_Button_Click);
            // 
            // Custommers_Button
            // 
            this.Custommers_Button.Name = "Custommers_Button";
            this.Custommers_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Custommers_Button.Text = "Đối tượng - Khách hàng";
            this.Custommers_Button.Click += new System.EventHandler(this.Custommers_Button_Click);
            // 
            // AccountList_Button
            // 
            this.AccountList_Button.Name = "AccountList_Button";
            this.AccountList_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.AccountList_Button.Text = "Hệ thống Tài Khoản Kế Toán";
            this.AccountList_Button.Click += new System.EventHandler(this.AccountList_Button_Click);
            // 
            // ItemList_Button
            // 
            this.ItemList_Button.Name = "ItemList_Button";
            this.ItemList_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ItemList_Button.Text = "Hàng hóa";
            this.ItemList_Button.Click += new System.EventHandler(this.ItemList_Button_Click);
            // 
            // UserList_Button
            // 
            this.UserList_Button.Name = "UserList_Button";
            this.UserList_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.UserList_Button.Text = "Người dùng";
            this.UserList_Button.Click += new System.EventHandler(this.UserList_Button_Click);
            // 
            // NhapSoDuaccordionControlElement
            // 
            this.NhapSoDuaccordionControlElement.Name = "NhapSoDuaccordionControlElement";
            this.NhapSoDuaccordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.NhapSoDuaccordionControlElement.Text = "Nhập số dư";
            this.NhapSoDuaccordionControlElement.Click += new System.EventHandler(this.NhapSoDuaccordionControlElement_Click);
            // 
            // WarehouseList_accordionControlElement
            // 
            this.WarehouseList_accordionControlElement.Name = "WarehouseList_accordionControlElement";
            this.WarehouseList_accordionControlElement.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.WarehouseList_accordionControlElement.Text = "Danh mục kho";
            this.WarehouseList_accordionControlElement.Click += new System.EventHandler(this.WarehouseList_accordionControlElement_Click);
            // 
            // Report_Group
            // 
            this.Report_Group.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.BaoCaoKeToanToanTap_MenuItem,
            this.BangCanDoiSoPhatSinh_Item});
            this.Report_Group.Expanded = true;
            this.Report_Group.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl)});
            this.Report_Group.Name = "Report_Group";
            this.Report_Group.Text = "Báo cáo";
            // 
            // BaoCaoKeToanToanTap_MenuItem
            // 
            this.BaoCaoKeToanToanTap_MenuItem.Name = "BaoCaoKeToanToanTap_MenuItem";
            this.BaoCaoKeToanToanTap_MenuItem.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.BaoCaoKeToanToanTap_MenuItem.Text = "Báo cáo kế toán toàn tập";
            this.BaoCaoKeToanToanTap_MenuItem.Click += new System.EventHandler(this.BaoCaoKeToanToanTap_MenuItem_Click);
            // 
            // BangCanDoiSoPhatSinh_Item
            // 
            this.BangCanDoiSoPhatSinh_Item.Name = "BangCanDoiSoPhatSinh_Item";
            this.BangCanDoiSoPhatSinh_Item.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.BangCanDoiSoPhatSinh_Item.Text = "Bảng cân đối số phát sinh tài khoản";
            this.BangCanDoiSoPhatSinh_Item.Click += new System.EventHandler(this.BangCanDoiSoPhatSinh_Item_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1014, 27);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 763);
            this.ControlContainer = this.Content;
            this.Controls.Add(this.Content);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.DoubleBuffered = true;
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlueStarGroup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer Content;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_Voucher;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement AccountList_Button;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ItemList_Button;
        private DevExpress.XtraBars.Navigation.AccordionControlElement UserList_Button;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Custommers_Button;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Company_Button;
        private DevExpress.XtraBars.Navigation.AccordionControlElement NhapSoDuaccordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Report_Group;
        private DevExpress.XtraBars.Navigation.AccordionControlElement BangCanDoiSoPhatSinh_Item;
        private DevExpress.XtraBars.Navigation.AccordionControlElement WarehouseList_accordionControlElement;
        private DevExpress.XtraBars.Navigation.AccordionControlElement BaoCaoKeToanToanTap_MenuItem;
    }
}