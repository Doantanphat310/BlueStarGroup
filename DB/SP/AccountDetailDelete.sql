DROP PROCEDURE IF EXISTS AccountDetailDelete;
GO
CREATE PROCEDURE AccountDetailDelete (
	@AccountDetailID varchar(50)
)
AS
	DELETE AccountDetail
	WHERE 
		AccountDetailID = @AccountDetailID
