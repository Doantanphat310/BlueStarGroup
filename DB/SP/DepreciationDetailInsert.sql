
alter proc [dbo].[DepreciationDetailInsert]
	@DepreciationDetailID varchar(50),
	@DepreciationID varchar(50),
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
set @DepDate = dateadd(m, @PeriodCurrent, (select StartDate from Depreciation where DepreciationID = @DepreciationID))
Set @Status = 0
if(@DepreciationDate = @DepDate)
begin
Set @Status = 1
end
INSERT INTO DepreciationDetail(
	DepreciationDetailID,
	DepreciationID,
	PeriodCurrent,
	DepreciationDate,
	QuantityPeriod,
	Amount,
	Descriptions,
	CreateDate,
	CreateUser,
	Status,
	CompanyID)
	VALUES(
	@DepreciationDetailID,
	@DepreciationID,
	@PeriodCurrent,
	@DepreciationDate,
	@QuantityPeriod,
	@Amount,
	@Descriptions,
	getdate(),
	@CreateUser,
	@Status,
	@CompanyID)
end


