DROP PROCEDURE IF EXISTS CompanyDelete;
GO
CREATE PROCEDURE CompanyDelete (
	@CompanyID varchar(20)
    ,@UserID varchar(20)
)
AS
	UPDATE Company
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UserId
		,IsDelete = 1
	WHERE 
		CompanyID = @CompanyID
