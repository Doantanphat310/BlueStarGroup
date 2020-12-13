
create proc BalanceInsert
			@BalanceID varchar(50),
			@AccountID varchar(50),
			@AccountDetailID varchar(50),
			@CustomerID varchar(50),
			@CompanyID varchar(50),
			@BalanceDate datetime,
			@DebitAmount money,
			@CreditAmount money,
			@CreateUser varchar(50)
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
           ,CreateUser)
     VALUES
           (@BalanceID,
			@AccountID,
			@AccountDetailID,
			@CustomerID,
			@CompanyID,
			@BalanceDate,
			@DebitAmount,
			@CreditAmount,
			getdate(),
			@CreateUser)
end



