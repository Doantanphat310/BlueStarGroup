DROP PROC IF EXISTS SP_ChungTuGhiSo
GO
CREATE PROC SP_ChungTuGhiSo 
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
WHERE V.CompanyID = @CompanyID
ORDER BY 
	V.VouchersTypeID,
	V.VoucherNo,
	V.VoucherDate