DROP PROCEDURE IF EXISTS CustomerDelete;
GO
CREATE PROCEDURE CustomerDelete (
	@CustomerID varchar(20)
)
AS
	DECLARE @RecordCount int;

	SET @RecordCount = (SELECT COUNT(CustomerID) FROM CustomerCompany WHERE CustomerID = @CustomerID);
	IF @RecordCount <= 1 
		DELETE Customer
		WHERE 
			CustomerID = @CustomerID
	