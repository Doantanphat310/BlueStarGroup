alter proc InvoiceUpdate
	@InvoiceID varchar(50),
	@CustomerID varchar(50) ,
	@Description nvarchar(max) ,
	@MaSo varchar(50) ,
	@MauSo varchar(50) ,
	@KyHieu varchar(50) ,
	@InvoiceNo varchar(50) ,
	@InvoiceType varchar(1) ,
	@InvoiceDate datetime ,
	@Amount money ,
	@VAT money ,
	@Discounts money ,
	@CreateUser varchar(50) ,
	@CompanyID varchar(50),
	@PaymentType varchar(2),
    @S35Type bit,
    @InvoiceAccountID varchar(50),
    @InvoiceAccountDetailID varchar(50),
    @InvoiceVATAccountID varchar(50),
	@MST varchar(50),
    @CustomerName varchar(250)
as
begin
	if(exists(Select * from UserRoleCompany where UserID = @CreateUser and CompanyID = @CompanyID and RoleID = 'ROLE01'))
	begin
			update Invoice
		set 
			CustomerID=@CustomerID,
			Description=@Description,
			InvoiceFormNo=@MaSo,
			FormNo=@MauSo,
			SerialNo=@KyHieu,
			InvoiceNo=@InvoiceNo,
			InvoiceType=@InvoiceType,
			InvoiceDate=@InvoiceDate,
			Amount=@Amount,
			VAT=@VAT,
			Discounts=@Discounts,
			updatedate = getdate(),
			updateuser = @CreateUser,
			PaymentType = @PaymentType,
			S35Type = @S35Type,
			InvoiceAccountID = @InvoiceAccountID,
			InvoiceAccountDetailID = @InvoiceAccountDetailID,
			InvoiceVATAccountID = @InvoiceVATAccountID,
			MST= @MST,
			CustomerName= @CustomerName
		where InvoiceID = @InvoiceID and CompanyID =@CompanyID
	end
	else
		begin
			update Invoice
			set 
				CustomerID=@CustomerID,
				Description=@Description,
				InvoiceFormNo=@MaSo,
				FormNo=@MauSo,
				SerialNo=@KyHieu,
				InvoiceNo=@InvoiceNo,
				InvoiceType=@InvoiceType,
				InvoiceDate=@InvoiceDate,
				Amount=@Amount,
				VAT=@VAT,
				Discounts=@Discounts,
				updatedate = getdate(),
				updateuser = @CreateUser,
				PaymentType = @PaymentType,
				S35Type = @S35Type,
				InvoiceAccountID = @InvoiceAccountID,
				InvoiceAccountDetailID = @InvoiceAccountDetailID,
				InvoiceVATAccountID = @InvoiceVATAccountID,
				MST= @MST,
				CustomerName= @CustomerName
			where InvoiceID = @InvoiceID and CompanyID =@CompanyID and CreateUser =@CreateUser
		end
end