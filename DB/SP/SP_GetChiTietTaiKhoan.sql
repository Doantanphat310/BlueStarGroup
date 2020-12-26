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
	,D.AccountDetailID
	,D.CustomerID
	,L.VoucherDate
	,L.VouchersTypeID
	,L.VoucherNo
	,ISNULL(D.Descriptions, L.VoucherDescription) VoucherDescription
	,D.DebitAmount
	,D.CreditAmount
FROM 
	Vouchers L
	INNER JOIN VouchersDetail D
		ON	L.OldVoucherID = D.OldVoucherID
			AND L.CompanyID = D.CompanyID
WHERE 
	L.CompanyID = @CompanyID
	AND AccountID = @AccountID
	AND L.VoucherDate >= @FromDate
	AND L.VoucherDate <= @ToDate
	AND (ISNULL(@AccountDetailID, '') = '' OR 
		(ISNULL(@AccountDetailID, '') != '' AND @AccountDetailID = D.AccountDetailID))
	AND (ISNULL(@CustomerID, '') = '' OR 
		(ISNULL(@CustomerID, '') != '' AND @CustomerID = D.CustomerID))
ORDER BY
	VoucherDate
	,VouchersTypeID
	,VoucherNo