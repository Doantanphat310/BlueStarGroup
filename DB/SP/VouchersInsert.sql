USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerInsert]    Script Date: 11/8/2020 12:04:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VouchersInsert] (
	@VouchersID varchar(50),
	@Amount money,
	@Description nvarchar(max),
	@VouchersTypeID varchar(50),
	@Date datetime,
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
Declare @VoucherNo bigint
set @VoucherNo = (select count(VouchersID) from Vouchers where VouchersTypeID = @VouchersTypeID and year(VoucherDate) = YEAR(@Date))
SELECT ISNULL(@VoucherNo, CAST(0 as bigint))
if(@VoucherNo = 0)
begin
	set @VoucherNo = 1
end
else
	begin
		set @VoucherNo = (select MAX(VoucherNo) from Vouchers where VouchersTypeID = @VouchersTypeID and year(VoucherDate) = YEAR(@Date)) + 1
	end
	INSERT INTO Vouchers(
		VouchersID,
		VoucherDescription,
		VoucherAmount,
		VouchersTypeID,
		VoucherDate,
		CreateUser,
		CreateDate,
		CompanyID,
		VoucherNo
		)
	VALUES(
		@VouchersID,
		@Description,
		@Amount,
		@VouchersTypeID,
		@Date,
		@CreateUser,
		GETDATE(),
		@CompanyID,
		@VoucherNo)