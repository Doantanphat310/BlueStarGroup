namespace BSClient.Views
{
    partial class ClockDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClockDB));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.LockDB_Cancel_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.LockDB_Delete_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.LockDB_Save_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.LockDB_gridControl = new DevExpress.XtraGrid.GridControl();
            this.LockDB_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LockDB_StartDate_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.LockDB_EndDate_dateEdit = new DevExpress.XtraEditors.DateEdit();
            this.LockDB_GetData_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_StartDate_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_StartDate_dateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_EndDate_dateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_EndDate_dateEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.LockDB_GetData_simpleButton);
            this.panelControl2.Controls.Add(this.LockDB_EndDate_dateEdit);
            this.panelControl2.Controls.Add(this.LockDB_StartDate_dateEdit);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.LockDB_Cancel_simpleButton);
            this.panelControl2.Controls.Add(this.LockDB_Delete_simpleButton);
            this.panelControl2.Controls.Add(this.LockDB_Save_simpleButton);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1303, 40);
            this.panelControl2.TabIndex = 0;
            // 
            // LockDB_Cancel_simpleButton
            // 
            this.LockDB_Cancel_simpleButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockDB_Cancel_simpleButton.Appearance.Options.UseFont = true;
            this.LockDB_Cancel_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("LockDB_Cancel_simpleButton.ImageOptions.Image")));
            this.LockDB_Cancel_simpleButton.Location = new System.Drawing.Point(942, 5);
            this.LockDB_Cancel_simpleButton.Name = "LockDB_Cancel_simpleButton";
            this.LockDB_Cancel_simpleButton.Size = new System.Drawing.Size(84, 29);
            this.LockDB_Cancel_simpleButton.TabIndex = 9;
            this.LockDB_Cancel_simpleButton.Text = "Hủy";
            this.LockDB_Cancel_simpleButton.Click += new System.EventHandler(this.LockDB_Cancel_simpleButton_Click);
            // 
            // LockDB_Delete_simpleButton
            // 
            this.LockDB_Delete_simpleButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockDB_Delete_simpleButton.Appearance.Options.UseFont = true;
            this.LockDB_Delete_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("LockDB_Delete_simpleButton.ImageOptions.Image")));
            this.LockDB_Delete_simpleButton.Location = new System.Drawing.Point(852, 5);
            this.LockDB_Delete_simpleButton.Name = "LockDB_Delete_simpleButton";
            this.LockDB_Delete_simpleButton.Size = new System.Drawing.Size(84, 29);
            this.LockDB_Delete_simpleButton.TabIndex = 7;
            this.LockDB_Delete_simpleButton.Text = "Xóa";
            this.LockDB_Delete_simpleButton.Click += new System.EventHandler(this.LockDB_Delete_simpleButton_Click);
            // 
            // LockDB_Save_simpleButton
            // 
            this.LockDB_Save_simpleButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockDB_Save_simpleButton.Appearance.Options.UseFont = true;
            this.LockDB_Save_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("LockDB_Save_simpleButton.ImageOptions.Image")));
            this.LockDB_Save_simpleButton.Location = new System.Drawing.Point(762, 5);
            this.LockDB_Save_simpleButton.Name = "LockDB_Save_simpleButton";
            this.LockDB_Save_simpleButton.Size = new System.Drawing.Size(84, 29);
            this.LockDB_Save_simpleButton.TabIndex = 6;
            this.LockDB_Save_simpleButton.Text = "Lưu";
            this.LockDB_Save_simpleButton.Click += new System.EventHandler(this.LockDB_Save_simpleButton_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.LockDB_gridControl);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1307, 697);
            this.panelControl1.TabIndex = 1;
            // 
            // LockDB_gridControl
            // 
            this.LockDB_gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LockDB_gridControl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockDB_gridControl.Location = new System.Drawing.Point(2, 42);
            this.LockDB_gridControl.MainView = this.LockDB_gridView;
            this.LockDB_gridControl.Name = "LockDB_gridControl";
            this.LockDB_gridControl.Size = new System.Drawing.Size(1303, 653);
            this.LockDB_gridControl.TabIndex = 0;
            this.LockDB_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.LockDB_gridView});
            // 
            // LockDB_gridView
            // 
            this.LockDB_gridView.GridControl = this.LockDB_gridControl;
            this.LockDB_gridView.Name = "LockDB_gridView";
            this.LockDB_gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.LockDB_gridView_RowUpdated);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 19);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Ngày bắt đầu";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(294, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(97, 19);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Ngày kết thúc";
            // 
            // LockDB_StartDate_dateEdit
            // 
            this.LockDB_StartDate_dateEdit.EditValue = null;
            this.LockDB_StartDate_dateEdit.Location = new System.Drawing.Point(110, 7);
            this.LockDB_StartDate_dateEdit.Name = "LockDB_StartDate_dateEdit";
            this.LockDB_StartDate_dateEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockDB_StartDate_dateEdit.Properties.Appearance.Options.UseFont = true;
            this.LockDB_StartDate_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LockDB_StartDate_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LockDB_StartDate_dateEdit.Size = new System.Drawing.Size(178, 26);
            this.LockDB_StartDate_dateEdit.TabIndex = 11;
            // 
            // LockDB_EndDate_dateEdit
            // 
            this.LockDB_EndDate_dateEdit.EditValue = null;
            this.LockDB_EndDate_dateEdit.Location = new System.Drawing.Point(407, 7);
            this.LockDB_EndDate_dateEdit.Name = "LockDB_EndDate_dateEdit";
            this.LockDB_EndDate_dateEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockDB_EndDate_dateEdit.Properties.Appearance.Options.UseFont = true;
            this.LockDB_EndDate_dateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LockDB_EndDate_dateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LockDB_EndDate_dateEdit.Size = new System.Drawing.Size(178, 26);
            this.LockDB_EndDate_dateEdit.TabIndex = 11;
            // 
            // LockDB_GetData_simpleButton
            // 
            this.LockDB_GetData_simpleButton.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LockDB_GetData_simpleButton.Appearance.Options.UseFont = true;
            this.LockDB_GetData_simpleButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.LockDB_GetData_simpleButton.Location = new System.Drawing.Point(591, 5);
            this.LockDB_GetData_simpleButton.Name = "LockDB_GetData_simpleButton";
            this.LockDB_GetData_simpleButton.Size = new System.Drawing.Size(109, 29);
            this.LockDB_GetData_simpleButton.TabIndex = 12;
            this.LockDB_GetData_simpleButton.Text = "Lấy dữ liệu";
            this.LockDB_GetData_simpleButton.Click += new System.EventHandler(this.LockDB_GetData_simpleButton_Click);
            // 
            // ClockDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 697);
            this.Controls.Add(this.panelControl1);
            this.Name = "ClockDB";
            this.Text = "Khóa sổ kế toán";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_StartDate_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_StartDate_dateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_EndDate_dateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LockDB_EndDate_dateEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton LockDB_Cancel_simpleButton;
        private DevExpress.XtraEditors.SimpleButton LockDB_Delete_simpleButton;
        private DevExpress.XtraEditors.SimpleButton LockDB_Save_simpleButton;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl LockDB_gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView LockDB_gridView;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton LockDB_GetData_simpleButton;
        private DevExpress.XtraEditors.DateEdit LockDB_EndDate_dateEdit;
        private DevExpress.XtraEditors.DateEdit LockDB_StartDate_dateEdit;
    }
}