DROP PROCEDURE IF EXISTS CustomerInsert;
GO
CREATE PROCEDURE CustomerInsert (
	@CustomerID varchar(20)
	,@CustomerName nvarchar(250)
	,@CustomerSName varchar(50)
	,@CustomerTIN varchar(20)
	,@CustomerAddress nvarchar(250)
	,@CustomerPhone varchar(10)
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
		,CustomerTIN
		,CustomerAddress
		,CustomerPhone
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
		,@CustomerTIN
		,@CustomerAddress
		,@CustomerPhone
		,@ParentID
		,@InvoiceFormNo
		,@FormNo
		,@SerialNo
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
