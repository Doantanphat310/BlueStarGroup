DROP PROCEDURE IF EXISTS AccountDetailUpdate;
GO
CREATE PROCEDURE AccountDetailUpdate (
	@CompanyID varchar(50)
	,@AccountID varchar(50)
	,@AccountDetailID varchar(50)
	,@AccountDetailName nvarchar(250)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE AccountDetail
	SET
		AccountDetailName = @AccountDetailName
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		CompanyID = @CompanyID
		AND AccountID = @AccountID
		AND AccountDetailID = @AccountDetailID
