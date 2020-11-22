CREATE PROCEDURE [dbo].[ItemTypeInsert] (
	@ItemTypeID varchar(20),
	@ItemTypeName nvarchar(250),
	@ItemTypeSName varchar(20),
	@UserID varchar(20)
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
		,@UserID
		,@UserID)