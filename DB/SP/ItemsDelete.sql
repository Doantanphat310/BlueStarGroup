DROP PROCEDURE IF EXISTS ItemsDelete;
GO
CREATE PROCEDURE ItemsDelete (
	@ItemID varchar(50)
    ,@UserID varchar(20)
)
AS
	UPDATE Items
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UserId
		,IsDelete = 1
	WHERE 
		ItemID = @ItemID
