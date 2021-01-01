USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[MasterInfo]    Script Date: 12/27/2020 11:49:01 AM ******/
DROP TABLE IF EXISTS [MasterInfo]
GO
CREATE TABLE [dbo].[MasterInfo](
	[MasterCd] [varchar](20) NOT NULL,
	[DetailCd] [varchar](20) NOT NULL,
	[Value] [nvarchar](100) NULL,
	[Value2] [nvarchar](100) NULL,
	[Value3] [nvarchar](100) NULL,
	[Value4] [nvarchar](100) NULL,
	[Value5] [nvarchar](100) NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_MasterInfo] PRIMARY KEY CLUSTERED 
(
	[MasterCd] ASC,
	[DetailCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'ITEMUNIT', N'CAI', N'Cái', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'ITEMUNIT', N'HOP', N'Hộp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'ITEMUNIT', N'KG', N'Ký', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'ITEMUNIT', N'M', N'Mét', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'ITEMUNIT', N'M2', N'Mét vuông', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'ITEMUNIT', N'M3', N'Mét khối', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'ITEMUNIT', N'TAN', N'Tấn', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'USERROLE', N'ROLE01', N'Full', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[MasterInfo] ([MasterCd], [DetailCd], [Value], [Value2], [Value3], [Value4], [Value5], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser]) VALUES (N'USERROLE', N'ROLE02', N'Read', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
