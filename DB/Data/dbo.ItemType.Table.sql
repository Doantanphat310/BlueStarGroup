USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[ItemType]    Script Date: 12/27/2020 11:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemType](
	[ItemTypeID] [varchar](50) NOT NULL,
	[ItemTypeName] [nvarchar](250) NULL,
	[ItemTypeSName] [varchar](20) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_ItemsType] PRIMARY KEY CLUSTERED 
(
	[ItemTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ItemType] ([ItemTypeID], [ItemTypeName], [ItemTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LSP0000000001', N'Tài sản cố định', N'N211', CAST(N'2020-11-21T14:31:24.267' AS DateTime), CAST(N'2020-11-21T14:31:24.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ItemType] ([ItemTypeID], [ItemTypeName], [ItemTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LSP0000000003', N'CPCPB ngắn hạn', N'N24201', CAST(N'2020-11-21T15:38:15.527' AS DateTime), CAST(N'2020-11-21T15:38:15.527' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ItemType] ([ItemTypeID], [ItemTypeName], [ItemTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LSP0000000004', N'CPCPB dài hạn', N'N24202', CAST(N'2020-11-21T15:38:15.527' AS DateTime), CAST(N'2020-11-21T15:38:15.527' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ItemType] ([ItemTypeID], [ItemTypeName], [ItemTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LSP0000000005', N'Vật liệu xây dựng', N'NH1', CAST(N'2020-11-21T15:38:15.530' AS DateTime), CAST(N'2020-12-05T21:43:40.610' AS DateTime), N'admin', N'admin')
INSERT [dbo].[ItemType] ([ItemTypeID], [ItemTypeName], [ItemTypeSName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LSP0000000006', N'Khác', N'NH2', CAST(N'2020-11-21T21:34:04.750' AS DateTime), CAST(N'2020-11-21T21:34:04.750' AS DateTime), N'admin', N'admin')
