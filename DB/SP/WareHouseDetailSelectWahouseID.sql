USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[WareHouseDetailSelect]    Script Date: 27/11/2020 5:08:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter proc [dbo].[WareHouseDetailSelectWahouseID]
@WareHouseID varchar(50), @CompanyID varchar(50), @CreateUser varchar(50)
as
begin
select A.*,B.ItemUnitID from WareHouseDetail as A inner join Items as B
on A.ItemID = B.ItemID
where A.WarehouseID = @WareHouseID and A.CompanyID = @CompanyID and A.CreateUser = @CreateUser
end