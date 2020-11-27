create proc DepreciationSelect
@WareHouseDetailID varchar(50), @CreateUser varchar(50), @CompanyID varchar(50)
as
begin
Select * from Depreciation
where WareHouseDetailID = @WareHouseDetailID and CreateUser = @CreateUser and CompanyID = @CompanyID
end

