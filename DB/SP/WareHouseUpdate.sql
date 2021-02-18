alter proc WareHouseUpdate
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
	@CompanyID varchar(50)
as
begin
	if(exists(Select * from UserRoleCompany where UserID = @CreateUser and CompanyID = @CompanyID and RoleID = 'ROLE01'))
	begin
		update WareHouse
	set 
		VouchersID = @VouchersID,
		InvoiceID = @InvoiceID,
		CustomerID = @CustomerID,
		WarehouseListID = @GeneralLedgerID,
		Date = @Date,
		DebitAccountID = @DebitAccountID,
		CreditAccountID = @CreditAccountID,
		Type = @Type,
		DeliverReceiver = @DeliverReceiver,
		Description = @Description,
		Attachfile = @Attachfile,
		Discount = @Discount,
		UpdateUser= @CreateUser,
		UpdateDate= getdate(),
		CompanyID = @CompanyID
		where WarehouseID = @WarehouseID and CompanyID =@CompanyID
	end
	else
		begin
							update WareHouse
			set 
				VouchersID = @VouchersID,
				InvoiceID = @InvoiceID,
				CustomerID = @CustomerID,
				WarehouseListID = @GeneralLedgerID,
				Date = @Date,
				DebitAccountID = @DebitAccountID,
				CreditAccountID = @CreditAccountID,
				Type = @Type,
				DeliverReceiver = @DeliverReceiver,
				Description = @Description,
				Attachfile = @Attachfile,
				Discount = @Discount,
				UpdateUser= @CreateUser,
				UpdateDate= getdate(),
				CompanyID = @CompanyID
				where WarehouseID = @WarehouseID and CreateUser = @CreateUser and CompanyID =@CompanyID
		end
end
