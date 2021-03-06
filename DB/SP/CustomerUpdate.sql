USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CustomerUpdate]    Script Date: 11/8/2020 12:08:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CustomerUpdate] (
	@CustomerID nvarchar(250),
	@CustomerName nvarchar(250),
	@CustomerSName varchar(50),
	@Address nvarchar(250),
	@Phone varchar(10),
	@UserId varchar(20)
)
AS
	UPDATE Customer
	SET
		CustomerName = @CustomerName,
		CustomerSName = @CustomerSName,
		[Address] = @Address,
		Phone = @Phone,
		UpdateDate = GETDATE(),
		UpdateUser = @UserId
	WHERE 
		CustomerID = @CustomerID
		AND IsDelete IS NULL