CREATE PROCEDURE [dbo].[UserRoleCompanyInsert] (
	@UserID varchar(20),
	@CompanyID varchar(20),
	@RoleID varchar(20)
)
AS	
	INSERT INTO UserRoleCompany(
		UserID,
		CompanyID,
		RoleID,
		CreateDate,
		UpdateDate,
		CreateUser,
		UpdateUser)
	VALUES(
		@UserID,
		@CompanyID,
		@RoleID,
		GETDATE(),
		GETDATE(),
		@UserId,
		@UserId)