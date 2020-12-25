using SQLAuto.Models;
using SQLAuto.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XMLHelper;
using Excel = Microsoft.Office.Interop.Excel;

namespace SQLAuto
{
    public partial class ExcelUC : UserControl
    {
        public List<Voucher> Vouchers { get; set; }

        private StringBuilder ErrorMessage { get; set; }

        private StringBuilder Output { get; set; }

        List<FileNameInfo> FileNameInfos { get; set; }

        private bool IsStoped = false;
        private int FileTotal;
        private int FileNumer;
        private int RecordTotal;
        private int RecordNumber;

        public ExcelUC()
        {
            InitializeComponent();

            IsStoped = true;
            SetEnable();

            InputFile_OpenFile.Dock = DockStyle.Fill;
            InputFolder_OpenFolder.Dock = DockStyle.Fill;
        }

        private void Convert_Button_Click(object sender, EventArgs e)
        {
            IsStoped = false;
            SetEnable();
            this.Cursor = Cursors.WaitCursor;

            Error_TextBox.Text = string.Empty;
            ErrorMessage = new StringBuilder();
            Output = new StringBuilder();

            LoadExcelFiles();

            GenerateInsertScript();

            WriteOutput();

            if (ErrorMessage != null && ErrorMessage.Length > 0)
            {
                Error_TextBox.Text = ErrorMessage.ToString();
            }

            IsStoped = true;
            SetEnable();

            this.Cursor = Cursors.Default;
            SetProcess("Đã xong!");
            MessageBox.Show("Convert data complete!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WriteOutput()
        {
            string outputDir = Path.Combine(Output_OpenFolder.FileName, "OutputData");
            string path;

            try
            {
                path = Path.Combine(outputDir, "VoucherInfo.xml");
                XMLHelpper.WriteXML<List<Voucher>>(path, Vouchers);
            }
            catch (Exception ex)
            {
                ErrorMessage.AppendLine(string.Format("Write file fail. =>Err: {0}", ex.Message));
            }

            try
            {
                path = Path.Combine(outputDir, "InsertScript.sql");
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
                File.WriteAllText(path, Output.ToString());
            }
            catch (Exception ex)
            {
                ErrorMessage.AppendLine(string.Format("Write file fail. =>Err: {0}", ex.Message));
            }

        }

        private void GenerateInsertScript()
        {
            if (Vouchers == null)
            {
                return;
            }

            SetProcess("Đang tạo câu lệnh SQL ...");
            int i = 0;
            int total = Vouchers.Count;
            foreach (Voucher item in Vouchers)
            {
                try
                {
                    SetProcess($"Đang tạo câu lệnh SQL thứ {i}/{total}");
                    Output.AppendLine(GetInsertScript(item));
                }
                catch (Exception ex)
                {
                    ErrorMessage.AppendLine(string.Format("Generate Script fail: {0}-{1}-{2}-{3} =>Err: {4}", item.VoucherType, item.VoucherNo, item.AccountID, item.AccountDetailID, ex.Message));
                }
            }
        }

        private string GetInsertScript(Voucher item)
        {
            string[] spl = item.VoucherDate.Split('/');
            string date = $"{spl[2]}/{spl[1]}/{spl[0]}";
            string columns = "VoucherType, VoucherNo, VoucherDate, Descriptions, DebitAmount, CreditAmount, AccountID, AccountDetailID, CustomerID";
            string values = $"'{item.VoucherType}', '{item.VoucherNo}', '{date}', N'{item.VoucherDescription}', {item.PSNo}, {item.PSCo}, '{item.AccountID}', '{item.AccountDetailID}', '{item.CustomerID}'";

            return $@"INSERT INTO VouchersTemp({columns}) VALUES({values})";
        }

        private void LoadExcelFiles()
        {
            ////string dirPath = InputFolder_OpenFolder.FileName;

            //SetProcess("Đang lấy file ...");
            //List<string> files = Directory.GetFiles(dirPath, "*.xlsx", SearchOption.AllDirectories).ToList();

            //List<FileNameInfo> fileNameInfos = new List<FileNameInfo>();
            //foreach (string filePath in files)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(filePath);
            //    if (!fileName.StartsWith("_sc_to_roi_"))
            //    {
            //        continue;
            //    }

            //    List<string> split = fileName.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //    string accountId = split.Count > 5 ? split[3] : string.Empty;
            //    string accountDetailId = split.Count > 6 ? split[4] : string.Empty;
            //    string customerId = split.Count > 7 ? split[5] : string.Empty;

            //    if (accountDetailId.Length > 2 && string.IsNullOrWhiteSpace(customerId))
            //    {
            //        customerId = accountDetailId;
            //        accountDetailId = string.Empty;
            //    }

            //    fileNameInfos.Add(new FileNameInfo
            //    {
            //        AccountID = accountId,
            //        AccountDetailID = accountDetailId,
            //        CustomerID = customerId,
            //        FileName = fileName,
            //        FilePath = filePath
            //    });
            //}
            if (FileNameInfos == null)
            {
                return;
            }
            FontHelper.InitFontHelper();
            Vouchers = new List<Voucher>();
            FileNumer = 0;
            FileTotal = FileNameInfos.Count;
            SetProcess($"Bắt đầu đọc file...");
            foreach (FileNameInfo fileNameInfo in FileNameInfos)
            {
                FileNumer++;
                LoadInput(fileNameInfo);
            }
        }

        private void LoadInput(FileNameInfo fileNameInfo)
        {
            Excel.Application excel = null;
            Excel.Workbook wkb = null;

            try
            {
                excel = new Excel.Application();

                wkb = OpenBook(excel, fileNameInfo.FilePath);
                excel.DisplayAlerts = false;
                Excel.Range xlRange = null;

                if (wkb.Sheets[1] is Excel.Worksheet sheet)
                {
                    xlRange = sheet.UsedRange;
                }

                string a, b, c, d;
                double e, f;
                if (xlRange != null)
                {
                    object[,] values = xlRange.Value2;
                    int row = xlRange.Rows.Count;
                    RecordTotal = row;
                    for (int i = 2; i <= row; i++)
                    {
                        RecordNumber = i;
                        SetProcessReadFile();

                        a = values[i, 1].ToString();
                        b = values[i, 2].ToString();
                        c = values[i, 3].ToString();
                        d = values[i, 4].ToString();
                        d = FontHelper.TCVN3ToUnicode(d);
                        e = Convert.ToDouble(values[i, 5] ?? 0);
                        f = Convert.ToDouble(values[i, 6] ?? 0);

                        Vouchers.Add(new Voucher
                        {
                            VoucherType = a,
                            VoucherNo = b,
                            VoucherDate = c,
                            VoucherDescription = d,
                            PSNo = e,
                            PSCo = f,
                            AccountID = fileNameInfo.AccountID,
                            AccountDetailID = fileNameInfo.AccountDetailID,
                            CustomerID = fileNameInfo.CustomerID
                        });
                    }
                }

                excel.Quit();
            }
            catch (Exception ex)
            {
                ErrorMessage.AppendLine(string.Format("Load file fail: {0} => Err: {1}", fileNameInfo.FileName, ex.Message));
                Console.WriteLine(ex.Message);
                if (excel != null)
                {
                    excel.Quit();
                }
            }
        }

        public Excel.Workbook OpenBook(Excel.Application excelInstance, string fileName, bool readOnly = true, bool editable = false, bool updateLinks = false)
        {
            Excel.Workbook book = excelInstance.Workbooks.Open(
                fileName, updateLinks, readOnly,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            return book;
        }

        private void SetProcess(string text)
        {
            Process_Label.Text = text;
            Process_Label.Refresh();
        }

        private void SetProcessReadFile()
        {
            string file = $"Đang đọc dòng thứ {RecordNumber}/{RecordTotal} của file {FileNumer}/{FileTotal}";
            Process_Label.Text = file;
            Process_Label.Refresh();
        }

        private void SetEnable()
        {
            Main_TableLayoutPanel.Enabled = IsStoped;
            Convert_Button.Enabled = IsStoped;
        }

        private void LoadData_Button_Click(object sender, EventArgs e)
        {
            IsStoped = false;
            SetEnable();
            this.Cursor = Cursors.WaitCursor;

            Error_TextBox.Text = string.Empty;
            ErrorMessage = new StringBuilder();
            Output = new StringBuilder();

            if (Excel_RadioButton.Checked)
            {
                LoadFilesInfo();
            }
            else
            {

            }

            if (ErrorMessage != null && ErrorMessage.Length > 0)
            {
                Error_TextBox.Text = ErrorMessage.ToString();
            }

            IsStoped = true;
            SetEnable();

            this.Cursor = Cursors.Default;
            MessageBox.Show("Load file complete!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadFilesInfo()
        {
            string dirPath = InputFolder_OpenFolder.FileName;
            List<string> files = Directory.GetFiles(dirPath, "*.xlsx", SearchOption.AllDirectories).ToList();

            FileNameInfos = new List<FileNameInfo>();
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                if (!fileName.StartsWith("_sc_to_roi_"))
                {
                    continue;
                }

                List<string> split = fileName.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string accountId = split.Count > 5 ? split[3] : string.Empty;
                string accountDetailId = split.Count > 6 ? split[4] : string.Empty;
                string customerId = split.Count > 7 ? split[5] : string.Empty;

                if (accountDetailId.Length > 2 && string.IsNullOrWhiteSpace(customerId))
                {
                    customerId = accountDetailId;
                    accountDetailId = string.Empty;
                }

                FileNameInfos.Add(new FileNameInfo
                {
                    AccountID = accountId,
                    AccountDetailID = accountDetailId,
                    CustomerID = customerId,
                    FileName = fileName,
                    FilePath = filePath
                });
            }

            FileName_DataGridView.DataSource = FileNameInfos;
        }

        private void LoadXMLFiles()
        {
            //string dirPath = InputFolder_OpenFolder.FileName;

            //SetProcess("Đang lấy file ...");
            //List<string> files = Directory.GetFiles(dirPath, "*.xlsx", SearchOption.AllDirectories).ToList();

            //FontHelper.InitFontHelper();
            //Vouchers = new List<Voucher>();
            //FileNumer = 0;
            //FileTotal = files.Count;
            //SetProcess($"Bắt đầu đọc file...");
            //foreach (string file in files)
            //{
            //    FileNumer++;
            //    //LoadInput(file);
            //}
        }

        private void Excel_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            InputFolder_OpenFolder.Visible = Excel_RadioButton.Checked;
            InputFile_OpenFile.Visible = !Excel_RadioButton.Checked;
        }
    }
}
