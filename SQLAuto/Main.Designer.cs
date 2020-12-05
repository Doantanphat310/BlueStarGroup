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
            this.Main_GridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.Run_Button = new System.Windows.Forms.Button();
            this.Load_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TableName_Label = new System.Windows.Forms.Label();
            this.TableName_TextBox = new System.Windows.Forms.TextBox();
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
            this.Main_GridView.Location = new System.Drawing.Point(183, 38);
            this.Main_GridView.MultiSelect = false;
            this.Main_GridView.Name = "Main_GridView";
            this.Main_GridView.ReadOnly = true;
            this.Main_GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Main_GridView.Size = new System.Drawing.Size(580, 383);
            this.Main_GridView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Exit_Button);
            this.panel1.Controls.Add(this.Run_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 45);
            this.panel1.TabIndex = 1;
            // 
            // Exit_Button
            // 
            this.Exit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit_Button.Location = new System.Drawing.Point(685, 10);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(75, 28);
            this.Exit_Button.TabIndex = 0;
            this.Exit_Button.Text = "Thoát";
            this.Exit_Button.UseVisualStyleBackColor = true;
            // 
            // Run_Button
            // 
            this.Run_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Run_Button.Location = new System.Drawing.Point(604, 10);
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
            this.Load_Button.Location = new System.Drawing.Point(685, 4);
            this.Load_Button.Name = "Load_Button";
            this.Load_Button.Size = new System.Drawing.Size(75, 28);
            this.Load_Button.TabIndex = 0;
            this.Load_Button.Text = "Load";
            this.Load_Button.UseVisualStyleBackColor = true;
            this.Load_Button.Click += new System.EventHandler(this.Load_Button_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TableName_Label);
            this.panel2.Controls.Add(this.Load_Button);
            this.panel2.Controls.Add(this.TableName_TextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 38);
            this.panel2.TabIndex = 3;
            // 
            // TableName_Label
            // 
            this.TableName_Label.AutoSize = true;
            this.TableName_Label.Location = new System.Drawing.Point(12, 12);
            this.TableName_Label.Name = "TableName_Label";
            this.TableName_Label.Size = new System.Drawing.Size(65, 13);
            this.TableName_Label.TabIndex = 1;
            this.TableName_Label.Text = "Table Name";
            // 
            // TableName_TextBox
            // 
            this.TableName_TextBox.Location = new System.Drawing.Point(83, 9);
            this.TableName_TextBox.Name = "TableName_TextBox";
            this.TableName_TextBox.Size = new System.Drawing.Size(163, 20);
            this.TableName_TextBox.TabIndex = 0;
            this.TableName_TextBox.TextChanged += new System.EventHandler(this.TableName_TextBox_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(183, 383);
            this.dataGridView1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 466);
            this.Controls.Add(this.Main_GridView);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.Main_GridView)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Label TableName_Label;
        private System.Windows.Forms.TextBox TableName_TextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

