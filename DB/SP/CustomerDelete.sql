CREATE PROCEDURE CustomerDelete (
	@CustomerID nvarchar(250),
	@UserId varchar(20)
)
AS
	UPDATE Customer
	SET
		UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		Status = 0
	WHERE 
		CustomerID = @CustomerID
		AND Status = 1