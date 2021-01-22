DROP PROC IF EXISTS SP_ChungTuGhiSo
GO
CREATE PROC SP_ChungTuGhiSo 
	@CompanyID VARCHAR(50),
	@FromDate DateTime,
	@ToDate DateTime
AS
SELECT
	M.VouchersID
	,D.VouchersDetailID
	,M.VouchersTypeID
	,T.VouchersTypeName
	,M.VoucherNo
	,M.VoucherDate
	,M.VoucherDescription
	,D.DebitAccountID
	,D.DebitAccountDetailID
	,D.CreditAccountID
	,D.CreditAccountDetailID
	,D.DebitAmount
FROM 
	Vouchers M
		INNER JOIN
	(
		SELECT
			CTNo.CompanyID
			,CTNo.VouchersID
			,CTNo.VouchersDetailID
			,CTNo.AccountID DebitAccountID
			,CTNo.AccountDetailID DebitAccountDetailID
			,CTCo.AccountID CreditAccountID
			,CTCo.AccountDetailID CreditAccountDetailID
			,CTNo.DebitAmount
		FROM
			(
				SELECT
					CompanyID
					,VouchersID
					,VouchersDetailID
					,AccountID
					,AccountDetailID
					,DebitAmount
				FROM
					VouchersDetail
				WHERE 
					CompanyID = @CompanyID
					AND DebitAmount > 0
			) CTNo
			INNER JOIN
			(
				SELECT
					CompanyID
					,VouchersID
					,VouchersDetailID
					,AccountID
					,AccountDetailID
					,CreditAmount
				FROM
					VouchersDetail
				WHERE 
					CompanyID = @CompanyID
					AND CreditAmount > 0
			) CTCo
				ON CTNo.VouchersID = CTCo.VouchersID
				AND CTNo.CompanyID = CTCo.CompanyID
	) D
	ON 
		M.VouchersID = D.VouchersID
		AND M.CompanyID = D.CompanyID
	INNER JOIN VouchersType T
		ON M.VouchersTypeID = T.VouchersTypeID
WHERE 
	M.CompanyID = @CompanyID
	AND M.VoucherDate >= @FromDate
	AND M.VoucherDate <= @ToDate 
ORDER BY
	M.VouchersTypeID
	,M.VoucherNo
