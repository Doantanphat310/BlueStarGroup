namespace BSClient.Views
{
    partial class VAT
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
            this.components = new System.ComponentModel.Container();
            this.dashboardBarAndDockingController1 = new DevExpress.DashboardWin.Native.DashboardBarAndDockingController(this.components);
            this.dashboardBarController1 = new DevExpress.DashboardWin.Bars.DashboardBarController(this.components);
            this.textBoxEditorBarController1 = new DevExpress.DashboardWin.Bars.TextBoxEditorBarController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBarAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBarController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxEditorBarController1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEditorBarController1
            // 
            this.textBoxEditorBarController1.Designer = null;
            // 
            // VAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 627);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VAT";
            this.Text = "Liên kết VAT";
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBarAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardBarController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxEditorBarController1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.DashboardWin.Native.DashboardBarAndDockingController dashboardBarAndDockingController1;
        private DevExpress.DashboardWin.Bars.DashboardBarController dashboardBarController1;
        private DevExpress.DashboardWin.Bars.TextBoxEditorBarController textBoxEditorBarController1;
    }
}