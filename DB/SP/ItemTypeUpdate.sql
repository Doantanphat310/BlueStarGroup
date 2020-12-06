DROP PROCEDURE IF EXISTS ItemTypeUpdate;
GO
CREATE PROCEDURE ItemTypeUpdate (
	@ItemTypeID varchar(50)
	,@ItemTypeName nvarchar(250)
	,@ItemTypeSName varchar(20)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE ItemType
	SET
		ItemTypeName = @ItemTypeName
		,ItemTypeSName = @ItemTypeSName
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		ItemTypeID = @ItemTypeID
