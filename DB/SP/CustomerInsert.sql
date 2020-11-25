USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerInsert]    Script Date: 11/24/2020 8:21:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CustomerInsert] (
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
	INSERT INTO Customer(
		CustomerID,
		CustomerName,
		CustomerSName,
		InvoiceFormNo,
		FormNo,
		SerialNo,
		[Address],
		Phone,
		CreateDate,
		UpdateDate,
		CreateUser,
		UpdateUser)
	VALUES(
		@CustomerID,
		@CustomerName,
		@CustomerSName,
		@InvoiceFormNo,
		@FormNo,
		@SerialNo,
		@Address,
		@Phone,
		GETDATE(),
		GETDATE(),
		@UserId,
		@UserId)