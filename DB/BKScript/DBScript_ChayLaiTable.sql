CREATE TABLE [WareHouse] (
  [RowID] [uniqueidentifier] default newid() ROWGUIDCOL  NOT NULL,
  [WarehouseID] varchar(50) not null,
  [VouchersID] varchar(50),
  [InvoiceID] varchar(50),
  [CustomerID] varchar(50),
  [GeneralLedgerID] varchar(50),
  [Date] datetime,
  [DebitAccountID] varchar(50),
  [CreditAccountID] varchar(50),
  [Type] varchar(1),
  [DeliverReceiver] nvarchar(250),
  [Description] nvarchar(max),
  [Attachfile] nvarchar(max),
  [Discount] money,
  [CreateDate] datetime default getdate(),
  [UpdateDate] datetime,
  [CreateUser] varchar(50),
  [UpdateUser] varchar(50),
  [IsDelete] bit,
  [CompanyID] varchar(50)
);

CREATE TABLE [WareHouseDetail] (
  [RowID] [uniqueidentifier] default newid() ROWGUIDCOL  NOT NULL,
  [WareHouseDetailID] varchar(50),
  [WarehouseID] varchar(50),
  [ItemID] varchar(50),
  [Quantity] numeric(18,2),
  [Price] money,
  [Amount] money,
  [CreateDate] datetime default getdate(),
  [UpdateDate] datetime,
  [CreateUser] varchar(50),
  [UpdateUser] varchar(50),
  Isdelete bit,
  [CompanyID] varchar(50)
);







CREATE TABLE [Invoice] (
  [RowID] [uniqueidentifier] default newid() ROWGUIDCOL  NOT NULL,
  [InvoiceID] varchar(50) not null,
  [VouchersID] varchar(50),
  [CustomerID] varchar(50),
  [Description] nvarchar(max),
  [MaSo] varchar(50),
  [MauSo] varchar(50),
  [KyHieu] varchar(50),
  [InvoiceNo] varchar(50),
  [InvoiceType] varchar(1),
  [InvoiceDate] datetime,
  [Amount] money,
  [VAT] money,
  [Discounts] money,
  [CreateDate] datetime default getdate(),
  [UpdateDate] datetime,
  [CreateUser] varchar(50),
  [UpdateUser] varchar(50),
  [IsDelete] bit,
  [CompanyID] varchar(50)
);


CREATE TABLE [Depreciation] (
[RowID] [uniqueidentifier] default newid() ROWGUIDCOL  NOT NULL,
  [DepreciationID] varchar(50),
  [WareHouseDetailID] varchar(50),
  [StartDate] datetime,
  [UseMonth] int,
  [DepreciationMonth] int,
  [CurrentMonth] int,
  [DepreciationAmount] money,
  [DepreciationPercent] float,
  [Status] bit,
  [IsDelete] bit,
  [CreateDate] datetime default getdate(),
  [UpdateDate] datetime,
  [CreateUser] varchar(50),
  [UpdateUser] varchar(50),
  [CompanyID] varchar(50)
);

CREATE TABLE [DepreciationDetail] (
  [RowID] [uniqueidentifier] default newid() ROWGUIDCOL  NOT NULL,
  [DepreciationDetailID] varchar(50),
  [DepreciationID] varchar(50),
  [PeriodCurrent] int,
  [DepreciationDate] datetime,
  [QuantityPeriod] int,
  [Amount] money,
  [Descriptions] nvarchar(max),
  [CreateDate] datetime default getdate(),
  [UpdateDate] datetime,
  [CreateUser] varchar(50),
  [UpdateUser] varchar(50),
  [Status] bit,
  [IsDelete] bit,
  [CompanyID] varchar(50)
);

