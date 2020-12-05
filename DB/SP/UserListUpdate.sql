DROP PROCEDURE IF EXISTS UserListUpdate;
GO
CREATE PROCEDURE UserListUpdate (
	@UserID varchar(20)
	,@Password varchar(250)
	,@UserName nvarchar(250)
	,@Phone varchar(10)
	,@Address nvarchar(250)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE UserList
	SET
		Password = @Password
		,UserName = @UserName
		,Phone = @Phone
		,Address = @Address
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		UserID = @UserID
