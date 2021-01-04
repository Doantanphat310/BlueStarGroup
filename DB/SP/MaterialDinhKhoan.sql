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
	Declare @MaterialInvoiceType table (InvoiceTypeSummary varchar(1),	InvoiceTypeName Nvarchar(50))
INSERT INTO @MaterialInvoiceType (InvoiceTypeSummary,InvoiceTypeName)
Values('R', N'Ra')
INSERT INTO @MaterialInvoiceType (InvoiceTypeSummary,InvoiceTypeName)
Values('V', N'Vào')
select * from @MaterialInvoiceType
end

alter proc SPSelectMaterialWareHouseType
as
begin
	Declare  @MaterialWareHouseType TABLE (WareHouseTypeSummary varchar(1),WareHouseTypeName Nvarchar(50))
INSERT INTO @MaterialWareHouseType (WareHouseTypeSummary,WareHouseTypeName)
Values('X', N'Xuất')
INSERT INTO @MaterialWareHouseType (WareHouseTypeSummary,WareHouseTypeName)
Values('N', N'Nhập')
select * from @MaterialWareHouseType
end


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




alter proc SPSelectMaterialDoiTuong
@CompanyID varchar(50)
as
begin
Select A.CustomerID,CustomerSName,CustomerName,InvoiceFormNo,FormNo,SerialNo from Customer as A
inner join CustomerCompany as B
on A.CustomerID = B.CustomerID
where CompanyID = @CompanyID
end

select * from




SPSelectMaterialTK 'CTY0000000003'



select * from AccountDetail

alter proc SPSelectMaterialTK
@CompanyID varchar(50)
as
begin
select 
case
when  B.AccountDetailID is null then A.AccountID
else  (A.AccountID + '/' + B.AccountDetailID)
end  'AccountIDFULL',  A.AccountID,B.AccountDetailID,
case
when B.AccountDetailName is null then A.AccountName
else B.AccountDetailName
end 'Name',A.DuNo,A.DuCo,A.HachToan,A.ThongKe,A.NgoaiTe,A.TK152_156,A.VatTu,A.ThueVAT,A.HopDong,A.CongNo 
from
(select * from Accounts) as A
left join
(Select * from AccountDetail 
where CompanyID = @CompanyID) as B
on A.AccountID = B.AccountID
order by AccountID,AccountDetailID
end



Create proc SPSelectMaterialGL
@CompanyID varchar(50)
as
begin
Select AccountID, GeneralLedgerName,GeneralLedgerID from GeneralLedger
end


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

ALTER proc [dbo].[SPCheckInvoiceNo]
@InvoiceID varchar(50),@CustomerID varchar(50),@InvoiceFormNo varchar(50),@FormNo varchar(50),@SerialNo varchar(50),@InvoiceNo varchar(50)
as
begin
--kiểm tra trùng số hóa đơn
if(exists(select * from Invoice where CustomerID = @CustomerID and InvoiceFormNo = @InvoiceFormNo and FormNo = @FormNo and SerialNo =@SerialNo and InvoiceNo = @InvoiceNo))
begin
	if(exists(select * from Invoice where CustomerID = @CustomerID and InvoiceFormNo = @InvoiceFormNo and FormNo = @FormNo and SerialNo =@SerialNo and InvoiceNo = @InvoiceNo and InvoiceID = @InvoiceID))
	begin
		Select '1' as msgCode, 'Correct' as msgName
	end
	else Select '0' as msgCode, N'Số hóa đơn đã tồn tại!' as msgName
end
else Select '1' as msgCode, 'Correct' as msgName
end

Create proc SPSelectAccountAccountDetail
@CompanyID varchar(50)
as
begin
select A.AccountID,A.AccountName,B.AccountDetailID,B.AccountDetailName,A.DuNo,A.DuCo,A.HachToan,A.ThongKe,A.NgoaiTe,A.TK152_156,A.VatTu,A.ThueVAT,A.HopDong,A.CongNo from Accounts as A left join AccountDetail as B
on A.AccountID = B.AccountID
where CompanyID = @CompanyID
order by A.AccountID,B.AccountDetailID
end

SP_TonKhoItem '2021-01-04','SP000001','CTY0000003'

alter proc SP_TonKhoItem
@VoucherDate datetime, @ItemID varchar(50), @CompanyID varchar(50)
as
begin

select ItemID, Type, Sum(Quantity) as Quantity from
(
--Xuất nhập tồn của năm nhập chứng từ
select ItemID, Type, Sum(Quantity) as'Quantity' from WareHouseDetail as A 
inner join WareHouse as B
on A.WarehouseID = B.WarehouseID
inner join WarehouseList as C
on B.WarehouseListID = C.WarehouseListID
inner join Vouchers as D
on B.VouchersID = D.VouchersID
where B.CompanyID = @CompanyID and A.ItemID = @ItemID and year(D.VoucherDate) = year(@VoucherDate)
group by ItemID, Type

union all
-- Đầu kỳ của năm nhập chứng từ
select ItemID,
case
when DebitAmount > 0 then 'N'
when CreditAmount > 0 then 'X'
end 'Type', BalanceQuatity as  'Quantity'
 from Balance
where CompanyID = @CompanyID and ItemID = @ItemID and year(BalanceDate) = year(@VoucherDate) 
) as D
Group by ItemID, Type
end

SPSelectAccountAccountDetail '000'

select * from Balance


