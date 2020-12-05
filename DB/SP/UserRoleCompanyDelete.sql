DROP PROCEDURE IF EXISTS UserRoleCompanyDelete;
GO
CREATE PROCEDURE UserRoleCompanyDelete (
	@UserID varchar(50)
	,@CompanyID varchar(50)
	,@RoleID varchar(50)
)
AS
	DELETE UserRoleCompany
	WHERE 
		UserID = @UserID
		AND CompanyID = @CompanyID
		AND RoleID = @RoleID
