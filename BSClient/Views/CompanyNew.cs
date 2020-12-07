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
        }

        private void SetBindingData()
        {
            // Thông tin công ty
            BindingTextEdit(this.CompanyName_TextEdit);
            BindingTextEdit(this.CompanySName_TextEdit);
            BindingTextEdit(this.Address_TextEdit);
            BindingTextEdit(this.District_TextEdit);
            BindingTextEdit(this.Province_TextEdit);
            BindingTextEdit(this.Phone_TextEdit);
            BindingTextEdit(this.Email_TextEdit);
            BindingTextEdit(this.Fax_TextEdit);
            BindingTextEdit(this.MST_TextEdit);
            BindingTextEdit(this.NoiQLThue_TextEdit);
            BindingTextEdit(this.BankAccount_TextEdit);
            BindingTextEdit(this.SoQuyetDinh_TextEdit);
            BindingTextEdit(this.NHKhoBac_TextEdit);
            BindingTextEdit(this.BankName_TextEdit);
            BindingTextEdit(this.MaSoHD_TextEdit);
            BindingTextEdit(this.TKThuThue_TextEdit);
            BindingTextEdit(this.BankBranch_TextEdit);

            //Thông tin chữ ký
            BindingTextEdit(this.Scheduler_TextEdit);
            BindingTextEdit(this.Stockkeeper_TextEdit);
            BindingTextEdit(this.Accountant_TextEdit);
            BindingTextEdit(this.Leader_TextEdit);
            BindingTextEdit(this.LeaderPosition_TextEdit);
            BindingTextEdit(this.ChiefaAcountant_TextEdit);

            // Thông tin hình ảnh
            BindingPictureEdit(this.Logo_PictureEdit);
            BindingPictureEdit(this.SchedulerSignature_PictureEdit);
            BindingPictureEdit(this.StockkeeperSignature_PictureEdit);
            BindingPictureEdit(this.AccountantSignature_PictureEdit);
            BindingPictureEdit(this.ChiefaAcountantSignature_PictureEdit);
            BindingPictureEdit(this.LeaderSignature_PictureEdit);
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

        private void BindingTextEdit(TextEdit edit)
        {
            try
            {
                edit.DataBindings.Clear();
                Binding b = new Binding("EditValue", this.BinSource, edit.Tag.ToString(), true);
                edit.DataBindings.Add(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BindingTextEdit: " + ex.Message);
            }
        }

        private void BindingPictureEdit(PictureEdit edit)
        {
            try
            {
                edit.DataBindings.Clear();
                Binding b = new Binding("Image", this.BinSource, $"{edit.Tag.ToString()}Image", true);
                edit.DataBindings.Add(b);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi BindingPictureEdit: " + ex.Message);
            }
        }

        public string GetImageFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Chọn một ảnh chữ ký",
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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

        public void SetLogo()
        {

        }
    }
}
