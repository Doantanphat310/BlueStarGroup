DROP PROC IF EXISTS SP_GetItems;
GO
CREATE PROCEDURE SP_GetItems 
	@CompanyID VARCHAR(50)
AS
	SELECT 
		L.*
		,D.CompanyID
		,D.ItemPrice
	FROM Items L
		INNER JOIN ItemPriceCompany D
			ON L.ItemID = D.ItemID
	WHERE 
		D.CompanyID = @CompanyID
	ORDER BY
		L.ItemName