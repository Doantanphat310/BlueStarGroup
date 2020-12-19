USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[WareHouseDetailSelect]    Script Date: 27/11/2020 5:08:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[WareHouseDetailSelect]
@WareHouseDetailID varchar(50), @CompanyID varchar(50), @CreateUser varchar(50)
as
begin
select * from WareHouseDetail
where WarehouseDetailID = @WareHouseDetailID and CompanyID = @CompanyID and CreateUser = @CreateUser
end