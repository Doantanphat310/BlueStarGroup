CREATE PROCEDURE [dbo].[ItemTypeDelete] (
	@ItemTypeID varchar(20),
	@UserID varchar(20)
)
AS	
	DELETE ItemType
	WHERE ItemTypeID = @ItemTypeID