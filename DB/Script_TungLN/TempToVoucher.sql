USE [BlueStarGroup]
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
	,CAST(VoucherNo as bigint)