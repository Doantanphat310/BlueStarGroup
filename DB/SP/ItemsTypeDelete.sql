CREATE PROCEDURE ItemsTypeDelete (
	@ItemsTypeID varchar(20),
	@UserID varchar(20)
)
AS	
	DELETE ItemsType
	WHERE ItemsTypeID = @ItemsTypeID