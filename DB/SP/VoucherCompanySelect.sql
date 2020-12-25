alter PROCEDURE [dbo].[VoucherCompanySelect] (
	@VoucherDate datetime,
	@CompanyID varchar(20)
)
AS
	SELECT * 
	FROM Vouchers
	WHERE 
		CompanyID = @CompanyID
		AND 
		IsDelete IS  NULL
		And Year(VoucherDate) = year(@VoucherDate)
	ORDER BY VouchersID


