CREATE PROCEDURE [dbo].[GeneralLedgerDetailInsert] (
	@GeneralLedgerDetailID varchar(30),
	@GeneralLedgerDetailName nvarchar(250),
	@GeneralLedgerID varchar(30),
	@CompanyID varchar(30),
	@UserID varchar(20)
)
AS	
	INSERT INTO GeneralLedgerDetail(
		GeneralLedgerDetailID
		,GeneralLedgerDetailName
		,GeneralLedgerID
		,CompanyID
		,CreateDate
		,UpdateDate
		,CreateUser
		,UpdateUser)
	VALUES(
		@GeneralLedgerDetailID
		,@GeneralLedgerDetailName
		,@GeneralLedgerID
		,@CompanyID
		,GETDATE()
		,GETDATE()
		,@UserID
		,@UserID)
