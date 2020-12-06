DROP PROCEDURE IF EXISTS AccountsInsert;
GO
CREATE PROCEDURE AccountsInsert (
	@AccountID varchar(30)
	,@AccountName nvarchar(250)
	,@AccountGroupID varchar(30)
	,@AccountLevel tinyint
	,@ParentID varchar(30)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO Accounts(
		AccountID
		,AccountName
		,AccountGroupID
		,AccountLevel
		,ParentID
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@AccountID
		,@AccountName
		,@AccountGroupID
		,@AccountLevel
		,@ParentID
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
