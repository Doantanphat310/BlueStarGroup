CREATE PROCEDURE ItemsPriceCompanyDelete (
	@ItemID varchar(50),
	@CompanyID varchar(50)
)
AS	
	DELETE ItemsPriceCompany
	WHERE ItemID = @ItemID
		AND CompanyID = @CompanyID