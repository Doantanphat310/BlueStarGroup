
Create proc [dbo].[DepreciationDelete]
	@DepreciationID varchar(50),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
update Depreciation
set 
	IsDelete = 0
where DepreciationID=@DepreciationID and CreateUser = @CreateUser and CompanyID =@CompanyID

update DepreciationDetail
set IsDelete = 0
where DepreciationID = @DepreciationID and CreateUser = @CreateUser and CompanyID =@CompanyID
end