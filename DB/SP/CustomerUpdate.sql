USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerUpdate]    Script Date: 11/24/2020 8:24:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CustomerUpdate] (
	@CustomerID nvarchar(250),
	@CustomerName nvarchar(250),
	@CustomerSName varchar(50),
	@InvoiceFormNo varchar(20),
	@FormNo varchar(20),
	@SerialNo varchar(20),
	@Address nvarchar(250),
	@Phone varchar(10),
	@UserId varchar(20)
)
AS
	UPDATE Customer
	SET
		CustomerName = @CustomerName,
		CustomerSName = @CustomerSName,
		InvoiceFormNo = @InvoiceFormNo,
		FormNo = @FormNo,
		SerialNo = @SerialNo,
		[Address] = @Address,
		Phone = @Phone,
		UpdateDate = GETDATE(),
		UpdateUser = @UserId
	WHERE 
		CustomerID = @CustomerID
		AND IsDelete IS NULL