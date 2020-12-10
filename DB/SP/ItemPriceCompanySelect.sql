DROP PROC IF EXISTS ItemsPriceCompanySelect;
GO
CREATE PROCEDURE ItemsPriceCompanySelect 
AS
	SELECT 
		D.*
		,L.ItemName
		,L2.CompanyName
	FROM Items L
		INNER JOIN ItemPriceCompany D
			ON L.ItemID = D.ItemID
		INNER JOIN Company L2
			ON L2.CompanyID = D.CompanyID
	WHERE 
		L.IsDelete IS NULL
		AND L2.IsDelete IS NULL
	ORDER BY
		L2.CompanyName
		,L.ItemName