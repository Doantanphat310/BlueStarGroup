DROP PROCEDURE IF EXISTS GeneralLedgerUpdate;
GO
CREATE PROCEDURE GeneralLedgerUpdate (
	@GeneralLedgerID varchar(50)
	,@GeneralLedgerName nvarchar(250)
	,@AccountID varchar(50)
	,@CompanyID varchar(50)
	,@ParentID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE GeneralLedger
	SET
		GeneralLedgerName = @GeneralLedgerName
		,AccountID = @AccountID
		,CompanyID = @CompanyID
		,ParentID = @ParentID
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		GeneralLedgerID = @GeneralLedgerID
