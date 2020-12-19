DROP PROCEDURE IF EXISTS UserListDelete;
GO
CREATE PROCEDURE UserListDelete (
	@UserID varchar(20)
)
AS
	DELETE UserList
	WHERE 
		UserID = @UserID
