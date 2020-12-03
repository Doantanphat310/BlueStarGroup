ALTER PROCEDURE [dbo].[GetSEQ] 
(
	@Type varchar(3)
)
AS
	DECLARE @MAXValue bigint;
	DECLARE @VouchersID Varchar(10);
	DECLARE @InvoiceID Varchar(10);
	Declare @WareHouseID varchar(50);
	Declare @WareHouseDetailID varchar(50);
	Declare @VouchersDetailID varchar(50);
	Declare @DepreciationID varchar(50);
	Declare @DepreciationDetailID varchar(50);
	
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
IF @Type = 'WH'
		BEGIN
			SET @WareHouseID = 'WH' + FORMAT(GETDATE(), 'yyyyMMdd');
			SET @MAXValue = (
				SELECT CAST(MAX(Right(WareHouseID,6)) AS bigint) MAXValue 
				FROM WareHouse
				WHERE WareHouseID Like @WareHouseID + '%');
		END
IF @Type = 'WHD'
		BEGIN
			SET @WareHouseDetailID = 'WHD' + FORMAT(GETDATE(), 'yyyyMMdd');
			SET @MAXValue = (
				SELECT CAST(MAX(Right(WareHouseDetailID,6)) AS bigint) MAXValue 
				FROM WareHouseDetail
				WHERE WareHouseDetailID Like @WareHouseDetailID + '%');
		END

IF @Type = 'DEP'
		BEGIN
			SET @DepreciationID = 'DEP' + FORMAT(GETDATE(), 'yyyyMMdd');
			SET @MAXValue = (
				SELECT CAST(MAX(Right(DepreciationID,6)) AS bigint) MAXValue 
				FROM Depreciation
				WHERE DepreciationID Like @DepreciationID + '%');
		END
IF @Type = 'DED'
		BEGIN
			SET @DepreciationDetailID = 'DED' + FORMAT(GETDATE(), 'yyyyMMdd');
			SET @MAXValue = (
				SELECT CAST(MAX(Right(DepreciationDetailID,6)) AS bigint) MAXValue 
				FROM DepreciationDetail
				WHERE DepreciationDetailID Like @DepreciationDetailID + '%');
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
	ELSE IF @Type = 'lSP'
		SET @MAXValue = (SELECT CAST(MAX(Right(ItemTypeID, 10)) AS bigint) MAXValue FROM ItemType);

	SELECT ISNULL(@MAXValue, CAST(0 as bigint));
	
