alter proc VoucherDetailKetChuyenData
@StartDate datetime, @EndDate datetime, @CompanyID varchar(50)
as
begin
select AccountID, KetChuyenDebitAccountID, KetChuyenCreditAccountID, 
case
when AccountID = KetChuyenDebitAccountID then AccountDetailID
else ''
end 'KetChuyenDebitAccountDetailID',
case
when AccountID = KetChuyenCreditAccountID then AccountDetailID
else ''
end 'KetChuyenCreditAccountDetailID',
CustomerID,DebitAmount, CreditAmount, DuNo, DuCo,GroupCode,
case
when DuNo = 1 and DuCo = 0 then DebitAmount - CreditAmount
when DuCo = 1 and DuNo = 0 then CreditAmount - DebitAmount
else ABS(DebitAmount - CreditAmount)
end 'Amount'
from (
		select C.*,D.DuNo, D.DuCo from (
				Select A.AccountID,A.AccountDetailID,A.CustomerID, sum(DebitAmount) as 'DebitAmount', sum(CreditAmount) as 'CreditAmount' from VouchersDetail as A
				inner join Vouchers as B
				on A.VouchersID = B.VouchersID
				where B.VoucherDate >= @StartDate and B.VoucherDate <= @EndDate and B.CompanyID = @CompanyID and B.IsDelete is null and A.IsDelete is Null
				and A.AccountID in (select 
				case
				when KetChuyenDebitAccountID = '911' then KetChuyenCreditAccountID
				when KetChuyenCreditAccountID = '911' then KetChuyenDebitAccountID
				end 'AccountID'
				 from KichBanKetChuyentable where CompanyID = @CompanyID)
				group by A.AccountID, A.AccountDetailID, A.CustomerID
		) as C
		inner join Accounts as D
		on C.AccountID = D.AccountID
) as E
inner join KichBanKetChuyentable as F
on E.AccountID = F.KetChuyenDebitAccountID or E.AccountID = F.KetChuyenCreditAccountID
order by GroupCode
end




