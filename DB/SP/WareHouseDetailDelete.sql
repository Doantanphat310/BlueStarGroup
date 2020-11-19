
create proc [dbo].[WareHouseDetailDelete]
	@WareHouseDetailID varchar(50),
	@CreateUser varchar(50),
	@CompanyID varchar(50)
as
begin
update WareHouseDetail
set 
	IsDelete = 0
	where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser and CompanyID =@CompanyID
update Depreciation
set IsDelete = 0
where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser and CompanyID =@CompanyID

update DepreciationDetail
set IsDelete = 0
where DepreciationID in (select DepreciationID from Depreciation where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser and CompanyID =@CompanyID )
and CreateUser = @CreateUser and CompanyID =@CompanyID
end