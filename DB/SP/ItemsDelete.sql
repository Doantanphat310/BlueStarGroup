DROP PROCEDURE IF EXISTS ItemsDelete;
GO
CREATE PROCEDURE ItemsDelete (
	@ItemID varchar(50)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE Items
	SET
		UpdateDate = GETDATE()
		,UpdateUser = @UpdateUser
		,IsDelete = 1
	WHERE 
		ItemID = @ItemID
