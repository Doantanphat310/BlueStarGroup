DROP PROCEDURE IF EXISTS AccountsUpdate;
GO
CREATE PROCEDURE AccountsUpdate (
	@AccountID varchar(30)
	,@AccountName nvarchar(250)
	,@AccountGroupID varchar(30)
	,@AccountLevel tinyint
	,@ParentID varchar(30)
    ,@UserID varchar(20)
)
AS
	UPDATE Accounts
	SET
		AccountID = @AccountID
		,AccountName = @AccountName
		,AccountGroupID = @AccountGroupID
		,AccountLevel = @AccountLevel
		,ParentID = @ParentID
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UserId
	WHERE 

