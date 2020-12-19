Create PROCEDURE VoucherDelete (
	@VoucherID varchar(50),
	@CompanyID varchar(50),
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
		--Delete wareHouse
		update WareHouse
		set UpdateDate = getdate(),
		UpdateUser = @UserId,
		Isdelete = 1
		where VouchersID = @VoucherID
		--delete WareHouseDetail voucherIDDetail
		update WareHouseDetail
		set UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		Isdelete = 1
		where WarehouseID in (select WarehouseID from WareHouse where VouchersID = @VoucherID)
		--delete invoice
		update Invoice
		set UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		Isdelete = 1
		where VouchersID = @VoucherID
end

