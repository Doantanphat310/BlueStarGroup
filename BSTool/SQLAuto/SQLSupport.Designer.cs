namespace SQLAuto
{
    partial class SQLSupport
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
            this.Main_GridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CleanData_CheckBox = new System.Windows.Forms.CheckBox();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.Run_Button = new System.Windows.Forms.Button();
            this.Load_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Model_CheckBox = new System.Windows.Forms.CheckBox();
            this.SP_CheckBox = new System.Windows.Forms.CheckBox();
            this.DAO_CheckBox = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_GridView
            // 
            this.Main_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Main_GridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_GridView.Location = new System.Drawing.Point(183, 40);
            this.Main_GridView.MultiSelect = false;
            this.Main_GridView.Name = "Main_GridView";
            this.Main_GridView.ReadOnly = true;
            this.Main_GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Main_GridView.Size = new System.Drawing.Size(676, 442);
            this.Main_GridView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CleanData_CheckBox);
            this.panel1.Controls.Add(this.Exit_Button);
            this.panel1.Controls.Add(this.Run_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 45);
            this.panel1.TabIndex = 1;
            // 
            // CleanData_CheckBox
            // 
            this.CleanData_CheckBox.AutoSize = true;
            this.CleanData_CheckBox.Checked = true;
            this.CleanData_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CleanData_CheckBox.Location = new System.Drawing.Point(12, 17);
            this.CleanData_CheckBox.Name = "CleanData_CheckBox";
            this.CleanData_CheckBox.Size = new System.Drawing.Size(132, 17);
            this.CleanData_CheckBox.TabIndex = 5;
            this.CleanData_CheckBox.Text = "Xóa thư mục và tạo lại";
            this.CleanData_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_Button.Location = new System.Drawing.Point(781, 10);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(75, 28);
            this.Exit_Button.TabIndex = 0;
            this.Exit_Button.Text = "Thoát";
            this.Exit_Button.UseVisualStyleBackColor = true;
            // 
            // Run_Button
            // 
            this.Run_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Run_Button.Location = new System.Drawing.Point(700, 10);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(75, 28);
            this.Run_Button.TabIndex = 0;
            this.Run_Button.Text = "Chạy";
            this.Run_Button.UseVisualStyleBackColor = true;
            this.Run_Button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // Load_Button
            // 
            this.Load_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Load_Button.Location = new System.Drawing.Point(772, 5);
            this.Load_Button.Name = "Load_Button";
            this.Load_Button.Size = new System.Drawing.Size(75, 28);
            this.Load_Button.TabIndex = 0;
            this.Load_Button.Text = "Load Data";
            this.Load_Button.UseVisualStyleBackColor = true;
            this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Model_CheckBox);
            this.panel2.Controls.Add(this.SP_CheckBox);
            this.panel2.Controls.Add(this.DAO_CheckBox);
            this.panel2.Controls.Add(this.Load_Button);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(859, 40);
            this.panel2.TabIndex = 3;
            // 
            // Model_CheckBox
            // 
            this.Model_CheckBox.AutoSize = true;
            this.Model_CheckBox.Checked = true;
            this.Model_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Model_CheckBox.Location = new System.Drawing.Point(112, 12);
            this.Model_CheckBox.Name = "Model_CheckBox";
            this.Model_CheckBox.Size = new System.Drawing.Size(55, 17);
            this.Model_CheckBox.TabIndex = 4;
            this.Model_CheckBox.Text = "Model";
            this.Model_CheckBox.UseVisualStyleBackColor = true;
            // 
            // SP_CheckBox
            // 
            this.SP_CheckBox.AutoSize = true;
            this.SP_CheckBox.Checked = true;
            this.SP_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SP_CheckBox.Location = new System.Drawing.Point(12, 12);
            this.SP_CheckBox.Name = "SP_CheckBox";
            this.SP_CheckBox.Size = new System.Drawing.Size(94, 17);
            this.SP_CheckBox.TabIndex = 3;
            this.SP_CheckBox.Text = "Store Procture";
            this.SP_CheckBox.UseVisualStyleBackColor = true;
            // 
            // DAO_CheckBox
            // 
            this.DAO_CheckBox.AutoSize = true;
            this.DAO_CheckBox.Checked = true;
            this.DAO_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DAO_CheckBox.Location = new System.Drawing.Point(173, 12);
            this.DAO_CheckBox.Name = "DAO_CheckBox";
            this.DAO_CheckBox.Size = new System.Drawing.Size(49, 17);
            this.DAO_CheckBox.TabIndex = 2;
            this.DAO_CheckBox.Text = "DAO";
            this.DAO_CheckBox.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 40);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(183, 442);
            this.dataGridView1.TabIndex = 4;
            // 
            // SQLSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main_GridView);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SQLSupport";
            this.Size = new System.Drawing.Size(859, 527);
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Main_GridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button Run_Button;
        private System.Windows.Forms.Button Load_Button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox Model_CheckBox;
        private System.Windows.Forms.CheckBox SP_CheckBox;
        private System.Windows.Forms.CheckBox DAO_CheckBox;
        private System.Windows.Forms.CheckBox CleanData_CheckBox;
    }
}

