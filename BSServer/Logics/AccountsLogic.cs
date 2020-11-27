using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Base;
using BSServer._Core.Context;
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
                    foreach (AccountGroup data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.AccountsDAO.InsertAccountGroup(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.AccountsDAO.UpdateAccountGroup(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.AccountsDAO.DeleteAccountGroup(data.AccountGroupID);
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
                                this.AccountsDAO.DeleteAccounts(data.AccountID);
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
