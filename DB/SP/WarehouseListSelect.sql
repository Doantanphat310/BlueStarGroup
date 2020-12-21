	create proc WarehouseListSelect
	@CompanyID varchar(50)
	as
	begin
	Select * from WarehouseList
	where CompanyID = @CompanyID
	end