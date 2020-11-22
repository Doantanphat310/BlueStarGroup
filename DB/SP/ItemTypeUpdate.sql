CREATE PROCEDURE ItemTypeUpdate (
	@ItemTypeID varchar(20),
	@ItemTypeName nvarchar(250),
	@ItemTypeSName varchar(20),
	@UserID varchar(20)
)
AS	
	UPDATE ItemType
	SET ItemTypeName = @ItemTypeName
		,ItemTypeSName = @ItemTypeSName
		,UpdateDate = GETDATE()
		,UpdateUser = @UserID
	WHERE ItemTypeID = @ItemTypeID