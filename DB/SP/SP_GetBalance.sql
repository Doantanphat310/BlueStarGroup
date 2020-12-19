DROP PROC IF EXISTS SP_GetBalance
GO
CREATE PROC SP_GetBalance
	@CompanyID varchar(50)
	,@FromDate	Datetime
AS
	SELECT
		BL.BalanceDate
		,BL.AccountID
		,ISNULL(BL.AccountDetailID, '') AccountDetailID
		,ISNULL(BL.CustomerID, '') CustomerID
		,ISNULL(BL.DebitAmount, 0) DebitBalance
		,ISNULL(BL.CreditAmount, 0) CreditBalance
	FROM Balance BL 
	WHERE CompanyID = @CompanyID
		AND BL.BalanceDate = (
			SELECT TOP 1 BalanceDate 
			FROM Balance 
			Where CompanyID = @CompanyID 
				AND BalanceDate <= @FromDate 
			ORDER BY BalanceDate DESC)