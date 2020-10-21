namespace DXBlueStarGroup_V3
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.CBE_Voucher = new DevExpress.XtraEditors.ComboBoxEdit();
            this.LKUESearch_Voucher = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CBE_Voucher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKUESearch_Voucher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.LKUESearch_Voucher);
            this.panelControl1.Controls.Add(this.CBE_Voucher);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(940, 507);
            this.panelControl1.TabIndex = 0;
            // 
            // CBE_Voucher
            // 
            this.CBE_Voucher.Location = new System.Drawing.Point(20, 70);
            this.CBE_Voucher.Name = "CBE_Voucher";
            this.CBE_Voucher.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CBE_Voucher.Properties.DropDownRows = 8;
            this.CBE_Voucher.Size = new System.Drawing.Size(196, 20);
            this.CBE_Voucher.TabIndex = 0;
            // 
            // LKUESearch_Voucher
            // 
            this.LKUESearch_Voucher.Location = new System.Drawing.Point(340, 191);
            this.LKUESearch_Voucher.Name = "LKUESearch_Voucher";
            this.LKUESearch_Voucher.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LKUESearch_Voucher.Properties.PopupView = this.searchLookUpEdit1View;
            this.LKUESearch_Voucher.Size = new System.Drawing.Size(229, 20);
            this.LKUESearch_Voucher.TabIndex = 3;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.CBE_Voucher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LKUESearch_Voucher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit CBE_Voucher;
        private DevExpress.XtraEditors.SearchLookUpEdit LKUESearch_Voucher;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
    }
}
