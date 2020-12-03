
alter proc [dbo].[DepreciationDetailUpdate]
	@DepreciationDetailID varchar(50),
	@PeriodCurrent int,
	@DepreciationDate datetime,
	@QuantityPeriod int,
	@Amount money,
	@Descriptions nvarchar(max),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
Declare @Status bit
Declare @DepDate datetime
Declare @DepreciationID varchar(50)
set @DepreciationID = (select DepreciationID from DepreciationDetail where DepreciationDetailID = @DepreciationDetailID)
set @DepDate = dateadd(m, @PeriodCurrent, (select StartDate from Depreciation where DepreciationID = @DepreciationID))
Set @Status = 0
if(@DepreciationDate = @DepDate)
begin
Set @Status = 1
end

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