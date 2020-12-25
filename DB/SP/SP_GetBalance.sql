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
		,TK.AccountName
		,ISNULL(BL.CustomerID, '') CustomerID
		,ISNULL(BL.DebitAmount, 0) DebitBalance
		,ISNULL(BL.CreditAmount, 0) CreditBalance
	FROM Balance BL 
		INNER JOIN
		(
			SELECT
				TK.AccountID
				,ISNULL(TKD.AccountDetailID,'') AccountDetailID
				,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
			FROM Accounts TK
			LEFT JOIN AccountDetail TKD 
				ON TK.AccountID = TKD.AccountID
					AND TKD.CompanyID = 'CTY0000000060'
		) AS TK
			ON TK.AccountID = BL.AccountID
				AND TK.AccountDetailID = ISNULL(BL.AccountDetailID, '')
	WHERE CompanyID = 'CTY0000000060'
		AND BL.BalanceDate = (
			SELECT TOP 1 BalanceDate 
			FROM Balance 
			Where CompanyID = BL.CompanyID 
				AND BalanceDate <= '2019/01/01' 
			ORDER BY BalanceDate DESC)