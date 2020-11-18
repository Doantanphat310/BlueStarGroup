USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[VoucherConditionSelect]    Script Date: 17/11/2020 3:24:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[VoucherConditionSelect] (
@CompanyID varchar(20),
@NgayBD datetime, @NgayKT datetime,
@VouchersTypeID varchar(20),
@UserName varchar(50) 
)
AS
begin
if(@VouchersTypeID = 'VOU000')
begin
SELECT VouchersID,Description,Date,Amount,VouchersTypeID,CreateUser,CompanyID
	FROM Vouchers
	WHERE 
		CompanyID = @CompanyID
		AND 
		IsDelete IS NULL
		AND date >= @NgayBD and date <= @NgayKT
	ORDER BY VouchersID
end
else
	begin
	SELECT VouchersID,Description,Date,Amount,VouchersTypeID,CreateUser,CompanyID
	FROM Vouchers
	WHERE 
		CompanyID = @CompanyID
		AND 
		IsDelete IS NULL
		AND
		VouchersTypeID = @VouchersTypeID
		AND date >= @NgayBD and date <= @NgayKT
	ORDER BY VouchersID
	end
end

	