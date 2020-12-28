using BSClient.Constants;
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
            List<Customer> customers = new List<Customer>();
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

            try
            {
                excel = new Excel.Application();

                wkb = OpenBook(excel, path);
                excel.DisplayAlerts = false;
                Excel.Range xlRange = null;
                Excel.Worksheet sheet = wkb.Sheets[ExcelTemplate.GetTemplate(ExcelTemplate.EXL000001)];
                if (sheet != null)
                {
                    xlRange = sheet.UsedRange;
                }

                string a, b, c, d, e, f, g, h;
                if (xlRange != null)
                {
                    object[,] values = xlRange.Value2;
                    int row = xlRange.Rows.Count;
                    for (int i = 2; i <= row; i++)
                    {
                        try
                        {
                            a = values[i, 1]?.ToString();
                            if (string.IsNullOrWhiteSpace(a))
                            {
                                continue;
                            }
                            a = FontHelper.TCVN3ToUnicode(a);
                            b = values[i, 2]?.ToString();
                            c = values[i, 3]?.ToString();
                            d = values[i, 4]?.ToString();
                            d = FontHelper.TCVN3ToUnicode(d);
                            e = values[i, 5]?.ToString();
                            f = values[i, 6]?.ToString();
                            g = values[i, 7]?.ToString();
                            h = values[i, 8]?.ToString();

                            customers.Add(new Customer
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
                            error.AppendLine($"Error: Dòng {i} =>{ex.Message}");
                        }
                    }
                }

                excel.Quit();

                return customers;
            }
            catch (Exception ex)
            {
                BSLog.Logger.Error(ex.Message);
                if (excel != null)
                {
                    excel.Quit();
                }
            }

            return customers;
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

        //private List<T> LoadXLSX(int column)
        //{

        //}
    }
}
