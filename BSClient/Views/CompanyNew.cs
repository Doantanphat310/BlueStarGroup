using BSClient.Constants;
using BSClient.Utility;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using BSServer.Controllers;
using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BSClient
{
    public partial class CompanyNew : XtraForm
    {
        private BindingSource BinSource { get; set; }

        private CompanyView CompanyInfo { get; set; }

        private ModifyMode EditMode { get; set; }

        private enum ImageType
        {
            Logo,
            Leader,
            ChiefaAcountant,
            Accountant,
            Stockkeeper,
            Scheduler
        }

        public CompanyNew(Company input = null)
        {
            InitializeComponent();

            if (input == null)
            {
                EditMode = ModifyMode.Insert;
            }
            else
            {
                EditMode = ModifyMode.Update;
            }

            CompanyInfo = ModelHelper.CopyToNew<Company, CompanyView>(input);
            BinSource = new BindingSource
            {
                DataSource = CompanyInfo
            };

            SetBindingData();
            SetEnable();

            if (!ClientCommon.HasAuthority(UserInfo.UserRole, BSRole.Full))
            {
                AddNew_Button.Enabled = false;
                Update_Button.Enabled = true;
            }
        }

        private void SetBindingData()
        {
            // Thông tin công ty
            DataBindingHelper.BindingTextEdit(this.CompanyName_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.CompanySName_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.Address_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.District_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.Province_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.Phone_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.Email_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.Fax_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.MST_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.NoiQLThue_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.BankAccount_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.SoQuyetDinh_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.NHKhoBac_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.BankName_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.MaSoHD_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.TKThuThue_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.BankBranch_TextEdit, BinSource);

            //Thông tin chữ ký
            DataBindingHelper.BindingTextEdit(this.Scheduler_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.Stockkeeper_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.Accountant_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.Leader_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.LeaderPosition_TextEdit, BinSource);
            DataBindingHelper.BindingTextEdit(this.ChiefaAcountant_TextEdit, BinSource);

            // Thông tin hình ảnh
            DataBindingHelper.BindingPictureEdit(this.Logo_PictureEdit, BinSource);
            DataBindingHelper.BindingPictureEdit(this.SchedulerSignature_PictureEdit, BinSource);
            DataBindingHelper.BindingPictureEdit(this.StockkeeperSignature_PictureEdit, BinSource);
            DataBindingHelper.BindingPictureEdit(this.AccountantSignature_PictureEdit, BinSource);
            DataBindingHelper.BindingPictureEdit(this.ChiefaAcountantSignature_PictureEdit, BinSource);
            DataBindingHelper.BindingPictureEdit(this.LeaderSignature_PictureEdit, BinSource);
        }

        private void SetEnable()
        {
            if (EditMode == ModifyMode.Insert)
            {
                AddNew_Button.Visible = true;
                Update_Button.Visible = false;

                AddNew_Button.Location = Update_Button.Location;
            }
            else
            {
                AddNew_Button.Visible = false;
                Update_Button.Visible = true;
            }
        }

        public string GetImageFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn hình ảnh",
                DefaultExt = "png",
                Filter = "Image Files(*.BMP;*.PNG;*.JPG;*.JPEG)|*.BMP;*.PNG;*.JPG;*.JPEG",
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }

            return string.Empty;
        }

        private void Logo_PictureEdit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangedImage(ImageType.Logo);
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            // Kiểm tra hợp lệ
            if (!IsValidateData())
            {
                return;
            }

            // Cập nhật dữ liệu
            using (CompanyController controller = new CompanyController())
            {
                try
                {
                    controller.UpdateCompany(CompanyInfo);
                }
                catch
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddNew_Button_Click(object sender, EventArgs e)
        {
            // Kiểm tra hợp lệ
            if (!IsValidateData())
            {
                return;
            }

            // Thêm mới dữ liệu
            using (CompanyController controller = new CompanyController())
            {
                try
                {
                    controller.InsertCompany(CompanyInfo);
                }
                catch
                {
                    MessageBoxHelper.ShowErrorMessage(BSMessage.BSM000002);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Kiểm tra hợp lệ trước khi lưu
        /// </summary>
        /// <returns>True:Hợp lệ/False: Ngược lại</returns>
        private bool IsValidateData()
        {
            return true;
        }

        private void ChuKyLapBieu_PictureEdit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangedImage(ImageType.Scheduler);
        }

        private void ChuKyThuQuy_PictureEdit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangedImage(ImageType.Stockkeeper);
        }

        private void ChuKyKeToanVien_PictureEdit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangedImage(ImageType.Accountant);
        }

        private void ChuKyLanhDao_PictureEdit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangedImage(ImageType.Leader);
        }

        private void ChuKyKTTruong_PictureEdit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ChangedImage(ImageType.ChiefaAcountant);
        }

        private void ChangedImage(ImageType imageType)
        {
            // Lấy đường dẫn
            string pathName = GetImageFileName();

            // Kiểm tra đường dẫn
            if (string.IsNullOrEmpty(pathName)) return;

            // Convert image sang Base64
            string logoBase64 = ClientCommon.GetBase64StringFormImage(pathName);

            // Gán hình ảnh cho control
            switch (imageType)
            {
                case ImageType.Logo:
                    this.CompanyInfo.Logo = logoBase64;
                    Logo_PictureEdit.Image = ClientCommon.Base64ToImage(logoBase64);
                    break;

                case ImageType.Accountant:
                    this.CompanyInfo.ChuKyKeToanVien = logoBase64;
                    AccountantSignature_PictureEdit.Image = ClientCommon.Base64ToImage(logoBase64);
                    break;

                case ImageType.ChiefaAcountant:
                    this.CompanyInfo.ChuKyKTTruong = logoBase64;
                    ChiefaAcountantSignature_PictureEdit.Image = ClientCommon.Base64ToImage(logoBase64);
                    break;

                case ImageType.Stockkeeper:
                    this.CompanyInfo.ChuKyThuQuy = logoBase64;
                    StockkeeperSignature_PictureEdit.Image = ClientCommon.Base64ToImage(logoBase64);
                    break;

                case ImageType.Scheduler:
                    this.CompanyInfo.ChuKyLapBieu = logoBase64;
                    SchedulerSignature_PictureEdit.Image = ClientCommon.Base64ToImage(logoBase64);
                    break;

                case ImageType.Leader:
                    this.CompanyInfo.ChuKyLanhDao = logoBase64;
                    LeaderSignature_PictureEdit.Image = ClientCommon.Base64ToImage(logoBase64);
                    break;
            }
        }
    }

    internal class CompanyView : Company
    {
        public Image LogoImage
        {
            get
            {
                return ClientCommon.Base64ToImage(Logo);
            }
        }

        public Image ChuKyLapBieuImage
        {
            get
            {
                return ClientCommon.Base64ToImage(ChuKyLapBieu);
            }
        }

        public Image ChuKyThuQuyImage
        {
            get
            {
                return ClientCommon.Base64ToImage(ChuKyThuQuy);
            }
        }

        public Image ChuKyKeToanVienImage
        {
            get
            {
                return ClientCommon.Base64ToImage(ChuKyKeToanVien);
            }
        }

        public Image ChuKyKTTruongImage
        {
            get
            {
                return ClientCommon.Base64ToImage(ChuKyKTTruong);
            }
        }

        public Image ChuKyLanhDaoImage
        {
            get
            {
                return ClientCommon.Base64ToImage(ChuKyLanhDao);
            }
        }
    }
}
