namespace BSClient.Views.Reports
{
    partial class BangCanDoiSoPhatSinhTaiKhoanReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BangCanDoiSoPhatSinhTaiKhoanReport));
            this.Main_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Main_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Print_Button = new DevExpress.XtraEditors.SimpleButton();
            this.From_DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.To_DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.Charter_Label = new DevExpress.XtraEditors.LabelControl();
            this.TypeSearch_LookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.SearchData_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Button_Panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ExportExcel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.SoCai_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Exit_Button = new DevExpress.XtraEditors.SimpleButton();
            this.KetChuyen_Button = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeSearch_LookUpEdit.Properties)).BeginInit();
            this.Button_Panel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_GridControl
            // 
            this.Main_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_GridControl.Location = new System.Drawing.Point(0, 32);
            this.Main_GridControl.MainView = this.Main_GridView;
            this.Main_GridControl.Name = "Main_GridControl";
            this.Main_GridControl.Size = new System.Drawing.Size(1090, 573);
            this.Main_GridControl.TabIndex = 0;
            this.Main_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Main_GridView});
            // 
            // Main_GridView
            // 
            this.Main_GridView.GridControl = this.Main_GridControl;
            this.Main_GridView.IndicatorWidth = 30;
            this.Main_GridView.Name = "Main_GridView";
            this.Main_GridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.Main_GridView_RowClick);
            // 
            // Print_Button
            // 
            this.Print_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Print_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Print_Button.ImageOptions.Image")));
            this.Print_Button.Location = new System.Drawing.Point(698, 3);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(90, 25);
            this.Print_Button.TabIndex = 0;
            this.Print_Button.Text = "Xuất báo cáo";
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // From_DateEdit
            // 
            this.From_DateEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.From_DateEdit.EditValue = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.From_DateEdit.Location = new System.Drawing.Point(41, 6);
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
            this.From_DateEdit.Size = new System.Drawing.Size(85, 20);
            this.From_DateEdit.TabIndex = 3;
            // 
            // To_DateEdit
            // 
            this.To_DateEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.To_DateEdit.EditValue = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.To_DateEdit.Location = new System.Drawing.Point(146, 6);
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
            this.To_DateEdit.Size = new System.Drawing.Size(85, 20);
            this.To_DateEdit.TabIndex = 4;
            // 
            // Charter_Label
            // 
            this.Charter_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Charter_Label.Location = new System.Drawing.Point(132, 9);
            this.Charter_Label.Name = "Charter_Label";
            this.Charter_Label.Size = new System.Drawing.Size(8, 13);
            this.Charter_Label.TabIndex = 5;
            this.Charter_Label.Text = "~";
            // 
            // TypeSearch_LookUpEdit
            // 
            this.TypeSearch_LookUpEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TypeSearch_LookUpEdit.Location = new System.Drawing.Point(237, 6);
            this.TypeSearch_LookUpEdit.Name = "TypeSearch_LookUpEdit";
            this.TypeSearch_LookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TypeSearch_LookUpEdit.Properties.NullText = "";
            this.TypeSearch_LookUpEdit.Size = new System.Drawing.Size(212, 20);
            this.TypeSearch_LookUpEdit.TabIndex = 6;
            // 
            // SearchData_Button
            // 
            this.SearchData_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchData_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SearchData_Button.ImageOptions.Image")));
            this.SearchData_Button.Location = new System.Drawing.Point(455, 3);
            this.SearchData_Button.Name = "SearchData_Button";
            this.SearchData_Button.Size = new System.Drawing.Size(87, 25);
            this.SearchData_Button.TabIndex = 7;
            this.SearchData_Button.Text = "Lấy số liệu";
            this.SearchData_Button.Click += new System.EventHandler(this.SearchData_Button_Click);
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.tableLayoutPanel1);
            this.Button_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Button_Panel.Location = new System.Drawing.Point(0, 0);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.Size = new System.Drawing.Size(1090, 32);
            this.Button_Panel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.Print_Button, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.Charter_Label, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.TypeSearch_LookUpEdit, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.To_DateEdit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.SearchData_Button, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.ExportExcel_Button, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.SoCai_Button, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.Exit_Button, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.KetChuyen_Button, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.From_DateEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1090, 32);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // ExportExcel_Button
            // 
            this.ExportExcel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExportExcel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ExportExcel_Button.ImageOptions.Image")));
            this.ExportExcel_Button.Location = new System.Drawing.Point(856, 3);
            this.ExportExcel_Button.Name = "ExportExcel_Button";
            this.ExportExcel_Button.Size = new System.Drawing.Size(61, 25);
            this.ExportExcel_Button.TabIndex = 9;
            this.ExportExcel_Button.Text = "Excel";
            this.ExportExcel_Button.Click += new System.EventHandler(this.ExportExcel_Button_Click);
            // 
            // SoCai_Button
            // 
            this.SoCai_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SoCai_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SoCai_Button.ImageOptions.Image")));
            this.SoCai_Button.Location = new System.Drawing.Point(794, 3);
            this.SoCai_Button.Name = "SoCai_Button";
            this.SoCai_Button.Size = new System.Drawing.Size(56, 25);
            this.SoCai_Button.TabIndex = 9;
            this.SoCai_Button.Text = "Sổ cái";
            this.SoCai_Button.Click += new System.EventHandler(this.SoCai_Button_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Exit_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Exit_Button.ImageOptions.Image")));
            this.Exit_Button.Location = new System.Drawing.Point(1007, 3);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(80, 25);
            this.Exit_Button.TabIndex = 8;
            this.Exit_Button.Text = "Thoát";
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // KetChuyen_Button
            // 
            this.KetChuyen_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KetChuyen_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("KetChuyen_Button.ImageOptions.Image")));
            this.KetChuyen_Button.Location = new System.Drawing.Point(923, 3);
            this.KetChuyen_Button.Name = "KetChuyen_Button";
            this.KetChuyen_Button.Size = new System.Drawing.Size(78, 25);
            this.KetChuyen_Button.TabIndex = 11;
            this.KetChuyen_Button.Text = "KC Nhanh";
            this.KetChuyen_Button.Click += new System.EventHandler(this.KetChuyen_Button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ngày";
            // 
            // BangCanDoiSoPhatSinhTaiKhoanReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 605);
            this.Controls.Add(this.Main_GridControl);
            this.Controls.Add(this.Button_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "BangCanDoiSoPhatSinhTaiKhoanReport";
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
            this.Button_Panel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Main_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Main_GridView;
        private DevExpress.XtraEditors.SimpleButton Print_Button;
        private DevExpress.XtraEditors.DateEdit From_DateEdit;
        private DevExpress.XtraEditors.DateEdit To_DateEdit;
        private DevExpress.XtraEditors.LabelControl Charter_Label;
        private DevExpress.XtraEditors.LookUpEdit TypeSearch_LookUpEdit;
        private DevExpress.XtraEditors.SimpleButton SearchData_Button;
        private System.Windows.Forms.Panel Button_Panel;
        private DevExpress.XtraEditors.SimpleButton ExportExcel_Button;
        private DevExpress.XtraEditors.SimpleButton SoCai_Button;
        private DevExpress.XtraEditors.SimpleButton Exit_Button;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton KetChuyen_Button;
        private System.Windows.Forms.Label label1;
    }
}
