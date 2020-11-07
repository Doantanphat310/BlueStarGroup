ALTER PROCEDURE [dbo].[CustomerSelect]
AS
	SELECT * 
	FROM Customer
	WHERE 
		IsDelete IS NULL
	ORDER BY CustomerID