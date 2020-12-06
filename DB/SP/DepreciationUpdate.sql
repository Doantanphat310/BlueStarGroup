
alter proc [dbo].[DepreciationUpdate]
	@DepreciationID varchar(50),
	@StartDate datetime,
	@UseMonth int,
	@DepreciationMonth int,
	@CurrentMonth int,
	@DepreciationAmount money,
	@DepreciationAmountPerMonth money,
	@Status bit,
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
update Depreciation
set 
	StartDate=@StartDate,
	UseMonth=@UseMonth,
	DepreciationMonth=@DepreciationMonth,
	CurrentMonth=@CurrentMonth,
	DepreciationAmount=@DepreciationAmount,
	DepreciationAmountPerMonth=@DepreciationAmountPerMonth,
	Status=@Status,
	updatedate = getdate(),
	updateuser=@CreateUser
where DepreciationID=@DepreciationID and CreateUser = @CreateUser and CompanyID =@CompanyID
end