DROP PROCEDURE IF EXISTS CustomerSelect;
GO
CREATE PROCEDURE CustomerSelect
AS
	SELECT * 
	FROM Customer
	WHERE 
		IsDelete IS NULL
	ORDER BY CustomerName