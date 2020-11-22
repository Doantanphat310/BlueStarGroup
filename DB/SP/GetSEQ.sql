CREATE PROCEDURE [dbo].[GetSEQ] 
(
	@Type varchar(3)
)
AS
	DECLARE @MAXValue bigint;
	DECLARE @VouchersID Varchar(10);
	DECLARE @InvoiceID Varchar(10);
	IF @Type = 'CT'
		BEGIN
			SET @VouchersID = 'CT' + FORMAT(GETDATE(), 'yyyyMMdd');
			SET @MAXValue = (
				SELECT CAST(MAX(Right(VouchersID, 6)) AS bigint) MAXValue 
				FROM Vouchers
				WHERE VouchersID Like @VouchersID + '%');
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
	ELSE IF @Type = 'LSP'
		SET @MAXValue = (SELECT CAST(MAX(Right(ItemTypeID, 10)) AS bigint) MAXValue FROM ItemType);

	SELECT ISNULL(@MAXValue, CAST(0 as bigint));	
