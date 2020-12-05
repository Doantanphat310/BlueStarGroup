DROP PROCEDURE IF EXISTS CustomerUpdate;
GO
CREATE PROCEDURE CustomerUpdate (
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
	UPDATE Customer
	SET
		CustomerName = @CustomerName
		,CustomerSName = @CustomerSName
		,Address = @Address
		,Phone = @Phone
		,ParentID = @ParentID
		,InvoiceFormNo = @InvoiceFormNo
		,FormNo = @FormNo
		,SerialNo = @SerialNo
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		CustomerID = @CustomerID
