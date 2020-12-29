DROP PROCEDURE IF EXISTS ItemsDelete;
GO
CREATE PROCEDURE ItemsDelete (
	@ItemID varchar(50)
)
AS
	DELETE Items
	WHERE 
		ItemID = @ItemID
