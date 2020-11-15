create PROCEDURE [dbo].[VoucherSelect]
AS
	SELECT * 
	FROM Vouchers
	WHERE 
		Isdelete IS not NULL
	ORDER BY VouchersID