DROP PROCEDURE IF EXISTS ItemPriceCompanyInsert;
GO
CREATE PROCEDURE ItemPriceCompanyInsert (
	@ItemID varchar(50)
	,@CompanyID varchar(50)
	,@ItemPrice money
    ,@UserId varchar(20)
)
AS
	INSERT INTO ItemPriceCompany(
		ItemID
		,CompanyID
		,ItemPrice
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@ItemID
		,@CompanyID
		,@ItemPrice
        ,GETDATE()
        ,GETDATE()
        ,@UserId
        ,@UserId)
