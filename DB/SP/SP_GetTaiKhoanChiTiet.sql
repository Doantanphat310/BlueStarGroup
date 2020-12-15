DROP PROC IF EXISTS SP_GetChiTietTaiKhoan
GO
CREATE PROC SP_GetChiTietTaiKhoan
	@CompanyID			varchar(50)
	,@AccountID			varchar(50)
	,@AccountDetailID	varchar(50)
	,@FromDate			Datetime
	,@ToDate			Datetime
AS
SELECT
	D.AccountID
	,L.VoucherDate
	,L.VouchersTypeID
	,L.VoucherNo
	,ISNULL(D.Descriptions, L.VoucherDescription) VoucherDescription
	,D.DebitAmount
	,D.CreditAmount
FROM 
	Vouchers L
	INNER JOIN VouchersDetail D
		ON L.VouchersID = D.VouchersID
WHERE 
	L.CompanyID = @CompanyID
	AND AccountID = @AccountID

	AND (@AccountDetailID IS NULL
		OR @AccountDetailID IS NOT NULL AND D.AccountDetailID >= @AccountDetailID)

	AND (@FromDate IS NULL
		OR @FromDate IS NOT NULL AND L.VoucherDate >= @FromDate)

	AND (@ToDate IS NULL
		OR @ToDate IS NOT NULL AND L.VoucherDate <= @ToDate)
ORDER BY
	VoucherDate
	,VouchersTypeID
	,VoucherNo