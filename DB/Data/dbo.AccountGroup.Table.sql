USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 12/27/2020 11:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[AccountGroupID] [varchar](50) NOT NULL,
	[AccountGroupName] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_AccountGroup] PRIMARY KEY CLUSTERED 
(
	[AccountGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AccountGroup] ([AccountGroupID], [AccountGroupName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LTK000001', N'TÀI SẢN', CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2020-11-26T21:54:45.660' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountGroup] ([AccountGroupID], [AccountGroupName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LTK000002', N'NỢ PHẢI TRẢ', CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2020-11-26T16:18:05.237' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountGroup] ([AccountGroupID], [AccountGroupName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LTK000003', N'VỐN CHỦ SỞ HỮU', CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2020-11-26T16:18:05.240' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountGroup] ([AccountGroupID], [AccountGroupName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LTK000004', N'DOANH THU', CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2020-11-26T16:18:05.240' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountGroup] ([AccountGroupID], [AccountGroupName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LTK000005', N'CHI PHÍ SẢN XUẤT, KINH DOANH', CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2020-11-26T16:18:05.240' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountGroup] ([AccountGroupID], [AccountGroupName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LTK000006', N'THU NHẬP KHÁC', CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2020-11-26T16:18:05.240' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountGroup] ([AccountGroupID], [AccountGroupName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LTK000007', N'CHI PHÍ KHÁC', CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2020-11-26T16:18:05.243' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountGroup] ([AccountGroupID], [AccountGroupName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'LTK000008', N'TÀI KHOẢN XÁC ĐỊNH KẾ QUẢ KINH DOANH', CAST(N'2020-11-25T00:00:00.000' AS DateTime), CAST(N'2020-11-25T00:00:00.000' AS DateTime), N'admin', N'admin')
