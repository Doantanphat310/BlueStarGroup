USE [BlueStarGroup]
GO
DROP TABLE IF EXISTS AccountDetail
CREATE TABLE AccountDetail(
	[CompanyID] [varchar](50) NOT NULL,
	[AccountID] [varchar](50) NOT NULL,
	[AccountDetailID] [varchar](50) NOT NULL,
	[AccountDetailName] [nvarchar](250) NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	CONSTRAINT [PK_AccountDetail] PRIMARY KEY  
	(
		[CompanyID] ASC,
		[AccountID] ASC,
		[AccountDetailID] ASC
	))

GO
INSERT INTO AccountDetail(CompanyID, AccountID, AccountDetailID, AccountDetailName, CreateDate, UpdateDate, CreateUser, UpdateUser)
SELECT 
	'CTY0000000060' CompanyID
	,LEFT(AccountID, CHARINDEX('/', AccountID) - 1) AccountID
	,SUBSTRING(AccountID, CHARINDEX('/', AccountID) + 1, LEN(AccountID) - CHARINDEX('/', AccountID)) AccountDetailID
	, AccountName
	,GETDATE()
	,GETDATE()
	,'admin'
	,'admin'
FROM Accounts
WHERE CHARINDEX('/', AccountID) > 0;

--GO
-- DELETE Accounts WHERE CHARINDEX('/', AccountID) > 0;