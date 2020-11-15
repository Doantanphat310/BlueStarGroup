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

SPSelectMaterialDoiTuong'test'

Create proc SPSelectMaterialDoiTuong
@CompanyID varchar(50)
as
begin
Select CustomerID,CustomerSName,CustomerName from Customer
end

Create proc SPSelectMaterialTK
as
begin
Select AccountID, TKNumber, AccountsName from Accounts
end

Create proc SPSelectMaterialGL
@CompanyID varchar(50)
as
begin
Select AccountID, GeneralLedgerName,GeneralLedgerID from GeneralLedger
end


SPCheckMaterialTK_GL '111','GL6'

alter proc SPCheckMaterialTK_GL
@AccountID varchar(50), @GeneralLedgerID varchar(50)
as
begin
	Declare @GeneralLedgerIDAccountID varchar(50)
	set @GeneralLedgerIDAccountID = (Select GeneralLedgerID from GeneralLedger where AccountID = @AccountID )
	if(exists(select * from GeneralLedger where AccountID = @AccountID and GeneralLedgerID = @GeneralLedgerID) 
	or exists(Select * from GeneralLedger where GeneralLedgerID = @GeneralLedgerID and ParentID = @GeneralLedgerIDAccountID))
	begin
		Select '1' as msgCode, 'Correct' as msgName
	end
	else
		Select '0' as msgCode, 'Incorrect' as msgName
end

SPSelectVoucherDinhKhoanWithVoucher '1'

Create proc SPSelectVoucherDinhKhoanWithVoucher
@VoucherID varchar(50)
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

SPSelectVoucherDinhKhoanWithVoucher '1'




