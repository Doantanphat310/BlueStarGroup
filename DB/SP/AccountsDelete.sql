ALTER PROCEDURE [dbo].[AccountsDelete] (
	@AccountID varchar(50)
)
AS
	DELETE Accounts
	WHERE 
		AccountID = @AccountID