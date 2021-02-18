using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.Utils.Extensions;
using System;
using System.Windows.Forms;

namespace BSClient
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        private bool IsLogined = false;
        private readonly string LoginCaption = "Đăng nhập";
        private readonly string AccessCaption = "Truy cập";
        private int LoginCount = 0;
        private readonly LoginMode Mode;

        public Login(LoginMode mode = LoginMode.None)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.No;
            Mode = mode;
#if DEBUG
            UserID_TextBox.Text = "admin";
            Password_TextBox.Text = "Ab123456";
#endif

            if (mode == LoginMode.ChangeCompany)
            {
                this.Cancel_Button.Visible = true;

                UserID_TextBox.Text = UserInfo.UserID;
                Password_TextBox.Text = UserInfo.Password;
                this.DialogResult = DialogResult.Cancel;

                SetCompanyComboBox();
                SetEnable(true);
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
                Users user = controller.GetUsers()?.Find(o => o.UserID.ToLower() == userID.ToLower());

                if (user != null && ClientCommon.IsCheckPass(Password_TextBox.Text, user.Password))
                {
                    SetUserInfo(user);

                    UserInfo.Companies = controller.GetUserRoleCompany(UserInfo.UserID);

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

        private void SetCompanyComboBox()
        {
            this.Company_LookUpEdit.SetupLookUpEdit("CompanyID", "CompanyName", UserInfo.Companies);

            if (string.IsNullOrWhiteSpace(UserInfo.CompanyID))
            {
                this.Company_LookUpEdit.ItemIndex = 0;
            }
            else
            {
                this.Company_LookUpEdit.EditValue = UserInfo.CompanyID;
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
                        SetCompanyComboBox();
                        SetEnable(true);
                    }
                }
            }

            this.Enabled = true;

            this.Cursor = Cursors.Default;
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void SetUserInfo(Users user = null)
        {
            if (user == null)
            {
                user = new Users();
            }

            UserInfo.UserID = UserID_TextBox.Text;
            UserInfo.UserName = user.UserName;
            UserInfo.UserRole = user.UserRole;
            UserInfo.Password = Password_TextBox.Text;
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

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void SetEnable(bool isLogin)
        {
            this.Company_Label.Enabled = isLogin;
            this.UserName_Label.Enabled = !isLogin;
            this.Password_Label.Enabled = !isLogin;

            Login_Button.Text = isLogin ? AccessCaption : LoginCaption;
            Back_Button.Enabled = isLogin;

            // Khi mode thay đổi cty, nếu chưa login thì ko thể cancel
            if (this.Mode == LoginMode.ChangeCompany)
            {
                Cancel_Button.Enabled = isLogin;
            }

            IsLogined = isLogin;
        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            SetEnable(false);
            CommonInfo.CompanyInfo = null;
            UserInfo.Companies = null;
            SetUserInfo();
            Company_LookUpEdit.Properties.DataSource = null;
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}