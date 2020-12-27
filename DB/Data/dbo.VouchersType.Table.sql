USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[VouchersType]    Script Date: 12/27/2020 11:49:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VouchersType](
	[VouchersTypeID] [varchar](50) NOT NULL,
	[VouchersTypeName] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
 CONSTRAINT [PK_VouchersType] PRIMARY KEY CLUSTERED 
(
	[VouchersTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status]) VALUES (N'CH', N'Chứng từ Chi', CAST(N'2020-10-29T23:20:28.337' AS DateTime), NULL, NULL, NULL, N'1')
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status]) VALUES (N'DC', N'Điều chỉnh', CAST(N'2020-10-29T23:20:28.403' AS DateTime), NULL, NULL, NULL, N'1')
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status]) VALUES (N'HT', N'Chứng từ Hạch toán', CAST(N'2020-10-29T23:20:28.373' AS DateTime), NULL, NULL, NULL, N'1')
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status]) VALUES (N'KC', N'Chứng từ kết chuyển', CAST(N'2020-10-29T23:20:28.350' AS DateTime), NULL, NULL, NULL, N'1')
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status]) VALUES (N'KH', N'Nhóm chứng từ khác', CAST(N'2020-10-29T23:20:28.387' AS DateTime), NULL, NULL, NULL, N'1')
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status]) VALUES (N'TH', N'Chứng từ Thu', CAST(N'2020-10-29T23:20:28.320' AS DateTime), NULL, NULL, NULL, N'1')
INSERT [dbo].[VouchersType] ([VouchersTypeID], [VouchersTypeName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [Status]) VALUES (N'VT', N'Chứng từ Vật tư', CAST(N'2020-10-29T23:20:28.360' AS DateTime), NULL, NULL, NULL, N'1')
ALTER TABLE [dbo].[VouchersType] ADD  CONSTRAINT [DF__VouchersT__Creat__30441BD6]  DEFAULT (getdate()) FOR [CreateDate]
GO
