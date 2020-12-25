namespace SQLAuto.UC
{
    partial class OpenFolder
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
            this.Path_TextBox = new System.Windows.Forms.TextBox();
            this.Select_Button = new System.Windows.Forms.Button();
            this.Main_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Main_TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Path_TextBox
            // 
            this.Path_TextBox.AllowDrop = true;
            this.Path_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Path_TextBox.Location = new System.Drawing.Point(0, 3);
            this.Path_TextBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.Path_TextBox.Multiline = true;
            this.Path_TextBox.Name = "Path_TextBox";
            this.Path_TextBox.Size = new System.Drawing.Size(475, 41);
            this.Path_TextBox.TabIndex = 0;
            // 
            // Select_Button
            // 
            this.Select_Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Select_Button.Location = new System.Drawing.Point(481, 3);
            this.Select_Button.Name = "Select_Button";
            this.Select_Button.Size = new System.Drawing.Size(34, 41);
            this.Select_Button.TabIndex = 1;
            this.Select_Button.Text = "...";
            this.Select_Button.UseVisualStyleBackColor = true;
            this.Select_Button.Click += new System.EventHandler(this.Select_Button_Click);
            // 
            // Main_TableLayoutPanel
            // 
            this.Main_TableLayoutPanel.ColumnCount = 2;
            this.Main_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.Main_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Main_TableLayoutPanel.Controls.Add(this.Select_Button, 1, 0);
            this.Main_TableLayoutPanel.Controls.Add(this.Path_TextBox, 0, 0);
            this.Main_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.Main_TableLayoutPanel.Name = "Main_TableLayoutPanel";
            this.Main_TableLayoutPanel.RowCount = 1;
            this.Main_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Main_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Main_TableLayoutPanel.Size = new System.Drawing.Size(518, 47);
            this.Main_TableLayoutPanel.TabIndex = 3;
            // 
            // OpenFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main_TableLayoutPanel);
            this.Name = "OpenFolder";
            this.Size = new System.Drawing.Size(518, 47);
            this.Main_TableLayoutPanel.ResumeLayout(false);
            this.Main_TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Path_TextBox;
        private System.Windows.Forms.Button Select_Button;
        private System.Windows.Forms.TableLayoutPanel Main_TableLayoutPanel;
    }
}
