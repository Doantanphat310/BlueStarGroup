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
		--,BL.AccountDetailID
		,TK.AccountName
		,ISNULL(BL.CustomerID, '') CustomerID
		--,BL.CustomerID
		,ISNULL(BL.DebitAmount, 0) DebitBalance
		,ISNULL(BL.CreditAmount, 0) CreditBalance
	FROM Balance BL 
		INNER JOIN
		(
			SELECT
				TK.AccountID
				--,ISNULL(TKD.AccountDetailID,'') AccountDetailID
				,TKD.AccountDetailID
				,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
			FROM Accounts TK
			LEFT JOIN AccountDetail TKD 
				ON TK.AccountID = TKD.AccountID
					AND TKD.CompanyID = @CompanyID
		) AS TK
			ON TK.AccountID = BL.AccountID
				AND ISNULL(TK.AccountDetailID, '') = ISNULL(BL.AccountDetailID, '')
	WHERE CompanyID = @CompanyID
		AND BL.BalanceDate = (
			SELECT TOP 1 BalanceDate 
			FROM Balance 
			Where CompanyID = BL.CompanyID 
				AND BalanceDate <= @FromDate 
			ORDER BY BalanceDate DESC)
	ORDER BY 
		BL.AccountID
		,BL.AccountDetailID
		,BL.CustomerID