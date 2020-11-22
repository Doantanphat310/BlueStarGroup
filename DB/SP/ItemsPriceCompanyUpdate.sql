CREATE PROCEDURE ItemsPriceCompanyUpdate (
	@ItemID varchar(50),
	@CompanyID varchar(50),
	@ItemPrices money,
	@UserId varchar(20)
)
AS
	UPDATE ItemsPriceCompany
	SET
		ItemPrices = @ItemPrices,
		UpdateDate = GETDATE(),
		UpdateUser = @UserId
	WHERE 
		ItemID = @ItemID
		AND CompanyID = @CompanyID