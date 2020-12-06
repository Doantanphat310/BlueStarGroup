-----
--Select Nghiep VU
--Select Đối tượng
--Select TK
--Select Sổ Cái
--Select Thông tin định khoản
------------

Alter proc SPSelectMaterialNV
as
begin
	CREATE TABLE #MaterialNV
	(
	NVSummary varchar(1),
	NVName Nvarchar(50),
	)
INSERT INTO #MaterialNV (NVSummary,NVName)
Values('N', N'Nợ')
INSERT INTO #MaterialNV (NVSummary,NVName)
Values('C', N'Có')
select * from #MaterialNV
end

SPSelectMaterialInvoiceType
alter proc SPSelectMaterialInvoiceType
as
begin
	CREATE TABLE #MaterialInvoiceType
	(
	InvoiceTypeSummary varchar(1),
	InvoiceTypeName Nvarchar(50),
	)
INSERT INTO #MaterialInvoiceType (InvoiceTypeSummary,InvoiceTypeName)
Values('R', N'Ra')
INSERT INTO #MaterialInvoiceType (InvoiceTypeSummary,InvoiceTypeName)
Values('V', N'Vào')
select * from #MaterialInvoiceType
end

create proc SPSelectMaterialWareHouseType
as
begin
	CREATE TABLE #MaterialWareHouseType
	(
	WareHouseTypeSummary varchar(1),
	WareHouseTypeName Nvarchar(50),
	)
INSERT INTO #MaterialInvoiceType (WareHouseTypeSummary,WareHouseTypeName)
Values('X', N'Xuất')
INSERT INTO #MaterialInvoiceType (WareHouseTypeSummary,WareHouseTypeName)
Values('N', N'Nhập')
select * from #MaterialInvoiceType
end


        public string MaSo { get; set; }
        public string MauSo { get; set; }
        public string KyHieu { get; set; }

SPSelectMaterialDoiTuong'test'

alter table Customer
Add  KyHieu varchar(50)

select * from Customer where CustomerID = 'CUS1'

alter proc SPSelectMaterialMaSoCustomer
@CustomerID varchar(50)
as
begin
	select  distinct 
	case
	when A.InvoiceFormNo is null then B.InvoiceFormNo
	else A.InvoiceFormNo
	end as 'InvoiceFormNo',
	case
	when A.FormNo is null then B.FormNo
	else A.FormNo
	end as 'FormNo',
	case
	when A.SerialNo is null then B.SerialNo
	else A.SerialNo
	end as 'SerialNo',
	B.CustomerID,B.CustomerName,B.CustomerSName from Invoice as A  right JOIN Customer as B
	on A.CustomerID = B.CustomerID 
	order by CustomerID
end


select  distinct 
	case
	when A.InvoiceFormNo is null then B.InvoiceFormNo
	else A.InvoiceFormNo
	end as 'InvoiceFormNo',
	case
	when A.FormNo is null then B.FormNo
	else A.FormNo
	end as 'FormNo',
	case
	when A.SerialNo is null then B.SerialNo
	else A.SerialNo
	end as 'SerialNo',
	B.CustomerID,B.CustomerName,B.CustomerSName from Invoice as A  right JOIN Customer as B
	on A.CustomerID = B.CustomerID 
	order by CustomerID

KH0000000043
KH0000000043
KH0000001395
KH0000001778
KH0000001160
KH0000001160
KH0000001687

select * from Invoice as A inner join Customer as B
on A.CustomerID = B.CustomerID


	InvoiceFormNo,FormNo,SerialNo 

update Customer
set Maso = Maso + 'PT', MauSo = MauSo + 'PT',kyHieu = KyHieu + 'PT'
where CustomerID = 'CUS1'

MS1PT	MAUS1PT	KH10DOMPT


select * from Customer
where CustomerID = 'CUS1' 
SPSelectMaterialMaSoCustomer 'test'

select * from Customer

MS1	MAUS1	KH10DOM	CUS1	Vlxd 10 đởm	10DOM

alter proc SPSelectMaterialDoiTuong
@CompanyID varchar(50)
as
begin
Select CustomerID,CustomerSName,CustomerName,InvoiceFormNo,FormNo,SerialNo from Customer
end

select * from  Customer

alter proc SPSelectMaterialTK
as
begin
Select AccountID, AccountName from Accounts
end
select * from Accounts
Create proc SPSelectMaterialGL
@CompanyID varchar(50)
as
begin
Select AccountID, GeneralLedgerName,GeneralLedgerID from GeneralLedger
end

select * from Accounts
where AccountID = '1123'

SPCheckMaterialTK_GL '1113','GL2'
select AccountID from Accounts where ParentID = '111'
select * from GeneralLedger where AccountID in ( select AccountID from Accounts where ParentID = '111')
select GeneralLedgerID,GeneralLedgerName,AccountID,ParentID from GeneralLedger

alter proc SPCheckMaterialTK_GL
@AccountID varchar(50), @GeneralLedgerID varchar(50)
as
begin
Declare @AccountID_GL varchar(50)
Set @AccountID_GL = (select accountID from GeneralLedger where GeneralLedgerID = @GeneralLedgerID)
if(exists(select * from GeneralLedger where AccountID = @AccountID and GeneralLedgerID = @GeneralLedgerID))
or
(exists(select * from Accounts where ParentID = @AccountID_GL))
begin
Select '1' as msgCode, 'Correct' as msgName
end
else Select '0' as msgCode, 'Incorrect' as msgName
end

select * from GeneralLedger where AccountID in (select AccountID from Accounts where ParentID = )

SPCheckMaterialTK_GL '111','SC0000000203'

select * from GeneralLedger where GeneralLedgerID = 'SC0000000158'

Nếu accountID của sổ cái là là của sổ cái hoặc 
accountID của sổ cái là cha của tài khoản thì ok

select * from Accounts
order by AccountID

select * from GeneralLedger
order by AccountID

SPSelectVoucherDinhKhoanWithVoucher '1'

alter proc SPSelectVoucherDinhKhoanWithVoucher
@VoucherID varchar(50)
as
begin
select 
	A.VouchersDetailID,
	case
	when DebitAmount is not null then 'N'
	When CreditAmount is not null then 'C'
	END AS 'NV',
	B.TKNumber,D.CustomerName,C.GeneralLedgerName
	,case
	when DebitAmount is null then CreditAmount
	When CreditAmount is null then DebitAmount
	END AS 'Amount'
from VouchersDetail as A inner join Accounts as B
on A.AccountID = B.AccountID
inner join GeneralLedger as C
on A.GeneralLedgerID = C.GeneralLedgerID
inner join Customer as D
on A.CustomerID = D.CustomerID
where VouchersID = @VoucherID
end

SPSelectVoucherDinhKhoanWithVoucher
Create proc SPSelectVoucherDinhKhoan
as
begin
select 
	case
	when DebitAmount is not null then 'N'
	When CreditAmount is not null then 'C'
	END AS 'NV',
	B.TKNumber,D.CustomerName,C.GeneralLedgerName
	,case
	when DebitAmount is null then CreditAmount
	When CreditAmount is null then DebitAmount
	END AS 'Amount',
	E.VouchersID,E.VouchersTypeID,E.VouchersTypeSumary,E.Date,E.Description,E.CreateUser
from VouchersDetail as A inner join Accounts as B
on A.AccountID = B.AccountID
inner join GeneralLedger as C
on A.GeneralLedgerID = C.GeneralLedgerID
inner join Customer as D
on A.CustomerID = D.CustomerID
inner join Vouchers as E
on A.VouchersID = E.VouchersID
end

SPSelectVoucherDinhKhoanWithVoucher '1'




