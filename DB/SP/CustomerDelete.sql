DROP PROCEDURE IF EXISTS CustomerDelete;
GO
CREATE PROCEDURE CustomerDelete (
	@CustomerID varchar(20)
    ,@UserID varchar(20)
)
AS
	UPDATE Customer
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UserId
		,IsDelete = 1
	WHERE 
		CustomerID = @CustomerID
