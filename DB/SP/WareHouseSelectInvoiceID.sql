USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[WareHouseSelectInvoiceID]    Script Date: 27/11/2020 5:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[WareHouseSelectInvoiceID]
@InvoiceID varchar(50), @CompanyID varchar(50), @CreateUser varchar(50)
as
begin
select * from WareHouse
where InvoiceID = @InvoiceID and CompanyID = @CompanyID and CreateUser = @CreateUser and IsDelete is NULL
end
