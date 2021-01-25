using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSClient.Views
{
    public partial class ClockDB : Form
    {
        public static MaterialNVController MaterialLockDB = new MaterialNVController();
        List<MaterialLockDB> materialLockDB = MaterialLockDB.GetMaterialLockDB();

        public BindingList<LockDBCompany> LockDBCompanyData;
        public List<LockDBCompany> LockDBCompanyDelete;
        public ClockDB()
        {
            InitializeComponent();

            DateTime firstDay = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime lastDay = new DateTime(DateTime.Now.Year, 12, 31);
            LockDB_StartDate_dateEdit.DateTime = firstDay;
            LockDB_EndDate_dateEdit.DateTime = lastDay;

            InitGridViewLockDB();
        }

        #region Init LockDB gridview
        private void InitGridViewLockDB()
        {
            Init_LockDB_GridView();
            Setup_LockDB_GridView();
            this.Load_LockDB_GridView(LockDB_StartDate_dateEdit.DateTime, LockDB_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);

        }
        private void Init_LockDB_GridView()
        {
            this.LockDB_gridView.Columns.Clear();
            this.LockDB_gridView.AddDateEditColumn("ClockDBDate", "Ngày khóa sổ", 150, true);
            List<ColumnInfo> columns = new List<ColumnInfo>
            {
                new ColumnInfo("Name", "Mở/Khóa Sổ",140)
            };
            this.LockDB_gridView.AddSearchLookupEditColumn(
                    "ClockStatus", "Mở/Khóa Sổ", 120, materialLockDB, "ID","Name", isAllowEdit: true, columns: columns);
            this.LockDB_gridView.AddColumn("ClockDBNote", "Ghi chú", 300, true);
            this.LockDB_gridView.AddColumn("CreateUser", "Người tạo", 60, false);
        }

        private void Setup_LockDB_GridView()
        {
            this.LockDB_gridView.SetupGridView(multiSelect: true, checkBoxSelectorColumnWidth: 30, hasShowRowHeader: true, columnAutoWidth: false);
            // this.S35_Invoice_gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
        }

        private void Load_LockDB_GridView(DateTime startDate, DateTime endDate, string companyID)
        {
            LockDBCompanyController controller = new LockDBCompanyController();
            LockDBCompanyData = new BindingList<LockDBCompany>(controller.GetLockDBCompany(startDate, endDate, companyID));
            this.LockDB_gridControl.DataSource = LockDBCompanyData;
            this.LockDBCompanyDelete = new List<LockDBCompany>();
        }
        #endregion Init LockDB gridview

        private void LockDB_Delete_simpleButton_Click(object sender, EventArgs e)
        {
            int[] selectIndex = this.LockDB_gridView.GetSelectedRows();
            foreach (int index in selectIndex)
            {
                LockDBCompany delete = this.LockDB_gridView.GetRow(index) as LockDBCompany;
                delete.IsDelete = true;
                if (!string.IsNullOrEmpty(delete.ClockDBID))
                {
                    this.LockDBCompanyData[index].Status = ModifyMode.Delete;
                    this.LockDBCompanyDelete.Add(delete);
                }
            }
            this.LockDB_gridView.DeleteSelectedRows();
        }

   

        private void LockDB_Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            this.LockDBCompanyDelete = new List<LockDBCompany>();
            this.Load_LockDB_GridView(LockDB_StartDate_dateEdit.DateTime, LockDB_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);

        }

        private void LockDB_Save_simpleButton_Click(object sender, EventArgs e)
        {
            //set trạng thái insert cho dòng mới
            foreach (LockDBCompany lockDBCompany in this.LockDBCompanyData)
            {
                if (string.IsNullOrEmpty(lockDBCompany.ClockDBID))
                {
                    lockDBCompany.CompanyID = CommonInfo.CompanyInfo.CompanyID;
                    lockDBCompany.Status = ModifyMode.Insert;
                }
            }
            int checkAction = 0;
            List<LockDBCompany> saveData = this.LockDBCompanyData.Where(o => o.Status == ModifyMode.Insert || o.Status == ModifyMode.Update || o.Status == ModifyMode.Delete).ToList();
            if (saveData?.Count > 0)
            {
                LockDBCompanyController controller = new LockDBCompanyController();
                if (controller.SaveLockDB(saveData))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            #region delete LockDBCompany
            if (LockDBCompanyDelete?.Count > 0)
            {
                LockDBCompanyController controller = new LockDBCompanyController();
                if (controller.SaveLockDB(LockDBCompanyDelete))
                {
                    checkAction++;
                }
                else
                {
                    checkAction = 0;
                    MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000002);
                }
            }

            if (checkAction > 0)
            {
                MessageBoxHelper.ShowInfoMessage(BSMessage.BSM000001);
            }
            #endregion delete LockDBCompany

            this.LockDBCompanyDelete = new List<LockDBCompany>();
            this.Load_LockDB_GridView(LockDB_StartDate_dateEdit.DateTime, LockDB_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);
        }

        private void LockDB_gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            bool isNewRow = this.LockDB_gridView.IsNewItemRow(e.RowHandle);
            if (isNewRow)
            {
                return;
            }

            Invoice row = e.Row as Invoice;
            if (row.Status == ModifyMode.Insert)
            {
                return;
            }
            row.Status = ModifyMode.Update;
        }

        private void LockDB_GetData_simpleButton_Click(object sender, EventArgs e)
        {
            this.Load_LockDB_GridView(LockDB_StartDate_dateEdit.DateTime, LockDB_EndDate_dateEdit.DateTime, CommonInfo.CompanyInfo.CompanyID);

        }
    }
}
