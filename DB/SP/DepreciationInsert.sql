
Create proc [dbo].[DepreciationInsert]
	@DepreciationID varchar(50),
	@WareHouseDetailID varchar(50),
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
INSERT INTO Depreciation(
	DepreciationID,
	WareHouseDetailID,
	StartDate,
	UseMonth,
	DepreciationMonth,
	CurrentMonth,
	DepreciationAmount,
	DepreciationPercent,
	Status,
	CreateDate,
	CreateUser,
	CompanyID)
	VALUES(
	@DepreciationID,
	@WareHouseDetailID,
	@StartDate,
	@UseMonth,
	@DepreciationMonth,
	@CurrentMonth,
	@DepreciationAmount,
	@DepreciationPercent,
	@Status,
	getdate(),
	@CreateUser,
	@CompanyID)
end