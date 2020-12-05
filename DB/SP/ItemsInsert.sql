DROP PROCEDURE IF EXISTS ItemsInsert;
GO
CREATE PROCEDURE ItemsInsert (
	@ItemID varchar(50)
	,@ItemName nvarchar(250)
	,@ItemSName varchar(20)
	,@ItemTypeID varchar(50)
	,@ItemUnit varchar(3)
	,@ItemSpecification nvarchar(250)
    ,@UpdateUser varchar(20)
)
AS
	INSERT INTO Items(
		ItemID
		,ItemName
		,ItemSName
		,ItemTypeID
		,ItemUnit
		,ItemSpecification
        ,CreateDate
        ,UpdateDate
        ,CreateUser
        ,UpdateUser)
	VALUES(
		@ItemID
		,@ItemName
		,@ItemSName
		,@ItemTypeID
		,@ItemUnit
		,@ItemSpecification
        ,GETDATE()
        ,GETDATE()
        ,@UpdateUser
        ,@UpdateUser)
