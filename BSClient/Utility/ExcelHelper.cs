using BSClient.Constants;
using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
using SSSuporter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BSClient.Utility
{
    public class ExcelHelper
    {
        public static List<Customer> LoadCustomer(out StringBuilder error)
        {
            error = new StringBuilder();
            List<Customer> resultData = new List<Customer>();

            object[,] values = GetExcelData(ExcelTemplate.EXL000001);

            if (values == null)
            {
                return resultData;
            }

            string a, b, c, d, e, f, g, h;
            int row = values.GetLength(0);
            for (int i = 2; i <= row; i++)
            {
                try
                {
                    a = values[i, 1]?.ToString();
                    if (string.IsNullOrWhiteSpace(a))
                    {
                        continue;
                    }

                    //a = FontHelper.TCVN3ToUnicode(a);
                    b = values[i, 2]?.ToString();
                    c = values[i, 3]?.ToString();
                    d = values[i, 4]?.ToString();
                    //d = FontHelper.TCVN3ToUnicode(d);
                    e = values[i, 5]?.ToString();
                    f = values[i, 6]?.ToString();
                    g = values[i, 7]?.ToString();
                    h = values[i, 8]?.ToString();

                    resultData.Add(new Customer
                    {
                        CustomerName = a,
                        CustomerSName = b,
                        CustomerTIN = c,
                        CustomerAddress = d,
                        CustomerPhone = e,
                        InvoiceFormNo = f,
                        FormNo = g,
                        SerialNo = h
                    });
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Debug(ex.Message);
                    error.AppendLine($"Lỗi dòng {i}: {ex.Message}");
                }
            }

            return resultData;
        }

        public static List<ItemUnit> LoadItemUnit(out StringBuilder error)
        {
            error = new StringBuilder();
            List<ItemUnit> resultData = new List<ItemUnit>();

            object[,] values = GetExcelData(ExcelTemplate.EXL000004);

            if (values == null)
            {
                return resultData;
            }

            string a, b;
            int row = values.GetLength(0);
            for (int i = 2; i <= row; i++)
            {
                try
                {
                    a = values[i, 1]?.ToString();
                    b = values[i, 2]?.ToString();
                    //b = FontHelper.TCVN3ToUnicode(b);

                    if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b))
                    {
                        continue;
                    }

                    resultData.Add(new ItemUnit
                    {
                        ItemUnitID = a.ToUpper(),
                        ItemUnitName = b
                    });
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Debug(ex.Message);
                    error.AppendLine($"Lỗi dòng {i}: {ex.Message}");
                }
            }

            return resultData;
        }

        public static List<ItemType> LoadItemType(out StringBuilder error)
        {
            error = new StringBuilder();
            List<ItemType> resultData = new List<ItemType>();

            object[,] values = GetExcelData(ExcelTemplate.EXL000003);

            if (values == null)
            {
                return resultData;
            }

            string a, b;
            int row = values.GetLength(0);
            for (int i = 2; i <= row; i++)
            {
                try
                {
                    a = values[i, 1]?.ToString();
                    if (string.IsNullOrWhiteSpace(a))
                    {
                        continue;
                    }

                    //a = FontHelper.TCVN3ToUnicode(a);
                    b = values[i, 2]?.ToString();

                    if (string.IsNullOrWhiteSpace(b))
                    {
                        continue;
                    }

                    resultData.Add(new ItemType
                    {
                        ItemTypeName = a,
                        ItemTypeSName = b
                    });
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Debug(ex.Message);
                    error.AppendLine($"Lỗi dòng {i}: {ex.Message}");
                }
            }

            return resultData;
        }

        public static List<Items> LoadItems(out StringBuilder error)
        {
            error = new StringBuilder();
            List<Items> resultData = new List<Items>();

            object[,] values = GetExcelData(ExcelTemplate.EXL000002);

            if (values == null)
            {
                return resultData;
            }

            string a, b, c, d, e;
            decimal f;
            int row = values.GetLength(0);
            for (int i = 2; i <= row; i++)
            {
                try
                {
                    a = values[i, 1]?.ToString();
                    if (string.IsNullOrWhiteSpace(a))
                    {
                        continue;
                    }
                    //a = FontHelper.TCVN3ToUnicode(a);
                    b = values[i, 2]?.ToString();
                    c = values[i, 3]?.ToString();
                    d = values[i, 4]?.ToString();
                    //d = FontHelper.TCVN3ToUnicode(d);
                    e = values[i, 5]?.ToString();
                    //e = FontHelper.TCVN3ToUnicode(e);
                    f = Convert.ToDecimal(values[i, 6] ?? 0);

                    resultData.Add(new Items
                    {
                        ItemName = a,
                        ItemSName = b,
                        ItemTypeID = c,
                        ItemUnitID = d,
                        ItemSpecification = e,
                        ItemPrice = f
                    });
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Debug(ex.Message);
                    error.AppendLine($"Lỗi dòng {i}: {ex.Message}");
                }
            }

            return resultData;
        }

        private static Excel.Workbook OpenBook(Excel.Application excelInstance, string fileName, bool readOnly = true, bool editable = false, bool updateLinks = false)
        {
            Excel.Workbook book = excelInstance.Workbooks.Open(
                fileName, updateLinks, readOnly,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            return book;
        }

        private static object[,] GetExcelData(string tempateID)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel file(*.xlsx)|*.xlsx",
                Multiselect = false
            };

            string path;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog.FileName;
            }
            else
            {
                return null;
            }

            Excel.Application excel = null;
            Excel.Workbook wkb = null;
            object[,] result = null;

            try
            {
                excel = new Excel.Application();

                wkb = OpenBook(excel, path);
                excel.DisplayAlerts = false;
                Excel.Range xlRange = null;
                Excel.Worksheet sheet = wkb.Sheets[ExcelTemplate.GetTemplate(tempateID)];
                if (sheet != null)
                {
                    xlRange = sheet.UsedRange;
                }

                if (xlRange != null)
                {
                    result = xlRange.Value2;
                }

                excel.Quit();

                return result;
            }
            catch (Exception ex)
            {
                BSLog.Logger.Error(ex.Message);
                if (excel != null)
                {
                    excel.Quit();
                }

                return result;
            }
        }

        public static List<Invoice> LoadInvoice(out StringBuilder error)
        {
            error = new StringBuilder();
            List<Invoice> resultData = new List<Invoice>();

            object[,] values = GetExcelData(ExcelTemplate.EXL000005);

            if (values == null)
            {
                return resultData;
            }

            string a, b, c, d, e, f, g, h, i, j, k, l, m, n, o;
            double date;
            int row = values.GetLength(0);
            for (int ir = 2; ir <= row; ir++)
            {
                try
                {
                    a = values[ir, 1]?.ToString();
                    if (string.IsNullOrWhiteSpace(a))
                    {
                        continue;
                    }

                    //a = FontHelper.TCVN3ToUnicode(a);
                    b = values[ir, 2]?.ToString();
                    c = values[ir, 3]?.ToString();
                    d = values[ir, 4]?.ToString();
                    //d = FontHelper.TCVN3ToUnicode(d);
                    e = values[ir, 5]?.ToString();
                    date = double.Parse(e);
                    f = values[ir, 6]?.ToString();
                    g = values[ir, 7]?.ToString();
                    h = values[ir, 8]?.ToString();

                    i = values[ir, 9]?.ToString();
                    j = values[ir, 10]?.ToString();
                    k = values[ir, 11]?.ToString();
                    l = values[ir, 12]?.ToString();

                    m = values[ir, 13]?.ToString();
                    n = values[ir, 14]?.ToString();
                    o = values[ir, 15]?.ToString();

                    resultData.Add(new Invoice
                    {
                        InvoiceFormNo = a,
                        FormNo = b,
                        SerialNo = c,
                        InvoiceNo = d,
                        InvoiceDate = DateTime.FromOADate(date),
                        CustomerID = f,
                        Amount = decimal.Parse(j),
                        VAT = decimal.Parse(k),
                        VATAmount = decimal.Parse(l),
                        PaymentType = m,
                        AccountIDFULL = o,
                        ItemID = g,
                        Quantity =  decimal.Parse(i),
                        Price = decimal.Parse(h),
                    });
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Debug(ex.Message);
                    error.AppendLine($"Lỗi dòng {ir}: {ex.Message}");
                }
            }
            return resultData;
        }

        public static List<KichBanKetChuyentable> LoadKichBanKC(out StringBuilder error)
        {
            error = new StringBuilder();
            List<KichBanKetChuyentable> resultData = new List<KichBanKetChuyentable>();

            object[,] values = GetExcelData(ExcelTemplate.EXL000006);

            if (values == null)
            {
                return resultData;
            }

            string a, b, c;
            int row = values.GetLength(0);
            for (int ir = 2; ir <= row; ir++)
            {
                try
                {
                    a = values[ir, 1]?.ToString();
                    if (string.IsNullOrWhiteSpace(a))
                    {
                        continue;
                    }

                    //a = FontHelper.TCVN3ToUnicode(a);
                    b = values[ir, 2]?.ToString();
                    c = values[ir, 3]?.ToString();
                   
                    resultData.Add(new KichBanKetChuyentable
                    {
                        GroupCode = a,
                        KetChuyenDebitAccountID = b,
                        KetChuyenCreditAccountID = c,
                        CompanyID = CommonInfo.CompanyInfo.CompanyID,
                        Status = ModifyMode.Insert,
                    });
                }
                catch (Exception ex)
                {
                    BSLog.Logger.Debug(ex.Message);
                    error.AppendLine($"Lỗi dòng {ir}: {ex.Message}");
                }
            }
            return resultData;
        }
    }
}
