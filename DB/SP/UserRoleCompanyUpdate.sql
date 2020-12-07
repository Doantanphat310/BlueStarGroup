DROP PROCEDURE IF EXISTS UserRoleCompanyUpdate;
GO
CREATE PROCEDURE UserRoleCompanyUpdate (
	@UserID varchar(50)
	,@CompanyID varchar(50)
	,@RoleID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE UserRoleCompany
	SET
		UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		UserID = @UserID
		AND CompanyID = @CompanyID
		AND RoleID = @RoleID
