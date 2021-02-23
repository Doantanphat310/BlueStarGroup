USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[VouchersVouchersDetailInsert]    Script Date: 17/11/2020 2:11:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

VouchersDetailSelectVoucherID 'CT20210223000002','CTY0000000241','NGAN'

select * from Vouchers
where VoucherNo = 2 and year(voucherdate) = '2021'

Alter PROCEDURE [dbo].[VouchersDetailSelectVoucherID] (
	@VouchersID varchar(50),
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
	begin
		select 
	A.VouchersDetailID, A.VouchersID, A.AccountID, A.CustomerID, A.AccountDetailID,A.CompanyID,A.Descriptions,
	case
	when DebitAmount is not null and DebitAmount > 0  then 'N'
	When CreditAmount is not null and CreditAmount > 0  then 'C'
	END AS 'NV',
	D.CustomerName
	,case
	when DebitAmount is null or DebitAmount <= 0 then CreditAmount
	When CreditAmount is null  or CreditAmount <= 0 then DebitAmount
	END AS 'Amount'
from VouchersDetail as A inner join Accounts as B
on A.AccountID = B.AccountID
left join Customer as D
on A.CustomerID = D.CustomerID
where VouchersID = @VouchersID and A.CompanyID = @CompanyID  and A.IsDelete is null
order by 'NV'
	end