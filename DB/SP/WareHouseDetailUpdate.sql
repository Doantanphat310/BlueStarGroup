
create proc [dbo].[WareHouseDetailUpdate]
	@WareHouseDetailID varchar(50),
	@ItemID varchar(50),
	@Quantity numeric(18, 2),
	@Price money,
	@Amount money,
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
update WareHouseDetail
set 
	ItemID=@ItemID,
	Quantity=@Quantity,
	Price=@Price,
	Amount=@Amount,
	UpdateUser=@CreateUser,
	UpdateDate = getdate()
	where WareHouseDetailID = @WareHouseDetailID
end