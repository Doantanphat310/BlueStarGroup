DROP PROCEDURE IF EXISTS ItemTypeDelete;
GO
CREATE PROCEDURE ItemTypeDelete (
	@ItemTypeID varchar(50)
)
AS
	DELETE ItemType
	WHERE 
		ItemTypeID = @ItemTypeID
