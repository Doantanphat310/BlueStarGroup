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
			,TK.AccountName
			,ISNULL(CustomerID, '') CustomerID
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
					,'CTY0000000060' CompanyID
					,ISNULL(TKD.AccountDetailID,'') AccountDetailID
					,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
				FROM Accounts TK
				LEFT JOIN AccountDetail TKD 
					ON TK.AccountID = TKD.AccountID
						AND TKD.CompanyID = 'CTY0000000060'
			) AS TK
				ON TK.AccountID = D.AccountID
				AND TK.AccountDetailID = ISNULL(D.AccountDetailID, '')	
				AND TK.CompanyID = D.CompanyID
		WHERE 
			L.CompanyID = 'CTY0000000060'
			--L.CompanyID = @CompanyID
			AND L.VoucherDate >= @FromDate
			AND L.VoucherDate <= @ToDate
		) PS
	GROUP BY 
		AccountID,
		AccountDetailID,
		CustomerID
	ORDER BY 
		AccountID,
		AccountDetailID,
		CustomerID