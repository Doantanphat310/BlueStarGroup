
Alter proc [dbo].[WareHouseDetailUpdate]
	@WareHouseDetailID varchar(50),
	@ItemID varchar(50),
	@Quantity numeric(18, 2),
	@Price money,
	@Amount money,
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
	if(exists(Select * from UserRoleCompany where UserID = @CreateUser and CompanyID = @CompanyID and RoleID = 'ROLE01'))
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
	else
		begin
			update WareHouseDetail
			set 
				ItemID=@ItemID,
				Quantity=@Quantity,
				Price=@Price,
				Amount=@Amount,
				UpdateUser=@CreateUser,
				UpdateDate = getdate()
				where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser
		end
end