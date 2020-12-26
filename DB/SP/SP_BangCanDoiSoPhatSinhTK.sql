DROP PROC IF EXISTS SP_BangCanDoiSoPhatSinhTK
GO
CREATE PROC SP_BangCanDoiSoPhatSinhTK
	@CompanyID	varchar(50)
	,@FromDate	Datetime
	,@ToDate	Datetime
AS
	SELECT 
		PS.AccountID
		,ISNULL(PS.AccountDetailID, '') AccountDetailID
		--,(SELECT CustomerSName FROM Customer WHERE CustomerID = PS.CustomerID) CustomerID
		,ISNULL(PS.CustomerID, '') CustomerID
		,MAX(PS.AccountName) AccountName
		,SUM(PS.DebitAmount) PSNo
		,SUM(PS.CreditAmount) PSCo
	FROM (
		SELECT
			D.AccountID
			,D.AccountDetailID
			,TK.AccountName
			,D.CustomerID
			,ISNULL(D.DebitAmount, 0) DebitAmount
			,ISNULL(D.CreditAmount, 0) CreditAmount
		FROM 
			Vouchers L
			INNER JOIN VouchersDetail D
				ON L.OldVoucherID = D.OldVoucherID
					AND L.CompanyID = D.CompanyID
			LEFT JOIN (
				SELECT
					TK.AccountID
					,@CompanyID CompanyID
					,TKD.AccountDetailID
					,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
				FROM Accounts TK
				LEFT JOIN AccountDetail TKD 
					ON TK.AccountID = TKD.AccountID
						AND TKD.CompanyID = @CompanyID
			) AS TK
				ON TK.AccountID = D.AccountID
				AND ISNULL(TK.AccountDetailID, '') = ISNULL(D.AccountDetailID, '')	
				AND TK.CompanyID = D.CompanyID
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