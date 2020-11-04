namespace DXBlueStarGroup_V3
{
    partial class UserManageControl
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
            this.BTUpdate = new System.Windows.Forms.Button();
            this.BTDelete = new System.Windows.Forms.Button();
            this.BTInsert = new System.Windows.Forms.Button();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTUpdate
            // 
            this.BTUpdate.Location = new System.Drawing.Point(434, 143);
            this.BTUpdate.Name = "BTUpdate";
            this.BTUpdate.Size = new System.Drawing.Size(75, 23);
            this.BTUpdate.TabIndex = 0;
            this.BTUpdate.Text = "Sửa";
            this.BTUpdate.UseVisualStyleBackColor = true;
            // 
            // BTDelete
            // 
            this.BTDelete.Location = new System.Drawing.Point(305, 143);
            this.BTDelete.Name = "BTDelete";
            this.BTDelete.Size = new System.Drawing.Size(75, 23);
            this.BTDelete.TabIndex = 0;
            this.BTDelete.Text = "Xóa";
            this.BTDelete.UseVisualStyleBackColor = true;
            // 
            // BTInsert
            // 
            this.BTInsert.Location = new System.Drawing.Point(181, 143);
            this.BTInsert.Name = "BTInsert";
            this.BTInsert.Size = new System.Drawing.Size(75, 23);
            this.BTInsert.TabIndex = 0;
            this.BTInsert.Text = "Thêm";
            this.BTInsert.UseVisualStyleBackColor = true;
            this.BTInsert.Click += new System.EventHandler(this.BTInsert_Click);
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(305, 56);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(204, 20);
            this.txtuser.TabIndex = 1;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(305, 82);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(204, 20);
            this.txtpass.TabIndex = 1;
            // 
            // UserManageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.BTInsert);
            this.Controls.Add(this.BTDelete);
            this.Controls.Add(this.BTUpdate);
            this.Name = "UserManageControl";
            this.Size = new System.Drawing.Size(683, 491);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTUpdate;
        private System.Windows.Forms.Button BTDelete;
        private System.Windows.Forms.Button BTInsert;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpass;
    }
}
