CREATE PROCEDURE GeneralLedgerDetailDelete (
	@GeneralLedgerDetailID varchar(30)
)
AS
	DELETE GeneralLedgerDetail
	WHERE 
		GeneralLedgerDetailID = @GeneralLedgerDetailID
