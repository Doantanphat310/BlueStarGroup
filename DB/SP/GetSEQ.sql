GetSEQ 'CT'

Alter PROCEDURE [dbo].[GetSEQ] 
(
	@Type varchar(3)
)
AS
	DECLARE @MAXValue bigint;
	DECLARE @VouchersID Varchar(10);
	DECLARE @VouchersDetailID Varchar(10);
	DECLARE @InvoiceID Varchar(10);
	IF @Type = 'CT'
		BEGIN
			SET @VouchersID = 'CT' + FORMAT(GETDATE(), 'yyyyMMdd');
			SET @MAXValue = (
				SELECT CAST(MAX(Right(VouchersID, 6)) AS bigint) MAXValue 
				FROM Vouchers
				WHERE VouchersID Like @VouchersID + '%');
		END
	IF @Type = 'CTD'
		BEGIN
			SET @VouchersDetailID = 'CTD' + FORMAT(GETDATE(), 'yyyyMMdd');
			SET @MAXValue = (
				SELECT CAST(MAX(Right(VouchersDetailID, 6)) AS bigint) MAXValue 
				FROM VouchersDetail
				WHERE VouchersDetailID Like @VouchersDetailID + '%');
		END
	IF @Type = 'HD'
		BEGIN
			SET @InvoiceID = 'HD' + FORMAT(GETDATE(), 'yyyyMMdd');
			SET @MAXValue = (
				SELECT CAST(MAX(Right(InvoiceID, 6)) AS bigint) MAXValue 
				FROM Invoice
				WHERE InvoiceID Like @InvoiceID + '%');
		END
	ELSE IF @Type = 'KH'
		SET @MAXValue = (SELECT CAST(MAX(Right(CustomerID, 10)) AS bigint) MAXValue FROM Customer);
	ELSE IF @Type = 'SP'
		SET @MAXValue = (SELECT CAST(MAX(Right(ItemID, 10)) AS bigint) MAXValue FROM Items);

		if(@MAXValue is null) SELECT CAST('0' AS bigint);
		else SELECT @MAXValue;

	