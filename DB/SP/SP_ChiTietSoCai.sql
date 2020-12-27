DROP PROC IF EXISTS SP_ChiTietSoCai
GO
CREATE PROC SP_ChiTietSoCai
	@CompanyID	VARCHAR(50),
	@FromDate	DateTime,
	@ToDate		DateTime
AS
SELECT
	CONVERT(Date, L.VoucherDate) VoucherDate
	,L.VouchersTypeID
	,L.VoucherNo
	,TK.AccountName
	,D.VouchersID 	
	,D.OldVoucherID	
	,ISNULL(D.Descriptions, L.VoucherDescription) VoucherDescription
	,D.AccountID
	,D.AccountDetailID
	,D2.AccountID CorrespondingAccountID
	,D2.AccountDetailID CorrespondingAccountDetailID
		
	,(CASE 
		WHEN D.CreditAmount != 0 THEN 0 
		ELSE 
			CASE WHEN D.DebitAmount < D2.CreditAmount THEN D.DebitAmount 
			ELSE D2.CreditAmount 
			END
	END) AS DebitAmount--PSNo	
	,(CASE 
		WHEN D.DebitAmount != 0 THEN 0 
		ELSE 
			CASE WHEN D.CreditAmount < D2.DebitAmount THEN D.CreditAmount 
			ELSE D2.DebitAmount 
			END
	END) AS CreditAmount--PSCo
FROM VouchersDetail D
	INNER JOIN VouchersDetail D2
		ON D.OldVoucherID = D2.OldVoucherID 
		AND D.CompanyID = D2.CompanyID
		AND ((D.DebitAmount > 0 AND  D2.CreditAmount > 0) OR (D.CreditAmount > 0 AND D2.DebitAmount > 0))
	INNER JOIN Vouchers L
		ON L.VouchersID = D.VouchersID
			AND L.CompanyID = D.CompanyID
	LEFT JOIN (
		SELECT
			TK.AccountID
			,@CompanyID CompanyID
			,TKD.AccountDetailID
			,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
		FROM Accounts TK
			LEFT JOIN AccountDetail TKD 
				ON TK.AccountID = TKD.AccountID
					AND TKD.CompanyID = @CompanyID
		) TK
		ON	TK.AccountID = D.AccountID
			AND ISNULL(TK.AccountDetailID, '') = ISNULL(D.AccountDetailID,'')
			AND TK.CompanyID = @CompanyID
WHERE 1 = 1
	AND D.CompanyID = @CompanyID
	AND L.VoucherDate >= @FromDate
	AND L.VoucherDate <= @ToDate
ORDER BY
	L.VoucherDate
	,L.VouchersTypeID
	,L.VoucherNo
	,D.AccountID
	,D2.VouchersDetailID