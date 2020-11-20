
Create proc [dbo].[DepreciationDetailInsert]
	@DepreciationDetailID varchar(50),
	@DepreciationID varchar(50),
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