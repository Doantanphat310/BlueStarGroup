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

alter proc SPSelectMaterialTK
as
begin
Select AccountID, AccountsName from Accounts
end

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
	if(exists(select * from GeneralLedger where AccountID = @AccountID and GeneralLedgerID = @GeneralLedgerID))
	or
	(exists(Select * from GeneralLedger where @GeneralLedgerID in ( select GeneralLedgerID from GeneralLedger where AccountID in ( select AccountID from Accounts where ParentID = @AccountID))))
	begin
		Select '1' as msgCode, 'Correct' as msgName
	end
	else
		Select '0' as msgCode, 'Incorrect' as msgName
end

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




