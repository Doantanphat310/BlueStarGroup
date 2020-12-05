DROP PROCEDURE IF EXISTS ItemPriceCompanyDelete;
GO
CREATE PROCEDURE ItemPriceCompanyDelete (
	@ItemID varchar(50)
	,@CompanyID varchar(50)
)
AS
	DELETE ItemPriceCompany
	WHERE 
		ItemID = @ItemID
		AND CompanyID = @CompanyID
