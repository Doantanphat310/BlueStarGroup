CREATE PROCEDURE [dbo].[GeneralLedgerDetailUpdate] (
	@GeneralLedgerDetailID varchar(30),
	@GeneralLedgerDetailName nvarchar(250),
	@UserID varchar(20)
)
AS
	UPDATE GeneralLedgerDetail
	SET
		GeneralLedgerDetailName = @GeneralLedgerDetailName
		,UpdateDate = GETDATE()
		,UpdateUser = @UserId
	WHERE 
		GeneralLedgerDetailID = @GeneralLedgerDetailID
