namespace BSClient.Controls
{
    partial class ErrorBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorBox));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Error_MemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.Exit_Button = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error_MemoEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Exit_Button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Error_MemoEdit, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 318);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Error_MemoEdit
            // 
            this.Error_MemoEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Error_MemoEdit.Location = new System.Drawing.Point(3, 3);
            this.Error_MemoEdit.Name = "Error_MemoEdit";
            this.Error_MemoEdit.Size = new System.Drawing.Size(684, 269);
            this.Error_MemoEdit.TabIndex = 0;
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Exit_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Exit_Button.ImageOptions.Image")));
            this.Exit_Button.Location = new System.Drawing.Point(604, 280);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(83, 32);
            this.Exit_Button.TabIndex = 9;
            this.Exit_Button.Text = "Thoát";
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // ErrorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 318);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ErrorBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lỗi";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Error_MemoEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.MemoEdit Error_MemoEdit;
        private DevExpress.XtraEditors.SimpleButton Exit_Button;
    }
}