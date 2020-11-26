CREATE PROCEDURE AccountsInsert (
	@AccountID varchar(50),
	@AccountName nvarchar(250),
	@AccountGroupID varchar(50),
	@AccountLevel tinyint,
	@ParentID varchar(10),
	@UserID varchar(20)
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
		,@UserID
		,@UserID)
