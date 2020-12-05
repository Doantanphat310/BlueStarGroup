DROP PROCEDURE IF EXISTS AccountGroupDelete;
GO
CREATE PROCEDURE AccountGroupDelete (
	@AccountGroupID varchar(50)
)
AS
	DELETE AccountGroup
	WHERE 
		AccountGroupID = @AccountGroupID
