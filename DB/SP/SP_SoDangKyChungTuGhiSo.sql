DROP PROC IF EXISTS SP_SoDangKyChungTuGhiSo
GO
CREATE PROC SP_SoDangKyChungTuGhiSo 
	@CompanyID VARCHAR(50)
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
WHERE V.CompanyID = 'CTY0000000060'
ORDER BY 
	V.VouchersTypeID,
	V.VoucherNo,
	V.VoucherDate