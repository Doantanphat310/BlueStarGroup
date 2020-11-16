CREATE PROCEDURE [dbo].[CustomerInsert] (
	@CustomerID nvarchar(250),
	@CustomerName nvarchar(250),
	@CustomerSName varchar(50),
	@Address nvarchar(250),
	@Phone varchar(10),
	@UserId varchar(20)
)
AS	
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