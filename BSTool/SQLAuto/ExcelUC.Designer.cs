namespace SQLAuto
{
    partial class ExcelUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Process_Label = new System.Windows.Forms.Label();
            this.Convert_Button = new System.Windows.Forms.Button();
            this.Main_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.InputFile_OpenFile = new SQLAuto.UC.OpenFile();
            this.InputFolder_OpenFolder = new SQLAuto.UC.OpenFolder();
            this.Output_OpenFolder = new SQLAuto.UC.OpenFolder();
            this.label1 = new System.Windows.Forms.Label();
            this.Output_Path = new System.Windows.Forms.Label();
            this.Error_Label = new System.Windows.Forms.Label();
            this.Error_TextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Excel_RadioButton = new System.Windows.Forms.RadioButton();
            this.LoadData_Button = new System.Windows.Forms.Button();
            this.FileName_DataGridView = new System.Windows.Forms.DataGridView();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.Main_TableLayoutPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileName_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Process_Label);
            this.panel1.Controls.Add(this.Convert_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 494);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 39);
            this.panel1.TabIndex = 2;
            // 
            // Process_Label
            // 
            this.Process_Label.ForeColor = System.Drawing.Color.Blue;
            this.Process_Label.Location = new System.Drawing.Point(100, 8);
            this.Process_Label.Name = "Process_Label";
            this.Process_Label.Size = new System.Drawing.Size(457, 23);
            this.Process_Label.TabIndex = 1;
            this.Process_Label.Text = "Processing";
            this.Process_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Convert_Button
            // 
            this.Convert_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Convert_Button.Location = new System.Drawing.Point(817, 4);
            this.Convert_Button.Name = "Convert_Button";
            this.Convert_Button.Size = new System.Drawing.Size(117, 27);
            this.Convert_Button.TabIndex = 0;
            this.Convert_Button.Text = "Chuyển đổi dữ liệu";
            this.Convert_Button.UseVisualStyleBackColor = true;
            this.Convert_Button.Click += new System.EventHandler(this.Convert_Button_Click);
            // 
            // Main_TableLayoutPanel
            // 
            this.Main_TableLayoutPanel.ColumnCount = 2;
            this.Main_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.Main_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TableLayoutPanel.Controls.Add(this.panel3, 1, 0);
            this.Main_TableLayoutPanel.Controls.Add(this.Output_OpenFolder, 1, 1);
            this.Main_TableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.Main_TableLayoutPanel.Controls.Add(this.Output_Path, 0, 1);
            this.Main_TableLayoutPanel.Controls.Add(this.Error_Label, 0, 4);
            this.Main_TableLayoutPanel.Controls.Add(this.Error_TextBox, 1, 4);
            this.Main_TableLayoutPanel.Controls.Add(this.panel2, 1, 2);
            this.Main_TableLayoutPanel.Controls.Add(this.FileName_DataGridView, 1, 3);
            this.Main_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.Main_TableLayoutPanel.Name = "Main_TableLayoutPanel";
            this.Main_TableLayoutPanel.RowCount = 5;
            this.Main_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.Main_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.Main_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Main_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.Main_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TableLayoutPanel.Size = new System.Drawing.Size(939, 494);
            this.Main_TableLayoutPanel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.InputFile_OpenFile);
            this.panel3.Controls.Add(this.InputFolder_OpenFolder);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(103, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(833, 29);
            this.panel3.TabIndex = 2;
            // 
            // InputFile_OpenFile
            // 
            this.InputFile_OpenFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.InputFile_OpenFile.FileName = "";
            this.InputFile_OpenFile.Filter = "XML file(*.xml)|*.xml";
            this.InputFile_OpenFile.Location = new System.Drawing.Point(557, 0);
            this.InputFile_OpenFile.Name = "InputFile_OpenFile";
            this.InputFile_OpenFile.Size = new System.Drawing.Size(276, 29);
            this.InputFile_OpenFile.TabIndex = 8;
            this.InputFile_OpenFile.Visible = false;
            // 
            // InputFolder_OpenFolder
            // 
            this.InputFolder_OpenFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputFolder_OpenFolder.FileName = "";
            this.InputFolder_OpenFolder.Location = new System.Drawing.Point(0, 0);
            this.InputFolder_OpenFolder.Name = "InputFolder_OpenFolder";
            this.InputFolder_OpenFolder.Size = new System.Drawing.Size(833, 29);
            this.InputFolder_OpenFolder.TabIndex = 0;
            // 
            // Output_OpenFolder
            // 
            this.Output_OpenFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output_OpenFolder.FileName = "";
            this.Output_OpenFolder.Location = new System.Drawing.Point(103, 38);
            this.Output_OpenFolder.Name = "Output_OpenFolder";
            this.Output_OpenFolder.Size = new System.Drawing.Size(833, 29);
            this.Output_OpenFolder.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input data";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Output_Path
            // 
            this.Output_Path.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output_Path.Location = new System.Drawing.Point(3, 35);
            this.Output_Path.Name = "Output_Path";
            this.Output_Path.Size = new System.Drawing.Size(94, 35);
            this.Output_Path.TabIndex = 2;
            this.Output_Path.Text = "Output";
            this.Output_Path.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Error_Label
            // 
            this.Error_Label.AutoSize = true;
            this.Error_Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.Error_Label.Location = new System.Drawing.Point(3, 365);
            this.Error_Label.Name = "Error_Label";
            this.Error_Label.Size = new System.Drawing.Size(94, 13);
            this.Error_Label.TabIndex = 2;
            this.Error_Label.Text = "Lỗi(nếu có)";
            // 
            // Error_TextBox
            // 
            this.Error_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Error_TextBox.ForeColor = System.Drawing.Color.Red;
            this.Error_TextBox.Location = new System.Drawing.Point(103, 368);
            this.Error_TextBox.Multiline = true;
            this.Error_TextBox.Name = "Error_TextBox";
            this.Error_TextBox.Size = new System.Drawing.Size(833, 123);
            this.Error_TextBox.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.Excel_RadioButton);
            this.panel2.Controls.Add(this.LoadData_Button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(103, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 34);
            this.panel2.TabIndex = 5;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(96, 9);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "XML(.xml)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Excel_RadioButton
            // 
            this.Excel_RadioButton.AutoSize = true;
            this.Excel_RadioButton.Checked = true;
            this.Excel_RadioButton.Location = new System.Drawing.Point(5, 9);
            this.Excel_RadioButton.Name = "Excel_RadioButton";
            this.Excel_RadioButton.Size = new System.Drawing.Size(77, 17);
            this.Excel_RadioButton.TabIndex = 3;
            this.Excel_RadioButton.TabStop = true;
            this.Excel_RadioButton.Text = "Excel(.xlsx)";
            this.Excel_RadioButton.UseVisualStyleBackColor = true;
            this.Excel_RadioButton.CheckedChanged += new System.EventHandler(this.Excel_RadioButton_CheckedChanged);
            // 
            // LoadData_Button
            // 
            this.LoadData_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadData_Button.Location = new System.Drawing.Point(713, 4);
            this.LoadData_Button.Name = "LoadData_Button";
            this.LoadData_Button.Size = new System.Drawing.Size(117, 27);
            this.LoadData_Button.TabIndex = 1;
            this.LoadData_Button.Text = "Load Data";
            this.LoadData_Button.UseVisualStyleBackColor = true;
            this.LoadData_Button.Click += new System.EventHandler(this.LoadData_Button_Click);
            // 
            // FileName_DataGridView
            // 
            this.FileName_DataGridView.AllowUserToAddRows = false;
            this.FileName_DataGridView.AllowUserToDeleteRows = false;
            this.FileName_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileName_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountID,
            this.AccountDetailID,
            this.CustomerID,
            this.FileName});
            this.FileName_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileName_DataGridView.Location = new System.Drawing.Point(103, 113);
            this.FileName_DataGridView.Name = "FileName_DataGridView";
            this.FileName_DataGridView.ReadOnly = true;
            this.FileName_DataGridView.Size = new System.Drawing.Size(833, 249);
            this.FileName_DataGridView.TabIndex = 6;
            // 
            // AccountID
            // 
            this.AccountID.DataPropertyName = "AccountID";
            this.AccountID.HeaderText = "TK";
            this.AccountID.Name = "AccountID";
            this.AccountID.ReadOnly = true;
            // 
            // AccountDetailID
            // 
            this.AccountDetailID.DataPropertyName = "AccountDetailID";
            this.AccountDetailID.HeaderText = "Thống Kê";
            this.AccountDetailID.Name = "AccountDetailID";
            this.AccountDetailID.ReadOnly = true;
            this.AccountDetailID.Width = 80;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "Khách Hàng";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            this.FileName.HeaderText = "Tên File";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 400;
            // 
            // ExcelUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main_TableLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Name = "ExcelUC";
            this.Size = new System.Drawing.Size(939, 533);
            this.panel1.ResumeLayout(false);
            this.Main_TableLayoutPanel.ResumeLayout(false);
            this.Main_TableLayoutPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileName_DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UC.OpenFolder InputFolder_OpenFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel Main_TableLayoutPanel;
        private System.Windows.Forms.Button Convert_Button;
        private System.Windows.Forms.Label Process_Label;
        private UC.OpenFolder Output_OpenFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Output_Path;
        private System.Windows.Forms.Label Error_Label;
        private System.Windows.Forms.TextBox Error_TextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton Excel_RadioButton;
        private System.Windows.Forms.Button LoadData_Button;
        private System.Windows.Forms.Panel panel3;
        private UC.OpenFile InputFile_OpenFile;
        private System.Windows.Forms.DataGridView FileName_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
    }
}
