namespace BSClient.Views
{
    partial class CustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerList));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.Customer_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Customer_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Customer_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.SelectCustomer_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Delete_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Save_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GroupControl)).BeginInit();
            this.Customer_GroupControl.SuspendLayout();
            this.Button_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Customer_GridControl
            // 
            this.Customer_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Customer_GridControl.Location = new System.Drawing.Point(2, 45);
            this.Customer_GridControl.MainView = this.Customer_GridView;
            this.Customer_GridControl.Name = "Customer_GridControl";
            this.Customer_GridControl.Size = new System.Drawing.Size(928, 424);
            this.Customer_GridControl.TabIndex = 0;
            this.Customer_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Customer_GridView});
            // 
            // Customer_GridView
            // 
            this.Customer_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.Customer_GridView.GridControl = this.Customer_GridControl;
            this.Customer_GridView.Name = "Customer_GridView";
            this.Customer_GridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.Customer_GridView_InvalidRowException);
            this.Customer_GridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.Customer_GridView_RowDeleted);
            this.Customer_GridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.Customer_GridView_ValidateRow);
            this.Customer_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Customer_GridView_RowUpdated);
            // 
            // Customer_GroupControl
            // 
            this.Customer_GroupControl.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Customer_GroupControl.CaptionImageOptions.Image")));
            this.Customer_GroupControl.Controls.Add(this.Customer_GridControl);
            this.Customer_GroupControl.Controls.Add(this.Button_Panel);
            buttonImageOptions1.Image = global::BSClient.Properties.Resources.excelimport;
            buttonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions2.Image")));
            this.Customer_GroupControl.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Import", false, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Nhập dữ liệu từ excel", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Export", false, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "Xuất dữ liệu ra excel", -1, true, null, true, false, true, null, -1)});
            this.Customer_GroupControl.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.Customer_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Customer_GroupControl.Location = new System.Drawing.Point(0, 0);
            this.Customer_GroupControl.Name = "Customer_GroupControl";
            this.Customer_GroupControl.Size = new System.Drawing.Size(932, 516);
            this.Customer_GroupControl.TabIndex = 0;
            this.Customer_GroupControl.Text = "Danh mục Khách hàng";
            this.Customer_GroupControl.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.Customer_GroupControl_CustomButtonClick);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.SelectCustomer_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Controls.Add(this.Save_Button);
            this.Button_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Button_Panel.Location = new System.Drawing.Point(2, 469);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(928, 45);
            this.Button_Panel.TabIndex = 1;
            // 
            // SelectCustomer_Button
            // 
            this.SelectCustomer_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectCustomer_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SelectCustomer_Button.ImageOptions.Image")));
            this.SelectCustomer_Button.Location = new System.Drawing.Point(3, 6);
            this.SelectCustomer_Button.Name = "SelectCustomer_Button";
            this.SelectCustomer_Button.Size = new System.Drawing.Size(142, 35);
            this.SelectCustomer_Button.TabIndex = 3;
            this.SelectCustomer_Button.Text = "Nhập từ Cty khác";
            this.SelectCustomer_Button.ToolTip = "Nhập khách hàng từ công ty khác";
            this.SelectCustomer_Button.Visible = false;
            this.SelectCustomer_Button.Click += new System.EventHandler(this.SelectCustomer_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Button.ImageOptions.Image")));
            this.Delete_Button.Location = new System.Drawing.Point(641, 6);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(90, 35);
            this.Delete_Button.TabIndex = 0;
            this.Delete_Button.Text = "Xóa";
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.ImageOptions.Image")));
            this.Cancel_Button.Location = new System.Drawing.Point(833, 6);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(90, 35);
            this.Cancel_Button.TabIndex = 2;
            this.Cancel_Button.Text = "Hủy";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Save_Button.ImageOptions.Image")));
            this.Save_Button.Location = new System.Drawing.Point(737, 6);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(90, 35);
            this.Save_Button.TabIndex = 1;
            this.Save_Button.Text = "Lưu";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // CustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Customer_GroupControl);
            this.Name = "CustomerList";
            this.Size = new System.Drawing.Size(932, 516);
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GroupControl)).EndInit();
            this.Customer_GroupControl.ResumeLayout(false);
            this.Button_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Customer_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Customer_GridView;
        private DevExpress.XtraEditors.GroupControl Customer_GroupControl;
        private System.Windows.Forms.Panel Button_Panel;
        private DevExpress.XtraEditors.SimpleButton Delete_Button;
        private DevExpress.XtraEditors.SimpleButton Cancel_Button;
        private DevExpress.XtraEditors.SimpleButton Save_Button;
        private DevExpress.XtraEditors.SimpleButton SelectCustomer_Button;
    }
}
