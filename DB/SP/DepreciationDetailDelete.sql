
alter proc [dbo].[DepreciationDetailDelete]
	@DepreciationDetailID varchar(50),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
delete DepreciationDetail
where DepreciationDetailID = @DepreciationDetailID and CreateUser = @CreateUser and CompanyID =@CompanyID
end