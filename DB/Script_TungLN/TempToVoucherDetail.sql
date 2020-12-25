USE [BlueStarGroup]
GO
DELETE VouchersDetail Where CompanyID = 'CTY0000000060'
GO
INSERT INTO VouchersDetail
           (OldVoucherID
           ,AccountID
           ,AccountDetailID
           ,CustomerID
		   ,Descriptions
           ,[DebitAmount]
           ,[CreditAmount]
           ,[CreateDate]
           ,[UpdateDate]
           ,[CreateUser]
           ,[UpdateUser]
		   ,CompanyID)
SELECT
	VoucherType + '/' + VoucherNo AS VoucherID
	,AccountID
	,AccountDetailID
	,CustomerID
	,Descriptions
	,DebitAmount
	,CreditAmount
	,GETDATE() [CreateDate]
	,GETDATE() [UpdateDate]
	,'admin' [CreateUser]
	,'admin' [UpdateUser]
	,'CTY0000000060' CompanyID
FROM VouchersTemp


