/****** Script for SelectTopNRows command from SSMS  ******/
DROP PROC IF EXISTS SP_GetCompany;
GO
CREATE PROC SP_GetCompany
AS
	SELECT 
		CompanyID
		,[CompanyName]
		,[CompanySName]
		,[Phone]
		,[Address]
		,[MST]
		,[Fax]
		,[Email]
		,[BankAccount]
		,[BankName]
		,[BankBranch]
	FROM Company
	ORDER BY
		CompanyName