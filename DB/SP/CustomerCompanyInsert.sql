DROP PROCEDURE IF EXISTS CustomerCompanyInsert;
GO
CREATE PROCEDURE CustomerCompanyInsert (
	@CompanyID varchar(50)
	,@CustomerID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO CustomerCompany(
		CompanyID
		,CustomerID
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@CompanyID
		,@CustomerID
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
