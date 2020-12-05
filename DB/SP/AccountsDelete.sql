DROP PROCEDURE IF EXISTS AccountsDelete;
GO
CREATE PROCEDURE AccountsDelete (
	@AccountID varchar(30)
)
AS
	DELETE Accounts
	WHERE 
		AccountID = @AccountID
