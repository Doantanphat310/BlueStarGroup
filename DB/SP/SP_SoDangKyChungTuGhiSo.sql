DROP PROC IF EXISTS SP_SoDangKyChungTuGhiSo
GO
CREATE PROC SP_SoDangKyChungTuGhiSo 
	@CompanyID VARCHAR(50),
	@FromDate DateTime,
	@ToDate DateTime
AS
SELECT
	V.VouchersTypeID,
	T.VouchersTypeName,
	V.VoucherNo,
	V.VoucherDate,
	V.VoucherAmount,
	V.VoucherDescription
FROM Vouchers V
	INNER JOIN VouchersType T
		ON V.VouchersTypeID = T.VouchersTypeID
WHERE V.CompanyID = @CompanyID
	AND V.VoucherDate >= @FromDate
	AND V.VoucherDate <= @ToDate 
ORDER BY 
	V.VouchersTypeID,
	V.VoucherNo,
	V.VoucherDate