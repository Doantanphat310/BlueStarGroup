create view WarehouseInfo
as
Select A.WarehouseID,A.WareHouseDetailID,A.ItemID,A.Quantity,A.Price,B.Date,B.Type, A.CompanyID from WareHouseDetail as A
inner join WareHouse as B
on A.WarehouseID = B.WarehouseID
where B.Date is not null and B.VouchersID is not null