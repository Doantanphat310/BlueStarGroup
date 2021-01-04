USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 12/27/2020 11:49:02 AM ******/
DROP TABLE IF EXISTS [WareHouse]
GO
CREATE TABLE [dbo].[WareHouse](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[WarehouseID] [varchar](50) NOT NULL,
	[VouchersID] [varchar](50) NULL,
	[InvoiceID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[WarehouseListID] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[DebitAccountID] [varchar](50) NULL,
	[CreditAccountID] [varchar](50) NULL,
	[Type] [varchar](1) NULL,
	[DeliverReceiver] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Attachfile] [nvarchar](max) NULL,
	[Discount] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
	[IsDelete] [bit] NULL,
	[CompanyID] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [WarehouseListID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'480ce911-b51e-42a4-8bbe-e60e12a74af0', N'WH20201222000001', N'CT20201222000001', N'HD20201222000001', N'KH0000001830', NULL, CAST(N'2019-12-01T00:00:00.000' AS DateTime), N'158', N'1111', N'N', N'Cty TNHH MTV Xăng Dầu Bến Tre', N'Dầu Do', NULL, NULL, CAST(N'2020-12-22T01:44:28.677' AS DateTime), CAST(N'2020-12-25T08:54:11.000' AS DateTime), N'admin', N'admin', 0, N'CTY0000000003')
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [WarehouseListID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'52022bd0-51fd-488b-8548-f8554d3d3ca6', N'WH20201222000002', N'CT20201222000001', N'HD20201222000002', N'KH0000001830', NULL, CAST(N'2019-12-01T00:00:00.000' AS DateTime), N'152', N'1111', N'N', N'Cty TNHH MTV Xăng Dầu Bến Tre', N'Dầu DO', NULL, NULL, CAST(N'2020-12-22T01:47:03.087' AS DateTime), NULL, N'admin', NULL, 0, N'CTY0000000003')
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [WarehouseListID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'195d4b54-bd10-4dd4-b76c-f66d84b4e8b7', N'WH20201225000001', N'CT20201222000001', N'HD20201222000001', N'KH0000001830', N'WHL20201224000001', CAST(N'2019-12-01T00:00:00.000' AS DateTime), N'158', N'1111', N'N', N'Cty TNHH MTV Xăng Dầu Bến Tre', N'Dầu Do', NULL, NULL, CAST(N'2020-12-25T08:59:59.943' AS DateTime), NULL, N'admin', NULL, NULL, N'CTY0000000003')
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [WarehouseListID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'69542144-e18f-4a08-bf26-50102f5a10c2', N'WH20201225000002', N'CT20201222000001', N'HD20201222000002', N'KH0000001830', N'WHL20201224000001', CAST(N'2019-12-01T00:00:00.000' AS DateTime), N'152', N'1111', N'N', N'Cty TNHH MTV Xăng Dầu Bến Tre', N'Dầu DO', NULL, NULL, CAST(N'2020-12-25T09:01:36.133' AS DateTime), NULL, N'admin', NULL, NULL, N'CTY0000000003')
ALTER TABLE [dbo].[WareHouse] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[WareHouse] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
