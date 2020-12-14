DROP PROC IF EXISTS BangCanDoiSoPhatSinhTKSelect
GO
CREATE PROC BangCanDoiSoPhatSinhTKSelect
	@CompanyID varchar(50)
	,@FromDate	Datetime = NULL
	,@ToDate	Datetime = NULL
AS
	SELECT 
		PS.AccountID
		,PS.AccountDetailID
		--,MAX(L.VouchersTypeID) VouchersTypeID
		--,D.AccountID
		--,D.AccountDetailID
		,MAX(PS.AccountName) AccountName
		--,MAX(ISNULL(D.Descriptions, L.Description)) Descriptions
		--,MAX(D.CustomerID) CustomerID
		,SUM(DKNo) DKNo
		,SUM(DKCo) DKCo
		,SUM(PS.PSNo) PSNo
		,SUM(PS.PSCo) PSCo
		,SUM(PS.CKNo) CKNo
		,SUM(PS.CKCo) CKCo
	FROM (
			SELECT
				D.AccountID
				,D.AccountDetailID
				,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
				,(
					SELECT DebitBalance FROM PriodBalance 
					WHERE AccountID = D.AccountID 
						AND (D.AccountDetailID IS NULL OR (D.AccountDetailID IS NOT NULL AND AccountDetailID = D.AccountDetailID))
				) AS DKNo
				,0 DKCo
				,D.DebitAmount PSNo
				,D.CreditAmount PSCo
				,CASE WHEN (0 + D.DebitAmount - 0 - D.CreditAmount) > 0 
					THEN (0 + D.DebitAmount - 0 - D.CreditAmount)
					ELSE 0
				END AS CKNo
				,CASE WHEN (0 + D.CreditAmount - 0 - D.DebitAmount) > 0 
					THEN (0 + D.CreditAmount - 0 - D.DebitAmount)
					ELSE 0
				END AS CKCo
			FROM 
				Vouchers L
				INNER JOIN VouchersDetail D
					ON L.VouchersID = D.VouchersID
				INNER JOIN Accounts TK
					ON D.AccountID = TK.AccountID
				LEFT JOIN AccountDetail TKD
					ON TKD.AccountID = D.AccountID AND TKD.AccountDetailID = D.AccountDetailID
			--WHERE 
			--	L.CompanyID = @CompanyID
			--	AND (@FromDate IS NULL
			--		OR @FromDate IS NOT NULL AND L.Date >= @FromDate)

			--	AND (@ToDate IS NULL
			--		OR @ToDate IS NOT NULL AND L.Date <= @ToDate)
	) AS PS
	GROUP BY 
		PS.AccountID,
		PS.AccountDetailID
	ORDER BY 
		PS.AccountID,
		PS.AccountDetailID