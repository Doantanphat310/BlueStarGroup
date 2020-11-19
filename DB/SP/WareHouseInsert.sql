create proc WareHouseInsert
	@WarehouseID varchar(50),
	@VouchersID varchar(50),
	@InvoiceID varchar(50),
	@CustomerID varchar(50),
	@GeneralLedgerID varchar(50),
	@Date datetime,
	@DebitAccountID varchar(50),
	@CreditAccountID varchar(50),
	@Type varchar(1),
	@DeliverReceiver nvarchar(250),
	@Description nvarchar(max),
	@Attachfile nvarchar(max),
	@Discount money,
	@CreateUser varchar(50),
	@IsDelete bit,
	@CompanyID varchar(50)
as
begin
INSERT INTO WareHouse(
	WarehouseID,
	VouchersID,
	InvoiceID,
	CustomerID,
	GeneralLedgerID,
	Date,
	DebitAccountID,
	CreditAccountID,
	Type,
	DeliverReceiver,
	Description,
	Attachfile,
	Discount,
	CreateUser,
	CreateDate,
	CompanyID)
	VALUES(
	@WarehouseID,
	@VouchersID,
	@InvoiceID,
	@CustomerID,
	@GeneralLedgerID,
	@Date,
	@DebitAccountID,
	@CreditAccountID,
	@Type,
	@DeliverReceiver,
	@Description,
	@Attachfile,
	@Discount,
	@CreateUser,
	getdate(),
	@CompanyID)
end