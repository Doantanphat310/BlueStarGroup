DROP PROCEDURE IF EXISTS ItemsUpdate;
GO
CREATE PROCEDURE ItemsUpdate (
	@ItemID varchar(50)
	,@ItemName nvarchar(250)
	,@ItemSName varchar(20)
	,@ItemTypeID varchar(50)
	,@ItemUnitID varchar(20)
	,@ItemSpecification nvarchar(250)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE Items
	SET
		ItemName = @ItemName
		,ItemSName = @ItemSName
		,ItemTypeID = @ItemTypeID
		,ItemUnitID = @ItemUnitID
		,ItemSpecification = @ItemSpecification
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		ItemID = @ItemID
