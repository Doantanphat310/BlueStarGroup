USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[VoucherCompanySelect]    Script Date: 13/11/2020 1:07:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[VoucherCompanySelect] (
	@CompanyID varchar(20)
)
AS
	SELECT * 
	FROM Vouchers
	WHERE 
		CompanyID = @CompanyID
		AND 
		IsDelete IS not NULL
	ORDER BY VouchersID

alter PROCEDURE [dbo].[VoucherConditionSelect] (
@CompanyID varchar(20),
@NgayBD datetime, @NgayKT datetime,
@VouchersTypeSumary varchar(20),
@UserName varchar(50) 
)
AS
	SELECT * 
	FROM Vouchers
	WHERE 
		CompanyID = @CompanyID
		AND 
		IsDelete IS NULL
		AND
		VouchersTypeSumary = @VouchersTypeSumary
		AND date >= @NgayBD and date <= @NgayKT
	ORDER BY VouchersID

EXEC sp_rename 'Vouchers.VourchersTypeSumary', 'VouchersTypeSumary', 'COLUMN';