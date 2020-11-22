ALTER PROCEDURE [dbo].[ItemsDelete] (
	@ItemID varchar(50),
	@UserId varchar(20)
)
AS
	UPDATE Items
	SET
		UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		IsDelete = 1
	WHERE 
		ItemID = @ItemID