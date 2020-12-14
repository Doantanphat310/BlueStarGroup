using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BSClient.Utility;
using BSCommon.Utility;
using System.IO;

namespace BSClient.Report
{
    public partial class BangCanDoiSoPhatSinhTaiKhoanReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BangCanDoiSoPhatSinhTaiKhoanReport()
        {
            InitializeComponent();
        }

        private void xrPictureBox1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string schedulerSignature = this.Parameters["SchedulerSignature"].Value.ToString();

            (sender as XRPictureBox).Image = ClientCommon.Base64ToImage(schedulerSignature);

            //string value = this.Parameters["SchedulerSignature"].Value.ToString();
            //MemoryStream stream = new MemoryStream(Convert.FromBase64String(value));
            //(sender as XRPictureBox).Image = Image.FromStream(stream);
        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string schedulerSignature = this.Parameters["SchedulerSignature"].Value.ToString();

            (sender as XRPictureBox).Image = ClientCommon.Base64ToImage(schedulerSignature);
        }
    }
}
