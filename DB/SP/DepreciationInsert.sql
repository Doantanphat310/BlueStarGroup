
alter proc [dbo].[DepreciationInsert]
	@DepreciationID varchar(50),
	@WareHouseDetailID varchar(50),
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
INSERT INTO Depreciation(
	DepreciationID,
	WareHouseDetailID,
	StartDate,
	UseMonth,
	DepreciationMonth,
	CurrentMonth,
	DepreciationAmount,
	DepreciationAmountPerMonth,
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
	@DepreciationAmountPerMonth,
	@Status,
	getdate(),
	@CreateUser,
	@CompanyID)
end