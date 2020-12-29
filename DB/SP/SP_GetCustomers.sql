DROP PROCEDURE IF EXISTS SP_GetCustomers;
GO
CREATE PROCEDURE SP_GetCustomers (
	@CompanyID varchar(50)
)
AS
	SELECT
		CUS.CustomerID
		,CUS.CustomerName
		,CUS.CustomerSName
		,CUS.CustomerTIN
		,CUS.CustomerAddress
		,CUS.CustomerPhone
		,CUS.ParentID
		,CUS.InvoiceFormNo
		,CUS.FormNo
		,CUS.SerialNo
        ,CUS.CreateDate
        ,CUS.UpdateDate
        ,CUS.CreateUser
        ,CUS.UpdateUser
		,COM.CompanyID
	FROM Customer CUS
		INNER JOIN CustomerCompany COM
			ON CUS.CustomerID = COM.CustomerID
	WHERE COM.CompanyID = @CompanyID
	ORDER BY CUS.CustomerName
