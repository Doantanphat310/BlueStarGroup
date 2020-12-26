/****** Script for SelectTopNRows command from SSMS  ******/
UPDATE V
SET V.CustomerID = C.CustomerID
--SELECT V.*
  FROM VouchersTemp V
  INNER JOIN Customer C ON V.OldCustomerID = C.OldCustomerID

  UPDATE V
SET V.CustomerID = C.CustomerID
--SELECT V.*
  FROM VouchersDetail V
  INNER JOIN Customer C ON V.OldCustomerID = C.OldCustomerID

  UPDATE V
SET V.VouchersID = C.VouchersID
--SELECT V.*
  FROM VouchersDetail V
  INNER JOIN Vouchers C ON V.OldVoucherID = C.OldVoucherID