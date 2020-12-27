USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[AccountDetail]    Script Date: 12/27/2020 11:48:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountDetail](
	[CompanyID] [varchar](50) NOT NULL,
	[AccountID] [varchar](50) NOT NULL,
	[AccountDetailID] [varchar](50) NOT NULL,
	[AccountDetailName] [nvarchar](250) NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_AccountDetail] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[AccountID] ASC,
	[AccountDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'01', N'Ngân hàng d?u tu phát tri?n - CN Ð?ng Kh?i 7291000', N'1121', N'CTY0000000060', CAST(N'2020-12-25T16:10:09.290' AS DateTime), CAST(N'2020-12-25T16:10:09.290' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'1121', N'02', N'Tiền Việt Nam', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'1121', N'03', N'Tiền Việt Nam', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'131', N'01', N'Phải thu của khách hàng ngắn hạn <= 12', CAST(N'2020-12-25T15:46:49.957' AS DateTime), CAST(N'2020-12-25T15:46:49.957' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'131', N'02', N'Phải thu khách hàng dài hạn > 12T  ', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'131', N'03', N'Người mua trả trước ngắn hạn <= 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'131', N'04', N'Người mua trả trước dài hạn > 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'1361', N'02', N'Vốn kinh doanh ở các đơn vị trực thuộc', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'1388', N'02', N'Phải thu khác > 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'152', N'01', N'Nguyên liệu, vật liệu 01', CAST(N'2020-12-25T09:59:22.170' AS DateTime), CAST(N'2020-12-25T09:59:22.170' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'242', N'02', N'Chi phí trả trước > 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'331', N'03', N'Phải trả cho người bán', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'352', N'02', N'Dự phòng bảo hành công trình xây dựng', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'352', N'03', N'Dự phòng tái cơ cấu doanh nghiệp', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'352', N'04', N'Dự phòng phải trả khác', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'5111', N'02', N'Doanh thu bán hàng hóa', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'5111', N'04', N'Doanh thu bán hàng hóa', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'515', N'02', N'Doanh thu hoạt động tài chính', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'632', N'02', N'Giá vốn hàng bán', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'632', N'04', N'Giá vốn hàng bán', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'6411', N'02', N'Chi phí nhân viên', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'6412', N'02', N'Chi phí nguyên vật liệu, bao bì', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'6418', N'02', N'Chi phí bằng tiền khác', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'6421', N'02', N'Chi phí nhân viên quản lý', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'6425', N'02', N'Thuế, phí và lệ phí', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'6427', N'02', N'Chi phí dịch vụ mua ngoài', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'6428', N'03', N'Chi phí bằng tiền khác', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000003', N'6428', N'30', N'Chi phí bằng tiền khác', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1121', N'01', N'Ngân hàng đầu tư phát triển - CN Đồng Khởi 72910000000490', CAST(N'2020-12-25T16:13:28.917' AS DateTime), CAST(N'2020-12-25T16:13:28.917' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1121', N'02', N'Ngân hàng AGRIBANK- CN Đồng Khởi 7109211030021', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-25T16:13:54.073' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1121', N'03', N'Ngân hàng TMCP Công Thương VN - CN Bến Tre 118 000 130 336 (10201.00020.66374)', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-25T16:13:55.073' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'131', N'01', N'Phải thu khách hàng ngắn hạn <= 12T', CAST(N'2020-12-25T15:49:56.053' AS DateTime), CAST(N'2020-12-25T15:49:56.053' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'131', N'02', N'Phải thu khách hàng dài hạn > 12T  ', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'131', N'03', N'Người mua trả trước ngắn hạn <= 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'131', N'04', N'Người mua trả trước dài hạn > 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1361', N'01', N'Phải thu nội bộ - CN Vĩnh Long', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1361', N'02', N'Phải thu nội bộ - CN 2', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1388', N'01', N'Phải thu khác <=12 tháng', CAST(N'2020-12-25T15:51:53.617' AS DateTime), CAST(N'2020-12-25T15:51:53.617' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1388', N'02', N'Phải thu khác > 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1561', N'01', N'Kho hàng hoá', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'1561', N'03', N'Kho khác', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'242', N'01', N'Chi phí trả trước <= 12T', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'242', N'02', N'Chi phí trả trước > 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'331', N'01', N'Phải trả người bán ngắn hạn <= 12T', CAST(N'2020-12-25T15:57:35.310' AS DateTime), CAST(N'2020-12-25T15:57:35.310' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'331', N'03', N'Trả trước người bán ngắn hạn <= 12T', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'3331', N'01', N'Thuế GTGT đầu ra', CAST(N'2020-12-25T16:16:26.187' AS DateTime), CAST(N'2020-12-25T16:16:26.187' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'3338', N'01', N'Thuế môn bài', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'335', N'01', N'Chi phí phải trả <= 12T', CAST(N'2020-12-25T16:16:41.840' AS DateTime), CAST(N'2020-12-25T16:16:41.840' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'3383', N'01', N'Phải trả ngắn hạn (<=1 năm)', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'3388', N'01', N'Phải trả ngắn hạn (<=1 năm)', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'3411', N'01', N'Vay nợ ngắn hạn <= 12T', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'352', N'02', N'Dự phòng bảo hành công trình xây dựng', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'352', N'03', N'Dự phòng tái cơ cấu doanh nghiệp', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'352', N'04', N'Dự phòng phải trả khác', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'5111', N'01', N'Doanh thu - Công ty Mẹ', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'5111', N'02', N'Doanh thu - CN Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'5111', N'04', N'Doanh thu - CN Tiền Giang', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'515', N'01', N'Doanh thu hoạt động tài chính', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'515', N'02', N'Doanh thu hoạt động tài chính - CN Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'632', N'01', N'Giá vốn hàng bán', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'632', N'02', N'Giá vốn - CN 1 - Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'632', N'04', N'Giá vốn - CN Tiền Giang', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'635', N'01', N'Chi phí lãi vay', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6411', N'01', N'Chi phí nhân viên', CAST(N'2020-12-25T15:59:09.247' AS DateTime), CAST(N'2020-12-25T15:59:09.247' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6411', N'02', N'Chi phí nhân viên - CN Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6412', N'01', N'Chi phí nguyên, vật liệu, bao bì', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6412', N'02', N'Chi phí nguyên, vật liệu, bao bì - CN Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6417', N'01', N'Chi phí dịch vụ mua ngoài', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6418', N'01', N'Chi phí bằng tiền khác', CAST(N'2020-12-25T16:15:24.700' AS DateTime), CAST(N'2020-12-25T16:15:24.700' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6418', N'02', N'Chi phí bằng tiền khác - CN Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-25T16:15:22.887' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6421', N'01', N'Chi phí nhân viên quản lý', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6421', N'02', N'Chi phí nhân viên quản lý - CN Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6423', N'01', N'Chi phí đồ dùng văn phòng', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6424', N'01', N'Chi phí khấu hao TSCĐ', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6425', N'01', N'Thuế, phí và lệ phí', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6425', N'02', N'Thuế, phí và lệ phí - CN Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6427', N'01', N'Chi phí dịch vụ mua ngoài', NULL, NULL, NULL, NULL)
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6427', N'02', N'Chi phí dịch vụ mua ngoài - CN Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6428', N'01', N'Chi bằng tiền khác', CAST(N'2020-12-25T15:58:42.950' AS DateTime), CAST(N'2020-12-25T15:58:42.950' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6428', N'03', N'Tiếp khách, hội nghị, khánh tiết, quảng cáo tiếp thị', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'6428', N'30', N'CN 1 - Vĩnh Long', CAST(N'2020-12-13T11:19:26.267' AS DateTime), CAST(N'2020-12-13T11:19:26.267' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000060', N'811', N'01', N'Chi phí khác', CAST(N'2020-12-25T15:59:33.607' AS DateTime), CAST(N'2020-12-25T15:59:33.607' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000238', N'131', N'01', N'Phải thu của khách hàng ngắn hạn', CAST(N'2020-12-25T10:21:36.910' AS DateTime), CAST(N'2020-12-25T10:21:36.910' AS DateTime), N'admin', N'admin')
INSERT [dbo].[AccountDetail] ([CompanyID], [AccountID], [AccountDetailID], [AccountDetailName], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser]) VALUES (N'CTY0000000238', N'131', N'03', N'Phải thu của khách hàng dài hạn', CAST(N'2020-12-25T10:21:36.910' AS DateTime), CAST(N'2020-12-25T10:21:36.910' AS DateTime), N'admin', N'admin')
