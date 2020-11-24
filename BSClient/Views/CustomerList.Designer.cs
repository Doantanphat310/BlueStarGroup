namespace BSClient.Views
{
    partial class CustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerList));
            this.Customer_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Customer_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.User_Group = new DevExpress.XtraEditors.GroupControl();
            this.UserButton_Panel = new System.Windows.Forms.Panel();
            this.Delete_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Save_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_Group)).BeginInit();
            this.User_Group.SuspendLayout();
            this.UserButton_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Customer_GridControl
            // 
            this.Customer_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Customer_GridControl.Location = new System.Drawing.Point(2, 39);
            this.Customer_GridControl.MainView = this.Customer_GridView;
            this.Customer_GridControl.Name = "Customer_GridControl";
            this.Customer_GridControl.Size = new System.Drawing.Size(834, 454);
            this.Customer_GridControl.TabIndex = 1;
            this.Customer_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Customer_GridView});
            // 
            // Customer_GridView
            // 
            this.Customer_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.Customer_GridView.GridControl = this.Customer_GridControl;
            this.Customer_GridView.Name = "Customer_GridView";
            this.Customer_GridView.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.Customer_GridView_InvalidRowException);
            this.Customer_GridView.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.Customer_GridView_RowDeleted);
            this.Customer_GridView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.Customer_GridView_ValidateRow);
            this.Customer_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Customer_GridView_RowUpdated);
            // 
            // User_Group
            // 
            this.User_Group.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("User_Group.CaptionImageOptions.Image")));
            this.User_Group.Controls.Add(this.Customer_GridControl);
            this.User_Group.Controls.Add(this.UserButton_Panel);
            this.User_Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.User_Group.Location = new System.Drawing.Point(0, 0);
            this.User_Group.Name = "User_Group";
            this.User_Group.Size = new System.Drawing.Size(838, 540);
            this.User_Group.TabIndex = 7;
            this.User_Group.Text = "Danh mục Khách hàng";
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
            // CustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.User_Group);
            this.Name = "CustomerList";
            this.Size = new System.Drawing.Size(838, 540);
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.User_Group)).EndInit();
            this.User_Group.ResumeLayout(false);
            this.UserButton_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Customer_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Customer_GridView;
        private DevExpress.XtraEditors.GroupControl User_Group;
        private System.Windows.Forms.Panel UserButton_Panel;
        private DevExpress.XtraEditors.SimpleButton Delete_Button;
        private DevExpress.XtraEditors.SimpleButton Cancel_Button;
        private DevExpress.XtraEditors.SimpleButton Save_Button;
    }
}
