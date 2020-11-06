﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;

namespace BSClient
{
    public partial class CompanyControl : DevExpress.XtraEditors.XtraUserControl
    {
        //DXBlueStarGroup_V3.BlueStarGroupEntities dbContext;
        int rowindex = 0;

        public CompanyControl()
        {
            InitializeComponent();

            // This line of code is generated by Data Source Configuration Wizard
            // Instantiate a new DBContext
            //dbContext = new DXBlueStarGroup_V3.BlueStarGroupEntities();
            // Call the Load method to get the data for the given DbSet from the database.
            //dbContext.Companies.Load();
            // This line of code is generated by Data Source Configuration Wizard
            //companiesBindingSource.DataSource = dbContext.Companies.Local.ToBindingList();

            ItemForLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            ItemForRowID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //  MessageBox.Show(RowIDTextEdit.Text);
            companiesBindingSource.AddNew();
            // companiesBindingSource.
            String RowID = Guid.NewGuid().ToString();
            File.WriteAllText(@"D:\TinPhatITSC\BlueStartGroup\TestGuidID.txt", RowID);
            ItemForRowID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            RowIDTextEdit.Focus();
            RowIDTextEdit.Text = RowID;
            NameTextEdit.Focus();
            // RowIDTextEdit.Visible = false;
            NameTextEdit.Text = RowID;

            SummaryNameTextEdit.Focus();
            ItemForRowID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // RowIDTextEdit.Visible = false;
            // gridViewCompany.SetRowCellValue()
            //     RowIDTextEdit.DataBindings.Add("Text", companiesBindingSource,
            //RowID, true, DataSourceUpdateMode.OnPropertyChanged);
            //NameTextEdit.Text = RowID + "Name";
            //NameTextEdit.Focus();
            //SummaryNameTextEdit.Focus();
            ////  ItemForName.fo
            ////NameTextEdit.BindingContext = RowID + "Name";
            //SummaryNameTextEdit.Text = "123Summaryname";
            //SummaryNameTextEdit.Focus();



            //int dataRowCount = gridViewCompany.DataRowCount;
            // DevExpress.XtraGrid.Columns.GridColumn col = gridViewCompany.Columns.ColumnByFieldName("Address");
            // gridViewCompany.SetRowCellValue(dataRowCount, col, RowID);
            // gridViewCompany.SetRowCellValue(companiesBindingSource.Count, "colRowID", RowID);

            // companiesBindingSource.DataSource[8][1] = "a";
        }

        private void barButtonItemdelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dữ liệu!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                companiesBindingSource.RemoveCurrent();
                gridViewCompany.DeleteSelectedRows();
            }

        }

        private void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //rowindex
                // companiesBindingSource.AddNew();
                // gridViewCompany.AddNewRow();
                //  gridViewCompany.DeleteRow()
                // gridViewCompany.DeleteRow(gridViewCompany.DataRowCount);

                //   gridViewCompany.DataSource = companiesBindingSource.DataSource;
                //  gridControlCompany.DataSource = companiesBindingSource.DataSource;
                //dbContext.SaveChanges();
                MessageBox.Show("Lưu dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Lỗi lưu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItemCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //var changed = dbContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();
            //foreach (var obj in changed)
            //{
            //    switch (obj.State)
            //    {
            //        case EntityState.Modified:
            //            obj.CurrentValues.SetValues(obj.OriginalValues);
            //            obj.State = EntityState.Unchanged;
            //            break;
            //        case EntityState.Added:
            //            obj.State = EntityState.Detached;
            //            break;
            //        case EntityState.Deleted:
            //            obj.State = EntityState.Unchanged;
            //            break;
            //    }
            //}
            //companiesBindingSource.ResetBindings(false);
        }

        private void gridViewCompany_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            String RowID = Guid.NewGuid().ToString();
            File.WriteAllText(@"D:\TinPhatITSC\BlueStartGroup\TestGuidID.txt", RowID);
            view.SetRowCellValue(e.RowHandle, "RowID", RowID);
        }

        public String GetFileName()
        {
            OpenFileDialog openFileDialogChuKy = new OpenFileDialog();

            // openFileDialogChuKy.ShowDialog();
            openFileDialogChuKy.Title = "Chọn một ảnh chữ ký";
            openFileDialogChuKy.DefaultExt = "png";
            openFileDialogChuKy.Filter = "png (*.png)|*.png|jpg (*.jpg)|*.jpg|jpeg (*.jpeg)|*.jpeg|bmp (*.bmp)|*.bmp";
            openFileDialogChuKy.FilterIndex = 2;
            openFileDialogChuKy.CheckFileExists = true;
            openFileDialogChuKy.CheckPathExists = true;


            if (openFileDialogChuKy.ShowDialog() == DialogResult.OK)
            {
                return openFileDialogChuKy.FileName;
            }
            return "";
        }
        private void pictureEditLB_DoubleClick(object sender, EventArgs e)
        {
            ChukyLapBieuTextEdit.Text = GetBase64StringForImage(GetFileName());
            pictureEditLB.Image = Base64ToImage(ChukyLapBieuTextEdit.Text);
        }

        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        public System.Drawing.Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void ChukyLapBieuTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ChukyLapBieuTextEdit.Text != "")
            {
                pictureEditLB.Image = Base64ToImage(ChukyLapBieuTextEdit.Text);
            }
            else
            {
                pictureEditLB.Image = null;
            }
        }

        private void pictureEditThQ_DoubleClick(object sender, EventArgs e)
        {
            ChuKyThuQuyTextEdit.Text = GetBase64StringForImage(GetFileName());
            pictureEditThQ.Image = Base64ToImage(ChuKyThuQuyTextEdit.Text);
        }

        private void pictureEditKTV_DoubleClick(object sender, EventArgs e)
        {
            ChuKyKeToanVienTextEdit.Text = GetBase64StringForImage(GetFileName());
            pictureEditKTV.Image = Base64ToImage(ChuKyKeToanVienTextEdit.Text);
        }

        private void pictureEditKTTruong_DoubleClick(object sender, EventArgs e)
        {
            ChuKyKTTruongTextEdit.Text = GetBase64StringForImage(GetFileName());
            pictureEditKTTruong.Image = Base64ToImage(ChuKyKTTruongTextEdit.Text);
        }

        private void ChuKyThuQuyTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ChuKyThuQuyTextEdit.Text != "")
            {
                pictureEditThQ.Image = Base64ToImage(ChuKyThuQuyTextEdit.Text);
            }
            else
            {
                pictureEditThQ.Image = null;
            }
        }

        private void ChuKyKeToanVienTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ChuKyKeToanVienTextEdit.Text != "")
            {
                pictureEditKTV.Image = Base64ToImage(ChuKyKeToanVienTextEdit.Text);
            }
            else
            {
                pictureEditKTV.Image = null;
            }
        }

        private void ChuKyKTTruongTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ChuKyKTTruongTextEdit.Text != "")
            {
                pictureEditKTTruong.Image = Base64ToImage(ChuKyKTTruongTextEdit.Text);
            }
            else
            {
                pictureEditKTTruong.Image = null;
            }
        }

        private void pictureEditLD_DoubleClick(object sender, EventArgs e)
        {
            ChuKyLanhDaoTextEdit.Text = GetBase64StringForImage(GetFileName());
            pictureEditLD.Image = Base64ToImage(ChuKyLanhDaoTextEdit.Text);
        }

        //private void pictureEditLD_EditValueChanged(object sender, EventArgs e)
        //{
        //    if (ChuKyLanhDaoTextEdit.Text != "")
        //    {
        //        pictureEditLD.Image = Base64ToImage(ChuKyLanhDaoTextEdit.Text);
        //    }
        //    else
        //    {
        //        pictureEditLD.Image = null;
        //    }
        //}

        private void ChuKyLanhDaoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (ChuKyLanhDaoTextEdit.Text != "")
            {
                pictureEditLD.Image = Base64ToImage(ChuKyLanhDaoTextEdit.Text);
            }
            else
            {
                pictureEditLD.Image = null;
            }
        }

        private void pictureEditLogo_DoubleClick(object sender, EventArgs e)
        {

            String Logotext = GetBase64StringForImage(GetFileName());
            ItemForLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            LogoTextEdit.Focus();
            LogoTextEdit.Text = Logotext;
            pictureEditLogo.Focus();
            pictureEditLogo.Image = Base64ToImage(LogoTextEdit.Text);
            ItemForLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void LogoTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (LogoTextEdit.Text != "")
            {
                pictureEditLogo.Image = Base64ToImage(LogoTextEdit.Text);
            }
            else
            {
                pictureEditLogo.Image = null;
            }
        }

        private void NameTextEdit_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show(RowIDTextEdit.Text);
        }

        private void gridViewCompany_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            ItemForLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            ItemForLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void pictureEditLogo_LoadCompleted(object sender, EventArgs e)
        {
            ItemForLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void pictureEditLogo_ImageChanged(object sender, EventArgs e)
        {
            ItemForLogo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
    }
}