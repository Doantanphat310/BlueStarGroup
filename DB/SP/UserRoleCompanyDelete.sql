CREATE PROCEDURE [dbo].[UserRoleCompanyDelete] (
	@UserID varchar(20),
	@CompanyID varchar(20),
	@RoleID varchar(20)
)
AS	
	DELETE UserRoleCompany
	WHERE
		UserID = @UserId
		AND CompanyID = @CompanyID
		AND RoleID = @RoleID