ALTER PROCEDURE AccountGroupDelete (
	@AccountGroupID varchar(50)
)
AS
	DELETE AccountGroup
	WHERE 
		AccountGroupID = @AccountGroupID