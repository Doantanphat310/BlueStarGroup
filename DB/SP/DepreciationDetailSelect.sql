create proc DepreciationDetailSelect
@DepreciationID varchar(50), @CreateUser varchar(50), @CompanyID varchar(50)
as
begin
Select * from DepreciationDetail
where DepreciationID = @DepreciationID and CreateUser = @CreateUser and CompanyID = @CompanyID
end
