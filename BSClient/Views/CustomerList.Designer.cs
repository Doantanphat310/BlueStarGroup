namespace BSClient.Views
{
    partial class CustomerList
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
            this.Customer_GridControl = new DevExpress.XtraGrid.GridControl();
            this.Customer_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Customer_GridControl
            // 
            this.Customer_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Customer_GridControl.Location = new System.Drawing.Point(0, 40);
            this.Customer_GridControl.MainView = this.Customer_GridView;
            this.Customer_GridControl.Name = "Customer_GridControl";
            this.Customer_GridControl.Size = new System.Drawing.Size(838, 500);
            this.Customer_GridControl.TabIndex = 1;
            this.Customer_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Customer_GridView});
            // 
            // Customer_GridView
            // 
            this.Customer_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.Customer_GridView.GridControl = this.Customer_GridControl;
            this.Customer_GridView.Name = "Customer_GridView";
            this.Customer_GridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.Customer_GridView_RowUpdated);
            // 
            // CustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Customer_GridControl);
            this.Name = "CustomerList";
            this.Size = new System.Drawing.Size(838, 540);
            this.Controls.SetChildIndex(this.Customer_GridControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl Customer_GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Customer_GridView;
    }
}
