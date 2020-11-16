using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BSServer.Logics
{
    public class UserLogic
    {
        public UserLogic(BSContext context)
        {
            this.Context = context;
            this.UserDAO = new UserDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private UserDAO UserDAO { get; set; }

        public bool SaveUser(List<UserInfo> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (UserInfo data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.UserDAO.InsertUser(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.UserDAO.UpdateUser(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.UserDAO.DeleteUser(data.UserID);
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

        public bool SaveUserRoleCompany(List<UserRoleInfo> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (UserRoleInfo data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.UserDAO.InsertUserRoleCompany(data);
                                break;

                            //// Update
                            //case 2:
                            //    this.UserDAO.UpdateCustommersCompany(customer);
                            //    break;

                            // Delete
                            case ModifyMode.Delete:
                                this.UserDAO.DeleteUserRoleCompany(data);
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
