DROP PROCEDURE IF EXISTS ItemUnitInsert;
GO
CREATE PROCEDURE ItemUnitInsert (
	@ItemUnitID varchar(50)
	,@ItemUnitName nvarchar(250)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO ItemUnit(
		ItemUnitID
		,ItemUnitName
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@ItemUnitID
		,@ItemUnitName
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
