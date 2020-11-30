CREATE PROCEDURE GeneralLedgerDelete (
	@GeneralLedgerID varchar(30),
	@UserID varchar(20)
)
AS
	UPDATE GeneralLedger
	SET
		IsDelete = 1
		,UpdateUser = @UserId
	WHERE 
		GeneralLedgerID = @GeneralLedgerID
