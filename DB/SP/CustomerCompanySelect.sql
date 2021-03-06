Create PROCEDURE [dbo].[CustomerCompanySelect] (
	@CompanyID varchar(20)
)
AS
	SELECT * 
	FROM Customer CUS
		INNER JOIN CustomerCommany COM
		ON CUS.CustomerID = COM.CustomerID
	WHERE 
		COM.CompanyID = @CompanyID
		AND 
		CUS.IsDelete IS NULL
	ORDER BY CUS.CustomerID