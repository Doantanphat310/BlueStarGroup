DROP PROC IF EXISTS SP_GetChiTietTaiKhoan
GO
CREATE PROC SP_GetChiTietTaiKhoan
	@CompanyID			varchar(50)
	,@AccountID			varchar(50)
	,@AccountDetailID	varchar(50) = NULL
	,@CustomerID		varchar(50) = NULL
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
		ON L.OldVoucherID = D.OldVoucherID
WHERE 
	L.CompanyID = @CompanyID
	AND AccountID = @AccountID

	AND (@AccountDetailID IS NULL
		OR @AccountDetailID IS NOT NULL AND D.AccountDetailID >= @AccountDetailID)

	AND (@CustomerID IS NULL
		OR @CustomerID IS NOT NULL AND D.AccountDetailID >= @CustomerID)

	AND L.VoucherDate >= @FromDate

	AND L.VoucherDate <= @ToDate
ORDER BY
	VoucherDate
	,VouchersTypeID
	,VoucherNo