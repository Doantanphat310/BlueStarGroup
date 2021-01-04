USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[ItemPriceCompany]    Script Date: 12/27/2020 11:49:01 AM ******/
DROP TABLE IF EXISTS [ItemPriceCompany]
GO
CREATE TABLE [dbo].[ItemPriceCompany](
	[ItemID] [varchar](50) NOT NULL,
	[CompanyID] [varchar](50) NOT NULL,
	[ItemPrice] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_ItemsPriceCompany] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ItemPriceCompany] ([ItemID], [CompanyID], [ItemPrice], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'SP0000000001', N'COM000000003', 100000.0000, CAST(N'2020-11-22T15:26:56.080' AS DateTime), CAST(N'2020-11-22T15:26:56.080' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ItemPriceCompany] ([ItemID], [CompanyID], [ItemPrice], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'SP0000000003', N'COM000000003', 200000.0000, CAST(N'2020-11-22T15:23:53.653' AS DateTime), CAST(N'2020-11-22T15:23:53.653' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ItemPriceCompany] ([ItemID], [CompanyID], [ItemPrice], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'SP0000000003', N'COM000000060', 100000.0000, CAST(N'2020-11-22T15:22:23.957' AS DateTime), CAST(N'2020-11-22T15:22:23.957' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ItemPriceCompany] ([ItemID], [CompanyID], [ItemPrice], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'SP0000000122', N'CTY0000000237', 100000.0000, CAST(N'2020-12-05T21:43:11.280' AS DateTime), CAST(N'2020-12-05T21:43:11.280' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ItemPriceCompany] ([ItemID], [CompanyID], [ItemPrice], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'SP0000000354', N'CTY0000000237', 10000.0000, CAST(N'2020-12-05T18:43:42.460' AS DateTime), CAST(N'2020-12-05T18:43:42.460' AS DateTime), N'admin', N'admin')
ALTER TABLE [dbo].[ItemPriceCompany] ADD  CONSTRAINT [DF_ItemsPriceCompany_ItemPrices]  DEFAULT ((0)) FOR [ItemPrice]
GO
