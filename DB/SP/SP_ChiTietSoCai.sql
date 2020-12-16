DROP PROC IF EXISTS SP_ChiTietSoCai
GO
CREATE PROC SP_ChiTietSoCai
	@CompanyID	VARCHAR(50),
	@FromDate	DateTime,
	@ToDate		DateTime
AS
SELECT
	FORMAT(L.VoucherDate, 'dd/MM/yyyy') VoucherDate
	,L.VouchersTypeID
	,L.VoucherNo
	,D.VouchersID
	,D.AccountID
	,D.AccountDetailID
	,D2.AccountID CorrespondingAccountID
	,D2.AccountDetailID CorrespondingAccountDetailID
	,D.DebitAmount
	,D.CreditAmount
	--,D2.DebitAmount
	--,D2.CreditAmount
FROM VouchersDetail D
	INNER JOIN VouchersDetail D2
		ON D.VouchersID = D2.VouchersID 
		AND D.AccountID != D2.AccountID 
		AND (D.DebitAmount = D2.CreditAmount AND D.CreditAmount = D2.DebitAmount)
	INNER JOIN Vouchers L
		ON L.VouchersID = D.VouchersID
WHERE 1 = 1
	AND L.CompanyID = @CompanyID
	AND L.VoucherDate >= @FromDate
	AND L.VoucherDate <= @ToDate
	--AND D.VouchersID = 'CH/48'
	--AND L.VoucherDate >= '2020-12-11' AND L.VoucherDate <= '2020-12-12'
--	L.VoucherDate >= '2020-12-11' AND L.VoucherDate <= '2020-12-12'
ORDER BY
	D.VouchersID
	,D.AccountID
	