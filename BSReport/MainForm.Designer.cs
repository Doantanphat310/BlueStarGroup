namespace BSReport
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
            this.ChungTuGhiSo_Button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChungTuGhiSo_Button
            // 
            this.ChungTuGhiSo_Button.Location = new System.Drawing.Point(12, 12);
            this.ChungTuGhiSo_Button.Name = "ChungTuGhiSo_Button";
            this.ChungTuGhiSo_Button.Size = new System.Drawing.Size(97, 28);
            this.ChungTuGhiSo_Button.TabIndex = 0;
            this.ChungTuGhiSo_Button.Text = "Chứng từ ghi sổ";
            this.ChungTuGhiSo_Button.UseVisualStyleBackColor = true;
            this.ChungTuGhiSo_Button.Click += new System.EventHandler(this.ChungTuGhiSo_Button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(540, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ChungTuGhiSo_Button);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChungTuGhiSo_Button;
        private System.Windows.Forms.Button button2;
    }
}