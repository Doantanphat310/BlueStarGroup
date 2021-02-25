DROP PROC IF EXISTS SP_GetCompanyByID;
GO
CREATE PROC SP_GetCompanyByID (
	@CompanyID VARCHAR(50)
)
AS
	SELECT 
		*
	FROM Company
	WHERE CompanyID = @CompanyID