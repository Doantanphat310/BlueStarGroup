DROP PROCEDURE IF EXISTS AccountGroupUpdate;
GO
CREATE PROCEDURE AccountGroupUpdate (
	@AccountGroupID varchar(50)
	,@AccountGroupName nvarchar(250)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE AccountGroup
	SET
		AccountGroupName = @AccountGroupName
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		AccountGroupID = @AccountGroupID
