DROP PROCEDURE IF EXISTS AccountDetailInsert;
GO
CREATE PROCEDURE AccountDetailInsert (
	@CompanyID varchar(50)
	,@AccountID varchar(50)
	,@AccountDetailID varchar(50)
	,@AccountDetailName nvarchar(250)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO AccountDetail(
		CompanyID
		,AccountID
		,AccountDetailID
		,AccountDetailName
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@CompanyID
		,@AccountID
		,@AccountDetailID
		,@AccountDetailName
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
