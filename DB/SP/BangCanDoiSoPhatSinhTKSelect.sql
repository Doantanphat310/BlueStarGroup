DROP PROCEDURE IF EXISTS BangCanDoiSoPhatSinhTKSelect;
GO
CREATE PROCEDURE BangCanDoiSoPhatSinhTKSelect
AS
	SELECT
		AccountID,
		AccountName
	FROM Accounts
	ORDER BY 
		AccountID