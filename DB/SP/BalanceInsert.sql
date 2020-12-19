
alter proc BalanceInsert
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
INSERT INTO [dbo].[Balance]
           (BalanceID
           ,AccountID
           ,AccountDetailID
           ,CustomerID
           ,CompanyID
           ,BalanceDate
           ,DebitAmount
           ,CreditAmount
           ,CreateDate
           ,CreateUser
		   ,ItemID
		   ,BalanceQuatity
			,BalancePrice
		   )
     VALUES
           (@BalanceID,
			@AccountID,
			@AccountDetailID,
			@CustomerID,
			@CompanyID,
			DATEADD(yy, DATEDIFF(yy, 0, @BalanceDate), 0),
			@DebitAmount,
			@CreditAmount,
			getdate(),
			@CreateUser,
			@ItemID,
		    @BalanceQuatity,
			@BalancePrice
			)
end



