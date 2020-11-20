Create PROCEDURE [dbo].[InvoiceSelectVoucherID] (
	@VouchersID varchar(50),
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
	begin
	select * from Invoice as A
	where VouchersID = @VouchersID and A.CompanyID = @CompanyID and A.CreateUser = @CreateUser and A.IsDelete is null
	end
		