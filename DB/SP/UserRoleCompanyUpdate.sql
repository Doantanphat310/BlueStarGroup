DROP PROCEDURE IF EXISTS UserRoleCompanyUpdate;
GO
CREATE PROCEDURE UserRoleCompanyUpdate (
	@UserID varchar(50)
	,@CompanyID varchar(50)
	,@RoleID varchar(50)
    ,@UserID varchar(20)
)
AS
	UPDATE UserRoleCompany
	SET
		UserID = @UserID
		,CompanyID = @CompanyID
		,RoleID = @RoleID
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UserId
	WHERE 

