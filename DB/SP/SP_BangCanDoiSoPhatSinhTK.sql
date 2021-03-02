DROP PROC IF EXISTS SP_BangCanDoiSoPhatSinhTK
GO
CREATE PROC SP_BangCanDoiSoPhatSinhTK
	@CompanyID	varchar(50)
	,@FromDate	Datetime
	,@ToDate	Datetime
AS
	SELECT 
		PS.AccountID
		,PS.AccountDetailID
		,PS.CustomerID
		,MAX(PS.AccountName) AccountName
		,SUM(PS.DebitAmount) PSNo
		,SUM(PS.CreditAmount) PSCo
	FROM (
		SELECT
			D.AccountID
			,ISNULL(D.AccountDetailID, '') AccountDetailID
			,ISNULL(D.CustomerID, '') CustomerID
			,TK.AccountName
			,ISNULL(D.DebitAmount, 0) DebitAmount
			,ISNULL(D.CreditAmount, 0) CreditAmount
		FROM 
			Vouchers L
			INNER JOIN VouchersDetail D
				ON  L.VouchersID = D.VouchersID
				AND L.CompanyID = D.CompanyID
			LEFT JOIN (
				SELECT
					TK.AccountID
					,TKD.AccountDetailID
					,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
				FROM Accounts TK
				LEFT JOIN AccountDetail TKD 
					ON  TK.AccountID = TKD.AccountID
					AND TKD.CompanyID = @CompanyID
			) AS TK
				ON TK.AccountID = D.AccountID
				AND ISNULL(TK.AccountDetailID, '') = ISNULL(D.AccountDetailID, '')
		WHERE
			L.CompanyID = @CompanyID
			AND L.VoucherDate >= @FromDate
			AND L.VoucherDate <= @ToDate
		) PS
	GROUP BY 
		AccountID,
		PS.AccountDetailID,
		PS.CustomerID
	ORDER BY 
		AccountID,
		PS.AccountDetailID,
		PS.CustomerID