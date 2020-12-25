DROP PROCEDURE IF EXISTS AccountDetailDelete;
GO
CREATE PROCEDURE AccountDetailDelete (
	@CompanyID varchar(50)
	,@AccountID varchar(50)
	,@AccountDetailID varchar(50)
)
AS
	DELETE AccountDetail
	WHERE 
		CompanyID = @CompanyID
		AND AccountID = @AccountID
		AND AccountDetailID = @AccountDetailID
