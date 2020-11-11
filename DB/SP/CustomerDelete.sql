CREATE PROCEDURE CustomerDelete (
	@CustomerID nvarchar(250),
	@UserId varchar(20)
)
AS
	UPDATE Customer
	SET
		UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		IsDelete = 1
	WHERE 
		CustomerID = @CustomerID