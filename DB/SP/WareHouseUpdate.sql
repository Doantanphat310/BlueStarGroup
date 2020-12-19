create proc WareHouseUpdate
	@WarehouseID varchar(50),
	@DebitAccountID varchar(50),
	@CreditAccountID varchar(50),
	@Type varchar(1),
	@DeliverReceiver nvarchar(250),
	@Description nvarchar(max),
	@Attachfile nvarchar(max),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
update WareHouse
set 
	DebitAccountID=@DebitAccountID,
	CreditAccountID=@CreditAccountID,
	Type=@Type,
	DeliverReceiver=@DeliverReceiver,
	Description=@Description,
	Attachfile=@Attachfile,
	UpdateUser=@CreateUser,
	UpdateDate=getdate(),
	CompanyID = @CompanyID
	where WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID =@CompanyID
end