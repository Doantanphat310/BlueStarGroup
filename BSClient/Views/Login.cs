using BSClient.Utility;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSClient
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        private readonly string LoginCaption = "Đăng nhập";
        private readonly string AccessCaption = "Truy cập";
        private readonly string CancelCaption = "Quay lại";
        private readonly string ExitCaption = "Thoát";
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
            ExecuteLogin();
        }

        private void ExecuteLogin()
        {
            this.Enabled = false;
            this.Refresh();

            this.Cursor = Cursors.WaitCursor;
            // đã đăng nhập
            if (IsLogined)
            {
                ExecuteAccess();
            }
            // chưa đăng nhập
            else
            {
                if (this.IsLogin())
                {
                    SetEnable(true);
                }
            }

            this.Enabled = true;

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

        private void ExecuteAccess()
        {
            var selected = Company_LookUpEdit.GetSelectedDataRow().CastTo<UserRoleCompany>();
            if (selected == null)
            {
                MessageBoxHelper.ShowInfoMessage("Vui lòng chọn Công ty!");
                Company_LookUpEdit.Focus();
                return;
            }

            using (CompanyController controller = new CompanyController())
            {
                CommonInfo.CompanyInfo = controller.GetCompanyInfo(selected.CompanyID);
            }
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
            Exit_Button.Text = isLogin ? CancelCaption : ExitCaption;

            IsLogined = isLogin;
        }

        //private void UserID_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        ExecuteLogin();
        //    }
        //}

        //private void Password_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter)
        //    {
        //        ExecuteLogin();
        //    }
        //}
    }
}