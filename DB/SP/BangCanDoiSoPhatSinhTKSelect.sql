DROP PROCEDURE IF EXISTS BangCanDoiSoPhatSinhTKSelect;
GO
CREATE PROCEDURE BangCanDoiSoPhatSinhTKSelect
AS
	SELECT * 
	FROM Company
	WHERE IsDelete IS NULL
	ORDER BY 
		CompanyName