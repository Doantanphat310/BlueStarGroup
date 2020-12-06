USE [BlueStarGroup]
GO
/****** Object:  StoredProcedure [dbo].[CloseGeneralLedgerUpdate]    Script Date: 05/12/2020 12:48:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[CloseGeneralLedgerDelete]
@CloseGeneralLedgerID varchar(50),@CreateUser varchar(50),@CompanyID varchar(50)
as
begin
Delete  CloseGeneralLedger
where @CloseGeneralLedgerID = @CloseGeneralLedgerID and CreateUser = @CreateUser and CompanyID = @CompanyID
end