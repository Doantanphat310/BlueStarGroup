using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BSClient
{
    public partial class UserManageControl : DevExpress.XtraEditors.XtraUserControl
    {
        public UserManageControl()
        {
            InitializeComponent();
        }

        void clear()
        {
            txtuser.Text = txtpass.Text = "";
            //modeluser.ID = 0;
        }

        private void BTInsert_Click(object sender, EventArgs e)
        {
            //modeluser.UserName = txtuser.Text.Trim();
            //  modeluser.Password =  txtpass.Text.Trim();



            //using (var ctx = new BlueStarGroupEntities())
            //{
            //    //Execute stored procedure as a function
            //    var ResultList = ctx.InsertUSer(txtuser.Text.Trim().Replace("'",""),txtpass.Text.Trim(),"N");


            //    foreach (InsertUSer_Result _resultList in ResultList)
            //    {
            //        switch (_resultList.MessageCode)
            //        {
            //            case "1":
            //                MessageBox.Show(_resultList.MessageBox.ToString(), "Insert User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                break;
            //            case "2":
            //                MessageBox.Show(_resultList.MessageBox.ToString(), "Insert User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                break;
            //            default:
            //                MessageBox.Show(_resultList.MessageBox.ToString(), "Insert User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                break;
            //        }
            //    }
            //}

            //var UserID = Guid.NewGuid();
            //modeluser.UserName = txtuser.Text.Trim();
            //modeluser.Password = txtpass.Text.Trim();
            //modeluser.ID = UserID;
            //using (BlueStarGroupEntities db = new BlueStarGroupEntities())
            //{
            //    db.Users.Add(modeluser);
            //    db.SaveChanges();
            //}


            //clear();
            //var id = Guid.NewGuid();
            //MessageBox.Show("Submitted Success");
        }
    }
}
