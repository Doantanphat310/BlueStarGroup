DROP PROCEDURE IF EXISTS CustomerDelete;
GO
CREATE PROCEDURE CustomerDelete (
	@CustomerID varchar(20)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE Customer
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UpdateUser
		,IsDelete = 1
	WHERE 
		CustomerID = @CustomerID
