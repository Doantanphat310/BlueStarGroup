
Create proc [dbo].[DepreciationDetailUpdate]
	@DepreciationDetailID varchar(50),
	@PeriodCurrent int,
	@DepreciationDate datetime,
	@QuantityPeriod int,
	@Amount money,
	@Descriptions nvarchar(max),
	@CreateUser varchar(50),
	@Status bit,
	@CompanyID varchar(50)
as
begin
update DepreciationDetail
set 
	PeriodCurrent =@PeriodCurrent,
	DepreciationDate =@DepreciationDate,
	QuantityPeriod =@QuantityPeriod,
	Amount =@Amount,
	Descriptions =@Descriptions,
	UpdateUser =@CreateUser,
	UpdateDate = getdate(),
	Status =@Status
where DepreciationDetailID=@DepreciationDetailID and CreateUser = @CreateUser and CompanyID =@CompanyID
end