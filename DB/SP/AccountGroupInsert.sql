DROP PROCEDURE IF EXISTS AccountGroupInsert;
GO
CREATE PROCEDURE AccountGroupInsert (
	@AccountGroupID varchar(50)
	,@AccountGroupName nvarchar(250)
    ,@UpdateUser varchar(20)
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
        ,@UpdateUser
        ,@UpdateUser)
