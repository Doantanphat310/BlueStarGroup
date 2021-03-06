ALTER PROCEDURE CustomerNotCompanySelect (
	@CompanyID varchar(20) NULL
)
AS
	SELECT *
	FROM Customer CUS
	WHERE 
		CUS.CustomerID NOT IN (
			SELECT CustomerID FROM CustomerCommany 
			WHERE CompanyID = @CompanyID)
		AND 
		CUS.IsDelete IS NULL
	ORDER BY CUS.CustomerID