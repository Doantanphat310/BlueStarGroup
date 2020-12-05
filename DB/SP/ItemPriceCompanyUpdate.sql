DROP PROCEDURE IF EXISTS ItemPriceCompanyUpdate;
GO
CREATE PROCEDURE ItemPriceCompanyUpdate (
	@ItemID varchar(50)
	,@CompanyID varchar(50)
	,@ItemPrice money
    ,@UserID varchar(20)
)
AS
	UPDATE ItemPriceCompany
	SET
		ItemPrice = @ItemPrice
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UserId
	WHERE 
		ItemID = @ItemID
		ANDCompanyID = @CompanyID
