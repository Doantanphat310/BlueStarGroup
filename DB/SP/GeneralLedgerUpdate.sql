CREATE PROCEDURE GeneralLedgerUpdate (
	@GeneralLedgerID varchar(30),
	@GeneralLedgerName nvarchar(250),
	@AccountID varchar(50),
	@CompanyID varchar(50),
	@ParentID varchar(30),
	@UserID varchar(20)
)
AS
	UPDATE GeneralLedger
	SET
		GeneralLedgerName = @GeneralLedgerName
		,AccountID = @AccountID
		,CompanyID = @CompanyID
		,ParentID = @ParentID
		,UpdateDate = GETDATE()
		,UpdateUser = @UserId
	WHERE 
		GeneralLedgerID = @GeneralLedgerID
