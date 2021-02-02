
alter proc LockDBCompanySelect
@StartDate Datetime, @EndDate Datetime , @CompanyID varchar(50), @UserCreate varchar(50)
as
begin
	select * from LockDBCompany
	where ClockDBDate <= @EndDate and ClockDBDate >= @StartDate and CompanyID = @CompanyID and IsDelete is null
end
