USE [BlueStarGroup]
GO

create proc WarehouseListInsert
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
,@CreateDate datetime
,@CompanyID varchar(50)
as
begin
INSERT INTO [dbo].[WarehouseList]
           ([WarehouseListID]
           ,[WarehouseListName]
           ,[WarehouseListDebitAccountID]
           ,[WarehouseListDebitAccountDetailID]
           ,[WarehouseListCreditAccountID]
           ,[WarehouseListCreditAccountDetailID]
           ,[WarehouseListManageCode]
           ,[WarehouseListTitle]
           ,[WarehouseListAddress]
           ,[WarehouseListNote]
		   ,[CompanyID]
           ,[CreateUser]
           ,[CreateDate])
     VALUES
			(@WarehouseListID
			,@WarehouseListName
			,@WarehouseListDebitAccountID
			,@WarehouseListDebitAccountDetailID
			,@WarehouseListCreditAccountID
			,@WarehouseListCreditAccountDetailID
			,@WarehouseListManageCode
			,@WarehouseListTitle
			,@WarehouseListAddress
			,@WarehouseListNote
			,@CompanyID
			,@CreateUser
			,@CreateDate
			)
end


