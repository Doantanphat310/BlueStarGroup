
Alter proc [dbo].[WareHouseDetailUpdate]
	@WareHouseDetailID varchar(50),
	@ItemID varchar(50),
	@Quantity numeric(18, 2),
	@Price money,
	@Amount money,
	@VAT decimal,
	@VATAmount money,
	@CreateUser varchar(50),
	@CompanyID varchar(50),
	@S35Price money,
	@S35Amount money,
	@S35VATAmount decimal,
	@S35VAT decimal,
	@DonGiaBinhQuan money,
	@SoLuongTon numeric(18, 2)
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
			VAT=@VAT,
			VATAmount=@VATAmount,
			UpdateUser=@CreateUser,
			UpdateDate = getdate(),
			S35Price= @S35Price ,
			S35Amount= @S35Amount ,
			S35VATAmount= @S35VATAmount ,
			S35VAT= @S35VAT ,
			DonGiaBinhQuan= @DonGiaBinhQuan ,
			SoLuongTon= @SoLuongTon 
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
				VAT=@VAT,
				VATAmount=@VATAmount,
				UpdateUser=@CreateUser,
				UpdateDate = getdate(),
				S35Price= @S35Price ,
				S35Amount= @S35Amount ,
				S35VATAmount= @S35VATAmount ,
				S35VAT= @S35VAT ,
				DonGiaBinhQuan= @DonGiaBinhQuan ,
				SoLuongTon= @SoLuongTon 
				where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser
		end
end