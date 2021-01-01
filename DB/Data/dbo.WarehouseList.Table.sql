USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[WarehouseList]    Script Date: 12/27/2020 11:49:02 AM ******/
DROP TABLE IF EXISTS [WarehouseList]
GO
CREATE TABLE [dbo].[WarehouseList](
	[WarehouseListID] [varchar](50) NOT NULL,
	[WarehouseListName] [nvarchar](250) NULL,
	[WarehouseListDebitAccountID] [varchar](50) NULL,
	[WarehouseListDebitAccountDetailID] [varchar](50) NULL,
	[WarehouseListCreditAccountID] [varchar](50) NULL,
	[WarehouseListCreditAccountDetailID] [varchar](50) NULL,
	[WarehouseListManageCode] [varchar](50) NULL,
	[WarehouseListTitle] [nvarchar](250) NULL,
	[WarehouseListAddress] [nvarchar](max) NULL,
	[WarehouseListNote] [nvarchar](max) NULL,
	[CompanyID] [varchar](50) NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[WarehouseListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[WarehouseList] ([WarehouseListID], [WarehouseListName], [WarehouseListDebitAccountID], [WarehouseListDebitAccountDetailID], [WarehouseListCreditAccountID], [WarehouseListCreditAccountDetailID], [WarehouseListManageCode], [WarehouseListTitle], [WarehouseListAddress], [WarehouseListNote], [CompanyID], [CreateUser], [UpdateUser], [CreateDate], [UpdateDate]) VALUES (N'WHL20201224000001', N'1561/01 - Kho hàng hóa', N'1561', N'', N'1561', N'', N'1', N'', N'', N'test note 1561/01', N'CTY0000000003', N'admin', N'admin', CAST(N'2020-12-24T00:41:48.047' AS DateTime), CAST(N'2020-12-24T00:58:10.017' AS DateTime))
INSERT [dbo].[WarehouseList] ([WarehouseListID], [WarehouseListName], [WarehouseListDebitAccountID], [WarehouseListDebitAccountDetailID], [WarehouseListCreditAccountID], [WarehouseListCreditAccountDetailID], [WarehouseListManageCode], [WarehouseListTitle], [WarehouseListAddress], [WarehouseListNote], [CompanyID], [CreateUser], [UpdateUser], [CreateDate], [UpdateDate]) VALUES (N'WHL20201224000002', N'test tên sổ', N'515', N'02', N'1562', N'', N'4', N'', N'test địa chỉ', N'test note', N'CTY0000000003', N'admin', N'admin', CAST(N'2020-12-24T00:43:58.033' AS DateTime), CAST(N'2020-12-24T00:57:48.187' AS DateTime))
INSERT [dbo].[WarehouseList] ([WarehouseListID], [WarehouseListName], [WarehouseListDebitAccountID], [WarehouseListDebitAccountDetailID], [WarehouseListCreditAccountID], [WarehouseListCreditAccountDetailID], [WarehouseListManageCode], [WarehouseListTitle], [WarehouseListAddress], [WarehouseListNote], [CompanyID], [CreateUser], [UpdateUser], [CreateDate], [UpdateDate]) VALUES (N'WHL20201225000001', N'1561/01 Kho hàng hóa', N'152', N'', N'1122', N'', N'1', N'sdsd', N'ss', N'dd', N'CTY0000000238', N'admin', N'admin', CAST(N'2020-12-25T10:33:56.217' AS DateTime), CAST(N'2020-12-25T10:34:22.577' AS DateTime))
INSERT [dbo].[WarehouseList] ([WarehouseListID], [WarehouseListName], [WarehouseListDebitAccountID], [WarehouseListDebitAccountDetailID], [WarehouseListCreditAccountID], [WarehouseListCreditAccountDetailID], [WarehouseListManageCode], [WarehouseListTitle], [WarehouseListAddress], [WarehouseListNote], [CompanyID], [CreateUser], [UpdateUser], [CreateDate], [UpdateDate]) VALUES (N'WHL20201225000002', N'1561/01 Kho hàng hóafffff', N'152', N'', N'1122', N'', N'1', N'sdsd', N'ss', N'ddsssdsd', N'CTY0000000238', N'admin', N'admin', CAST(N'2020-12-25T10:34:31.000' AS DateTime), CAST(N'2020-12-25T10:34:42.810' AS DateTime))
