using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Context;
using BSServer.DAOs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSServer.Logics
{
   public  class VoucherDetailLogic
    {
        public VoucherDetailLogic(BSContext context)
        {
            this.Context = context;
            this.VoucherDetailDAO = new VoucherDetailDAO(this.Context);
            this.VoucherDAO = new VoucherDAO(this.Context);
            this.CommonDAO = new CommonDAO(this.Context);
        }

        private BSContext Context { get; set; }

        private VoucherDAO VoucherDAO { get; set; }
        private VoucherDetailDAO VoucherDetailDAO { get; set; }
        private CommonDAO CommonDAO { get; set; }

        public bool SaveVoucherDetail(List<VoucherDetail> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (VoucherDetail data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                data.VouchersDetailID = CommonDAO.GetVoucherDetailID();
                                this.VoucherDetailDAO.InsertVouchersDetail(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.VoucherDetailDAO.UpdateVoucherDetail(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.VoucherDetailDAO.DeleteVoucherDetail(data.VouchersDetailID,data.CompanyID);
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

        #region Insert voucher - Detail
        public bool SaveVoucher_Detail(List<VoucherDetail> saveData, Voucher voucher)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    #region insert voucher before detail
                    //get voucherID
                    switch (voucher.Status)
                    {
                        // Add new
                        case ModifyMode.Insert:
                            //get, set voucherID
                            voucher.VouchersID = this.CommonDAO.GetVoucherID();
                            this.VoucherDAO.InsertVouchers(voucher);
                            break;

                        // Update
                        case ModifyMode.Update:
                            this.VoucherDAO.UpdateVoucher(voucher);
                            break;

                        // Delete
                        case ModifyMode.Delete:
                            this.VoucherDAO.DeleteVoucher(voucher.VouchersID, voucher.CompanyID);
                            break;
                    }
                    #endregion insert voucher before detail

                    foreach (VoucherDetail data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                data.VouchersID = voucher.VouchersID;
                                data.VouchersDetailID = CommonDAO.GetVoucherDetailID();
                                this.VoucherDetailDAO.InsertVouchersDetail(data);
                                break;

                            // Update
                            case ModifyMode.Update:
                                this.VoucherDetailDAO.UpdateVoucherDetail(data);
                                break;

                            // Delete
                            case ModifyMode.Delete:
                                this.VoucherDetailDAO.DeleteVoucherDetail(data.VouchersDetailID, data.CompanyID);
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
        #endregion Insert voucher - Detail
    }
}
