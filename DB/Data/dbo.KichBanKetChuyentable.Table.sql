USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[KichBanKetChuyentable]    Script Date: 12/27/2020 11:49:01 AM ******/
DROP TABLE IF EXISTS [KichBanKetChuyentable]
GO
CREATE TABLE [dbo].[KichBanKetChuyentable](
	[GroupCode] [varchar](50) NULL,
	[KetChuyenDebitAccountID] [varchar](50) NULL,
	[KetChuyenCreditAccountID] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](50) NULL,
	[CompanyID] [varchar](50) NULL,
	[KetChuyenDebitAccountDetailID] [varchar](50) NULL,
	[KetChuyenCreditAccountDetailID] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[KichBanKetChuyentable] ([GroupCode], [KetChuyenDebitAccountID], [KetChuyenCreditAccountID], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CompanyID], [KetChuyenDebitAccountDetailID], [KetChuyenCreditAccountDetailID]) VALUES (N'1', N'911', N'632', NULL, NULL, NULL, NULL, N'CTY0000000003', NULL, NULL)
INSERT [dbo].[KichBanKetChuyentable] ([GroupCode], [KetChuyenDebitAccountID], [KetChuyenCreditAccountID], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CompanyID], [KetChuyenDebitAccountDetailID], [KetChuyenCreditAccountDetailID]) VALUES (N'1', N'911', N'635', NULL, NULL, NULL, NULL, N'CTY0000000003', NULL, NULL)
INSERT [dbo].[KichBanKetChuyentable] ([GroupCode], [KetChuyenDebitAccountID], [KetChuyenCreditAccountID], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CompanyID], [KetChuyenDebitAccountDetailID], [KetChuyenCreditAccountDetailID]) VALUES (N'1', N'911', N'6411', NULL, NULL, NULL, NULL, N'CTY0000000003', NULL, NULL)
INSERT [dbo].[KichBanKetChuyentable] ([GroupCode], [KetChuyenDebitAccountID], [KetChuyenCreditAccountID], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CompanyID], [KetChuyenDebitAccountDetailID], [KetChuyenCreditAccountDetailID]) VALUES (N'1', N'911', N'3341', NULL, NULL, NULL, NULL, N'CTY0000000003', NULL, NULL)
INSERT [dbo].[KichBanKetChuyentable] ([GroupCode], [KetChuyenDebitAccountID], [KetChuyenCreditAccountID], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CompanyID], [KetChuyenDebitAccountDetailID], [KetChuyenCreditAccountDetailID]) VALUES (N'2', N'515', N'911', NULL, NULL, NULL, NULL, N'CTY0000000003', NULL, NULL)
INSERT [dbo].[KichBanKetChuyentable] ([GroupCode], [KetChuyenDebitAccountID], [KetChuyenCreditAccountID], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [CompanyID], [KetChuyenDebitAccountDetailID], [KetChuyenCreditAccountDetailID]) VALUES (N'2', N'5111', N'911', NULL, NULL, NULL, NULL, N'CTY0000000003', NULL, NULL)
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_KetChuyen]    Script Date: 12/27/2020 11:49:06 AM ******/
ALTER TABLE [dbo].[KichBanKetChuyentable] ADD  CONSTRAINT [UC_KetChuyen] UNIQUE NONCLUSTERED 
(
	[KetChuyenDebitAccountID] ASC,
	[KetChuyenCreditAccountID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
