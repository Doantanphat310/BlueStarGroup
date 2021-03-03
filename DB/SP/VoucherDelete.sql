alter PROCEDURE VoucherDelete (
	@VoucherID varchar(50),
	@CompanyID varchar(50),
	@UserId varchar(20)
)
AS
begin
		--delete invoice
		delete Invoice
		where VouchersID = @VoucherID
				--delete WareHouseDetail voucherIDDetail
		delete WareHouseDetail
		where WarehouseID in (select WarehouseID from WareHouse where VouchersID = @VoucherID)
				--Delete wareHouse
		delete WareHouse
		where VouchersID = @VoucherID
				--delete voucherDetail
		delete VouchersDetail
		where VouchersID = @VoucherID

		delete Vouchers
		WHERE 
		VouchersID = @VoucherID

end

