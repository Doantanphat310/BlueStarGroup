USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[VouchersVouchersDetailInsert]    Script Date: 17/11/2020 2:11:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter PROCEDURE [dbo].[VouchersDetailSelectVoucherID] (
	@VouchersID varchar(50),
	@CompanyID varchar(50),
	@CreateUser varchar(20)
)
AS	
	begin
		select 
	A.VouchersDetailID, A.VouchersID, A.AccountID, A.CustomerID, A.GeneralLedgerID,A.CompanyID,A.Descriptions,
	case
	when DebitAmount is not null then 'N'
	When CreditAmount is not null then 'C'
	END AS 'NV',
	D.CustomerName,C.GeneralLedgerName
	,case
	when DebitAmount is null then CreditAmount
	When CreditAmount is null then DebitAmount
	END AS 'Amount'
from VouchersDetail as A inner join Accounts as B
on A.AccountID = B.AccountID
inner join GeneralLedger as C
on A.GeneralLedgerID = C.GeneralLedgerID
left join Customer as D
on A.CustomerID = D.CustomerID
where VouchersID = @VouchersID and A.CompanyID = @CompanyID and A.CreateUser = @CreateUser and A.IsDelete is null
	end