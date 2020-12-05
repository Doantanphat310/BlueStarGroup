DROP PROCEDURE IF EXISTS UserListDelete;
GO
CREATE PROCEDURE UserListDelete (
	@UserID varchar(20)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE UserList
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UpdateUser
		,IsDelete = 1
	WHERE 
		UserID = @UserID
