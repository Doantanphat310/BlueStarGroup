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
            this.GeneralData_Tab = new System.Windows.Forms.TabControl();
            this.SQLSupport_TabPage = new System.Windows.Forms.TabPage();
            this.sqlSupport1 = new SQLAuto.SQLSupport();
            this.ExcelSupport_TabPage = new System.Windows.Forms.TabPage();
            this.excelUC1 = new SQLAuto.ExcelUC();
            this.GenReportData_TabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.InputFolder_OpenFolder = new SQLAuto.UC.OpenFolder();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FileName_TextBox = new System.Windows.Forms.TextBox();
            this.Execute_Button = new System.Windows.Forms.Button();
            this.SQL_TextBox = new System.Windows.Forms.TextBox();
            this.GeneralData_Tab.SuspendLayout();
            this.SQLSupport_TabPage.SuspendLayout();
            this.ExcelSupport_TabPage.SuspendLayout();
            this.GenReportData_TabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralData_Tab
            // 
            this.GeneralData_Tab.Controls.Add(this.SQLSupport_TabPage);
            this.GeneralData_Tab.Controls.Add(this.ExcelSupport_TabPage);
            this.GeneralData_Tab.Controls.Add(this.GenReportData_TabPage);
            this.GeneralData_Tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneralData_Tab.Location = new System.Drawing.Point(0, 0);
            this.GeneralData_Tab.Name = "GeneralData_Tab";
            this.GeneralData_Tab.SelectedIndex = 0;
            this.GeneralData_Tab.Size = new System.Drawing.Size(1071, 598);
            this.GeneralData_Tab.TabIndex = 0;
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
            // GenReportData_TabPage
            // 
            this.GenReportData_TabPage.Controls.Add(this.tableLayoutPanel1);
            this.GenReportData_TabPage.Location = new System.Drawing.Point(4, 22);
            this.GenReportData_TabPage.Name = "GenReportData_TabPage";
            this.GenReportData_TabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GenReportData_TabPage.Size = new System.Drawing.Size(1063, 572);
            this.GenReportData_TabPage.TabIndex = 2;
            this.GenReportData_TabPage.Text = "Tạo Dữ Liệu";
            this.GenReportData_TabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.InputFolder_OpenFolder, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.FileName_TextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Execute_Button, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.SQL_TextBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1057, 566);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // InputFolder_OpenFolder
            // 
            this.InputFolder_OpenFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputFolder_OpenFolder.FileName = "";
            this.InputFolder_OpenFolder.Location = new System.Drawing.Point(87, 3);
            this.InputFolder_OpenFolder.Name = "InputFolder_OpenFolder";
            this.InputFolder_OpenFolder.Size = new System.Drawing.Size(967, 26);
            this.InputFolder_OpenFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thư mục chứa";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên file";
            // 
            // FileName_TextBox
            // 
            this.FileName_TextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FileName_TextBox.Location = new System.Drawing.Point(87, 38);
            this.FileName_TextBox.Name = "FileName_TextBox";
            this.FileName_TextBox.Size = new System.Drawing.Size(213, 20);
            this.FileName_TextBox.TabIndex = 3;
            // 
            // Execute_Button
            // 
            this.Execute_Button.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Execute_Button.Location = new System.Drawing.Point(979, 538);
            this.Execute_Button.Name = "Execute_Button";
            this.Execute_Button.Size = new System.Drawing.Size(75, 23);
            this.Execute_Button.TabIndex = 4;
            this.Execute_Button.Text = "Thực hiện";
            this.Execute_Button.UseVisualStyleBackColor = true;
            this.Execute_Button.Click += new System.EventHandler(this.Execute_Button_Click);
            // 
            // SQL_TextBox
            // 
            this.SQL_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SQL_TextBox.Location = new System.Drawing.Point(87, 67);
            this.SQL_TextBox.Multiline = true;
            this.SQL_TextBox.Name = "SQL_TextBox";
            this.SQL_TextBox.Size = new System.Drawing.Size(967, 464);
            this.SQL_TextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 598);
            this.Controls.Add(this.GeneralData_Tab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.GeneralData_Tab.ResumeLayout(false);
            this.SQLSupport_TabPage.ResumeLayout(false);
            this.ExcelSupport_TabPage.ResumeLayout(false);
            this.GenReportData_TabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl GeneralData_Tab;
        private System.Windows.Forms.TabPage SQLSupport_TabPage;
        private System.Windows.Forms.TabPage ExcelSupport_TabPage;
        private SQLSupport sqlSupport1;
        private ExcelUC excelUC1;
        private System.Windows.Forms.TabPage GenReportData_TabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UC.OpenFolder InputFolder_OpenFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FileName_TextBox;
        private System.Windows.Forms.Button Execute_Button;
        private System.Windows.Forms.TextBox SQL_TextBox;
    }
}