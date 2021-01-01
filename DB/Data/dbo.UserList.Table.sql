USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[UserList]    Script Date: 12/27/2020 11:49:01 AM ******/
DROP TABLE IF EXISTS [UserList]
GO
CREATE TABLE [dbo].[UserList](
	[UserID] [varchar](20) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[UserName] [nvarchar](250) NOT NULL,
	[Phone] [varchar](10) NULL,
	[Address] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[UserList] ([UserID], [Password], [UserName], [Phone], [Address], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'admin', N'QcCfuN+3EP2eyy+QpwarCcMNb0M=', N'admin', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[UserList] ([UserID], [Password], [UserName], [Phone], [Address], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'ThanhPTC', N'QkTZw5ymLHZ/byRaVc4PFHYjNH4=', N'ThanhPTC', NULL, NULL, CAST(N'2020-12-25T10:27:38.807' AS DateTime), CAST(N'2020-12-25T10:27:38.807' AS DateTime), N'admin', N'admin')
INSERT [dbo].[UserList] ([UserID], [Password], [UserName], [Phone], [Address], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'tungln', N'8WeFhi906ad7RcqL6iwLPSh/PeE=', N'lương Ngọc Tùng', N'0974333477', N'Lagi Bình Thuận', CAST(N'2020-11-15T02:00:53.927' AS DateTime), CAST(N'2020-11-18T22:25:00.677' AS DateTime), N'admin', N'admin')
INSERT [dbo].[UserList] ([UserID], [Password], [UserName], [Phone], [Address], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'tungln10', N'O92+RcAwN5u1dQrRdn8tF01o6SU=', N'Tùng bbbb', N'0974333477', N'Bình', CAST(N'2020-11-19T01:02:49.430' AS DateTime), CAST(N'2020-12-19T23:30:58.173' AS DateTime), N'admin', N'admin')
INSERT [dbo].[UserList] ([UserID], [Password], [UserName], [Phone], [Address], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'tungln2', N'DUqSImvrJqGq+Irb9u5quf3YFt8=', N'luong ngoc tung', N'097444444', N'bình thuận', CAST(N'2020-11-18T17:54:51.460' AS DateTime), CAST(N'2020-11-18T22:25:00.673' AS DateTime), N'admin', N'admin')
