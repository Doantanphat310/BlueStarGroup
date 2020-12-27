DROP PROC IF EXISTS SP_ChiTietSoCai
GO
CREATE PROC SP_ChiTietSoCai2
	@CompanyID	VARCHAR(50),
	@FromDate	DateTime,
	@ToDate		DateTime
AS
SELECT
	D.AccountID
	,D.AccountDetailID
	,TK.AccountName
	,CONVERT(Date, L.VoucherDate) VoucherDate
	,D.OldVoucherID VoucherID
	,L.VouchersTypeID
	,L.VoucherNo
	,ISNULL(D.Descriptions, L.VoucherDescription) VoucherDescription
	,D2.AccountID CorrespondingAccountID
	,D2.AccountDetailID CorrespondingAccountDetailID
	,D.DebitAmount
	,D.CreditAmount
FROM VouchersDetail D
	INNER JOIN VouchersDetail D2
		ON D.OldVoucherID = D2.OldVoucherID 
		AND D.AccountID != D2.AccountID 
		AND (D.DebitAmount = D2.CreditAmount AND D.CreditAmount = D2.DebitAmount)
	INNER JOIN Vouchers L
		ON L.OldVoucherID = D.OldVoucherID
			AND l.CompanyID = D.CompanyID
	LEFT JOIN (
		SELECT
			TK.AccountID
			,@CompanyID CompanyID
			,ISNULL(TKD.AccountDetailID,'') AccountDetailID
			,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
		FROM Accounts TK
			LEFT JOIN AccountDetail TKD 
				ON TK.AccountID = TKD.AccountID
					AND TKD.CompanyID = @CompanyID
		) TK
		ON	TK.AccountID = D.AccountID
			AND TK.AccountDetailID = ISNULL(D.AccountDetailID,'')
			AND TK.CompanyID = D.CompanyID 
WHERE 1 = 1
	AND L.CompanyID = @CompanyID
	AND L.VoucherDate >= @FromDate
	AND L.VoucherDate <= @ToDate
ORDER BY
	--D.AccountID
	--,D.AccountDetailID
	--,
	L.VoucherDate
	,L.VouchersTypeID
	,L.VoucherNo	