alter PROCEDURE [dbo].[VouchersDetailDelete] (
	@VouchersDetailID varchar(50),
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
	begin
		update VouchersDetail
		set IsDelete = 0
		where VouchersDetailID = @VouchersDetailID and CompanyID = @CompanyID and CreateUser = @CreateUser
	end