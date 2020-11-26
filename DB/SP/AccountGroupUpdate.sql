CREATE PROCEDURE AccountGroupUpdate (
	@AccountGroupID varchar(50),
	@AccountGroupName nvarchar(250),
	@UserID varchar(20)
)
AS
	UPDATE AccountGroup
	SET
		AccountGroupName = @AccountGroupName
		,UpdateDate = GETDATE()
		,UpdateUser = @UserId
	WHERE 
		AccountGroupID = @AccountGroupID
