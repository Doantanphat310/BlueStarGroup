
Create view View_InvoiceSameDaySamCustomer
as
SELECT a.*
FROM Invoice as a
JOIN 
(SELECT InvoiceDate, CustomerID, InvoiceType, CompanyID, COUNT(*) 'InvoiceCount'
FROM Invoice 
GROUP BY InvoiceDate, CustomerID, InvoiceType, CompanyID
HAVING COUNT(*) > 1 ) as b
ON a.InvoiceDate = b.InvoiceDate
AND a.CustomerID = b.CustomerID
and a.CompanyID = b.CompanyID
and a.InvoiceType = b.InvoiceType 