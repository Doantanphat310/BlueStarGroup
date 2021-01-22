DROP PROC IF EXISTS SP_SoQuyTienMat
GO
CREATE PROC SP_SoQuyTienMat 
	@CompanyID VARCHAR(50),
	@FromDate DateTime,
	@ToDate DateTime
AS
SELECT
	D.AccountID,
	D.AccountDetailID,
	TK.AccountName,
	V.VoucherDate,
	V.VouchersTypeID,
	V.VoucherNo,
	V.VoucherDescription,
	D.DebitAmount,
	D.CreditAmount,
	BL.DebitAmount BalanceDebitAmount,
	BL.CreditAmount BalanceCreditAmount
FROM Vouchers V
	INNER JOIN VouchersDetail D
		ON V.CompanyID = D.CompanyID
		AND V.VouchersID = D.VouchersID
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
	INNER JOIN (
		SELECT
			CompanyID,
			AccountID,
			AccountDetailID,
			SUM(DebitAmount) DebitAmount,
			SUM(CreditAmount) CreditAmount
		FROM Balance
		WHERE 
			CONVERT(date, BalanceDate) = CONVERT(date, @FromDate)
			AND CompanyID = @CompanyID
		GROUP BY
			CompanyID,
			AccountID, 
			AccountDetailID
	) BL
		ON 
			D.CompanyID = BL.CompanyID
		AND D.AccountID = BL.AccountID
		AND ISNULL(D.AccountDetailID, '') = ISNULL(BL.AccountDetailID,'')
WHERE 1 = 1
	AND V.CompanyID = @CompanyID
	AND (D.AccountID LIKE '111%' OR D.AccountID LIKE '112%')
	AND V.VoucherDate >= @FromDate
	AND V.VoucherDate <= @ToDate
ORDER BY
	D.AccountID,
	D.AccountDetailID,
	V.VoucherDate,
	VouchersTypeID DESC,
	V.VoucherNo