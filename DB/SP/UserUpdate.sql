CREATE PROCEDURE [dbo].[UserUpdate] (
	@UserID varchar(20),
	@Password varchar(250) = NULL,
	@UserName nvarchar(250),
	@Phone varchar(10),
	@UpdateUserID varchar(20)
)
AS	
	UPDATE UserList
	SET 
		[Password] =
			CASE 
				WHEN (@Password IS NULL) THEN [Password]
				ELSE @Password					
			END,
		UserName = @UserName,
		Phone = @Phone,
		UpdateDate = GETDATE(),
		UpdateUser = @UpdateUserID
	WHERE
		UserID = @UserId
		AND IsDelete IS NULL