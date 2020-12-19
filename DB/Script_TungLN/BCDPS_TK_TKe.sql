INSERT Balance(BalanceDate, CompanyID, AccountID, AccountDetailID,  DebitAmount, CreditAmount, CreateDate, CreateUser, UpdateDate, UpdateUser)

SELECT
	'2020/10/31'
	,'CTY0000000060'
	,PS.AccountID
	,PS.AccountDetailID
	,CASE WHEN (PS.PSNo > PSCo) THEN PS.PSNo - PSCo 
		WHEN (PS.PSNo = PSCo AND EXISTS (SELECT AccountID FROM Accounts WHERE AccountID = PS.AccountID AND DuNo = 1)) THEN 10000
		ELSE 0
	END DKNo
	,CASE WHEN (PS.PSCo > PSNo) THEN PS.PSCo - PSNo
		WHEN (PS.PSNo = PSCo AND EXISTS (SELECT AccountID FROM Accounts WHERE AccountID = PS.AccountID AND DuCo = 1)) THEN 15000
		ELSE 0
	END DKCo
	,GETDATE()
	,'admin'
	,GETDATE()
	,'admin'
FROM (
	SELECT 
		PS.AccountID
		,PS.AccountDetailID
		,MAX(PS.AccountName) AccountName
		--,(
		--		SELECT DebitBalance FROM PriodBalance 
		--		WHERE AccountID = PS.AccountID 
		--			AND (PS.AccountDetailID IS NULL OR (PS.AccountDetailID IS NOT NULL AND AccountDetailID = PS.AccountDetailID))
		--	) AS DKNo
		--,MAX(ISNULL(D.Descriptions, L.Description)) Descriptions
		--,MAX(D.CustomerID) CustomerID
		--,SUM(DKNo) DKNo
		--,SUM(DKCo) DKCo
		,SUM(PS.PSNo) PSNo
		,SUM(PS.PSCo) PSCo
		--,SUM(PS.CKNo) CKNo
		--,SUM(PS.CKCo) CKCo
	FROM (
		SELECT
			D.AccountID
			,ISNULL(D.AccountDetailID, '') AccountDetailID
			,ISNULL(TKD.AccountDetailName, TK.AccountName) AccountName
			--,(
			--	SELECT DebitBalance FROM PriodBalance 
			--	WHERE AccountID = D.AccountID 
			--		AND (D.AccountDetailID IS NULL OR (D.AccountDetailID IS NOT NULL AND AccountDetailID = D.AccountDetailID))
			--) AS 
			--,0 DKNo
			--,0 DKCo
			,D.DebitAmount PSNo
			,D.CreditAmount PSCo
			--,CASE WHEN (0 + D.DebitAmount - 0 - D.CreditAmount) > 0 
			--	THEN (0 + D.DebitAmount - 0 - D.CreditAmount)
			--	ELSE 0
			--END AS CKNo
			--,CASE WHEN (0 + D.CreditAmount - 0 - D.DebitAmount) > 0 
			--	THEN (0 + D.CreditAmount - 0 - D.DebitAmount)
			--	ELSE 0
			--END AS CKCo
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
	) PS
	GROUP BY 
		AccountID,
		AccountDetailID
	) PS
	--LEFT JOIN 
	--	(
	--		SELECT
	--			BL.AccountID
	--			,ISNULL(BL.AccountDetailID, '') AccountDetailID
	--			,BL.DebitBalance
	--			,BL.CreditBalance
	--		FROM PriodBalance BL 
	--		WHERE BL.PriodDate = (SELECT TOP 1 PriodDate FROM PriodBalance Where PriodDate <= '2020/11/30' ORDER BY PriodDate DESC)
	--	) BL
	--	ON BL.AccountID = PS.AccountID 
	--	AND BL.AccountDetailID = PS.AccountDetailID
ORDER BY 
		AccountID,
		AccountDetailID