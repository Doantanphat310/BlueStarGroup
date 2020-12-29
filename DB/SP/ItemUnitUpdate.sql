DROP PROCEDURE IF EXISTS ItemUnitUpdate;
GO
CREATE PROCEDURE ItemUnitUpdate (
	@ItemUnitID varchar(50)
	,@ItemUnitName nvarchar(250)
    ,@UpdateUser varchar(20)
)
AS
	UPDATE ItemUnit
	SET
		ItemUnitName = @ItemUnitName
        ,UpdateDate = GETDATE()
        ,UpdateUser = @UpdateUser
	WHERE 
		ItemUnitID = @ItemUnitID
