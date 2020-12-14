DROP TABLE IF EXISTS [Invoice]
GO
CREATE TABLE [Invoice](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[InvoiceID] [varchar](50) NOT NULL,
	[VouchersID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[InvoiceFormNo] [varchar](50) NULL,
	[FormNo] [varchar](50) NULL,
	[SerialNo] [varchar](50) NULL,
	[InvoiceNo] [varchar](50) NULL,
	[InvoiceType] [varchar](1) NULL,
	[InvoiceDate] [datetime] NULL,
	[Amount] [money] NULL,
	[VAT] [decimal](18, 0) NULL,
	[Discounts] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
	[IsDelete] [bit] NULL,
	[CompanyID] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 10/12/2020 8:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
DROP TABLE IF EXISTS [Vouchers]
GO
CREATE TABLE [dbo].[Vouchers](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[VouchersID] [varchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Amount] [money] NOT NULL,
	[Date] [datetime] NULL,
	[VouchersTypeID] [varchar](50) NULL,
	[CompanyID] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VouchersDetail]    Script Date: 10/12/2020 8:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
DROP TABLE IF EXISTS [VouchersDetail]
GO
CREATE TABLE [dbo].[VouchersDetail](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[VouchersDetailID] [varchar](50) NULL,
	[VouchersID] [varchar](50) NULL,
	[AccountID] [varchar](50) NULL,
	[CompanyID] [varchar](50) NULL,
	[GeneralLedgerID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[DebitAmount] [money] NULL,
	[CreditAmount] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
	[Descriptions] [nvarchar](max) NULL,
 CONSTRAINT [PK_VouchersDetail] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VouchersType]    Script Date: 10/12/2020 8:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
DROP TABLE IF EXISTS [VouchersType]
GO
CREATE TABLE [dbo].[VouchersType](
	[RowID] [varchar](36) NULL,
	[VouchersTypeName] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[VouchersTypeID] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 10/12/2020 8:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
DROP TABLE IF EXISTS [WareHouse]
GO
CREATE TABLE [dbo].[WareHouse](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[WarehouseID] [varchar](50) NOT NULL,
	[VouchersID] [varchar](50) NULL,
	[InvoiceID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[GeneralLedgerID] [varchar](50) NULL,
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[WareHouseDetail]    Script Date: 10/12/2020 8:33:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
DROP TABLE IF EXISTS [WareHouseDetail]
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
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'906fb714-e332-4895-a0ba-ab8c4bc752f8', N'HD20201203000001', N'CT20201201000001', N'KH0000000043', N'Dầu Do', N'01GTKT', N'01GTKT0/001', N'VP/19E', N'0082037', N'V', CAST(0x0000A9FE00000000 AS DateTime), 4709091.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(0x0000AC8600B199D3 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'556fea32-0518-4382-914e-cfad556d2755', N'HD20201203000002', N'CT20201201000001', N'KH0000000043', N'Dầu Do', N'01GTKT', N'01GTKT0/001', N'XN/18E', N'0096495', N'V', CAST(0x0000AA3400000000 AS DateTime), 15800000.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(0x0000AC8600B20A58 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'5197bb3e-e540-424e-8ddc-ffcc2f61d078', N'HD20201203000003', N'CT20201203000001', N'KH0000001395', N'Phí đăng kiểm', N'01GTKT', N'01GTKT2/003', N'AA/19P', N'0001105', N'V', CAST(0x0000AA3100000000 AS DateTime), 290909.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(0x0000AC8600D1F323 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'f4f3e85e-6d98-4da1-ae9c-961194bf36c1', N'HD20201203000004', N'CT20201203000002', N'KH0000001778', N'Tiếp khách', N'01GTKT', N'01GTKT3/003', N'BD/18P', N'0021415', N'V', CAST(0x0000AA6400000000 AS DateTime), 788182.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(0x0000AC8600EA0521 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'eeea94e7-4a5c-4d4d-9574-5059a2bbd828', N'HD20201203000005', N'CT20201203000003', N'KH0000001160', N'Nhập cát', N'01GTKT', N'01GTKT3/001', N'16AA/20F', N'0049813', N'V', CAST(0x0000AB2C00000000 AS DateTime), 13000000.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(0x0000AC8600EBA5D6 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'907d57bb-7b7b-4053-8b1c-1eb39dea94ab', N'HD20201203000006', N'CT20201203000003', N'KH0000001160', N'Nhập cát', N'01GTKT', N'01GTKT3/001', N'16AB/17F', N'0051346', N'V', CAST(0x0000AB4000000000 AS DateTime), 13000000.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(0x0000AC8600EBA5DA AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'5ce1ceb3-7077-4418-be8a-8b224b5fb91a', N'HD20201203000007', N'CT20201203000004', N'KH0000001687', N'Xe ô tô tải (Tự đổ)(Biển số: 51D - 429.43)', N'01GTKT', N'01GTKT0/001', N'MK/18E', N'0000023', N'V', CAST(0x0000AB7700000000 AS DateTime), 136363636.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(0x0000AC8600F03DDD AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'07faf6fc-7ec1-418b-a17f-0bc393ec3034', N'CT20201203000004', N'Xe ô tô tải (Tự đổ) (Biển số: 51D-429.43) đã qua sử dụng. Hiệu FORLAND; Loại: THACO FLD 345C; Số máy: 4DW83-73*B0205201*; Số khung: RNHD345DCH064493; Màu: Xanh', 150000000.0000, CAST(0x0000AB7700000000 AS DateTime), N'HT', N'COM0001', CAST(0x0000AC8600EF9469 AS DateTime), NULL, N'admin', NULL, NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'4aa2a580-e614-4e18-9b71-0e0f28cf272f', N'CT20201119000003', N'test seqid 3', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC78010D8DB5 AS DateTime), CAST(0x0000AC83000AC920 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'45a4ea13-8a20-4d14-9ae1-0e610024c3ba', N'CT20201203000001', N'Phí đăng kiểm', 370000.0000, CAST(0x0000AC8400000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC8600D1600E AS DateTime), CAST(0x0000AC8600D17E0A AS DateTime), N'admin', N'admin', NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'067c1e62-0624-41cc-8e09-1224ca944a28', N'CT20201205000001', N'Phát nhập đầu kỳ', 100000000000.0000, CAST(0x0000AB3500000000 AS DateTime), N'DK', N'COM0001', CAST(0x0000AC88000A17B6 AS DateTime), NULL, N'admin', NULL, NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'36c4432a-5540-42a4-b3db-15bd76f9bb7e', N'CT20201118100209451', N'Chi mua hàng hóa 2', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC77016B2442 AS DateTime), CAST(0x0000AC8300086507 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'd4f404b4-711d-4937-8384-1d1d69eb6e2f', N'CT20201130000011', N'test seqid 2', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC83001A465B AS DateTime), CAST(0x0000AC840177FB07 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'596096c7-0b58-4e52-bd23-27627d97a038', N'CTD20201130000001', N'Test 30 lần 2 thêm mới', 0.0000, CAST(0x0000AC8300000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC8300010282 AS DateTime), CAST(0x0000AC8300082B49 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'7f94e0cb-2e22-475f-9af8-2da84290b8ef', N'CT20201130000010', N'test seqid 1', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC83001A3F88 AS DateTime), CAST(0x0000AC83001A728F AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'fdd2727c-5cc8-41fd-82dd-358e1afd08d6', N'CT20201130000008', N'test seqid 3', 12000.0000, CAST(0x0000AC7700000000 AS DateTime), N'KC', N'COM0001', CAST(0x0000AC830013380A AS DateTime), NULL, N'admin', NULL, 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'dc421fc4-6ae8-4ede-8c63-35d2aae0e4f9', N'CT20201118100313372', N'Chi mua vật liệu 3', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC77016B6F21 AS DateTime), CAST(0x0000AC83000A22D5 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'd4c75cdc-76fc-486c-9dad-3930b3e99e70', N'CT20201203000003', N'Nhập cát', 28600000.0000, CAST(0x0000AC8400000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC8600EAF043 AS DateTime), CAST(0x0000AC86017D4729 AS DateTime), N'admin', N'admin', NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'b4c24ec2-3a48-4a8e-9d1f-43d4b53e7966', N'CT20201130000002', N'Thu mua vật liệu xậy dựng', 1100000000.0000, CAST(0x0000AC7600000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC8300103986 AS DateTime), CAST(0x0000AC8300105292 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'44d0a75b-d601-416e-a9f2-5612cea97355', N'CT20201203000002', N'Tiếp khách', 867000.0000, CAST(0x0000AC8400000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC8600E98584 AS DateTime), NULL, N'admin', NULL, NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'ba43089a-111c-46e4-8216-6b60cd8e1461', N'CT20201130000007', N'test seqid 2', 12000.0000, CAST(0x0000AC7700000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC8300132B38 AS DateTime), NULL, N'admin', NULL, 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'87073bc5-6f74-431c-b3c9-6c63b9a98246', N'CT20201130000009', N'test seqid', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC83001A3959 AS DateTime), CAST(0x0000AC8401781573 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'b6fdbdf3-bd91-4660-9d0f-6d51c8ad49e9', N'CT20201201000001', N'Dầu DO', 22560000.0000, CAST(0x0000AB3500000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC840172CBF5 AS DateTime), CAST(0x0000AC8600B0B6A5 AS DateTime), N'admin', N'admin', NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'02ca3b18-cbc3-410c-9125-74db501c438d', N'CT20201119000001', N'test seqid', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC78010CEA9C AS DateTime), CAST(0x0000AC8401780D9F AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'1836e108-1ddf-459f-ae86-7f9af238135d', N'CT20201130000001', N'Test 3333', 12000.0000, CAST(0x0000AC8300000000 AS DateTime), N'VT', N'COM0001', CAST(0x0000AC830007483A AS DateTime), NULL, N'admin', NULL, 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'677da1f4-6c45-4a93-a2e6-80944d6daf8c', N'CT20201208000001', N'0000775 - Chiết khấu hàng tháng 01.01.2020 đến 31.01.2020', 47000000.0000, CAST(0x0000AB6100000000 AS DateTime), N'HT', N'COM0001', CAST(0x0000AC8B0184A409 AS DateTime), NULL, N'admin', NULL, NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'7a613420-0d41-4ada-83e8-829e5e2af84f', N'CT20201119000004', N'test seqid 4', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC78010D9958 AS DateTime), CAST(0x0000AC83000ABADA AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'2adda6ed-57f5-4730-8898-8431ad4de58f', N'CT20201130000005', N'test seqid 21222', 12000.0000, CAST(0x0000AC7700000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC83001257F4 AS DateTime), NULL, N'admin', NULL, 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'f528c474-9503-43b2-b9a6-9155523a7369', N'CT20201130000004', N'test seqid 21222', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC8300122A1C AS DateTime), CAST(0x0000AC8300126719 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'd0b760ff-1f0f-493d-8bcc-9781be5f387d', N'CT20201130000003', N'test seqid 2', 12000.0000, CAST(0x0000AC7700000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC830011F992 AS DateTime), CAST(0x0000AC8300123791 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'1d80f988-a578-4628-8a9e-9cec985fc766', N'CTD20201130000001', N'Test 30 lần 2 thêm mới', 0.0000, CAST(0x0000AC7C00000000 AS DateTime), N'VT', N'COM0001', CAST(0x0000AC830005D264 AS DateTime), CAST(0x0000AC8300082B49 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'e1f03665-617b-42c9-b342-b895e60ef72a', N'CTD20201130000001', N'Test 30 lần 2 thêm mới', 0.0000, CAST(0x0000AC8300000000 AS DateTime), N'VT', N'COM0001', CAST(0x0000AC830001648E AS DateTime), CAST(0x0000AC8300082B49 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'd6aa40cc-ceda-4af3-a43d-b9db37995729', N'CT20201208000002', N'Xe nâng Nissan FD35 (đã qua sử dụng)', 265000.0000, CAST(0x0000AB7700000000 AS DateTime), N'HT', N'COM0001', CAST(0x0000AC8B0185D12C AS DateTime), NULL, N'admin', NULL, NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'76cf5f24-bbde-4d7e-bad3-c617bb3a6c73', N'CT20201118100729841', N'Tùng test 3', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC77016C9BB7 AS DateTime), CAST(0x0000AC83000AA1D9 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'56829c64-aa75-49fc-9f98-cde78ce800c7', N'CT20201130000006', N'test seqid 1', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC8300131F2B AS DateTime), CAST(0x0000AC830018D7EC AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'bbd1f6c2-62c8-45c9-b180-d84052c87f4f', N'CTD20201130000001', N'Test 30 lần 2 thêm mới', 0.0000, CAST(0x0000AC8200000000 AS DateTime), N'TH', N'COM0001', CAST(0x0000AC830000A12E AS DateTime), CAST(0x0000AC8300082B49 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'e2fdc59e-a10b-44e9-ac7d-f6a3370eb94f', N'CT20201118055856761', N'Chi mua vật liệu xậy dựng', 0.0000, CAST(0x0000AC7600000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC7701285773 AS DateTime), CAST(0x0000AC830010630E AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'cb41a41f-9e85-41d1-b776-fb90a47cb430', N'CT20201119000002', N'test seqid 2', 0.0000, CAST(0x0000AC7700000000 AS DateTime), N'CH', N'COM0001', CAST(0x0000AC78010D4D87 AS DateTime), CAST(0x0000AC83001213F6 AS DateTime), N'admin', N'admin', 0)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'a5ec584a-e7e7-4554-86dd-0477401cd400', N'CTD20201203000004', N'CT20201203000001', N'1111', N'COM0001', N'SC0000000203', NULL, NULL, 370000.0000, CAST(0x0000AC8600D16017 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'217a04d5-1e94-4c29-8c91-216530454012', N'CTD20201203000007', N'CT20201203000001', N'6425', N'COM0001', N'SC0000000097', NULL, 50000.0000, NULL, CAST(0x0000AC8600D16020 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'd9ed1a55-ed40-49ef-b488-26d9ba9d94c6', N'CTD20201203000012', N'CT20201203000003', N'1561', N'COM0001', N'SC0000000142', NULL, 26000000.0000, NULL, CAST(0x0000AC8600EAF04D AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'c35967ab-08ed-4a6b-8144-2ab5d3303c53', N'CTD20201203000005', N'CT20201203000001', N'6425', N'COM0001', N'SC0000000097', NULL, 290909.0000, NULL, CAST(0x0000AC8600D16019 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'b2f951fa-cd22-488d-9fd6-306d64f12547', N'CTD20201203000013', N'CT20201203000003', N'1331', N'COM0001', N'SC0000000080', NULL, 2600000.0000, NULL, CAST(0x0000AC8600EAF050 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'992ad909-0205-46f2-8ced-3262273f4bc4', N'CTD20201203000008', N'CT20201203000002', N'1331', N'COM0001', N'SC0000000080', NULL, 788182.0000, NULL, CAST(0x0000AC8600E9858B AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'b94965af-0446-4b79-a4d1-5e87c19a32e5', N'CTD20201203000009', N'CT20201203000002', N'1111', N'COM0001', N'SC0000000203', NULL, NULL, 867000.0000, CAST(0x0000AC8600E9858E AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'82181791-5ec1-4faa-92e2-6d3e03ac49fe', N'CTD20201203000011', N'CT20201203000003', N'1111', N'COM0001', N'SC0000000203', NULL, NULL, 28600000.0000, CAST(0x0000AC8600EAF04A AS DateTime), CAST(0x0000AC86017D4E0E AS DateTime), N'admin', N'admin', NULL, N'Trần Thị Ngọc Duyên')
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'9b8edf3b-a1d5-4151-87ca-80cece4de1bf', N'CTD20201203000015', N'CT20201203000004', N'2113', N'COM0001', N'SC0000000184', NULL, 136363636.0000, NULL, CAST(0x0000AC8600EF9474 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'4430fa0b-5da0-434a-8240-812f621d0f86', N'CTD20201208000004', N'CT20201208000002', N'331/01', N'COM0001', N'SC0000000240', N'KH0000000280', NULL, 265000.0000, CAST(0x0000AC8B0185D133 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'87f4a2c1-e083-4b6b-a435-a0fa8c87c56a', N'CTD20201203000010', N'CT20201203000002', N'6428', N'COM0001', N'SC0000000008', N'KH0000000000', 78818.0000, NULL, CAST(0x0000AC8600E98591 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'50f28a93-3d46-4f13-9c7f-a9c0c8a116c0', N'CTD20201208000001', N'CT20201208000001', N'331/01', N'COM0001', N'SC0000000240', N'KH0000000014', 47000000.0000, NULL, CAST(0x0000AC8B0184A413 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'aa2a41b3-a641-4133-8b15-ae04838c0122', N'CTD20201203000001', N'CT20201201000001', N'1111', N'COM0001', N'SC0000000203', NULL, NULL, 22560000.0000, CAST(0x0000AC8600B0B6DB AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'd315001a-93e3-44d5-b1cf-b0971e57115d', N'CTD20201208000003', N'CT20201208000001', N'1331', N'COM0001', N'SC0000000080', NULL, NULL, 4272727.0000, CAST(0x0000AC8B0184A41A AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'8efe3e80-4bb0-4aca-94d6-b3bfcf251f77', N'CTD20201203000002', N'CT20201201000001', N'152', N'COM0001', N'SC0000000175', NULL, 20509091.0000, NULL, CAST(0x0000AC8600B0B6DF AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'1ea599f6-ee09-42fa-9512-c50099eb7dd6', N'CTD20201205000001', N'CT20201205000001', N'1111', N'COM0001', N'SC0000000203', NULL, 100000000000.0000, NULL, CAST(0x0000AC88000A17CE AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'0675785f-5fa1-4c82-ac83-ccbd38222228', N'CTD20201208000002', N'CT20201208000001', N'711', N'COM0001', N'SC0000000104', N'KH0000000014', NULL, 42727273.0000, CAST(0x0000AC8B0184A417 AS DateTime), NULL, N'admin', NULL, NULL, N'0000775')
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'38a60377-136a-4191-b4d3-d2bd34033ee6', N'CTD20201203000006', N'CT20201203000001', N'1331', N'COM0001', N'SC0000000080', NULL, 29091.0000, NULL, CAST(0x0000AC8600D1601D AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'e65eece1-a6b6-4748-96ba-ddf7ae141ec4', N'CTD20201203000014', N'CT20201203000004', N'331', N'COM0001', N'SC0000000154', N'KH0000001687', NULL, 150000000.0000, CAST(0x0000AC8600EF9471 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'c2501b74-d2e3-432e-8c46-e8d61559b8ac', N'CTD20201208000005', N'CT20201208000002', N'2411', N'COM0001', N'SC0000000045', NULL, 265000.0000, NULL, CAST(0x0000AC8B0185D137 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'02cb6c10-6c7e-4b86-8ba6-efb811100c21', N'CTD20201203000016', N'CT20201203000004', N'1331', N'COM0001', N'SC0000000080', NULL, 13636364.0000, NULL, CAST(0x0000AC8600EF9477 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersDetail] ([RowID], [VouchersDetailID], [VouchersID], [AccountID], [CompanyID], [GeneralLedgerID], [CustomerID], [DebitAmount], [CreditAmount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [Descriptions]) VALUES (N'e8b1b72b-2f6d-4eb5-a83d-f3531619def4', N'CTD20201203000003', N'CT20201201000001', N'1331', N'COM0001', N'SC0000000080', NULL, 2050909.0000, NULL, CAST(0x0000AC8600B0B6E2 AS DateTime), NULL, N'admin', NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([RowID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status], [VouchersTypeID]) VALUES (N'A729EEA5-8365-4464-B69E-FC1245500369', N'Chứng từ Thu', CAST(0x0000AC630180A6B0 AS DateTime), NULL, NULL, NULL, N'1', N'TH')
INSERT [dbo].[VouchersType] ([RowID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status], [VouchersTypeID]) VALUES (N'4DE7B934-E0E9-4018-89A5-6916169C77D8', N'Chứng từ Chi', CAST(0x0000AC630180A6B5 AS DateTime), NULL, NULL, NULL, N'1', N'CH')
INSERT [dbo].[VouchersType] ([RowID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status], [VouchersTypeID]) VALUES (N'E71A9899-C9FE-4A64-9F45-F6D839480D35', N'Chứng từ kết chuyển', CAST(0x0000AC630180A6B9 AS DateTime), NULL, NULL, NULL, N'1', N'KC')
INSERT [dbo].[VouchersType] ([RowID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status], [VouchersTypeID]) VALUES (N'CA36D612-5F20-45EC-A6E7-22CC81F5E03D', N'Chứng từ Vật tư', CAST(0x0000AC630180A6BC AS DateTime), NULL, NULL, NULL, N'1', N'VT')
INSERT [dbo].[VouchersType] ([RowID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status], [VouchersTypeID]) VALUES (N'7330B586-FB72-4D84-B703-649A1AE697D9', N'Chứng từ Hạch toán', CAST(0x0000AC630180A6C0 AS DateTime), NULL, NULL, NULL, N'1', N'HT')
INSERT [dbo].[VouchersType] ([RowID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status], [VouchersTypeID]) VALUES (N'D454BB16-2E5C-46A0-A0AF-844BCE15C8BA', N'Nhóm chứng từ khác', CAST(0x0000AC630180A6C4 AS DateTime), NULL, NULL, NULL, N'1', N'KH')
INSERT [dbo].[VouchersType] ([RowID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status], [VouchersTypeID]) VALUES (N'A9A7C9FE-1480-434D-AC02-0D30FB7262B8', N'Điều chỉnh', CAST(0x0000AC630180A6C9 AS DateTime), NULL, NULL, NULL, N'1', N'DC')
INSERT [dbo].[VouchersType] ([RowID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status], [VouchersTypeID]) VALUES (N'3B784BD0-5C15-4404-8A65-A5D4D806A468', N'Đầu kỳ', CAST(0x0000AC680006F427 AS DateTime), NULL, NULL, NULL, N'1', N'DK')
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [GeneralLedgerID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'a9239d7e-6eb7-437b-a73c-cb703286eb78', N'WH20201203000001', N'CT20201201000001', N'HD20201203000001', N'KH0000000043', N'SC0000000175', CAST(0x0000AB3500000000 AS DateTime), N'152', N'1111', N'N', N'Cty TNHH MTV Xăng Dầu Bến Tre', N'Dầu Do', NULL, NULL, CAST(0x0000AC8600B333EE AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [GeneralLedgerID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'd146da69-cba0-45b7-8f7a-2749084442e1', N'WH20201203000002', N'CT20201201000001', N'HD20201203000002', N'KH0000000043', N'SC0000000175', CAST(0x0000AB3500000000 AS DateTime), N'152', N'1111', N'N', N'Cty TNHH MTV Xăng Dầu Bến Tre', N'Dầu DO', NULL, NULL, CAST(0x0000AC8600B38344 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [GeneralLedgerID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'9502cbdf-592a-4fa6-a981-88d6d98625f1', N'WH20201203000003', N'CT20201203000003', N'HD20201203000005', N'KH0000001160', N'SC0000000142', CAST(0x0000AC8400000000 AS DateTime), N'1561', N'1111', N'N', N'Cty TNHH MTV VLXD Kim Cát', N'Nhập Cát', NULL, NULL, CAST(0x0000AC8600ECADDF AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [GeneralLedgerID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'8c8a926c-ebcd-42d1-a4c5-625310f96ee4', N'WH20201203000004', N'CT20201203000003', N'HD20201203000006', N'KH0000001160', N'SC0000000142', CAST(0x0000AC8400000000 AS DateTime), N'1561', N'1111', N'N', N'Cty TNHH MTV VLXD Kim Cát', N'Nhập cát', NULL, NULL, CAST(0x0000AC8600ED4525 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[WareHouse] ([RowID], [WarehouseID], [VouchersID], [InvoiceID], [CustomerID], [GeneralLedgerID], [Date], [DebitAccountID], [CreditAccountID], [Type], [DeliverReceiver], [Description], [Attachfile], [Discount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'1ba78f69-86e5-44a2-8140-9d81b76c852d', N'WH20201203000005', N'CT20201203000004', N'HD20201203000007', NULL, N'SC0000000184', CAST(0x0000AB7700000000 AS DateTime), N'2113', N'331', N'N', NULL, N'Xe ô tô tải (Tự đổ) (Biển số: 51D-429.43) đã qua sử dụng. Hiệu FORLAND; Loại: THACO FLD 345C; Số máy: 4DW83-73*B0205201*; Số khung: RNHD345DCH064493; Màu: Xanh', NULL, NULL, CAST(0x0000AC8600F0DBC4 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'29c6e31c-ac62-432a-9b12-03284ea07cf1', N'WHD20201203000001', N'WH20201203000001', N'SP0000000097', CAST(350.00 AS Numeric(18, 2)), 13454.5457, 4709091.0000, CAST(0x0000AC8600CD9F92 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'4e533e5f-ed17-4fb8-b5d4-d4400418188f', N'WHD20201203000002', N'WH20201203000002', N'SP0000000097', CAST(1000.00 AS Numeric(18, 2)), 15800.0000, 15800000.0000, CAST(0x0000AC8600CE1794 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'c06d9ea7-6056-4225-995a-393d5373c0fc', N'WHD20201203000003', N'WH20201203000003', N'SP0000000050', CAST(250.00 AS Numeric(18, 2)), 52000.0000, 13000000.0000, CAST(0x0000AC8600ECF9A1 AS DateTime), CAST(0x0000AC8901277D2D AS DateTime), N'admin', N'admin', NULL, N'COM0001')
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'26363a40-bc7f-4ad9-b595-311d71a18057', N'WHD20201203000004', N'WH20201203000004', N'SP0000000048', CAST(250.00 AS Numeric(18, 2)), 52000.0000, 13000000.0000, CAST(0x0000AC8600ED7C30 AS DateTime), CAST(0x0000AC890127915E AS DateTime), N'admin', N'admin', NULL, N'COM0001')
INSERT [dbo].[WareHouseDetail] ([RowID], [WareHouseDetailID], [WarehouseID], [ItemID], [Quantity], [Price], [Amount], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Isdelete], [CompanyID]) VALUES (N'950d9662-d646-469a-9e17-a41de8b5e48b', N'WHD20201203000005', N'WH20201203000005', N'SP0000000096', CAST(1.00 AS Numeric(18, 2)), 136363636.0000, 136363636.0000, CAST(0x0000AC8600F24238 AS DateTime), NULL, N'admin', NULL, NULL, N'COM0001')
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Vouchers__FFEE7450916D6532]    Script Date: 10/12/2020 8:33:33 PM ******/
ALTER TABLE [dbo].[VouchersType] ADD UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Vouchers] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[VouchersDetail] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[VouchersType] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[VouchersType] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[VouchersType] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[WareHouse] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[WareHouse] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[WareHouseDetail] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[WareHouseDetail] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
