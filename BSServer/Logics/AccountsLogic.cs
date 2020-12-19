using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
using BSServer._Core.Utility;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;

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

        public List<BangCanDoiSoPhatSinhTK> GetBangCanDoiSoPhatSinhByThongKe(DateTime fromDate, DateTime toDate)
        {
            List<BangCanDoiSoPhatSinhTK> psData = this.AccountsDAO.GetBangCanDoiSoPhatSinhTK(fromDate, toDate);

            List<GetBalance> dkData = this.AccountsDAO.GetSoDuDauKy(fromDate);
            DateTime balanceDate;
            List<BangCanDoiSoPhatSinhTK> psDKData = null;

            if (dkData != null && dkData.Count > 0)
            {
                balanceDate = dkData[0].BalanceDate;
                psDKData = this.AccountsDAO.GetBangCanDoiSoPhatSinhTK(balanceDate, fromDate);
            }

            // tính lại đầu kỳ
            if (psDKData != null)
            {
                foreach (var item in dkData)
                {
                    BangCanDoiSoPhatSinhTK psdk = psDKData.Find(o => o.AccountID == item.AccountID && o.AccountDetailID == item.AccountDetailID);
                    decimal dk;
                    if (psdk != null)
                    {
                        dk = item.DebitBalance - item.CreditBalance + psdk.PSNo - psdk.PSCo;
                    }
                    else
                    {
                        dk = item.DebitBalance - item.CreditBalance;
                    }

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

            // Thêm DK vào phát sinh
            foreach(var item in psData)
            {
                var dk = dkData.Find(o => o.AccountID == item.AccountID && o.AccountDetailID == item.AccountDetailID);
                if(dk != null)
                {
                    item.DKNo = dk.DebitBalance;
                    item.DKCo = dk.CreditBalance;
                }

                decimal ck = item.DKNo + item.PSNo - item.DKCo - item.PSCo;
                if (ck > 0)
                {
                    item.CKNo = ck;
                    item.CKCo = 0;
                }
                else
                {
                    item.CKNo = 0;
                    item.CKCo = -1 * ck;
                }
            }

            return psData;
        }

        public List<GetChiTietSoCai> GetChiTietSoCai(DateTime fromDate, DateTime toDate)
        {
            List<BangCanDoiSoPhatSinhTK> psdata = this.GetBangCanDoiSoPhatSinhByThongKe(fromDate, toDate);

            List<GetChiTietSoCai> chitiet = this.AccountsDAO.GetChiTietSoCai(fromDate, toDate);

            // gán đầu kỳ và cuối kỳ
            if (psdata != null && chitiet != null)
            {
                foreach (var item in psdata)
                {
                    GetChiTietSoCai itemFind = chitiet.Find(o => o.AccountID == item.AccountID && o.AccountDetailID == item.AccountDetailID);
                    if(itemFind != null)
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
    }

}
