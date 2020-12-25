namespace SQLAuto
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.SQLSupport_TabPage = new System.Windows.Forms.TabPage();
            this.sqlSupport1 = new SQLAuto.SQLSupport();
            this.ExcelSupport_TabPage = new System.Windows.Forms.TabPage();
            this.excelUC1 = new SQLAuto.ExcelUC();
            this.tabControl1.SuspendLayout();
            this.SQLSupport_TabPage.SuspendLayout();
            this.ExcelSupport_TabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SQLSupport_TabPage);
            this.tabControl1.Controls.Add(this.ExcelSupport_TabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1071, 598);
            this.tabControl1.TabIndex = 0;
            // 
            // SQLSupport_TabPage
            // 
            this.SQLSupport_TabPage.Controls.Add(this.sqlSupport1);
            this.SQLSupport_TabPage.Location = new System.Drawing.Point(4, 22);
            this.SQLSupport_TabPage.Name = "SQLSupport_TabPage";
            this.SQLSupport_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SQLSupport_TabPage.Size = new System.Drawing.Size(1063, 572);
            this.SQLSupport_TabPage.TabIndex = 0;
            this.SQLSupport_TabPage.Text = "SQL";
            this.SQLSupport_TabPage.UseVisualStyleBackColor = true;
            // 
            // sqlSupport1
            // 
            this.sqlSupport1.ColumnData = null;
            this.sqlSupport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlSupport1.Location = new System.Drawing.Point(3, 3);
            this.sqlSupport1.Name = "sqlSupport1";
            this.sqlSupport1.Size = new System.Drawing.Size(1057, 566);
            this.sqlSupport1.TabIndex = 0;
            // 
            // ExcelSupport_TabPage
            // 
            this.ExcelSupport_TabPage.Controls.Add(this.excelUC1);
            this.ExcelSupport_TabPage.Location = new System.Drawing.Point(4, 22);
            this.ExcelSupport_TabPage.Name = "ExcelSupport_TabPage";
            this.ExcelSupport_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ExcelSupport_TabPage.Size = new System.Drawing.Size(1063, 572);
            this.ExcelSupport_TabPage.TabIndex = 1;
            this.ExcelSupport_TabPage.Text = "Excel";
            this.ExcelSupport_TabPage.UseVisualStyleBackColor = true;
            // 
            // excelUC1
            // 
            this.excelUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.excelUC1.Location = new System.Drawing.Point(3, 3);
            this.excelUC1.Name = "excelUC1";
            this.excelUC1.Size = new System.Drawing.Size(1057, 566);
            this.excelUC1.TabIndex = 0;
            this.excelUC1.Vouchers = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 598);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.SQLSupport_TabPage.ResumeLayout(false);
            this.ExcelSupport_TabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SQLSupport_TabPage;
        private System.Windows.Forms.TabPage ExcelSupport_TabPage;
        private SQLSupport sqlSupport1;
        private ExcelUC excelUC1;
    }
}