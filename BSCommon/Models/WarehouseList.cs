using BSCommon.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCommon.Models
{
    public class WarehouseList
    {
            public string WarehouseListID {get; set;}
            public string WarehouseListName { get; set;}
            public string WarehouseListDebitAccountID { get; set;}
            public string WarehouseListDebitAccountDetailID { get; set;}
            public string WarehouseListCreditAccountID { get; set;}
            public string WarehouseListCreditAccountDetailID { get; set;}
            public string WarehouseListManageCode { get; set;}
            public string WarehouseListTitle { get; set;}
            public string WarehouseListAddress { get; set;}
            public string WarehouseListNote { get; set;}
            public string CompanyID { get; set;}
            public string CreateUser { get; set;}
            public ModifyMode Status { get; set; }
    }
}
