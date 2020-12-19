namespace BSClient.Views
{
    partial class BangCanDoiSoPhatSinhTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BangCanDoiSoPhatSinhTaiKhoan));
            this.Main_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Main_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Print_Button = new DevExpress.XtraEditors.SimpleButton();
            this.From_DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.To_DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TypeSearch_LookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.SearchData_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserButton_Panel = new System.Windows.Forms.Panel();
            this.KetChuyen_Button = new DevExpress.XtraEditors.SimpleButton();
            this.ExportExcel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.SoCai_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Exit_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeSearch_LookUpEdit.Properties)).BeginInit();
            this.UserButton_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_GridControl
            // 
            this.Main_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_GridControl.Location = new System.Drawing.Point(0, 34);
            this.Main_GridControl.MainView = this.Main_GridView;
            this.Main_GridControl.Name = "Main_GridControl";
            this.Main_GridControl.Size = new System.Drawing.Size(1090, 534);
            this.Main_GridControl.TabIndex = 0;
            this.Main_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Main_GridView});
            // 
            // Main_GridView
            // 
            this.Main_GridView.GridControl = this.Main_GridControl;
            this.Main_GridView.Name = "Main_GridView";
            this.Main_GridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.Main_GridView_RowClick);
            // 
            // Print_Button
            // 
            this.Print_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Print_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Print_Button.ImageOptions.Image")));
            this.Print_Button.Location = new System.Drawing.Point(718, 4);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(90, 25);
            this.Print_Button.TabIndex = 0;
            this.Print_Button.Text = "Xuất báo cáo";
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // From_DateEdit
            // 
            this.From_DateEdit.EditValue = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.From_DateEdit.Location = new System.Drawing.Point(10, 6);
            this.From_DateEdit.Name = "From_DateEdit";
            this.From_DateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.From_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.From_DateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.From_DateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.From_DateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.From_DateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.From_DateEdit.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.From_DateEdit.Size = new System.Drawing.Size(86, 20);
            this.From_DateEdit.TabIndex = 3;
            // 
            // To_DateEdit
            // 
            this.To_DateEdit.EditValue = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.To_DateEdit.Location = new System.Drawing.Point(116, 6);
            this.To_DateEdit.Name = "To_DateEdit";
            this.To_DateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.To_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.To_DateEdit.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.To_DateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.To_DateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.To_DateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.To_DateEdit.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.To_DateEdit.Size = new System.Drawing.Size(86, 20);
            this.To_DateEdit.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(102, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(8, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "~";
            // 
            // TypeSearch_LookUpEdit
            // 
            this.TypeSearch_LookUpEdit.Location = new System.Drawing.Point(208, 6);
            this.TypeSearch_LookUpEdit.Name = "TypeSearch_LookUpEdit";
            this.TypeSearch_LookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TypeSearch_LookUpEdit.Properties.NullText = "";
            this.TypeSearch_LookUpEdit.Size = new System.Drawing.Size(149, 20);
            this.TypeSearch_LookUpEdit.TabIndex = 6;
            // 
            // SearchData_Button
            // 
            this.SearchData_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SearchData_Button.ImageOptions.Image")));
            this.SearchData_Button.Location = new System.Drawing.Point(363, 4);
            this.SearchData_Button.Name = "SearchData_Button";
            this.SearchData_Button.Size = new System.Drawing.Size(87, 25);
            this.SearchData_Button.TabIndex = 7;
            this.SearchData_Button.Text = "Lấy số liệu";
            this.SearchData_Button.Click += new System.EventHandler(this.SearchData_Button_Click);
            // 
            // UserButton_Panel
            // 
            this.UserButton_Panel.Controls.Add(this.KetChuyen_Button);
            this.UserButton_Panel.Controls.Add(this.ExportExcel_Button);
            this.UserButton_Panel.Controls.Add(this.SoCai_Button);
            this.UserButton_Panel.Controls.Add(this.Exit_Button);
            this.UserButton_Panel.Controls.Add(this.SearchData_Button);
            this.UserButton_Panel.Controls.Add(this.TypeSearch_LookUpEdit);
            this.UserButton_Panel.Controls.Add(this.labelControl2);
            this.UserButton_Panel.Controls.Add(this.To_DateEdit);
            this.UserButton_Panel.Controls.Add(this.From_DateEdit);
            this.UserButton_Panel.Controls.Add(this.Print_Button);
            this.UserButton_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserButton_Panel.Location = new System.Drawing.Point(0, 0);
            this.UserButton_Panel.Name = "UserButton_Panel";
            this.UserButton_Panel.Size = new System.Drawing.Size(1090, 34);
            this.UserButton_Panel.TabIndex = 1;
            // 
            // KetChuyen_Button
            // 
            this.KetChuyen_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KetChuyen_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("KetChuyen_Button.ImageOptions.Image")));
            this.KetChuyen_Button.Location = new System.Drawing.Point(943, 4);
            this.KetChuyen_Button.Name = "KetChuyen_Button";
            this.KetChuyen_Button.Size = new System.Drawing.Size(78, 25);
            this.KetChuyen_Button.TabIndex = 10;
            this.KetChuyen_Button.Text = "KC Nhanh";
            // 
            // ExportExcel_Button
            // 
            this.ExportExcel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportExcel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ExportExcel_Button.ImageOptions.Image")));
            this.ExportExcel_Button.Location = new System.Drawing.Point(876, 3);
            this.ExportExcel_Button.Name = "ExportExcel_Button";
            this.ExportExcel_Button.Size = new System.Drawing.Size(61, 25);
            this.ExportExcel_Button.TabIndex = 9;
            this.ExportExcel_Button.Text = "Excel";
            this.ExportExcel_Button.Click += new System.EventHandler(this.ExportExcel_Button_Click);
            // 
            // SoCai_Button
            // 
            this.SoCai_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SoCai_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SoCai_Button.ImageOptions.Image")));
            this.SoCai_Button.Location = new System.Drawing.Point(814, 4);
            this.SoCai_Button.Name = "SoCai_Button";
            this.SoCai_Button.Size = new System.Drawing.Size(56, 25);
            this.SoCai_Button.TabIndex = 9;
            this.SoCai_Button.Text = "Sổ cái";
            this.SoCai_Button.Click += new System.EventHandler(this.SoCai_Button_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Exit_Button.ImageOptions.Image")));
            this.Exit_Button.Location = new System.Drawing.Point(1027, 4);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(60, 25);
            this.Exit_Button.TabIndex = 8;
            this.Exit_Button.Text = "Thoát";
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // BangCanDoiSoPhatSinhTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 568);
            this.Controls.Add(this.Main_GridControl);
            this.Controls.Add(this.UserButton_Panel);
            this.Name = "BangCanDoiSoPhatSinhTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng cân đối phát sinh số tài khoản";
            this.Load += new System.EventHandler(this.BangCanDoiSoPhatSinhTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeSearch_LookUpEdit.Properties)).EndInit();
            this.UserButton_Panel.ResumeLayout(false);
            this.UserButton_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Main_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Main_GridView;
        private DevExpress.XtraEditors.SimpleButton Print_Button;
        private DevExpress.XtraEditors.DateEdit From_DateEdit;
        private DevExpress.XtraEditors.DateEdit To_DateEdit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit TypeSearch_LookUpEdit;
        private DevExpress.XtraEditors.SimpleButton SearchData_Button;
        private System.Windows.Forms.Panel UserButton_Panel;
        private DevExpress.XtraEditors.SimpleButton KetChuyen_Button;
        private DevExpress.XtraEditors.SimpleButton ExportExcel_Button;
        private DevExpress.XtraEditors.SimpleButton SoCai_Button;
        private DevExpress.XtraEditors.SimpleButton Exit_Button;
    }
}
