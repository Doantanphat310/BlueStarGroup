USE [BlueStarGroup]
GO

alter proc WarehouseListUpdate
@WarehouseListID varchar(50)
,@WarehouseListName nvarchar(250)
,@WarehouseListDebitAccountID varchar(50)
,@WarehouseListDebitAccountDetailID varchar(50)
,@WarehouseListCreditAccountID varchar(50)
,@WarehouseListCreditAccountDetailID varchar(50)
,@WarehouseListManageCode varchar(50)
,@WarehouseListTitle nvarchar(250)
,@WarehouseListAddress nvarchar(max)
,@WarehouseListNote nvarchar(max)
,@CreateUser varchar(50)
,@CompanyID varchar(50)
as
begin
update  WarehouseList
set 
WarehouseListID = @WarehouseListID,
WarehouseListName = @WarehouseListName,
WarehouseListDebitAccountID = @WarehouseListDebitAccountID,
WarehouseListDebitAccountDetailID = @WarehouseListDebitAccountDetailID,
WarehouseListCreditAccountID = @WarehouseListCreditAccountID,
WarehouseListCreditAccountDetailID = @WarehouseListCreditAccountDetailID,
WarehouseListManageCode = @WarehouseListManageCode,
WarehouseListTitle = @WarehouseListTitle,
WarehouseListAddress = @WarehouseListAddress,
WarehouseListNote = @WarehouseListNote,
CompanyID = @CompanyID,
UpdateUser = @CreateUser,
UpdateDate = getdate()
where  companyID = @CompanyID and CreateUser = @CreateUser and WarehouseListID = @WarehouseListID
end


