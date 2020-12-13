DROP PROCEDURE IF EXISTS AccountDetailInsert;
GO
CREATE PROCEDURE AccountDetailInsert (
	@AccountDetailID varchar(50)
	,@AccountDetailName nvarchar(250)
	,@AccountID varchar(50)
	,@CompanyID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO AccountDetail(
		AccountDetailID
		,AccountDetailName
		,AccountID
		,CompanyID
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@AccountDetailID
		,@AccountDetailName
		,@AccountID
		,@CompanyID
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
