ALTER PROCEDURE [dbo].[UserInsert] (
	@UserID varchar(20),
	@Password varchar(250),
	@UserName nvarchar(250),
	@Phone varchar(10),
	@Address nvarchar(250),
	@UpdateUserID varchar(20)
)
AS	
	INSERT INTO UserList(
		UserID,
		[Password],
		UserName,
		Phone,
		[Address],
		CreateDate,
		UpdateDate,
		CreateUser,
		UpdateUser)
	VALUES(
		@UserID,
		@Password,
		@UserName,
		@Phone,
		@Address,
		GETDATE(),
		GETDATE(),
		@UpdateUserID,
		@UpdateUserID)