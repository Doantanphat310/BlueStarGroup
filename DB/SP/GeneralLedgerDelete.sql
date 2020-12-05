DROP PROCEDURE IF EXISTS GeneralLedgerDelete;
GO
CREATE PROCEDURE GeneralLedgerDelete (
	@GeneralLedgerID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE GeneralLedger
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UpdateUser
		,IsDelete = 1
	WHERE 
		GeneralLedgerID = @GeneralLedgerID
