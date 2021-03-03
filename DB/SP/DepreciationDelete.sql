
alter proc [dbo].[DepreciationDelete]
	@DepreciationID varchar(50),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
delete DepreciationDetail
where DepreciationID = @DepreciationID and CreateUser = @CreateUser and CompanyID =@CompanyID

delete Depreciation
where DepreciationID=@DepreciationID and CreateUser = @CreateUser and CompanyID =@CompanyID

end