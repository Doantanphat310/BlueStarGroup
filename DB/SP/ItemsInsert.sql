ALTER PROCEDURE [dbo].[ItemsInsert] (
	@ItemID varchar(50),
	@ItemName nvarchar(250),
	@ItemSName varchar(20),
	@ItemTypeID varchar(50),
	@ItemUnit varchar(3),
	@UserID varchar(20)
)
AS	
	INSERT INTO Items(
	   ItemID
      ,ItemName
      ,ItemSName
      ,ItemTypeID
      ,ItemUnit
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
		,GETDATE()
		,GETDATE()
		,@UserID
		,@UserID)