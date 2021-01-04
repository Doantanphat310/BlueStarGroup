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
        private int LoginCount = 0;

        private List<Users> Users { get; set; }

        public Login()
        {
            InitializeComponent();

#if DEBUG
            UserID_TextBox.Text = "admin";
            Password_TextBox.Text = "Ab123456";
#endif

            using (UserController controller = new UserController())
            {
                Users = controller.GetUsers();
            }
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
                Users user = Users?.Find(o => o.UserID == userID);

                if (user != null && ClientCommon.IsCheckPass(Password_TextBox.Text, user.Password))
                {
                    UserInfo.UserID = user.UserID;
                    UserInfo.UserName = user.UserName;
                    UserInfo.UserRole = user.UserRole;
                    UserInfo.Password = user.Password;
                    UserInfo.Address = user.Address;
                    UserInfo.Phone = user.Phone;

                    List<UserRoleCompany> companys = controller.GetUserRoleCompany(UserInfo.UserID);

                    this.Company_LookUpEdit.SetupLookUpEdit("CompanyID", "CompanyName", companys);
                    this.Company_LookUpEdit.ItemIndex = 0;

                    return true;
                }
                else
                {
                    LoginCount++;
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
                if (LoginCount > 4)
                {
                    MessageBoxHelper.ShowInfoMessage("Bạn đã nhập sai liên tiếp.\r\nVui lòng đóng phần mềm và thử lại!");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    if (this.IsLogin())
                    {
                        LoginCount = 0;
                        SetEnable(true);
                    }
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
                SetUserInfo();
                Company_LookUpEdit.Properties.DataSource = null;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void SetUserInfo(Users user = null)
        {
            if (user == null)
            {
                user = new Users();
            }

            UserInfo.UserID = user.UserID;
            UserInfo.UserName = user.UserName;
            UserInfo.UserRole = user.UserRole;
            UserInfo.Password = user.Password;
            UserInfo.Address = user.Address;
            UserInfo.Phone = user.Phone;
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

            UserInfo.UserRole = selected.UserRoleValue;
            UserInfo.CompanyID = selected.CompanyID;

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
    }
}