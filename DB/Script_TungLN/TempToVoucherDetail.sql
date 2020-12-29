USE [BlueStarGroup]
GO
DELETE Vouchers Where CompanyID = 'CTY0000000060';
GO
INSERT INTO Vouchers
           (VouchersID
		   ,OldVoucherID	
           ,VouchersTypeID
           ,VoucherNo
		   ,VoucherDate
		   ,VoucherDescription
           ,[CreateDate]
           ,[UpdateDate]
           ,[CreateUser]
           ,[UpdateUser]
		   ,CompanyID
		   ,VoucherAmount)
SELECT 
	'CT' + FORMAT(VoucherDate, 'yyyyMMdd') + FORMAT(ROW_NUMBER () OVER (PARTITION BY VoucherDate ORDER BY VoucherDate, VoucherType, CAST(VoucherNo as bigint)), '000') VouchersID
	,CT.OldVoucherID
	,CT.VoucherType
	,CT.VoucherNo
	,CT.VoucherDate
	,CT.Descriptions
	,GETDATE() CreateDate
	,GETDATE() UpdateDate
	,'admin' CreateUser
	,'admin' UpdateUser
	,'CTY0000000060' CompanyID
	,VoucherAmount
FROM (
	SELECT
		VoucherType + '/' + VoucherNo AS OldVoucherID
		,VoucherType
		,VoucherNo
		,VoucherDate
		,Descriptions
		,SUM(DebitAmount) VoucherAmount	 	
	FROM VouchersTemp
	GROUP BY VoucherDate,VoucherType,VoucherNo,Descriptions
) CT;

GO
----------------------
DELETE VouchersDetail Where CompanyID = 'CTY0000000060'
GO
INSERT INTO VouchersDetail
           (VouchersDetailID
		   ,VouchersID
		   ,OldVoucherID
           ,AccountID
           ,AccountDetailID
           ,OldCustomerID
		   ,Descriptions
           ,[DebitAmount]
           ,[CreditAmount]
           ,[CreateDate]
           ,[UpdateDate]
           ,[CreateUser]
           ,[UpdateUser]
		   ,CompanyID
		   ,CustomerID)
SELECT
	'CTD' + FORMAT(GETDATE(), 'yyyyMMdd') + FORMAT(ROW_NUMBER() OVER(PARTITION BY VoucherDate ORDER BY VoucherDate, VoucherType, VoucherNo), '0000')
	,(SELECT VouchersID FROM Vouchers WHERE CompanyID = 'CTY0000000060' AND VouchersTypeID =  VT.VoucherType AND VoucherNo = VT.VoucherNo) AS VoucherID
	,VoucherType + '/' + VoucherNo AS OldVoucherID
	,AccountID
	,CASE WHEN TRIM(AccountDetailID) = '' THEN NULL ELSE AccountDetailID END
	,OldCustomerID
	,Descriptions
	,DebitAmount
	,CreditAmount
	,GETDATE() [CreateDate]
	,GETDATE() [UpdateDate]
	,'admin' [CreateUser]
	,'admin' [UpdateUser]
	,'CTY0000000060' CompanyID
	,(SELECT CustomerID FROM Customer WHERE CustomerSName = VT.OldCustomerID) CustomerID
FROM VouchersTemp VT;


