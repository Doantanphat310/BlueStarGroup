Create PROCEDURE CompanyInsert (
	@CompanyID nvarchar(250),
	@CompanyName nvarchar(250),
	@CompanySName varchar(50),
	@Address nvarchar(250),
	@Phone varchar(10),
	@UserId varchar(20)
)
AS	
	INSERT INTO Company(
		CompanyID,
		CompanyName,
		CompanySName,
		[Address],
		Phone,
		CreateDate,
		UpdateDate,
		CreateUser,
		UpdateUser)
	VALUES(
		@CompanyID,
		@CompanyName,
		@CompanySName,
		@Address,
		@Phone,
		GETDATE(),
		GETDATE(),
		@UserId,
		@UserId)