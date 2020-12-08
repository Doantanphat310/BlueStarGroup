DROP PROCEDURE IF EXISTS CompanySelect;
GO
CREATE PROCEDURE CompanySelect
AS
	SELECT * 
	FROM Company
	WHERE IsDelete IS NULL
	ORDER BY 
		CompanyName