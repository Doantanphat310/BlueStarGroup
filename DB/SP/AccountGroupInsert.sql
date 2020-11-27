CREATE PROCEDURE AccountGroupInsert (
	@AccountGroupID varchar(50),
	@AccountGroupName nvarchar(250),
	@UserID varchar(20)
)
AS	
	INSERT INTO AccountGroup(
		AccountGroupID
		,AccountGroupName
		,CreateDate
		,UpdateDate
		,CreateUser
		,UpdateUser)
	VALUES(
		@AccountGroupID
		,@AccountGroupName
		,GETDATE()
		,GETDATE()
		,@UserID
		,@UserID)
