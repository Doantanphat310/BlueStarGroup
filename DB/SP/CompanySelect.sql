Create PROCEDURE [dbo].[CompanySelect] 
AS
	SELECT * 
	FROM Company COM
	WHERE COM.IsDelete IS NULL
	ORDER BY 
		COM.CompanyID