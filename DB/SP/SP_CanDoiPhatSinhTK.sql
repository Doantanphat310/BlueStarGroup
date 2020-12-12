alter Proc SP_CanDoiPhatSinhTK
@NgayBD datetime, @NgayKT datetime
as
begin
select A.AccountID,A.AccountName,B.NDK as 'DKNo',B.CDK as 'DKCo',A.N as 'PSNo',A.C as 'PSCo',
case
when A.DuNo = 1 then (B.NDK + A.N - A.C)
else 0
end as 'CKNo',
case
when A.DuCo = 1 then (B.CDK + A.C - A.N)
else 0
end as 'CKCo'
 from
--Giả định lấy dữ liệu theo ngày BĐ và KT
--select phát sinh nợ có
	(Select A.AccountID,C.AccountName,C.DuNo,C.DuCo, ISNULL((SUM(A.DebitAmount)), CAST(0 as bigint)) as 'N', ISNULL((SUM(A.CreditAmount)), CAST(0 as bigint)) as 'C' from VouchersDetail as A
	inner join Vouchers as B
	on A.VouchersID = B.VouchersID
	inner join Accounts as C
	on A.AccountID = C.AccountID
	where B.VouchersTypeID <> 'DK' or B.VouchersTypeID <> 'CK'
	group by A.AccountID,C.AccountName,C.DuNo,C.DuCo) A
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



