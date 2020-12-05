DROP PROCEDURE IF EXISTS CompanyDelete;
GO
CREATE PROCEDURE CompanyDelete (
	@CompanyID varchar(20)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE Company
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UpdateUser
		,IsDelete = 1
	WHERE 
		CompanyID = @CompanyID
