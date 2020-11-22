ALTER PROCEDURE ItemsPriceCompanySelect 
AS
	SELECT 
		L.ItemID
		,L.ItemName
		,L2.CompanyID
		,L2.CompanyName
		,D.ItemPrices
	FROM Items L
		INNER JOIN ItemsPriceCompany D
			ON L.ItemID = D.ItemID
		INNER JOIN Company L2
			ON L2.CompanyID = D.CompanyID
	WHERE 
		L.IsDelete IS NULL
		AND L2.IsDelete IS NULL
	ORDER BY 
		L.ItemID,
		L2.CompanyID