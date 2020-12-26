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
	FORMAT(ROW_NUMBER () OVER (ORDER BY CT.OldVoucherID), 'CT00000000000') VouchersID
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
	,0 VoucherAmount
FROM (
	SELECT
		VoucherType + '/' + VoucherNo AS OldVoucherID
		,VoucherType
		,VoucherNo
		,VoucherDate
		,Descriptions		
	FROM VouchersTemp
	GROUP BY VoucherDate,VoucherType,VoucherNo,Descriptions
) CT
ORDER BY 
	VoucherDate
	,VoucherType
	,CAST(VoucherNo as bigint);

GO
----------------------
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
	(SELECT VoucherID FROM Vouchers WHERE VouchersTypeID =  VT.VoucherType AND VoucherNo = VT.VoucherNo) AS VoucherID
	,VoucherType + '/' + VoucherNo AS OldVoucherID
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
FROM VouchersTemp VT


