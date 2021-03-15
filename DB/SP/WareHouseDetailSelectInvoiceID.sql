USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[WareHouseDetailSelect]    Script Date: 27/11/2020 5:08:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter proc [dbo].[WareHouseDetailSelectInvoiceID]
@InvoiceID varchar(50), @CompanyID varchar(50), @CreateUser varchar(50)
as
begin
select A.*,B.ItemUnitID,D.VAT from WareHouseDetail as A inner join Items as B
on A.ItemID = B.ItemID
inner join WareHouse as C
on A.WarehouseID = C.WarehouseID
inner join Invoice as D
on D.InvoiceID = C.InvoiceID
where A.WarehouseID in (Select WarehouseID from WareHouse where InvoiceID = @InvoiceID) and A.CompanyID = @CompanyID 
end
