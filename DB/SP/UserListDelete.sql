DROP PROCEDURE IF EXISTS UserListDelete;
GO
CREATE PROCEDURE UserListDelete (
	@UserID varchar(20)
    ,@UserID varchar(20)
)
AS
	UPDATE UserList
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UserId
		,IsDelete = 1
	WHERE 
		UserID = @UserID
