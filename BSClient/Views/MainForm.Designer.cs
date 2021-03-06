﻿namespace BSClient
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
            this.Content = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ACE_Voucher = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ACE_Company = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.Custommers_Button = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementAccountGroup = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementHangHoa = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.ACE_User = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement10 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Content.Appearance.Options.UseBackColor = true;
            this.Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Content.Location = new System.Drawing.Point(173, 27);
            this.Content.Margin = new System.Windows.Forms.Padding(2);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(841, 736);
            this.Content.TabIndex = 0;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement4});
            this.accordionControl1.Location = new System.Drawing.Point(0, 27);
            this.accordionControl1.Margin = new System.Windows.Forms.Padding(2);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(173, 736);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ACE_Voucher,
            this.accordionControlElement3});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Công việc mỗi ngày";
            // 
            // ACE_Voucher
            // 
            this.ACE_Voucher.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.ACE_Voucher.Name = "ACE_Voucher";
            this.ACE_Voucher.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ACE_Voucher.Text = "Nhập chứng từ";
            this.ACE_Voucher.Click += new System.EventHandler(this.ACE_Voucher_Click);
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Text = "Báo cáo";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.ACE_Company,
            this.Custommers_Button,
            this.accordionControlElementAccountGroup,
            this.accordionControlElementHangHoa,
            this.ACE_User,
            this.accordionControlElement10});
            this.accordionControlElement4.Expanded = true;
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Text = "Quản trị hệ thống";
            // 
            // ACE_Company
            // 
            this.ACE_Company.Name = "ACE_Company";
            this.ACE_Company.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ACE_Company.Text = "Thông tin doanh nghiệp";
            this.ACE_Company.Click += new System.EventHandler(this.ACE_Company_Click);
            // 
            // Custommers_Button
            // 
            this.Custommers_Button.Name = "Custommers_Button";
            this.Custommers_Button.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.Custommers_Button.Text = "Đối tượng - Khách hàng";
            this.Custommers_Button.Click += new System.EventHandler(this.Custommers_Button_Click);
            // 
            // accordionControlElementAccountGroup
            // 
            this.accordionControlElementAccountGroup.Name = "accordionControlElementAccountGroup";
            this.accordionControlElementAccountGroup.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementAccountGroup.Text = "Hệ thống Tài Khoản Kế Toán - Sổ cái";
            this.accordionControlElementAccountGroup.Click += new System.EventHandler(this.accordionControlElementAccountGroup_Click);
            // 
            // accordionControlElementHangHoa
            // 
            this.accordionControlElementHangHoa.Name = "accordionControlElementHangHoa";
            this.accordionControlElementHangHoa.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementHangHoa.Text = "Hàng hóa";
            this.accordionControlElementHangHoa.Click += new System.EventHandler(this.accordionControlElementHangHoa_Click);
            // 
            // ACE_User
            // 
            this.ACE_User.Name = "ACE_User";
            this.ACE_User.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.ACE_User.Text = "Người dùng";
            this.ACE_User.Click += new System.EventHandler(this.ACE_User_Click);
            // 
            // accordionControlElement10
            // 
            this.accordionControlElement10.Name = "accordionControlElement10";
            this.accordionControlElement10.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement10.Text = "Nhập số dư";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Margin = new System.Windows.Forms.Padding(2);
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1014, 27);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // MainForm
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 763);
            this.ControlContainer = this.Content;
            this.Controls.Add(this.Content);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.DoubleBuffered = true;
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.NavigationControl = this.accordionControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BlueStarGroup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer Content;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_Voucher;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_User;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementAccountGroup;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementHangHoa;
        private DevExpress.XtraBars.Navigation.AccordionControlElement Custommers_Button;
        private DevExpress.XtraBars.Navigation.AccordionControlElement ACE_Company;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement10;
    }
}