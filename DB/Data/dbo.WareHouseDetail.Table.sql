USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[WareHouseDetail]    Script Date: 12/27/2020 11:49:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouseDetail](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[WareHouseDetailID] [varchar](50) NULL,
	[WarehouseID] [varchar](50) NULL,
	[ItemID] [varchar](50) NULL,
	[Quantity] [numeric](18, 2) NULL,
	[Price] [money] NULL,
	[Amount] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
	[Isdelete] [bit] NULL,
	[CompanyID] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'518d700f-4c5e-48a1-88b9-5629105f5f5a', N'WHD20201222000001', N'WH20201222000001', N'SP0000000097', CAST(350.00 AS Numeric(18, 2)), 13454.5514, 4709093.0000, CAST(N'2020-12-22T01:45:57.070' AS DateTime), NULL, N'admin', NULL, 0, N'CTY0000000003')
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'e01a1e36-1cc4-4c2d-a723-426a4dcb2881', N'WHD20201222000002', N'WH20201222000002', N'SP0000000097', CAST(1000.00 AS Numeric(18, 2)), 15800.0000, 15800000.0000, CAST(N'2020-12-22T01:47:47.913' AS DateTime), NULL, N'admin', NULL, 0, N'CTY0000000003')
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'18e803ef-0a7f-4c79-9894-3e4515595312', N'WHD20201225000001', N'WH20201225000001', N'SP0000000097', CAST(350.00 AS Numeric(18, 2)), 13454.5514, 4709093.0000, CAST(N'2020-12-25T09:00:57.960' AS DateTime), NULL, N'admin', NULL, NULL, N'CTY0000000003')
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'de0b073c-53af-4dfb-9a00-2044496ec96b', N'WHD20201225000002', N'WH20201225000002', N'SP0000000097', CAST(1000.00 AS Numeric(18, 2)), 15800.0000, 15800000.0000, CAST(N'2020-12-25T09:02:00.040' AS DateTime), NULL, N'admin', NULL, NULL, N'CTY0000000003')
ALTER TABLE [dbo].[WareHouseDetail] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[WareHouseDetail] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
