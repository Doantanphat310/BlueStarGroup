namespace BSClient.Views
{
    partial class CompanyList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyList));
            this.Company_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Company_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Company_GroupControl = new DevExpress.XtraEditors.GroupControl();
            this.UserButton_Panel = new System.Windows.Forms.Panel();
            this.Delete_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Save_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Company_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_GroupControl)).BeginInit();
            this.Company_GroupControl.SuspendLayout();
            this.UserButton_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Company_GridControl
            // 
            this.Company_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Company_GridControl.Location = new System.Drawing.Point(2, 20);
            this.Company_GridControl.MainView = this.Company_GridView;
            this.Company_GridControl.Name = "Company_GridControl";
            this.Company_GridControl.Size = new System.Drawing.Size(834, 473);
            this.Company_GridControl.TabIndex = 1;
            this.Company_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Company_GridView});
            // 
            // Company_GridView
            // 
            this.Company_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.Company_GridView.GridControl = this.Company_GridControl;
            this.Company_GridView.Name = "Company_GridView";
            this.Company_GridView.OptionsBehavior.ReadOnly = true;
            this.Company_GridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.Company_GridView_InvalidRowException);
            this.Company_GridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.Company_GridView_RowDeleted);
            this.Company_GridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.Company_GridView_ValidateRow);
            this.Company_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Company_GridView_RowUpdated);
            // 
            // Company_GroupControl
            // 
            this.Company_GroupControl.Controls.Add(this.Company_GridControl);
            this.Company_GroupControl.Controls.Add(this.UserButton_Panel);
            this.Company_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Company_GroupControl.Location = new System.Drawing.Point(0, 0);
            this.Company_GroupControl.Name = "Company_GroupControl";
            this.Company_GroupControl.Size = new System.Drawing.Size(838, 540);
            this.Company_GroupControl.TabIndex = 7;
            this.Company_GroupControl.Text = "Danh mục Công ty";
            // 
            // UserButton_Panel
            // 
            this.UserButton_Panel.Controls.Add(this.Delete_Button);
            this.UserButton_Panel.Controls.Add(this.Cancel_Button);
            this.UserButton_Panel.Controls.Add(this.Save_Button);
            this.UserButton_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserButton_Panel.Location = new System.Drawing.Point(2, 493);
            this.UserButton_Panel.Name = "UserButton_Panel";
            this.UserButton_Panel.Size = new System.Drawing.Size(834, 45);
            this.UserButton_Panel.TabIndex = 5;
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Button.ImageOptions.Image")));
            this.Delete_Button.Location = new System.Drawing.Point(547, 6);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(90, 35);
            this.Delete_Button.TabIndex = 6;
            this.Delete_Button.Text = "Xóa";
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.ImageOptions.Image")));
            this.Cancel_Button.Location = new System.Drawing.Point(739, 6);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(90, 35);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "Hủy";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Save_Button.ImageOptions.Image")));
            this.Save_Button.Location = new System.Drawing.Point(643, 6);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(90, 35);
            this.Save_Button.TabIndex = 7;
            this.Save_Button.Text = "Lưu";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // CompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Company_GroupControl);
            this.Name = "CompanyList";
            this.Size = new System.Drawing.Size(838, 540);
            ((System.ComponentModel.ISupportInitialize)(this.Company_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_GroupControl)).EndInit();
            this.Company_GroupControl.ResumeLayout(false);
            this.UserButton_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Company_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Company_GridView;
        private DevExpress.XtraEditors.GroupControl Company_GroupControl;
        private System.Windows.Forms.Panel UserButton_Panel;
        private DevExpress.XtraEditors.SimpleButton Delete_Button;
        private DevExpress.XtraEditors.SimpleButton Cancel_Button;
        private DevExpress.XtraEditors.SimpleButton Save_Button;
    }
}
