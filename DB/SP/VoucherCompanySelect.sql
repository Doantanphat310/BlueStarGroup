alter PROCEDURE [dbo].[VoucherCompanySelect] (
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