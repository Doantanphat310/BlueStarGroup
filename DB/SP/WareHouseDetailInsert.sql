
alter proc [dbo].[WareHouseDetailInsert]
	@WareHouseDetailID varchar(50),
	@WarehouseID varchar(50),
	@ItemID varchar(50),
	@Quantity numeric(18, 2),
	@Price money,
	@Amount money,
	@VAT decimal,
	@VATAmount money,
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
INSERT INTO WareHouseDetail(
	WareHouseDetailID,
	WarehouseID,
	ItemID,
	Quantity,
	Price,
	Amount,
	VAT,
	VATAmount,
	CreateDate,
	CreateUser,
	CompanyID)
	VALUES(
	@WareHouseDetailID,
	@WarehouseID,
	@ItemID,
	@Quantity,
	@Price,
	@Amount,
	@VAT,
	@VATAmount,
	getdate(),
	@CreateUser,
	@CompanyID)
end