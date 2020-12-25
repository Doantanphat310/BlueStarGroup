using BSCommon.Constant;
using BSCommon.Models;
using BSCommon.Utility;
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

        public bool SaveUser(List<Users> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (Users data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                this.UserDAO.InsertUserList(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.UserDAO.UpdateUserList(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.UserDAO.DeleteUserList(data);
                                break;
                        }
                    }

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool SaveUserRoleCompany(List<UserRoleCompany> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (UserRoleCompany data in saveData)
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
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
