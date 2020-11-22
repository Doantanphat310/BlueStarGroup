CREATE PROCEDURE ItemsPriceCompanyInsert (
	@ItemID varchar(50),
	@CompanyID varchar(50),
	@ItemPrices money,
	@UserId varchar(20)
)
AS	
	INSERT INTO ItemsPriceCompany(
		ItemID
		,CompanyID
		,ItemPrices
		,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@ItemID
		,@CompanyID
		,@ItemPrices
		,GETDATE()
		,GETDATE()
		,@UserID
		,@UserID)