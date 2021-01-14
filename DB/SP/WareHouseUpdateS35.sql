Create proc WareHouseUpdateS35
@WareHouseID varchar(50), @VoucherID varchar(50),@CompanyID varchar(50), @CreateUser varchar(50)
as
begin
	update WareHouse
	set VouchersID = @VoucherID,
	UpdateUser = @CreateUser
	where WarehouseID = @WareHouseID and CompanyID = @CompanyID and CreateUser = @CreateUser
end


select * from WareHouse