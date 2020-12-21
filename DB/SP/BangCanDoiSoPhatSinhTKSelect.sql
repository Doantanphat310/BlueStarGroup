DROP PROC IF EXISTS BangCanDoiSoPhatSinhTKSelect
GO
CREATE PROC BangCanDoiSoPhatSinhTKSelect
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
			,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
			,ISNULL(CustomerID, '') CustomerID
			,ISNULL(D.DebitAmount, 0) DebitAmount
			,ISNULL(D.CreditAmount, 0) CreditAmount
		FROM 
			Vouchers L
			INNER JOIN VouchersDetail D
				ON L.OldVoucherID = D.OldVoucherID
			INNER JOIN Accounts TK
				ON D.AccountID = TK.AccountID
			LEFT JOIN AccountDetail TKD
				ON TKD.AccountID = D.AccountID 
				AND TKD.AccountDetailID = D.AccountDetailID
		WHERE 
			L.CompanyID = @CompanyID
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