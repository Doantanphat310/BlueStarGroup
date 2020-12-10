namespace BSClient.Views
{
    partial class SoCaiChiTietReport
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
            this.Main_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.UserButton_Panel = new System.Windows.Forms.Panel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.To_DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.From_DateEdit = new DevExpress.XtraEditors.DateEdit();
            this.NgayPS_Label = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.Print_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GroupControl)).BeginInit();
            this.Main_GroupControl.SuspendLayout();
            this.UserButton_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_GridControl
            // 
            this.Main_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_GridControl.Location = new System.Drawing.Point(2, 65);
            this.Main_GridControl.MainView = this.Main_GridView;
            this.Main_GridControl.Name = "Main_GridControl";
            this.Main_GridControl.Size = new System.Drawing.Size(834, 401);
            this.Main_GridControl.TabIndex = 0;
            this.Main_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Main_GridView});
            // 
            // Main_GridView
            // 
            this.Main_GridView.GridControl = this.Main_GridControl;
            this.Main_GridView.Name = "Main_GridView";
            // 
            // Main_GroupControl
            // 
            this.Main_GroupControl.Controls.Add(this.Main_GridControl);
            this.Main_GroupControl.Controls.Add(this.UserButton_Panel);
            this.Main_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_GroupControl.Location = new System.Drawing.Point(0, 0);
            this.Main_GroupControl.Name = "Main_GroupControl";
            this.Main_GroupControl.Size = new System.Drawing.Size(838, 468);
            this.Main_GroupControl.TabIndex = 0;
            this.Main_GroupControl.Text = "Báo cáo Bảng cân đối phát sinh";
            // 
            // UserButton_Panel
            // 
            this.UserButton_Panel.Controls.Add(this.labelControl2);
            this.UserButton_Panel.Controls.Add(this.To_DateEdit);
            this.UserButton_Panel.Controls.Add(this.From_DateEdit);
            this.UserButton_Panel.Controls.Add(this.NgayPS_Label);
            this.UserButton_Panel.Controls.Add(this.labelControl1);
            this.UserButton_Panel.Controls.Add(this.lookUpEdit1);
            this.UserButton_Panel.Controls.Add(this.Print_Button);
            this.UserButton_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserButton_Panel.Location = new System.Drawing.Point(2, 20);
            this.UserButton_Panel.Name = "UserButton_Panel";
            this.UserButton_Panel.Size = new System.Drawing.Size(834, 45);
            this.UserButton_Panel.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(460, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(8, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "~";
            // 
            // To_DateEdit
            // 
            this.To_DateEdit.EditValue = null;
            this.To_DateEdit.Location = new System.Drawing.Point(474, 12);
            this.To_DateEdit.Name = "To_DateEdit";
            this.To_DateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.To_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.To_DateEdit.Size = new System.Drawing.Size(115, 20);
            this.To_DateEdit.TabIndex = 4;
            // 
            // From_DateEdit
            // 
            this.From_DateEdit.EditValue = null;
            this.From_DateEdit.Location = new System.Drawing.Point(339, 12);
            this.From_DateEdit.Name = "From_DateEdit";
            this.From_DateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.From_DateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.From_DateEdit.Size = new System.Drawing.Size(115, 20);
            this.From_DateEdit.TabIndex = 3;
            // 
            // NgayPS_Label
            // 
            this.NgayPS_Label.Location = new System.Drawing.Point(261, 15);
            this.NgayPS_Label.Name = "NgayPS_Label";
            this.NgayPS_Label.Size = new System.Drawing.Size(72, 13);
            this.NgayPS_Label.TabIndex = 2;
            this.NgayPS_Label.Text = "Ngày phát sinh";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tài Khoản";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(65, 12);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(184, 20);
            this.lookUpEdit1.TabIndex = 1;
            // 
            // Print_Button
            // 
            this.Print_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Print_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Print_Button.ImageOptions.Image")));
            this.Print_Button.Location = new System.Drawing.Point(693, 4);
            this.Print_Button.Name = "Print_Button";
            this.Print_Button.Size = new System.Drawing.Size(134, 35);
            this.Print_Button.TabIndex = 0;
            this.Print_Button.Text = "Xuất Báo cáo";
            this.Print_Button.Click += new System.EventHandler(this.Print_Button_Click);
            // 
            // BangCanDoiSoPhatSinhTKReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main_GroupControl);
            this.Name = "BangCanDoiSoPhatSinhTKReport";
            this.Size = new System.Drawing.Size(838, 468);
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GroupControl)).EndInit();
            this.Main_GroupControl.ResumeLayout(false);
            this.UserButton_Panel.ResumeLayout(false);
            this.UserButton_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.To_DateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From_DateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Main_GridControl;
        private DevExpress.XtraEditors.GroupControl Main_GroupControl;
        private System.Windows.Forms.Panel UserButton_Panel;
        private DevExpress.XtraEditors.SimpleButton Print_Button;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit To_DateEdit;
        private DevExpress.XtraEditors.DateEdit From_DateEdit;
        private DevExpress.XtraEditors.LabelControl NgayPS_Label;
        private DevExpress.XtraGrid.Views.Grid.GridView Main_GridView;
    }
}
