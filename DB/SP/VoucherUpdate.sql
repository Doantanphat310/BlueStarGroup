USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerUpdate]    Script Date: 11/8/2020 12:08:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Alter PROCEDURE [dbo].[VoucherUpdate] (
	@VouchersID nvarchar(250),
	@Amount money,
	@Description nvarchar(max),
	@CreateUser varchar(20)
)
AS
	--UPDATE Vouchers
	--SET
	--	VoucherAmount = @Amount,
	--	VoucherDescription = @Description,
	--	UpdateDate = GETDATE(),
	--	UpdateUser = @CreateUser
	--WHERE 
	--	VouchersID = @VouchersID
	--	AND IsDelete IS NULL

if(exists(select * from Vouchers as A inner join UserRoleCompany as B on A.CompanyID = B.CompanyID where B.RoleID = 'ROLE01' and B.UserID = @CreateUser and A.VouchersID = @VouchersID))
begin
	UPDATE Vouchers
	SET
		VoucherAmount = @Amount,
		VoucherDescription = @Description,
		UpdateDate = GETDATE(),
		UpdateUser = @CreateUser
	WHERE 
		VouchersID = @VouchersID
		AND IsDelete IS NULL
end
else 
	begin
		UPDATE Vouchers
	SET
		VoucherAmount = @Amount,
		VoucherDescription = @Description,
		UpdateDate = GETDATE(),
		UpdateUser = @CreateUser
	WHERE 
		VouchersID = @VouchersID
		AND IsDelete IS NULL
		and CreateUser = @CreateUser
	end

select * from Vouchers

select * from UserRoleCompany

select * from MasterInfo