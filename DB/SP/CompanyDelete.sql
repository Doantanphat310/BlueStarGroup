DROP PROCEDURE IF EXISTS CompanyDelete;
GO
CREATE PROCEDURE CompanyDelete (
	@CompanyID varchar(20)
)
AS
	DELETE Company
	WHERE 
		CompanyID = @CompanyID
