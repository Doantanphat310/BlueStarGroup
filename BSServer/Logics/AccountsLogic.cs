using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer._Core.Utility;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BSServer.Logics
{
    public class AccountsLogic : BaseLogic
    {
        public AccountsLogic(BSContext context) : base(context)
        {
            this.Context = context;
            this.AccountsDAO = new AccountsDAO(this.Context);
        }

        private AccountsDAO AccountsDAO { get; set; }

        public bool SaveAccountGroup(List<AccountGroup> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = this.AccountsDAO.GetAccountGroupSEQ();
                    foreach (AccountGroup data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq += 1;
                                data.AccountGroupID = GenerateID.AccountGroupID(seq);
                                this.AccountsDAO.InsertAccountGroup(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.AccountsDAO.UpdateAccountGroup(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.AccountsDAO.DeleteAccountGroup(data);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Update data fail.\r\n" + e.Message);
                    return false;
                }
            }
        }

        public bool SaveAccounts(List<Accounts> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = this.AccountsDAO.GetGeneralLedgerSEQ();

                    foreach (Accounts data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.AccountsDAO.InsertAccounts(data);

                                break;

                            // Update
                            case ModifyMode.Update:
                                this.AccountsDAO.UpdateAccounts(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.AccountsDAO.DeleteAccounts(data);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Update data fail.\r\n" + e.Message);
                    return false;
                }
            }
        }

        public bool SaveAccountDetail(List<AccountDetail> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (AccountDetail data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.AccountsDAO.InsertAccountDetail(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.AccountsDAO.UpdateAccountDetail(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.AccountsDAO.DeleteAccountDetail(data);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Update data fail.\r\n" + e.Message);
                    return false;
                }
            }
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinhChiTiet(DateTime fromDate, DateTime toDate)
        {
            List<GetCanDoiSoPhatSinhTaiKhoan> psData = this.AccountsDAO.GetCanDoiSoPhatSinhTaiKhoanByKH(fromDate, toDate);

            List<GetBalance> dkData = this.AccountsDAO.GetSoDuDauKy(fromDate);
            DateTime balanceDate;
            List<GetCanDoiSoPhatSinhTaiKhoan> psDKData = null;

            if (dkData != null && dkData.Count > 0)
            {
                balanceDate = dkData[0].BalanceDate;
                if (balanceDate.Date < fromDate.Date)
                {
                    psDKData = this.AccountsDAO.GetCanDoiSoPhatSinhTaiKhoanByKH(balanceDate, fromDate.AddDays(-1));
                }
            }

            // tính lại đầu kỳ
            if (psDKData != null)
            {
                foreach (var item in dkData)
                {
                    GetCanDoiSoPhatSinhTaiKhoan psdk = psDKData.Find(o =>
                        o.AccountID == item.AccountID &&
                        o.AccountDetailID == item.AccountDetailID &&
                        o.CustomerID == item.CustomerID);

                    decimal dk = 0;
                    if (psdk != null)
                    {
                        dk = item.DebitBalance - item.CreditBalance + psdk.PSNo - psdk.PSCo;

                        if (dk > 0)
                        {
                            item.DebitBalance = dk;
                            item.CreditBalance = 0;
                        }
                        else
                        {
                            item.DebitBalance = 0;
                            item.CreditBalance = (-1) * dk;
                        }
                    }
                }
            }

            // Thêm DK và tính CK

            // Có ĐK nhưng không có PS
            var dkNotPS = new List<GetCanDoiSoPhatSinhTaiKhoan>();
            foreach (GetBalance item in dkData)
            {
                var psFind = psData.Find(o =>
                   o.AccountID == item.AccountID &&
                   o.AccountDetailID == item.AccountDetailID &&
                   o.CustomerID == item.CustomerID);
                // có ps
                if (psFind != null)
                {
                    psFind.DKNo = item.DebitBalance;
                    psFind.DKCo = item.CreditBalance;

                    //decimal ckNo = psFind.DKNo + psFind.PSNo - psFind.DKCo - psFind.PSCo;
                    //if (ckNo > 0)
                    //{
                    //    psFind.CKNo = ckNo;
                    //}
                    //else
                    //{
                    //    psFind.CKCo = Math.Abs(ckNo);
                    //}
                }
                // không có ps
                else
                {
                    dkNotPS.Add(new GetCanDoiSoPhatSinhTaiKhoan
                    {
                        AccountID = item.AccountID,
                        AccountName = item.AccountName,
                        AccountDetailID = item.AccountDetailID,
                        CustomerID = item.CustomerID,
                        DKNo = item.DebitBalance,
                        DKCo = item.CreditBalance,
                        PSNo = 0,
                        PSCo = 0,
                        //CKNo = item.DebitBalance,
                        //CKCo = item.CreditBalance
                    }); ;
                }
            }

            // Thêm danh sách có đầu kỳ nhưng không có phát sinh
            psData.AddRange(dkNotPS);

            // Tính cuối kỳ
            foreach(var ps in psData)
            {
                decimal ckNo = ps.DKNo + ps.PSNo - ps.DKCo - ps.PSCo;
                if (ckNo > 0)
                {
                    ps.CKNo = ckNo;
                }
                else
                {
                    ps.CKCo = Math.Abs(ckNo);
                }
            }

            return psData;
        }

        public List<GetChiTietSoCai> GetChiTietSoCai(DateTime fromDate, DateTime toDate)
        {
            List<GetCanDoiSoPhatSinhTaiKhoan> psdata = this.GetBangCanDoiSoPhatSinhChiTiet(fromDate, toDate);

            List<GetChiTietSoCai> chitiet = this.AccountsDAO.GetChiTietSoCai(fromDate, toDate);

            // gán đầu kỳ và cuối kỳ
            if (psdata != null && chitiet != null)
            {
                foreach (var item in psdata)
                {
                    GetChiTietSoCai itemFind = chitiet.Find(o => o.AccountID == item.AccountID && o.AccountDetailID == item.AccountDetailID);
                    if (itemFind != null)
                    {
                        itemFind.DKNo = item.DKNo;
                        itemFind.DKCo = item.DKCo;
                        itemFind.PSNo = item.PSNo;
                        itemFind.PSCo = item.PSCo;
                        itemFind.CKNo = item.CKNo;
                        itemFind.CKCo = item.CKCo;
                    }
                }
            }

            return chitiet;
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinh(DateTime fromDate, DateTime toDate, int type)
        {
            switch (type)
            {
                case 0:
                    return GetBangCanDoiSoPhatSinhByTaiKhoan(fromDate, toDate);

                case 1:
                    return GetBangCanDoiSoPhatSinhByThongKe(fromDate, toDate);

                case 2:
                    return GetBangCanDoiSoPhatSinhByKH(fromDate, toDate);
            }

            return null;
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinhByTaiKhoan(DateTime fromDate, DateTime toDate)
        {
            List<GetCanDoiSoPhatSinhTaiKhoan> data = GetBangCanDoiSoPhatSinhChiTiet(fromDate, toDate);

            data = data
                .GroupBy(o => o.AccountID)
                .OrderBy(o => o.Key)
                .Select(o => new GetCanDoiSoPhatSinhTaiKhoan
                {
                    AccountID = o.Key,
                    AccountName = o.Max(s => s.AccountName),
                    DKNo = o.Sum(s => s.DKNo),
                    DKCo = o.Sum(s => s.DKCo),
                    PSNo = o.Sum(s => s.PSNo),
                    PSCo = o.Sum(s => s.PSCo),
                    CKNo = o.Sum(s => s.CKNo),
                    CKCo = o.Sum(s => s.CKCo)
                })
                .ToList();

            return data;
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinhByThongKe(DateTime fromDate, DateTime toDate)
        {
            List<GetCanDoiSoPhatSinhTaiKhoan> data = GetBangCanDoiSoPhatSinhChiTiet(fromDate, toDate);

            data = data
                .GroupBy(o => new { o.AccountID, o.AccountDetailID })
                .OrderBy(o => o.Key.AccountID)
                .ThenBy(o => o.Key.AccountDetailID)
                .Select(o => new GetCanDoiSoPhatSinhTaiKhoan
                {
                    AccountID = o.Key.AccountID,
                    AccountDetailID = o.Key.AccountDetailID,
                    AccountName = o.Max(s => s.AccountName),
                    DKNo = o.Sum(s => s.DKNo),
                    DKCo = o.Sum(s => s.DKCo),
                    PSNo = o.Sum(s => s.PSNo),
                    PSCo = o.Sum(s => s.PSCo),
                    CKNo = o.Sum(s => s.CKNo),
                    CKCo = o.Sum(s => s.CKCo)
                })
                .ToList();

            return data;
        }

        public List<GetCanDoiSoPhatSinhTaiKhoan> GetBangCanDoiSoPhatSinhByKH(DateTime fromDate, DateTime toDate)
        {
            List<GetCanDoiSoPhatSinhTaiKhoan> data = GetBangCanDoiSoPhatSinhChiTiet(fromDate, toDate);

            data = data
                .OrderBy(o => o.AccountID)
                .ThenBy(o => o.AccountDetailID)
                .ThenBy(o => o.CustomerID)
                .ToList();

            return data;
        }
    }
}
