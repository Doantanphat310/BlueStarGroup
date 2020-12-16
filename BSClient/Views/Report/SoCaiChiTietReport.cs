using BSClient.Utility;
using DevExpress.XtraReports.UI;

namespace BSClient.Report
{
    public partial class SoCaiChiTietReport : DevExpress.XtraReports.UI.XtraReport
    {
        public SoCaiChiTietReport()
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
