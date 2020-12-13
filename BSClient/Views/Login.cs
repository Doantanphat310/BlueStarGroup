using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BSClient
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        private readonly string LoginCaption = "Đăng nhập";
        private readonly string AccessCaption = "Truy cập";
        private bool IsLogined = false;

        public Login()
        {
            InitializeComponent();
        }

        private bool IsLogin()
        {
            string userID = UserID_TextBox.Text;
            if (string.IsNullOrWhiteSpace(userID))
            {
                MessageBoxHelper.ShowInfoMessage("Tên đăng nhập không được trống!");
                UserID_TextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(Password_TextBox.Text))
            {
                MessageBoxHelper.ShowInfoMessage("Mật khẩu không được trống!");
                Password_TextBox.Focus();
                return false;
            }

            using (UserController controller = new UserController())
            {
                UserInfo user = controller.GetUserInfo(userID);

                if (user != null && ClientCommon.IsCheckPass(Password_TextBox.Text, user.Password))
                {
                    CommonInfo.UserInfo = user;

                    List<UserRoleCompany> companys = controller.GetUserRoleCompany(user.UserID);

                    this.Company_LookUpEdit.SetupLookUpEdit("CompanyID", "CompanyName", companys);
                    this.Company_LookUpEdit.ItemIndex = 0;

                    return true;
                }
                else
                {
                    MessageBoxHelper.ShowInfoMessage("Tên đăng nhập hoặc mật khẩu không đúng!");
                    UserID_TextBox.Focus();
                    return false;
                }
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;

            // đã đăng nhập
            if (IsLogined)
            {
                ExcuteAccess();
            }
            // chưa đăng nhập
            else
            {
                if (this.IsLogin())
                {
                    //this.Company_Label.Enabled = true;
                    //this.UserName_Label.Enabled = false;
                    //this.Password_Label.Enabled = false;

                    //Login_Button.Text = AccessCaption;

                    //IsLogined = true;

                    SetEnable(true);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            if (IsLogined)
            {
                SetEnable(false);
                CommonInfo.CompanyInfo = null;
                CommonInfo.UserInfo = null;
                Company_LookUpEdit.Properties.DataSource = null;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void ExcuteAccess()
        {
            var selected = Company_LookUpEdit.GetSelectedDataRow().CastTo<UserRoleCompany>();
            if (selected == null)
            {
                MessageBoxHelper.ShowInfoMessage("Vui lòng chọn Công ty!");
                Company_LookUpEdit.Focus();
                return;
            }

            CommonInfo.CompanyInfo = new Company
            {
                CompanyID = selected.CompanyID,
                CompanyName = selected.CompanyName
            };
            CommonInfo.UserInfo.UserRole = selected.UserRoleName;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetEnable(bool isLogin)
        {
            this.Company_Label.Enabled = isLogin;
            this.UserName_Label.Enabled = !isLogin;
            this.Password_Label.Enabled = !isLogin;

            Login_Button.Text = isLogin ? AccessCaption : LoginCaption;

            IsLogined = isLogin;
        }
    }
}