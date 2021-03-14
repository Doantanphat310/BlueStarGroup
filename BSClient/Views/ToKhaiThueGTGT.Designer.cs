namespace BSClient.Views
{
    partial class ToKhaiThueGTGT
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ToKhai_LaySoLieu_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.ToKhai_PhanTramThue_textEdit = new DevExpress.XtraEditors.TextEdit();
            this.ToKhai_Loai_searchLookUpEdit = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ToKhai_ToDate = new DevExpress.XtraEditors.DateEdit();
            this.ToKhai_FromDate = new DevExpress.XtraEditors.DateEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.ToKhai_gridControl = new DevExpress.XtraGrid.GridControl();
            this.ToKhai_gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_PhanTramThue_textEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_Loai_searchLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_ToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_ToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_FromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_FromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ToKhai_LaySoLieu_simpleButton);
            this.panelControl1.Controls.Add(this.ToKhai_PhanTramThue_textEdit);
            this.panelControl1.Controls.Add(this.ToKhai_Loai_searchLookUpEdit);
            this.panelControl1.Controls.Add(this.ToKhai_ToDate);
            this.panelControl1.Controls.Add(this.ToKhai_FromDate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1307, 63);
            this.panelControl1.TabIndex = 0;
            // 
            // ToKhai_LaySoLieu_simpleButton
            // 
            this.ToKhai_LaySoLieu_simpleButton.Location = new System.Drawing.Point(491, 10);
            this.ToKhai_LaySoLieu_simpleButton.Name = "ToKhai_LaySoLieu_simpleButton";
            this.ToKhai_LaySoLieu_simpleButton.Size = new System.Drawing.Size(124, 23);
            this.ToKhai_LaySoLieu_simpleButton.TabIndex = 4;
            this.ToKhai_LaySoLieu_simpleButton.Text = "Lấy số liệu";
            this.ToKhai_LaySoLieu_simpleButton.Click += new System.EventHandler(this.ToKhai_LaySoLieu_simpleButton_Click);
            // 
            // ToKhai_PhanTramThue_textEdit
            // 
            this.ToKhai_PhanTramThue_textEdit.Location = new System.Drawing.Point(344, 12);
            this.ToKhai_PhanTramThue_textEdit.Name = "ToKhai_PhanTramThue_textEdit";
            this.ToKhai_PhanTramThue_textEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ToKhai_PhanTramThue_textEdit.Size = new System.Drawing.Size(141, 20);
            this.ToKhai_PhanTramThue_textEdit.TabIndex = 3;
            // 
            // ToKhai_Loai_searchLookUpEdit
            // 
            this.ToKhai_Loai_searchLookUpEdit.Location = new System.Drawing.Point(238, 12);
            this.ToKhai_Loai_searchLookUpEdit.Name = "ToKhai_Loai_searchLookUpEdit";
            this.ToKhai_Loai_searchLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToKhai_Loai_searchLookUpEdit.Properties.PopupView = this.searchLookUpEdit1View;
            this.ToKhai_Loai_searchLookUpEdit.Size = new System.Drawing.Size(100, 20);
            this.ToKhai_Loai_searchLookUpEdit.TabIndex = 2;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ToKhai_ToDate
            // 
            this.ToKhai_ToDate.EditValue = null;
            this.ToKhai_ToDate.Location = new System.Drawing.Point(125, 12);
            this.ToKhai_ToDate.Name = "ToKhai_ToDate";
            this.ToKhai_ToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToKhai_ToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToKhai_ToDate.Size = new System.Drawing.Size(107, 20);
            this.ToKhai_ToDate.TabIndex = 1;
            // 
            // ToKhai_FromDate
            // 
            this.ToKhai_FromDate.EditValue = null;
            this.ToKhai_FromDate.Location = new System.Drawing.Point(12, 12);
            this.ToKhai_FromDate.Name = "ToKhai_FromDate";
            this.ToKhai_FromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToKhai_FromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ToKhai_FromDate.Size = new System.Drawing.Size(107, 20);
            this.ToKhai_FromDate.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.ToKhai_gridControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 63);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1307, 634);
            this.panelControl2.TabIndex = 1;
            // 
            // ToKhai_gridControl
            // 
            this.ToKhai_gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToKhai_gridControl.Location = new System.Drawing.Point(2, 2);
            this.ToKhai_gridControl.MainView = this.ToKhai_gridView;
            this.ToKhai_gridControl.Name = "ToKhai_gridControl";
            this.ToKhai_gridControl.Size = new System.Drawing.Size(1303, 630);
            this.ToKhai_gridControl.TabIndex = 0;
            this.ToKhai_gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ToKhai_gridView});
            // 
            // ToKhai_gridView
            // 
            this.ToKhai_gridView.GridControl = this.ToKhai_gridControl;
            this.ToKhai_gridView.Name = "ToKhai_gridView";
            // 
            // ToKhai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 697);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ToKhai";
            this.Text = "ToKhai";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_PhanTramThue_textEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_Loai_searchLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_ToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_ToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_FromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_FromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToKhai_gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit ToKhai_ToDate;
        private DevExpress.XtraEditors.DateEdit ToKhai_FromDate;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl ToKhai_gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView ToKhai_gridView;
        private DevExpress.XtraEditors.SimpleButton ToKhai_LaySoLieu_simpleButton;
        private DevExpress.XtraEditors.TextEdit ToKhai_PhanTramThue_textEdit;
        private DevExpress.XtraEditors.SearchLookUpEdit ToKhai_Loai_searchLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}