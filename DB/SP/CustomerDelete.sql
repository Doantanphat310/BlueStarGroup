DROP PROCEDURE IF EXISTS CustomerDelete;
GO
CREATE PROCEDURE CustomerDelete (
	@CustomerID varchar(20)
)
AS
	DELETE Customer
	WHERE 
		CustomerID = @CustomerID
