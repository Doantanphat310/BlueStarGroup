USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[GeneralLedger]    Script Date: 11/16/2020 11:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralLedger](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[GeneralLedgerID] [varchar](50) NOT NULL,
	[GeneralLedgerName] [nvarchar](250) NULL,
	[GeneralLedgerSName] [varchar](20) NULL,
	[AccountID] [varchar](50) NULL,
	[ParentID] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_GeneralLedger] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralLedgerCompany]    Script Date: 11/16/2020 11:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralLedgerCompany](
	[GeneralLedgerID] [varchar](50) NULL,
	[CompanyID] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 11/16/2020 11:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[RowID] [uniqueidentifier] NOT NULL,
	[InvoiceID] [varchar](50) NOT NULL,
	[CompanyID] [varchar](50) NULL,
	[VouchersIDetailD] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Code1] [varchar](10) NULL,
	[Code2] [varchar](10) NULL,
	[Code3] [varchar](10) NULL,
	[InvoiceNo] [varchar](10) NULL,
	[InvoiceType] [varchar](1) NULL,
	[InvoiceDate] [datetime] NULL,
	[Amount] [money] NULL,
	[VAT] [money] NULL,
	[Discounts] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 11/16/2020 11:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[InvoiceDetailID] [varchar](50) NOT NULL,
	[InvoiceID] [varchar](50) NOT NULL,
	[CompanyID] [varchar](50) NULL,
	[ItemID] [varchar](50) NULL,
	[Quantity] [numeric](18, 2) NULL,
	[Price] [money] NULL,
	[Amount] [money] NULL,
	[GeneralLedgerID] [varchar](50) NULL,
	[Startdate] [datetime] NULL,
	[UseMonth] [int] NULL,
	[DepreciationMonth] [int] NULL,
	[CurrentMonth] [int] NULL,
	[DepreciationAmount] [money] NULL,
	[DepreciationPercent] [numeric](3, 2) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 11/16/2020 11:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vouchers](
	[RowID] [uniqueidentifier] DEFAULT (NEWID())  ROWGUIDCOL  NOT NULL,
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
/****** Object:  Table [dbo].[VouchersDetail]    Script Date: 11/16/2020 11:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[VouchersDetail](
	[RowID] [uniqueidentifier]  DEFAULT (NEWID())   ROWGUIDCOL  NOT NULL,
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
 CONSTRAINT [PK_VouchersDetail] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VouchersType]    Script Date: 11/16/2020 11:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VouchersType](
	[VouchersTypeID] [varchar](50) NOT NULL,
	[VouchersTypeName] [nvarchar](250) NULL,
	[VouchersTypeSName] [varchar](20) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_VouchersType] PRIMARY KEY CLUSTERED 
(
	[VouchersTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WareHouseDetail]    Script Date: 11/16/2020 11:13:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouseDetail](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[WareHouseDetailID] [varchar](50) NOT NULL,
	[CompanyID] [varchar](30) NOT NULL,
	[VouchersDetailID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[ItemID] [varchar](50) NULL,
	[Quantity] [numeric](18, 2) NULL,
	[Price] [money] NULL,
	[Amount] [money] NULL,
	[Startdate] [datetime] NULL,
	[UseMonth] [int] NULL,
	[DepreciationMonth] [int] NULL,
	[CurrentMonth] [int] NULL,
	[DepreciationAmount] [money] NULL,
	[DepreciationPercent] [numeric](3, 2) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK__WareHous__3214EC2776BE3ED0] PRIMARY KEY CLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'76fd9431-3e13-4219-a830-45e81649534e', N'VOU20201116224311000', NULL, 0.0000, NULL, NULL, NULL, CAST(N'2020-11-16T22:44:24.977' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[Vouchers] ([RowID], [VouchersID], [Description], [Amount], [Date], [VouchersTypeID], [CompanyID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'40e095e6-aa71-499e-a417-f1f4c4f8e943', N'VOU20201116224311001', NULL, 0.0000, NULL, NULL, NULL, CAST(N'2020-11-16T22:44:38.913' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [VouchersTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'VTP000001', N'Chứng từ Thu', N'TH', CAST(N'2020-10-29T23:20:28.320' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [VouchersTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'VTP000002', N'Chứng từ Chi', N'CH', CAST(N'2020-10-29T23:20:28.337' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [VouchersTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'VTP000003', N'Chứng từ kết chuyển', N'KC', CAST(N'2020-10-29T23:20:28.350' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [VouchersTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'VTP000004', N'Chứng từ Vật tư', N'VT', CAST(N'2020-10-29T23:20:28.360' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [VouchersTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'VTP000005', N'Chứng từ Hạch toán', N'HT', CAST(N'2020-10-29T23:20:28.373' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [VouchersTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'VTP000006', N'Nhóm chứng từ khác', N'KH', CAST(N'2020-10-29T23:20:28.387' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [VouchersTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'VTP000007', N'Điều chỉnh', N'DC', CAST(N'2020-10-29T23:20:28.403' AS DateTime), NULL, NULL, NULL, NULL)
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [VouchersTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete]) VALUES (N'VTP000008', N'Phát Test', N'TEst', CAST(N'2020-11-03T00:25:19.063' AS DateTime), NULL, NULL, NULL, NULL)
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_GeneralLedger]    Script Date: 11/16/2020 11:13:40 PM ******/
ALTER TABLE [dbo].[GeneralLedger] ADD  CONSTRAINT [UQ_GeneralLedger] UNIQUE NONCLUSTERED 
(
	[GeneralLedgerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Invoice]    Script Date: 11/16/2020 11:13:40 PM ******/
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [UQ_Invoice] UNIQUE NONCLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_InvoiceDetail]    Script Date: 11/16/2020 11:13:40 PM ******/
ALTER TABLE [dbo].[InvoiceDetail] ADD  CONSTRAINT [UQ_InvoiceDetail] UNIQUE NONCLUSTERED 
(
	[InvoiceDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_Vouchers]    Script Date: 11/16/2020 11:13:40 PM ******/
ALTER TABLE [dbo].[Vouchers] ADD  CONSTRAINT [UQ_Vouchers] UNIQUE NONCLUSTERED 
(
	[VouchersID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Vouchers__FFEE745054833C10]    Script Date: 11/16/2020 11:13:40 PM ******/
ALTER TABLE [dbo].[VouchersDetail] ADD  CONSTRAINT [UQ__Vouchers__FFEE745054833C10] UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__WareHous__FFEE7450F3496B5B]    Script Date: 11/16/2020 11:13:40 PM ******/
ALTER TABLE [dbo].[WareHouseDetail] ADD  CONSTRAINT [UQ__WareHous__FFEE7450F3496B5B] UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GeneralLedger] ADD  CONSTRAINT [DF__GeneralLe__RowID__1699586C]  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF__Invoice__RowID__7908F585]  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  CONSTRAINT [DF__InvoiceDe__RowID__0D0FEE32]  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Vouchers] ADD  CONSTRAINT [DF__Vouchers__RowID__6F7F8B4B]  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Vouchers] ADD  CONSTRAINT [DF_Vouchers_Amount]  DEFAULT ((0)) FOR [Amount]
GO
ALTER TABLE [dbo].[Vouchers] ADD  CONSTRAINT [DF_Vouchers_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[VouchersDetail] ADD  CONSTRAINT [DF__VouchersD__RowID__74444068]  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[VouchersType] ADD  CONSTRAINT [DF__VouchersT__Creat__27C3E46E]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[VouchersType] ADD  CONSTRAINT [DF__VouchersT__Statu__28B808A7]  DEFAULT ((1)) FOR [IsDelete]
GO
ALTER TABLE [dbo].[WareHouseDetail] ADD  CONSTRAINT [DF__WareHouse__RowID__02925FBF]  DEFAULT (newid()) FOR [RowID]
GO
