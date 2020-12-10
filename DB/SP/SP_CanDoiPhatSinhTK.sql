Create Proc SP_CanDoiPhatSinhTK
@NgayBD datetime, @NgayKT datetime
as
begin
select A.AccountID,A.AccountName,B.NDK as 'DKNo',B.CDK as 'DKCo',A.N as 'PSNo',A.C as 'PSCo',(B.NDK + A.N - A.C) as 'CKNo',(B.CDK + A.C - A.N) as 'CKCo'
 from
--Giả định lấy dữ liệu theo ngày BĐ và KT
--select phát sinh nợ có
	(Select A.AccountID,C.AccountName, ISNULL((SUM(A.DebitAmount)), CAST(0 as bigint)) as 'N', ISNULL((SUM(A.CreditAmount)), CAST(0 as bigint)) as 'C' from VouchersDetail as A
	inner join Vouchers as B
	on A.VouchersID = B.VouchersID
	inner join Accounts as C
	on A.AccountID = C.AccountID
	where B.VouchersTypeID <> 'DK' or B.VouchersTypeID <> 'CK'
	group by A.AccountID,C.AccountName) A
left join
--Select Nợ Có Dk
	(
	Select A.AccountID, ISNULL((SUM(A.DebitAmount)), CAST(0 as bigint)) as 'NDK', ISNULL((SUM(A.CreditAmount)), CAST(0 as bigint)) as 'CDK' from VouchersDetail as A
	inner join Vouchers as B
	on A.VouchersID = B.VouchersID
	where B.VouchersTypeID = 'DK' or B.VouchersTypeID = 'CK'
	group by A.AccountID) B
on A.AccountID = B.AccountID
order by A.AccountID
end