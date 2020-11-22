ALTER PROCEDURE [ItemsTypeInsert] (
	@ItemsTypeID varchar(20),
	@ItemsTypeName nvarchar(250),
	@ItemsTypeSName varchar(20),
	@UserID varchar(20)
)
AS	
	INSERT INTO ItemsType(
		ItemsTypeID
		,ItemsTypeName
		,ItemsTypeSName
		,CreateDate
		,UpdateDate
		,CreateUser
		,UpdateUser)
	VALUES(
		@ItemsTypeID
		,@ItemsTypeName
		,@ItemsTypeSName
		,GETDATE()
		,GETDATE()
		,@UserID
		,@UserID)