namespace BSClient.Views
{
    partial class ChiTietTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChiTietTaiKhoan));
            this.Main_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Main_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Print_Button = new DevExpress.XtraEditors.SimpleButton();
            this.UserButton_Panel = new System.Windows.Forms.Panel();
            this.ExportExcel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Exit_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Bottom_Panel = new System.Windows.Forms.Panel();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.DKNo_SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DKCo_SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.PSNo_SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.PSCo_SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.CKNo_SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.CKCo_SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).BeginInit();
            this.UserButton_Panel.SuspendLayout();
            this.Bottom_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DKNo_SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DKCo_SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSNo_SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSCo_SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CKNo_SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CKCo_SpinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_GridControl
            // 
            this.Main_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_GridControl.Location = new System.Drawing.Point(0, 34);
            this.Main_GridControl.MainView = this.Main_GridView;
            this.Main_GridControl.Name = "Main_GridControl";
            this.Main_GridControl.Size = new System.Drawing.Size(881, 310);
            this.Main_GridControl.TabIndex = 0;
            this.Main_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Main_GridView});
            // 
            // Main_GridView
            // 
            this.Main_GridView.GridControl = this.Main_GridControl;
            this.Main_GridView.Name = "Main_GridView";
            // 
            // Print_Button
            // 
            this.Print_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Print_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Print_Button.ImageOptions.Image")));
            this.Print_Button.Location = new System.Drawing.Point(655, 4);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(90, 25);
            this.Print_Button.TabIndex = 0;
            this.Print_Button.Text = "Xuất báo cáo";
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // UserButton_Panel
            // 
            this.UserButton_Panel.Controls.Add(this.ExportExcel_Button);
            this.UserButton_Panel.Controls.Add(this.Exit_Button);
            this.UserButton_Panel.Controls.Add(this.Print_Button);
            this.UserButton_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserButton_Panel.Location = new System.Drawing.Point(0, 0);
            this.UserButton_Panel.Name = "UserButton_Panel";
            this.UserButton_Panel.Size = new System.Drawing.Size(881, 34);
            this.UserButton_Panel.TabIndex = 1;
            // 
            // ExportExcel_Button
            // 
            this.ExportExcel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportExcel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ExportExcel_Button.ImageOptions.Image")));
            this.ExportExcel_Button.Location = new System.Drawing.Point(751, 4);
            this.ExportExcel_Button.Name = "ExportExcel_Button";
            this.ExportExcel_Button.Size = new System.Drawing.Size(61, 25);
            this.ExportExcel_Button.TabIndex = 9;
            this.ExportExcel_Button.Text = "Excel";
            this.ExportExcel_Button.Click += new System.EventHandler(this.ExportExcel_Button_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Exit_Button.ImageOptions.Image")));
            this.Exit_Button.Location = new System.Drawing.Point(818, 4);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(60, 25);
            this.Exit_Button.TabIndex = 8;
            this.Exit_Button.Text = "Thoát";
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Bottom_Panel
            // 
            this.Bottom_Panel.Controls.Add(this.tablePanel1);
            this.Bottom_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Bottom_Panel.Location = new System.Drawing.Point(0, 344);
            this.Bottom_Panel.Name = "Bottom_Panel";
            this.Bottom_Panel.Size = new System.Drawing.Size(881, 84);
            this.Bottom_Panel.TabIndex = 10;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 60F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.DKNo_SpinEdit);
            this.tablePanel1.Controls.Add(this.label1);
            this.tablePanel1.Controls.Add(this.label2);
            this.tablePanel1.Controls.Add(this.label3);
            this.tablePanel1.Controls.Add(this.DKCo_SpinEdit);
            this.tablePanel1.Controls.Add(this.PSNo_SpinEdit);
            this.tablePanel1.Controls.Add(this.PSCo_SpinEdit);
            this.tablePanel1.Controls.Add(this.CKNo_SpinEdit);
            this.tablePanel1.Controls.Add(this.CKCo_SpinEdit);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tablePanel1.Location = new System.Drawing.Point(503, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Size = new System.Drawing.Size(378, 84);
            this.tablePanel1.TabIndex = 0;
            // 
            // DKNo_SpinEdit
            // 
            this.tablePanel1.SetColumn(this.DKNo_SpinEdit, 1);
            this.DKNo_SpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DKNo_SpinEdit.Location = new System.Drawing.Point(63, 4);
            this.DKNo_SpinEdit.Name = "DKNo_SpinEdit";
            this.DKNo_SpinEdit.Properties.DisplayFormat.FormatString = "#,##0";
            this.DKNo_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DKNo_SpinEdit.Properties.EditFormat.FormatString = "#,##0";
            this.DKNo_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DKNo_SpinEdit.Properties.ReadOnly = true;
            this.tablePanel1.SetRow(this.DKNo_SpinEdit, 0);
            this.DKNo_SpinEdit.Size = new System.Drawing.Size(153, 20);
            this.DKNo_SpinEdit.TabIndex = 2;
            // 
            // label1
            // 
            this.tablePanel1.SetColumn(this.label1, 0);
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.tablePanel1.SetRow(this.label1, 0);
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đầu kỳ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.tablePanel1.SetColumn(this.label2, 0);
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.tablePanel1.SetRow(this.label2, 1);
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phát sinh";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.tablePanel1.SetColumn(this.label3, 0);
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.tablePanel1.SetRow(this.label3, 2);
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cuối kỳ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DKCo_SpinEdit
            // 
            this.tablePanel1.SetColumn(this.DKCo_SpinEdit, 2);
            this.DKCo_SpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.DKCo_SpinEdit.Location = new System.Drawing.Point(222, 4);
            this.DKCo_SpinEdit.Name = "DKCo_SpinEdit";
            this.DKCo_SpinEdit.Properties.DisplayFormat.FormatString = "#,##0";
            this.DKCo_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DKCo_SpinEdit.Properties.EditFormat.FormatString = "#,##0";
            this.DKCo_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.DKCo_SpinEdit.Properties.ReadOnly = true;
            this.tablePanel1.SetRow(this.DKCo_SpinEdit, 0);
            this.DKCo_SpinEdit.Size = new System.Drawing.Size(153, 20);
            this.DKCo_SpinEdit.TabIndex = 2;
            // 
            // PSNo_SpinEdit
            // 
            this.tablePanel1.SetColumn(this.PSNo_SpinEdit, 1);
            this.PSNo_SpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PSNo_SpinEdit.Location = new System.Drawing.Point(63, 32);
            this.PSNo_SpinEdit.Name = "PSNo_SpinEdit";
            this.PSNo_SpinEdit.Properties.DisplayFormat.FormatString = "#,##0";
            this.PSNo_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PSNo_SpinEdit.Properties.EditFormat.FormatString = "#,##0";
            this.PSNo_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PSNo_SpinEdit.Properties.ReadOnly = true;
            this.tablePanel1.SetRow(this.PSNo_SpinEdit, 1);
            this.PSNo_SpinEdit.Size = new System.Drawing.Size(153, 20);
            this.PSNo_SpinEdit.TabIndex = 2;
            // 
            // PSCo_SpinEdit
            // 
            this.tablePanel1.SetColumn(this.PSCo_SpinEdit, 2);
            this.PSCo_SpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.PSCo_SpinEdit.Location = new System.Drawing.Point(222, 32);
            this.PSCo_SpinEdit.Name = "PSCo_SpinEdit";
            this.PSCo_SpinEdit.Properties.DisplayFormat.FormatString = "#,##0";
            this.PSCo_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PSCo_SpinEdit.Properties.EditFormat.FormatString = "#,##0";
            this.PSCo_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.PSCo_SpinEdit.Properties.ReadOnly = true;
            this.tablePanel1.SetRow(this.PSCo_SpinEdit, 1);
            this.PSCo_SpinEdit.Size = new System.Drawing.Size(153, 20);
            this.PSCo_SpinEdit.TabIndex = 2;
            // 
            // CKNo_SpinEdit
            // 
            this.tablePanel1.SetColumn(this.CKNo_SpinEdit, 1);
            this.CKNo_SpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CKNo_SpinEdit.Location = new System.Drawing.Point(63, 60);
            this.CKNo_SpinEdit.Name = "CKNo_SpinEdit";
            this.CKNo_SpinEdit.Properties.DisplayFormat.FormatString = "#,##0";
            this.CKNo_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.CKNo_SpinEdit.Properties.EditFormat.FormatString = "#,##0";
            this.CKNo_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.CKNo_SpinEdit.Properties.ReadOnly = true;
            this.tablePanel1.SetRow(this.CKNo_SpinEdit, 2);
            this.CKNo_SpinEdit.Size = new System.Drawing.Size(153, 20);
            this.CKNo_SpinEdit.TabIndex = 2;
            // 
            // CKCo_SpinEdit
            // 
            this.tablePanel1.SetColumn(this.CKCo_SpinEdit, 2);
            this.CKCo_SpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.CKCo_SpinEdit.Location = new System.Drawing.Point(222, 60);
            this.CKCo_SpinEdit.Name = "CKCo_SpinEdit";
            this.CKCo_SpinEdit.Properties.DisplayFormat.FormatString = "#,##0";
            this.CKCo_SpinEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.CKCo_SpinEdit.Properties.EditFormat.FormatString = "#,##0";
            this.CKCo_SpinEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.CKCo_SpinEdit.Properties.ReadOnly = true;
            this.tablePanel1.SetRow(this.CKCo_SpinEdit, 2);
            this.CKCo_SpinEdit.Size = new System.Drawing.Size(153, 20);
            this.CKCo_SpinEdit.TabIndex = 2;
            // 
            // ChiTietTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 428);
            this.Controls.Add(this.Main_GridControl);
            this.Controls.Add(this.Bottom_Panel);
            this.Controls.Add(this.UserButton_Panel);
            this.Name = "ChiTietTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Tài Khoản";
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).EndInit();
            this.UserButton_Panel.ResumeLayout(false);
            this.Bottom_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DKNo_SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DKCo_SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSNo_SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSCo_SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CKNo_SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CKCo_SpinEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Main_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Main_GridView;
        private DevExpress.XtraEditors.SimpleButton Print_Button;
        private System.Windows.Forms.Panel UserButton_Panel;
        private DevExpress.XtraEditors.SimpleButton ExportExcel_Button;
        private DevExpress.XtraEditors.SimpleButton Exit_Button;
        private System.Windows.Forms.Panel Bottom_Panel;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SpinEdit DKNo_SpinEdit;
        private DevExpress.XtraEditors.SpinEdit DKCo_SpinEdit;
        private DevExpress.XtraEditors.SpinEdit PSNo_SpinEdit;
        private DevExpress.XtraEditors.SpinEdit PSCo_SpinEdit;
        private DevExpress.XtraEditors.SpinEdit CKNo_SpinEdit;
        private DevExpress.XtraEditors.SpinEdit CKCo_SpinEdit;
    }
}
