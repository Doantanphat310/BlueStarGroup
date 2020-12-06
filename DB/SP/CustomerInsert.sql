DROP PROCEDURE IF EXISTS CustomerInsert;
GO
CREATE PROCEDURE CustomerInsert (
	@CustomerID varchar(20)
	,@CustomerName nvarchar(250)
	,@CustomerSName varchar(50)
	,@Address nvarchar(250)
	,@Phone varchar(10)
	,@ParentID varchar(20)
	,@InvoiceFormNo varchar(20)
	,@FormNo varchar(20)
	,@SerialNo varchar(20)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO Customer(
		CustomerID
		,CustomerName
		,CustomerSName
		,Address
		,Phone
		,ParentID
		,InvoiceFormNo
		,FormNo
		,SerialNo
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@CustomerID
		,@CustomerName
		,@CustomerSName
		,@Address
		,@Phone
		,@ParentID
		,@InvoiceFormNo
		,@FormNo
		,@SerialNo
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
