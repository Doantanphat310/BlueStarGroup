
alter proc [dbo].[WareHouseDetailDelete]
	@WareHouseDetailID varchar(50),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
delete DepreciationDetail
where DepreciationID in (select DepreciationID from Depreciation where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser and CompanyID =@CompanyID )
and CreateUser = @CreateUser and CompanyID =@CompanyID

delete Depreciation
where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser and CompanyID =@CompanyID

delete WareHouseDetail
	where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser and CompanyID =@CompanyID
end