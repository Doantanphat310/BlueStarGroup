namespace BSClient.Base
{
    partial class BaseFormList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFormList));
            this.ToolBar_Panel = new DevExpress.Utils.Layout.StackPanel();
            this.Add_Item = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.Add_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Delete_Item = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.Delete_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Save_Item = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.Save_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar_Panel)).BeginInit();
            this.ToolBar_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Add_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delete_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Save_Item)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar_Panel
            // 
            this.ToolBar_Panel.Controls.Add(this.Add_Item);
            this.ToolBar_Panel.Controls.Add(this.Delete_Item);
            this.ToolBar_Panel.Controls.Add(this.Save_Item);
            this.ToolBar_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar_Panel.Location = new System.Drawing.Point(0, 0);
            this.ToolBar_Panel.Name = "ToolBar_Panel";
            this.ToolBar_Panel.Size = new System.Drawing.Size(558, 40);
            this.ToolBar_Panel.TabIndex = 6;
            // 
            // Add_Item
            // 
            this.Add_Item.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Add_Button});
            this.Add_Item.Location = new System.Drawing.Point(3, -1);
            this.Add_Item.Name = "Add_Item";
            this.Add_Item.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.Add_Item.Size = new System.Drawing.Size(98, 42);
            this.Add_Item.TabIndex = 3;
            // 
            // Add_Button
            // 
            this.Add_Button.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Right)});
            this.Add_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Add_Button.ImageOptions.Image")));
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Add_Button.Text = "Thêm";
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Delete_Item
            // 
            this.Delete_Item.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Delete_Button});
            this.Delete_Item.Location = new System.Drawing.Point(107, -1);
            this.Delete_Item.Name = "Delete_Item";
            this.Delete_Item.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.Delete_Item.Size = new System.Drawing.Size(98, 42);
            this.Delete_Item.TabIndex = 4;
            // 
            // Delete_Button
            // 
            this.Delete_Button.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.Delete_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Button.ImageOptions.Image")));
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Delete_Button.Text = "Xóa";
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Save_Item
            // 
            this.Save_Item.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.Save_Button});
            this.Save_Item.Location = new System.Drawing.Point(211, -1);
            this.Save_Item.Name = "Save_Item";
            this.Save_Item.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.Save_Item.Size = new System.Drawing.Size(117, 42);
            this.Save_Item.TabIndex = 6;
            // 
            // Save_Button
            // 
            this.Save_Button.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.Save_Button.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Save_Button.ImageOptions.Image")));
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Save_Button.Text = "Lưu";
            this.Save_Button.Click += new System.EventHandler(this.Save_Button_Click);
            // 
            // BaseFormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolBar_Panel);
            this.Name = "BaseFormList";
            this.Size = new System.Drawing.Size(558, 365);
            ((System.ComponentModel.ISupportInitialize)(this.ToolBar_Panel)).EndInit();
            this.ToolBar_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Add_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Delete_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Save_Item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel ToolBar_Panel;
        private DevExpress.XtraBars.Navigation.AccordionControl Add_Item;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Add_Button;
        private DevExpress.XtraBars.Navigation.AccordionControl Delete_Item;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Delete_Button;
        private DevExpress.XtraBars.Navigation.AccordionControl Save_Item;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Save_Button;
    }
}
