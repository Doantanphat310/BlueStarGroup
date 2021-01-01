USE [BlueStarGroup]
GO
DROP TABLE IF EXISTS [Invoice]
GO
CREATE TABLE [dbo].[Invoice](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[InvoiceID] [varchar](50) NOT NULL,
	[VouchersID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[InvoiceFormNo] [varchar](50) NULL,
	[FormNo] [varchar](50) NULL,
	[SerialNo] [varchar](50) NULL,
	[InvoiceNo] [varchar](50) NULL,
	[InvoiceType] [varchar](1) NULL,
	[InvoiceDate] [datetime] NULL,
	[Amount] [money] NULL,
	[VAT] [decimal](18, 0) NULL,
	[Discounts] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
	[IsDelete] [bit] NULL,
	[CompanyID] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'25d17a53-d055-417a-8578-3d4c62c54518', N'HD20201222000001', N'CT20201222000001', N'KH0000001830', N'Dầu Do', N'01GTKT', N'01GTKT0/001', N'VP/19E', N'0082037', N'V', CAST(N'2019-02-24T00:00:00.000' AS DateTime), 4709091.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(N'2020-12-22T01:39:17.330' AS DateTime), NULL, N'admin', NULL, NULL, N'CTY0000000003')
INSERT [dbo].[Invoice] ([RowID], [InvoiceID], [VouchersID], [CustomerID], [Description], [InvoiceFormNo], [FormNo], [SerialNo], [InvoiceNo], [InvoiceType], [InvoiceDate], [Amount], [VAT], [Discounts], [CreateDate], [UpdateDate], [CreateUser], [UpdateUser], [IsDelete], [CompanyID]) VALUES (N'6593d426-195d-4d90-899e-e19bdcd8644d', N'HD20201222000002', N'CT20201222000001', N'KH0000001830', N'Dầu Do', N'01GTKT', N'01GTKT0/002', N'VP/18E', N'0096495', N'V', CAST(N'2019-04-19T00:00:00.000' AS DateTime), 15800000.0000, CAST(10 AS Decimal(18, 0)), 0.0000, CAST(N'2020-12-22T01:39:17.343' AS DateTime), NULL, N'admin', NULL, NULL, N'CTY0000000003')
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
