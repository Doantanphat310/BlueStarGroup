USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerInsert]    Script Date: 11/8/2020 12:04:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CustomerInsert] (
	@CustomerName nvarchar(250),
	@CustomerSName varchar(50),
	@Address nvarchar(250),
	@Phone varchar(10),
	@UserId varchar(20)
)
AS	
	DECLARE @SEQ bigint;
	DECLARE @CustomerID varchar(20);
	SET @SEQ = (SELECT MAX(SEQ) + 1 FROM Customer);

	SET @CustomerID = 'CUS' + FORMAT(@SEQ, '0000000000');

	INSERT INTO Customer(
		CustomerID,
		CustomerName,
		CustomerSName,
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
		@Address,
		@Phone,
		GETDATE(),
		GETDATE(),
		@UserId,
		@UserId)