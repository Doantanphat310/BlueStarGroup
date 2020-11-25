ALTER PROCEDURE [dbo].[ItemsInsert] (
	@ItemID varchar(50),
	@ItemName nvarchar(250),
	@ItemSName varchar(20),
	@ItemTypeID varchar(50),
	@ItemUnit varchar(10),
	@ItemSpecification varchar(20),
	@UserID varchar(20)
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
		,@UserID
		,@UserID)