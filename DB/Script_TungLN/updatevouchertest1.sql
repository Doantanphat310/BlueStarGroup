Update VouchersDetail 
SET CustomerID = CASE WHEN TRIM(CustomerID) = '' THEN NULL ELSE CustomerID END
WHERE CompanyID = 'CTY0000000060'

Update VouchersDetail 
SET AccountDetailID = CASE WHEN TRIM(AccountDetailID) = '' THEN NULL ELSE AccountDetailID END
WHERE CompanyID = 'CTY0000000060'

Update VouchersDetail SET OldCustomerID = CustomerID WHERE CompanyID = 'CTY0000000060'
Update VouchersDetail SET VouchersID = CustomerID WHERE CompanyID = 'CTY0000000060'

Update VouchersTemp SET OldCustomerID = CustomerID 

SELECT * FROM VouchersDetail  WHERE CompanyID = 'CTY0000000060';

SELECT VouchersDetail