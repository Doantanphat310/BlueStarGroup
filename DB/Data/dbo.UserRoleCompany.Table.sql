USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[UserRoleCompany]    Script Date: 12/27/2020 11:49:01 AM ******/
DROP TABLE IF EXISTS [UserRoleCompany]
GO
CREATE TABLE [dbo].[UserRoleCompany](
	[CompanyID] [varchar](50) NOT NULL,
	[UserID] [varchar](50) NOT NULL,
	[RoleID] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_UserRoleCompany] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UserRoleCompany] ([CompanyID], [UserID], [RoleID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'admin', N'ROLE01', NULL, NULL, N'admin', N'admin')
INSERT [dbo].[UserRoleCompany] ([CompanyID], [UserID], [RoleID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'admin', N'ROLE01', CAST(N'2020-12-13T17:01:24.423' AS DateTime), CAST(N'2020-12-13T17:01:24.423' AS DateTime), N'admin', N'admin')
INSERT [dbo].[UserRoleCompany] ([CompanyID], [UserID], [RoleID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000237', N'admin', N'ROLE01', CAST(N'2020-12-12T23:33:17.340' AS DateTime), CAST(N'2020-12-12T23:33:17.340' AS DateTime), N'admin', N'admin')
INSERT [dbo].[UserRoleCompany] ([CompanyID], [UserID], [RoleID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000238', N'admin', N'ROLE01', CAST(N'2020-12-25T10:03:51.503' AS DateTime), CAST(N'2020-12-25T10:03:51.503' AS DateTime), N'admin', N'admin')
INSERT [dbo].[UserRoleCompany] ([CompanyID], [UserID], [RoleID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'ThanhPTC', N'ROLE01', CAST(N'2020-12-25T10:28:54.573' AS DateTime), CAST(N'2020-12-25T10:28:54.573' AS DateTime), N'admin', N'admin')
INSERT [dbo].[UserRoleCompany] ([CompanyID], [UserID], [RoleID], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000238', N'ThanhPTC', N'ROLE01', CAST(N'2020-12-25T10:28:54.557' AS DateTime), CAST(N'2020-12-25T10:28:54.557' AS DateTime), N'admin', N'admin')
