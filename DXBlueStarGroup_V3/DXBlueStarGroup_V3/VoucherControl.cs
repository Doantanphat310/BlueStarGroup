using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace DXBlueStarGroup_V3
{
    public partial class VoucherControl : UserControl
    {
        public VoucherControl()
        {
            InitializeComponent();
          
           LUE_Voucher.AutoSearch += OnAutoSearch;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VoucherControl_Load(object sender, EventArgs e)
        {
           
            ComboBoxItemCollection coll = CBE_Voucher.Properties.Items;
            coll.BeginUpdate();
            try
            {
                coll.Add(new PersonInfo("All", "Tất cả"));
                coll.Add(new PersonInfo("TH", "Chứng từ Thu"));
                coll.Add(new PersonInfo("CH", "Chứng từ Chi"));
                coll.Add(new PersonInfo("NH", "Chứng từ Ngân hàng"));
                coll.Add(new PersonInfo("KC", "Chứng từ Kết chuyển"));
                coll.Add(new PersonInfo("VT", "Chứng từ Vật tư"));
                coll.Add(new PersonInfo("HT", "Chứng từ Hạch toán"));
                coll.Add(new PersonInfo("KH", "Nhóm Chứng từ khác"));
                coll.Add(new PersonInfo("DC", "Điều chỉnh"));
            }
            finally
            {
                coll.EndUpdate();
            }
            CBE_Voucher.SelectedIndex = -1;            
        }

        public class PersonInfo
        {
            private string _ID;
            private string _Name;

            public PersonInfo(string ID, string Name)
            {
                _ID = ID;
                _Name = Name;
            }

            public override string ToString()
            {
                return _ID + ": " + _Name;
            }
        }


      
        void OnAutoSearch(object sender, LookUpEditAutoSearchEventArgs e)
        {
            string[] fields = new string[] { "ShipCity", "ShipCountry" };
            e.SetParameters(fields, e.Text, FindPanelParserKind.And, FilterCondition.StartsWith);
        }
    }
}
