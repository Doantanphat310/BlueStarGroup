using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BSServer.Controllers;
using BSCommon.Models;
using BSCommon.Utility;
using BSClient.Utility;

namespace BSClient
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }
        
        private bool IsLogin()
        {
            if (string.IsNullOrWhiteSpace(UserName_TextBox.Text) || string.IsNullOrWhiteSpace(Password_TextBox.Text))
            {
                MessageBox.Show("User or Pass is not empty!");
                return false;
            }

            UserController login = new UserController();
            UserInfo user = login.GetUserInfo(UserName_TextBox.Text);

            if (user != null && ClientCommon.IsCheckPass(Password_TextBox.Text, user.Password))
            {
                CommonInfo.UserInfo = user;
                return true;
            }
            else
            {
                MessageBox.Show("User or Pass is invalid!");
                return false;
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            if (this.IsLogin())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SHA1Helper.GetHash("Ab123456"); 
        }
    }
}