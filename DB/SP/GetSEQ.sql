CREATE PROCEDURE [dbo].[GetSEQ] 
(
	@Type varchar(3)
)
AS
	IF @Type = 'VOU'
		SELECT CAST(MAX(Right(VouchersID, 3)) AS INT) MAXValue
		FROM Vouchers