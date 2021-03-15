

alter proc ToKhaiSelect
@FromDate datetime, @Todate datetime, @InvoiceType varchar(1), @CompanyID varchar(50)
as
begin
if(@InvoiceType = 'A')
begin
Select A.InvoiceType, C.VouchersTypeID +'/'+ CONVERT(varchar(10),C.VoucherNo) as 'CTNo',A.InvoiceDate,A.InvoiceNo,
	A.Amount,A.VAT,A.VATAmount,A.Description,B.CustomerID,
	CASE
		WHEN A.InvoiceType = 'V' THEN B.CustomerTIN
		WHEN A.InvoiceType = 'R' THEN NULL
		ELSE NULL
	END AS CustomerTIN,
	B.CustomerName, C.VouchersID
	 from Invoice as A inner join Customer as B
	on A.CustomerID = B.CustomerID
	inner join Vouchers as C
	on A.VouchersID = C.VouchersID
	where A.InvoiceType is not null and A.CompanyID = @CompanyID 
	and InvoiceDate between @FromDate and @Todate
	order by A.InvoiceType, A.InvoiceDate
end
else
begin
Select A.InvoiceType, C.VouchersTypeID +'/'+ CONVERT(varchar(10),C.VoucherNo) as 'CTNo',A.InvoiceDate,A.InvoiceNo,
	A.Amount,A.VAT,A.VATAmount,A.Description,B.CustomerID,
	CASE
		WHEN A.InvoiceType = 'V' THEN B.CustomerTIN
		WHEN A.InvoiceType = 'R' THEN NULL
		ELSE NULL
	END AS CustomerTIN,
	B.CustomerName, C.VouchersID
	 from Invoice as A inner join Customer as B
	on A.CustomerID = B.CustomerID
	inner join Vouchers as C
	on A.VouchersID = C.VouchersID
	where A.InvoiceType is not null and A.CompanyID = @CompanyID 
	and InvoiceType = @InvoiceType
	and InvoiceDate between @FromDate and @Todate
	order by A.InvoiceType, A.InvoiceDate
end
	
end
