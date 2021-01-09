using BSReport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSReport
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ChungTuGhiSo_Button_Click(object sender, EventArgs e)
        {
            string path = GetPathFile(nameof(ChungTuGhiSo));
            List<ChungTuGhiSo> chungTuGhiSos = GetChungTuGhiSo();

            SSSuporter.XMLHelpper.WriteXML<List<ChungTuGhiSo>>(path, chungTuGhiSos);

            MessageBox.Show("Success!");
        }

        private List<ChungTuGhiSo> GetChungTuGhiSo()
        {
            using (MyContext context = new MyContext())
            {
                string sql = @"
SELECT
	V.VouchersTypeID,
	T.VouchersTypeName,
	V.VoucherNo,
	V.VoucherDate,
	V.VoucherAmount,
	V.VoucherDescription
FROM Vouchers V
	INNER JOIN VouchersType T
		ON V.VouchersTypeID = T.VouchersTypeID
WHERE V.CompanyID = 'CTY0000000060'
ORDER BY 
	V.VouchersTypeID,
	V.VoucherNo,
	V.VoucherDate
";
                return context.Database.SqlQuery<ChungTuGhiSo>(sql).ToList();
            }
        }

        private string GetPathFile(string fileName)
        {
            string pathDir = Directory.GetCurrentDirectory();

            return Path.Combine(pathDir, "Output", $"{fileName}.xml");
        }
    }
}
