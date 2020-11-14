namespace BSClient.Controls
{
    partial class ButtonGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonGroup));
            this.New_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Button_Panel = new DevExpress.Utils.Layout.StackPanel();
            this.Delete_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Edit_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Save_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Button_Panel)).BeginInit();
            this.Button_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // New_Button
            // 
            this.New_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("New_Button.ImageOptions.Image")));
            this.New_Button.Location = new System.Drawing.Point(3, 5);
            this.New_Button.Name = "New_Button";
            this.New_Button.Size = new System.Drawing.Size(95, 38);
            this.New_Button.TabIndex = 0;
            this.New_Button.Text = "Thêm";
            // 
            // Button_Panel
            // 
            this.Button_Panel.Controls.Add(this.New_Button);
            this.Button_Panel.Controls.Add(this.Delete_Button);
            this.Button_Panel.Controls.Add(this.Edit_Button);
            this.Button_Panel.Controls.Add(this.Save_Button);
            this.Button_Panel.Controls.Add(this.Cancel_Button);
            this.Button_Panel.Location = new System.Drawing.Point(0, 0);
            this.Button_Panel.Name = "Button_Panel";
            this.Button_Panel.ScrollBarSmallChange = 3;
            this.Button_Panel.Size = new System.Drawing.Size(512, 48);
            this.Button_Panel.TabIndex = 1;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Button.ImageOptions.Image")));
            this.Delete_Button.Location = new System.Drawing.Point(104, 5);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(95, 38);
            this.Delete_Button.TabIndex = 1;
            this.Delete_Button.Text = "Xóa";
            // 
            // Edit_Button
            // 
            this.Edit_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Edit_Button.ImageOptions.Image")));
            this.Edit_Button.Location = new System.Drawing.Point(205, 5);
            this.Edit_Button.Name = "Edit_Button";
            this.Edit_Button.Size = new System.Drawing.Size(95, 38);
            this.Edit_Button.TabIndex = 4;
            this.Edit_Button.Text = "Sửa";
            // 
            // Save_Button
            // 
            this.Save_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Save_Button.ImageOptions.Image")));
            this.Save_Button.Location = new System.Drawing.Point(306, 5);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(95, 38);
            this.Save_Button.TabIndex = 2;
            this.Save_Button.Text = "Lưu";
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Cancel_Button.ImageOptions.Image")));
            this.Cancel_Button.Location = new System.Drawing.Point(407, 5);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(95, 38);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "Hủy";
            this.Cancel_Button.Visible = false;
            // 
            // ButtonGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.Button_Panel);
            this.Name = "ButtonGroup";
            this.Size = new System.Drawing.Size(512, 77);
            ((System.ComponentModel.ISupportInitialize)(this.Button_Panel)).EndInit();
            this.Button_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton New_Button;
        private DevExpress.Utils.Layout.StackPanel Button_Panel;
        private DevExpress.XtraEditors.SimpleButton Delete_Button;
        private DevExpress.XtraEditors.SimpleButton Edit_Button;
        private DevExpress.XtraEditors.SimpleButton Save_Button;
        private DevExpress.XtraEditors.SimpleButton Cancel_Button;
    }
}
