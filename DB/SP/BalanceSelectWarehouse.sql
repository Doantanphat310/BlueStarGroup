alter proc BalanceSelectWarehouse
			@BalanceDate datetime,
			@CompanyID varchar(50), 
			@AccountID varchar(50),
			@AccountDetailID varchar(50),
			@CustomerID varchar(50)
as
begin
Select BalanceID,BalanceDate,AccountID,AccountDetailID,CustomerID,CompanyID,DebitAmount,CreditAmount from Balance
where CompanyID = @CompanyID 
and year(BalanceDate) = YEAR (@BalanceDate)
and AccountID =@AccountID
and AccountDetailID =@AccountDetailID
and CustomerID = @CustomerID
end