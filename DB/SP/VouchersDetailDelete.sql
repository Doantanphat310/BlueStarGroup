create PROCEDURE [dbo].[VouchersDetailDelete] (
	@VouchersDetailID varchar(50),
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
	begin
		update VouchersDetail
		set IsDelete = 1
		where VouchersDetailID = @VouchersDetailID and CompanyID = @CompanyID and CreateUser = @CreateUser

		declare @VoucherID varchar(50)
		set @VoucherID = (select distinct VouchersID from VouchersDetail where VouchersDetailID = @VouchersDetailID)
		Declare @Counter int
		set @Counter = (select COUNT(VouchersDetailID) from VouchersDetail where VouchersID = @VoucherID and IsDelete is NULL)
		if(@Counter < 1)
		begin
			update Vouchers
			set IsDelete = 1
			where VouchersID = @VoucherID
		end
	end