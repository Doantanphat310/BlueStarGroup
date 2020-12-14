DROP PROCEDURE IF EXISTS AccountDetailUpdate;
GO
CREATE PROCEDURE AccountDetailUpdate (
	@AccountDetailID varchar(50)
	,@AccountDetailName nvarchar(250)
	,@AccountID varchar(50)
	,@CompanyID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE AccountDetail
	SET
		AccountDetailName = @AccountDetailName
		,AccountID = @AccountID
		,CompanyID = @CompanyID
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		AccountDetailID = @AccountDetailID
