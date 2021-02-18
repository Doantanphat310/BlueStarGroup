alter proc WareHouseUpdateS35
@WareHouseID varchar(50), @VoucherID varchar(50),@Date datetime,@CompanyID varchar(50), @CreateUser varchar(50)
as
begin
	if(exists(Select * from UserRoleCompany where UserID = @CreateUser and CompanyID = @CompanyID and RoleID = 'ROLE01'))
	begin
		update WareHouse
		set VouchersID = @VoucherID,
		UpdateUser = @CreateUser,
		Date = @Date
		where WarehouseID = @WareHouseID and CompanyID = @CompanyID
	end
	else
		begin
			update WareHouse
			set VouchersID = @VoucherID,
			UpdateUser = @CreateUser,
			Date = @Date
			where WarehouseID = @WareHouseID and CompanyID = @CompanyID and CreateUser = @CreateUser
		end
end
