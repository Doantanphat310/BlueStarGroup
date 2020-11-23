using BSCommon.Constant;
using BSCommon.Models;
using BSServer._Core.Context;
using BSServer._Core.Utility;
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
        }

        private BSContext Context { get; set; }

        private VoucherDAO VoucherDAO { get; set; }
        private VoucherDetailDAO VoucherDetailDAO { get; set; }

        public bool SaveVoucherDetail(List<VoucherDetail> saveData)
        {
            using (DbContextTransaction transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    long seq = VoucherDetailDAO.GetVoucherDetailSEQ();
                    foreach (VoucherDetail data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seq++;
                                data.VouchersDetailID = GenerateID.VoucherDetailID(seq);
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
                    long seq = VoucherDAO.GetVoucherSEQ();
                    switch (voucher.Status)
                    {
                        // Add new
                        case ModifyMode.Insert:
                            //get, set voucherID
                            seq++;
                            voucher.VouchersID = GenerateID.VoucherDetailID(seq);
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

                    long seqDetail = VoucherDetailDAO.GetVoucherDetailSEQ();
                    foreach (VoucherDetail data in saveData)
                    {
                        switch (data.Status)
                        {
                            // Add new
                            case ModifyMode.Insert:
                                seqDetail++;
                                data.VouchersID = voucher.VouchersID;
                                data.VouchersDetailID = GenerateID.VoucherDetailID(seqDetail);
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
