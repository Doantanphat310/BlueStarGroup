using BSClient.Utility;
using DevExpress.XtraReports.UI;

namespace BSClient.Report
{
    public partial class BangCanDoiSoPhatSinhTaiKhoanReport : DevExpress.XtraReports.UI.XtraReport
    {
        public BangCanDoiSoPhatSinhTaiKhoanReport()
        {
            InitializeComponent();
        }

        private void SchedulerSignature_PictureBox_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string schedulerSignature = this.Parameters["SchedulerSignature"].Value.ToString();

            (sender as XRPictureBox).Image = ClientCommon.Base64ToImage(schedulerSignature);
        }

        private void ChiefaAcountantSignture_PictureBox_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string schedulerSignature = this.Parameters["ChiefaAcountantSignture"].Value.ToString();

            (sender as XRPictureBox).Image = ClientCommon.Base64ToImage(schedulerSignature);
        }
    }
}
