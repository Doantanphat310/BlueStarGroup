DROP PROCEDURE IF EXISTS ItemTypeInsert;
GO
CREATE PROCEDURE ItemTypeInsert (
	@ItemTypeID varchar(50)
	,@ItemTypeName nvarchar(250)
	,@ItemTypeSName varchar(20)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO ItemType(
		ItemTypeID
		,ItemTypeName
		,ItemTypeSName
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@ItemTypeID
		,@ItemTypeName
		,@ItemTypeSName
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
