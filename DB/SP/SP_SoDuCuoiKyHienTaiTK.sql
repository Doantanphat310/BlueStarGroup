

alter proc SP_SoDuCuoiKyHienTaiTK
@AccountID varchar(50),@AccountDetailID varchar(50),@CustomerID varchar(50),@CompanyID varchar(50),
@VoucherDate datetime,@VoucherDetailID varchar(50)
as 
begin
---select số dư cuối kỳ
select AccountID,AccountDetailID,CustomerID,CompanyID, sum(DebitAmount) as 'DebitAmount', sum(CreditAmount) as 'CreditAmount'
from
(
---select số dư đầu kỳ
SELECT t.AccountID,
case 
		when t.AccountDetailID is null then ''
		else t.AccountDetailID
		end 'AccountDetailID' , 
		case
		when t.CustomerID is null then ''
		else t.CustomerID
		end 'CustomerID'
,t.CompanyID,t.DebitAmount,t.CreditAmount
FROM (
		SELECT AccountID,
		case 
		when AccountDetailID is null then ''
		else AccountDetailID
		end 'AccountDetailID' , 
		case
		when CustomerID is null then ''
		else CustomerID
		end 'CustomerID'
		,CompanyID, MAX(BalanceDate) as MaxTime
		FROM Balance
		where year(BalanceDate) = year(@VoucherDate) 
		and  AccountID = @AccountID 
		and ISNULL(AccountDetailID, '') = @AccountDetailID 
		and  ISNULL(CustomerID, '') = @CustomerID
		GROUP BY AccountID,AccountDetailID,CustomerID,CompanyID
) r
INNER JOIN Balance t
ON t.AccountID = r.AccountID and ISNULL(t.AccountDetailID, '') = r.AccountDetailID and ISNULL(t.CustomerID, '')  = r.CustomerID
and t.CompanyID = r.CompanyID AND t.BalanceDate = r.MaxTime
---Select số phát sinh
UNION all
		select AccountID ,
		case 
		when AccountDetailID is null then ''
		else AccountDetailID
		end 'AccountDetailID' , 
		case
		when CustomerID is null then ''
		else CustomerID
		end 'CustomerID'
		, VouchersDetail.CompanyID , sum(DebitAmount) as 'DebitAmount', sum(CreditAmount) as 'CreditAmount' from VouchersDetail inner join Vouchers
		on VouchersDetail.VouchersID = Vouchers.VouchersID
		where AccountID = @AccountID 
		and ISNULL(AccountDetailID, '') = @AccountDetailID 
		and  ISNULL(CustomerID, '') = @CustomerID
		and VouchersDetail.CompanyID = @CompanyID 
		and year(VoucherDate) = year(@VoucherDate)
		and @VoucherDetailID <> VouchersDetailID
		group by AccountID,AccountDetailID,CustomerID,VouchersDetail.CompanyID
	) as A
	group by AccountID,AccountDetailID,CustomerID,CompanyID
end