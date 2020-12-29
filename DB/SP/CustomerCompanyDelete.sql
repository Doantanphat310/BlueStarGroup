DROP PROCEDURE IF EXISTS CustomerCompanyDelete;
GO
CREATE PROCEDURE CustomerCompanyDelete (
	@CompanyID varchar(50)
	,@CustomerID varchar(50)
)
AS
	DELETE CustomerCompany
	WHERE 
		CompanyID = @CompanyID
		AND CustomerID = @CustomerID
