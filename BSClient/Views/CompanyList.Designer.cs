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
            this.Edit_Button = new DevExpress.XtraEditors.SimpleButton();
            this.AddNew_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Delete_Button = new DevExpress.XtraEditors.SimpleButton();
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
            this.Company_GridControl.TabIndex = 0;
            this.Company_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Company_GridView});
            // 
            // Company_GridView
            // 
            this.Company_GridView.GridControl = this.Company_GridControl;
            this.Company_GridView.Name = "Company_GridView";
            this.Company_GridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.Company_GridView_RowClick);
            // 
            // Company_GroupControl
            // 
            this.Company_GroupControl.Controls.Add(this.Company_GridControl);
            this.Company_GroupControl.Controls.Add(this.UserButton_Panel);
            this.Company_GroupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Company_GroupControl.Location = new System.Drawing.Point(0, 0);
            this.Company_GroupControl.Name = "Company_GroupControl";
            this.Company_GroupControl.Size = new System.Drawing.Size(838, 540);
            this.Company_GroupControl.TabIndex = 0;
            this.Company_GroupControl.Text = "Danh mục Công ty";
            // 
            // UserButton_Panel
            // 
            this.UserButton_Panel.Controls.Add(this.Edit_Button);
            this.UserButton_Panel.Controls.Add(this.AddNew_Button);
            this.UserButton_Panel.Controls.Add(this.Delete_Button);
            this.UserButton_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserButton_Panel.Location = new System.Drawing.Point(2, 493);
            this.UserButton_Panel.Name = "UserButton_Panel";
            this.UserButton_Panel.Size = new System.Drawing.Size(834, 45);
            this.UserButton_Panel.TabIndex = 1;
            // 
            // Edit_Button
            // 
            this.Edit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Edit_Button.ImageOptions.Image")));
            this.Edit_Button.Location = new System.Drawing.Point(645, 7);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(90, 35);
            this.Edit_Button.TabIndex = 1;
            this.Edit_Button.Text = "Sửa";
            this.Edit_Button.Click += new System.EventHandler(this.Edit_Button_Click);
            // 
            // AddNew_Button
            // 
            this.AddNew_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNew_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("AddNew_Button.ImageOptions.Image")));
            this.AddNew_Button.Location = new System.Drawing.Point(549, 7);
            this.AddNew_Button.Name = "AddNew_Button";
            this.AddNew_Button.Size = new System.Drawing.Size(90, 35);
            this.AddNew_Button.TabIndex = 0;
            this.AddNew_Button.Text = "Thêm";
            this.AddNew_Button.Click += new System.EventHandler(this.AddNew_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Button.ImageOptions.Image")));
            this.Delete_Button.Location = new System.Drawing.Point(741, 7);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(90, 35);
            this.Delete_Button.TabIndex = 2;
            this.Delete_Button.Text = "Xóa";
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
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
        private DevExpress.XtraEditors.SimpleButton Edit_Button;
        private DevExpress.XtraEditors.SimpleButton AddNew_Button;
    }
}
