alter PROCEDURE [dbo].[VouchersDetailDelete] (
	@VouchersDetailID varchar(50),
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
	begin
		declare @VoucherID varchar(50)
		set @VoucherID = (select distinct VouchersID from VouchersDetail where VouchersDetailID = @VouchersDetailID)

		delete VouchersDetail
		where VouchersDetailID = @VouchersDetailID and CompanyID = @CompanyID and CreateUser = @CreateUser

		declare @Count int
		set @Count = (select count(*) from VouchersDetail where VouchersID = @VoucherID)
		if(@Count <= 0)
		begin
				delete Vouchers
				where VouchersID = @VoucherID
		end
	end