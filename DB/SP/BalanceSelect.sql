alter proc BalanceSelect
			@BalanceDate datetime,
			@CompanyID varchar(50)
as
begin
Select * from Balance
where CompanyID = @CompanyID and year(BalanceDate) = YEAR (@BalanceDate)
end


