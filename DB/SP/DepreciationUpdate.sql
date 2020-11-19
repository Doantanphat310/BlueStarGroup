
Create proc [dbo].[DepreciationUpdate]
	@DepreciationID varchar(50),
	@StartDate datetime,
	@UseMonth int,
	@DepreciationMonth int,
	@CurrentMonth int,
	@DepreciationAmount money,
	@DepreciationPercent float,
	@Status bit,
	@CreateDate datetime,
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
	DepreciationPercent=@DepreciationPercent,
	Status=@Status,
	updatedate = getdate(),
	updateuser=@CreateUser
where DepreciationID=@DepreciationID and CreateUser = @CreateUser and CompanyID =@CompanyID
end