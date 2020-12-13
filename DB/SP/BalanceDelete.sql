
Create proc BalanceDelete
			@BalanceID varchar(50),
			@CompanyID varchar(50),
			@CreateUser varchar(50)
as
begin
DELETE FROM [dbo].[Balance]
      WHERE BalanceID = @BalanceID and CompanyID = @CompanyID and CreateUser = @CreateUser
end


