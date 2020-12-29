DROP PROCEDURE IF EXISTS ItemUnitDelete;
GO
CREATE PROCEDURE ItemUnitDelete (
	@ItemUnitID varchar(50)
)
AS
	DELETE ItemUnit
	WHERE 
		ItemUnitID = @ItemUnitID
