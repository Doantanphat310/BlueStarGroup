ALTER TABLE VouchersDetail ADD AccountDetailID VARCHAR(50);

Update VouchersDetail SET AccountDetailID = NULL;

--SELECT * FROM VouchersDetail
Update VouchersDetail SET AccountDetailID = SUBSTRING(AccountID, CHARINDEX('/', AccountID) + 1, LEN(AccountID) - CHARINDEX('/', AccountID))
WHERE CHARINDEX('/', AccountID) > 0;

Update VouchersDetail SET AccountID = LEFT(AccountID, CHARINDEX('/', AccountID) - 1)
WHERE CHARINDEX('/', AccountID) > 0;