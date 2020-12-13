namespace BSClient.Views
{
    partial class BangCanDoiSoPhatSinhTKReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BangCanDoiSoPhatSinhTKReport));
            this.Main_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Main_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Print_Button = new DevExpress.XtraEditors.SimpleButton();
            this.From_DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.To_DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.UserButton_Panel = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.UserButton_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_GridControl
            // 
            this.Main_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_GridControl.Location = new System.Drawing.Point(0, 34);
            this.Main_GridControl.MainView = this.Main_GridView;
            this.Main_GridControl.Name = "Main_GridControl";
            this.Main_GridControl.Size = new System.Drawing.Size(862, 402);
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
            this.Print_Button.Location = new System.Drawing.Point(490, 4);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(90, 25);
            this.Print_Button.TabIndex = 0;
            this.Print_Button.Text = "Xuất báo cáo";
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // From_DateEdit
            // 
            this.From_DateEdit.EditValue = new System.DateTime(2020, 12, 13, 20, 31, 17, 292);
            this.From_DateEdit.Location = new System.Drawing.Point(10, 6);
            this.From_DateEdit.Name = "From_DateEdit";
            this.From_DateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.From_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.From_DateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.From_DateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.From_DateEdit.Size = new System.Drawing.Size(86, 20);
            this.From_DateEdit.TabIndex = 3;
            // 
            // To_DateEdit
            // 
            this.To_DateEdit.EditValue = new System.DateTime(2020, 12, 13, 0, 0, 0, 0);
            this.To_DateEdit.Location = new System.Drawing.Point(116, 6);
            this.To_DateEdit.Name = "To_DateEdit";
            this.To_DateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.To_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.To_DateEdit.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.To_DateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
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
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(208, 6);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(149, 20);
            this.lookUpEdit1.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(363, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(87, 25);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Lấy số liệu";
            // 
            // UserButton_Panel
            // 
            this.UserButton_Panel.Controls.Add(this.simpleButton4);
            this.UserButton_Panel.Controls.Add(this.simpleButton5);
            this.UserButton_Panel.Controls.Add(this.simpleButton3);
            this.UserButton_Panel.Controls.Add(this.simpleButton2);
            this.UserButton_Panel.Controls.Add(this.simpleButton1);
            this.UserButton_Panel.Controls.Add(this.lookUpEdit1);
            this.UserButton_Panel.Controls.Add(this.labelControl2);
            this.UserButton_Panel.Controls.Add(this.To_DateEdit);
            this.UserButton_Panel.Controls.Add(this.From_DateEdit);
            this.UserButton_Panel.Controls.Add(this.Print_Button);
            this.UserButton_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserButton_Panel.Location = new System.Drawing.Point(0, 0);
            this.UserButton_Panel.Name = "UserButton_Panel";
            this.UserButton_Panel.Size = new System.Drawing.Size(862, 34);
            this.UserButton_Panel.TabIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(799, 4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(60, 25);
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "Thoát";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(586, 4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(56, 25);
            this.simpleButton3.TabIndex = 9;
            this.simpleButton3.Text = "Sổ cái";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.ImageOptions.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(715, 4);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(78, 25);
            this.simpleButton4.TabIndex = 10;
            this.simpleButton4.Text = "KC Nhanh";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.ImageOptions.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(648, 3);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(61, 25);
            this.simpleButton5.TabIndex = 9;
            this.simpleButton5.Text = "Excel";
            // 
            // BangCanDoiSoPhatSinhTKReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 436);
            this.Controls.Add(this.Main_GridControl);
            this.Controls.Add(this.UserButton_Panel);
            this.Name = "BangCanDoiSoPhatSinhTKReport";
            this.Text = "Bảng cân đối phát sinh số tài khoản";
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Panel UserButton_Panel;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
