DROP PROCEDURE IF EXISTS UserRoleCompanyInsert;
GO
CREATE PROCEDURE UserRoleCompanyInsert (
	@UserID varchar(50)
	,@CompanyID varchar(50)
	,@RoleID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO UserRoleCompany(
		UserID
		,CompanyID
		,RoleID
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@UserID
		,@CompanyID
		,@RoleID
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
