DROP PROCEDURE IF EXISTS ItemsUpdate;
GO
CREATE PROCEDURE ItemsUpdate (
	@ItemID varchar(50)
	,@ItemName nvarchar(250)
	,@ItemSName varchar(20)
	,@ItemTypeID varchar(50)
	,@ItemUnit varchar(3)
	,@ItemSpecification nvarchar(250)
    ,@UserID varchar(20)
)
AS
	UPDATE Items
	SET
		ItemName = @ItemName
		,ItemSName = @ItemSName
		,ItemTypeID = @ItemTypeID
		,ItemUnit = @ItemUnit
		,ItemSpecification = @ItemSpecification
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UserId
	WHERE 
		ItemID = @ItemID
