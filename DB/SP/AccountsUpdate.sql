CREATE PROCEDURE AccountsUpdate (
	@AccountID varchar(50),
	@AccountName nvarchar(250),
	@AccountGroupID varchar(50),
	@AccountLevel tinyint,
	@ParentID uniqueidentifier,
	@UserID varchar(20)
)
AS
	UPDATE Accounts
	SET
		AccountName = @AccountName
		,AccountGroupID = @AccountGroupID
		,AccountLevel = @AccountLevel
		,ParentID = @ParentID
		,UpdateDate = GETDATE()
		,UpdateUser = @UserId
	WHERE 
		AccountID = @AccountID
