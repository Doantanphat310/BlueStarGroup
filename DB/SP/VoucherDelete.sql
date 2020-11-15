CREATE PROCEDURE VoucherDelete (
	@VoucherID nvarchar(250),
	@UserId varchar(20)
)
AS
begin
		UPDATE Vouchers
		SET
		UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		IsDelete = 1
		WHERE 
		VouchersID = @VoucherID
		--delete voucherDetail
		Update VouchersDetail 
		set UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		IsDelete = 1
		where VouchersID = @VoucherID
		--delete WareHouseDetail voucherIDDetail
		update WareHouseDetail
		set UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		Isdelete = 1
		where VouchersDetailID in (select VouchersDetailID from VouchersDetail where VouchersID = @VoucherID)
		--delete inVoiceDetail invoice ID
		update InvoiceDetail
		set UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		Isdelete = 1
		where InvoiceID in (select InvoiceID from Invoice where VouchersIDetailD in (select VouchersIDetailD from VouchersDetail where VouchersID = @VoucherID))
		--delete invoice
		update Invoice
		set UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		Isdelete = 1
		where VouchersIDetailD in (select VouchersDetailID from VouchersDetail where VouchersID = @VoucherID)
end


EXEC sp_rename 'Invoice.Status', 'IsDelete', 'COLUMN';
Alter table Invoice
alter column IsDelete bit