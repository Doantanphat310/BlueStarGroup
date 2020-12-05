DROP PROCEDURE IF EXISTS GeneralLedgerInsert;
GO
CREATE PROCEDURE GeneralLedgerInsert (
	@GeneralLedgerID varchar(50)
	,@GeneralLedgerName nvarchar(250)
	,@AccountID varchar(50)
	,@CompanyID varchar(50)
	,@ParentID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO GeneralLedger(
		GeneralLedgerID
		,GeneralLedgerName
		,AccountID
		,CompanyID
		,ParentID
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@GeneralLedgerID
		,@GeneralLedgerName
		,@AccountID
		,@CompanyID
		,@ParentID
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
