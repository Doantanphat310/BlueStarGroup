alter proc BalanceUpdate
			@BalanceID varchar(50),
			@AccountID varchar(50),
			@AccountDetailID varchar(50),
			@CustomerID varchar(50),
			@CompanyID varchar(50),
			@BalanceDate datetime,
			@DebitAmount money,
			@CreditAmount money,
			@CreateUser varchar(50),
			@ItemID varchar(50),
			@BalanceQuatity decimal,
			@BalancePrice money
as
begin
UPDATE [dbo].[Balance]
   SET 
      [AccountID] = @AccountID,
      [AccountDetailID] = @AccountDetailID,
      [CustomerID] = @CustomerID,
      [CompanyID] = @CompanyID,
      [BalanceDate] = @BalanceDate,
      [DebitAmount] = @DebitAmount,
      [CreditAmount] = @CreditAmount,
      [UpdateDate] = getdate(),
      [UpdateUser] = @CreateUser,
		[ItemID] = @ItemID,
		[BalanceQuatity] = @BalanceQuatity,
		[BalancePrice] = @BalancePrice
 WHERE BalanceID = @BalanceID and CompanyID = @CompanyID and CreateUser = @CreateUser
end


