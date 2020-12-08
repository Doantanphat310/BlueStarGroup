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
                                seq++;
                                GeneralLedger generalLedger = new GeneralLedger
                                {
                                    GeneralLedgerID = GenerateID.GeneralLedgerID(seq),
                                    AccountID = data.AccountID,
                                    GeneralLedgerName = $"{data.AccountID} - {data.AccountName}"
                                };

                                this.AccountsDAO.InsertAccounts(data);

                                this.AccountsDAO.InsertGeneralLedger(generalLedger);

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

        public bool SaveGeneralLedger(List<GeneralLedger> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = this.AccountsDAO.GetGeneralLedgerSEQ();

                    foreach (GeneralLedger data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.GeneralLedgerID = GenerateID.GeneralLedgerID(seq);

                                this.AccountsDAO.InsertGeneralLedger(data);

                                break;

                            // Update
                            case ModifyMode.Update:
                                this.AccountsDAO.UpdateGeneralLedger(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.AccountsDAO.DeleteGeneralLedger(data);
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
    }
}
