CREATE PROCEDURE ItemsTypeUpdate (
	@ItemsTypeID varchar(20),
	@ItemsTypeName nvarchar(250),
	@ItemsTypeSName varchar(20),
	@UserID varchar(20)
)
AS	
	UPDATE ItemsType
	SET ItemsTypeID = @ItemsTypeID
		,ItemsTypeName = @ItemsTypeName
		,ItemsTypeSName = @ItemsTypeSName
		,UpdateDate = GETDATE()
		,UpdateUser = @UserID
	WHERE ItemsTypeID = @ItemsTypeID