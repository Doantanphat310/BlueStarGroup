alter proc BalanceSelectWarehouse
			@BalanceDate datetime,
			@CompanyID varchar(50), 
			@AccountID varchar(50),
			@AccountDetailID varchar(50),
			@CustomerID varchar(50)
as
begin
Select BalanceID,BalanceDate,AccountID,AccountDetailID,CustomerID,CompanyID,DebitAmount,CreditAmount,
Balance.ItemID,BalanceQuatity, BalancePrice,Items.ItemUnitID,
case
when IsNull(DebitAmount,0) > 0 then DebitAmount
when IsNull(CreditAmount,0) > 0 then CreditAmount
end 'Amount'
 from Balance inner join Items
 on Balance.ItemID = Items.ItemID
where CompanyID = @CompanyID 
and year(BalanceDate) = YEAR (@BalanceDate)
and AccountID =@AccountID
and IsNull(AccountDetailID,'') =@AccountDetailID
and IsNull(CustomerID,'')  = @CustomerID
end