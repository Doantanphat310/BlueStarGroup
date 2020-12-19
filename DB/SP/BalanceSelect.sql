alter proc BalanceSelect
			@BalanceDate datetime,
			@CompanyID varchar(50)
as
begin
Select BalanceID,BalanceDate,AccountID,AccountDetailID,CustomerID,CompanyID,DebitAmount,CreditAmount from Balance
where CompanyID = @CompanyID 
and year(BalanceDate) = YEAR (@BalanceDate)
and AccountID not in (select AccountID from Accounts where TK152_156 = 1)
end




