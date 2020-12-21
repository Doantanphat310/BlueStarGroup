
Create table WarehouseList
(
WarehouseListID varchar(50) Primary Key,
WarehouseListName nvarchar(250),
WarehouseListDebitAccountID varchar(50),
WarehouseListDebitAccountDetailID varchar(50),
WarehouseListCreditAccountID varchar(50),
WarehouseListCreditAccountDetailID varchar(50),
WarehouseListManageCode varchar(50),
WarehouseListTitle nvarchar(250),
WarehouseListAddress nvarchar(max),
WarehouseListNote nvarchar(max),
CompanyID varchar(50),
CreateUser varchar(50),
UpdateUser varchar(50),
CreateDate datetime,
UpdateDate datetime
)