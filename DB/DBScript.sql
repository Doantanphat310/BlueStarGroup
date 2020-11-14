USE [BlueStarGroup]
GO
/****** Object:  UserDefinedFunction [dbo].[Fun_ConvertDateVarchar]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Fun_ConvertDateVarchar]()
returns varchar(18)
as
begin return  (select cast(format(getdate(),'yyyyMMddHHmmssffff') As varchar(18)))
end
GO
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[RowID] [uniqueidentifier] NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[AccountGroupID] [varchar](50) NULL,
 CONSTRAINT [PK__AccountG__3214EC2752D348C8] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__AccountG__FFEE74507732D7C8] UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TKNumber] [int] NULL,
	[Name] [nvarchar](250) NULL,
	[AccountGroupID] [varchar](41) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[ParentID] [varchar](50) NULL,
	[AccountID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TKNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[RowID] [varchar](36) NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[CompanyID] [varchar](20) NOT NULL,
	[CompanyCode] [varchar](20) NULL,
	[CompanyName] [nvarchar](250) NULL,
	[CompanySName] [varchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[MST] [varchar](20) NULL,
	[District] [nvarchar](250) NULL,
	[Province] [nvarchar](250) NULL,
	[Phone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[AccountBank] [varchar](50) NULL,
	[Bank] [nvarchar](250) NULL,
	[BranchBank] [nvarchar](250) NULL,
	[Logo] [nvarchar](max) NULL,
	[BackGround] [nvarchar](max) NULL,
	[StampCircel] [nvarchar](max) NULL,
	[StampSquare] [nvarchar](max) NULL,
	[SoQuyetDinh] [varchar](50) NULL,
	[MaSoHD] [varchar](50) NULL,
	[NoiQLThue] [nvarchar](max) NULL,
	[NHKhoBac] [nvarchar](max) NULL,
	[TKThuThue] [varchar](50) NULL,
	[LapBieu] [nvarchar](250) NULL,
	[KTTruong] [nvarchar](250) NULL,
	[KTVien] [nvarchar](250) NULL,
	[LanhDao] [nvarchar](250) NULL,
	[ThuQuy] [nvarchar](250) NULL,
	[ChucDanhLanhDao] [nvarchar](250) NULL,
	[ChukyLapBieu] [nvarchar](max) NULL,
	[ChuKyKTTruong] [nvarchar](max) NULL,
	[ChuKyKeToanVien] [nvarchar](max) NULL,
	[ChuKyLanhDao] [nvarchar](max) NULL,
	[ChuKyThuQuy] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK__Company__3214EC273C2E9514] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Company__FFEE74501E661DDF] UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[SEQ] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [varchar](20) NOT NULL,
	[CustomerName] [nvarchar](250) NOT NULL,
	[CustomerSName] [varchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [varchar](10) NULL,
	[ParentID] [varchar](20) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK__Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Customer] UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerCommany]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerCommany](
	[CompanyID] [varchar](50) NOT NULL,
	[CustomerID] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_CommanyCustomer] PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC,
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhSachKhachHang$]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhSachKhachHang$](
	[Name] [nvarchar](255) NULL,
	[Summary] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepreciationDetail]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepreciationDetail](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceDetailID] [varchar](50) NULL,
	[WareHouseDetailID] [varchar](50) NULL,
	[PeriodCurrent] [int] NULL,
	[DepreciationDate] [datetime] NULL,
	[QuantityPeriod] [int] NULL,
	[Amount] [money] NULL,
	[Descriptions] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[CompanyID] [varchar](50) NULL,
	[DepreciationID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralLedger]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralLedger](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[SummaryName] [varchar](20) NULL,
	[AccountID] [varchar](50) NULL,
	[ParentID] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[GeneralLedgerID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralLedgerCompany]    Script Date: 11/15/2020 2:08:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralLedgerCompany](
	[GeneralLedgerID] [varchar](50) NULL,
	[CompanyID] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VouchersIDetailD] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[Code1] [varchar](10) NULL,
	[Code2] [varchar](10) NULL,
	[Code3] [varchar](10) NULL,
	[InvoiceNo] [varchar](10) NULL,
	[InvoiceType] [varchar](1) NULL,
	[InvoiceDate] [datetime] NULL,
	[Amount] [money] NULL,
	[VAT] [money] NULL,
	[Discounts] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[CompanyID] [varchar](50) NULL,
	[InvoiceID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [varchar](50) NULL,
	[ItemID] [varchar](50) NULL,
	[Quantity] [numeric](18, 2) NULL,
	[Price] [money] NULL,
	[Amount] [money] NULL,
	[GeneralLedgerID] [varchar](50) NULL,
	[Startdate] [datetime] NULL,
	[UseMonth] [int] NULL,
	[DepreciationMonth] [int] NULL,
	[CurrentMonth] [int] NULL,
	[DepreciationAmount] [money] NULL,
	[DepreciationPercent] [numeric](3, 2) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[CompanyID] [varchar](50) NULL,
	[InvoiceDetailID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[SummaryName] [varchar](20) NULL,
	[ItemsTypeID] [varchar](50) NULL,
	[Unit] [varchar](3) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[ItemID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsPriceCompany]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsPriceCompany](
	[CompanyID] [varchar](50) NULL,
	[ItemID] [varchar](50) NULL,
	[PricesSuggest] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsType]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsType](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[SummaryName] [varchar](20) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[ItemsTypeID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasterInfo]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasterInfo](
	[MasterCd] [varchar](20) NOT NULL,
	[DetailCd] [varchar](20) NOT NULL,
	[Value] [varchar](100) NULL,
	[Value2] [varchar](100) NULL,
	[Value3] [varchar](100) NULL,
	[Value4] [varchar](100) NULL,
	[Value5] [varchar](100) NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_MasterInfo_1] PRIMARY KEY CLUSTERED 
(
	[MasterCd] ASC,
	[DetailCd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserList]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[IsDelete] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleCompany]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleCompany](
	[UserID] [varchar](50) NOT NULL,
	[CompanyID] [varchar](50) NOT NULL,
	[RoleID] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
 CONSTRAINT [PK_UserRoleCompany] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC,
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vouchers](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Amount] [money] NULL,
	[Date] [datetime] NULL,
	[VouchersTypeID] [varchar](50) NULL,
	[VourchersTypeSumary] [varchar](20) NOT NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[CompanyID] [varchar](50) NULL,
	[VouchersID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VouchersDetail]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VouchersDetail](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VouchersID] [varchar](50) NULL,
	[AccountID] [varchar](50) NULL,
	[GeneralLedgerID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[DebitAmount] [money] NULL,
	[CreditAmount] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[CompanyID] [varchar](50) NULL,
	[VouchersDetailID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VouchersType]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VouchersType](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[SummaryName] [varchar](20) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[VouchersTypeID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WareHouseDetail]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouseDetail](
	[RowID] [varchar](36) NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[VouchersDetailID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[ItemID] [varchar](50) NULL,
	[Quantity] [numeric](18, 2) NULL,
	[Price] [money] NULL,
	[Amount] [money] NULL,
	[Startdate] [datetime] NULL,
	[UseMonth] [int] NULL,
	[DepreciationMonth] [int] NULL,
	[CurrentMonth] [int] NULL,
	[DepreciationAmount] [money] NULL,
	[DepreciationPercent] [numeric](3, 2) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](20) NULL,
	[UpdateUser] [varchar](20) NULL,
	[Status] [varchar](1) NULL,
	[CompanyID] [varchar](30) NOT NULL,
	[WareHouseDetailID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AccountGroup] ADD  CONSTRAINT [DF__AccountGr__RowID__5C6CB6D7]  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Accounts] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [df_ParentID]  DEFAULT ((0)) FOR [ParentID]
GO
ALTER TABLE [dbo].[Company] ADD  CONSTRAINT [DF__Company__RowID__4D2A7347]  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF__Customer__RowID__51EF2864]  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CustomerID]  DEFAULT ('''CUS'' + FORMAT(SEQ, ''0000000000'')') FOR [CustomerID]
GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[CustomerCommany] ADD  CONSTRAINT [DF_CommanyCustomer_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[DepreciationDetail] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[GeneralLedger] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Items] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[ItemsType] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Vouchers] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[VouchersDetail] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[VouchersType] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[VouchersType] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[VouchersType] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[WareHouseDetail] ADD  DEFAULT (newid()) FOR [RowID]
GO
/****** Object:  StoredProcedure [dbo].[CompanySelect]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[CompanySelect] 
AS
	SELECT * 
	FROM Company COM
	WHERE COM.IsDelete IS NULL
	ORDER BY 
		COM.CompanyID
GO
/****** Object:  StoredProcedure [dbo].[CustomerCompanySelect]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[CustomerCompanySelect] (
	@CompanyID varchar(20)
)
AS
	SELECT * 
	FROM Customer CUS
		INNER JOIN CustomerCommany COM
		ON CUS.CustomerID = COM.CustomerID
	WHERE 
		COM.CompanyID = @CompanyID
		AND 
		CUS.IsDelete IS NULL
	ORDER BY CUS.CustomerID
GO
/****** Object:  StoredProcedure [dbo].[CustomerDelete]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerDelete] (
	@CustomerID nvarchar(250),
	@UserId varchar(20)
)
AS
	UPDATE Customer
	SET
		UpdateDate = GETDATE(),
		UpdateUser = @UserId,
		IsDelete = 1
	WHERE 
		CustomerID = @CustomerID
GO
/****** Object:  StoredProcedure [dbo].[CustomerInsert]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerInsert] (
	@CustomerID nvarchar(250),
	@CustomerName nvarchar(250),
	@CustomerSName varchar(50),
	@Address nvarchar(250),
	@Phone varchar(10),
	@UserId varchar(20)
)
AS	
	INSERT INTO Customer(
		CustomerID,
		CustomerName,
		CustomerSName,
		[Address],
		Phone,
		CreateDate,
		UpdateDate,
		CreateUser,
		UpdateUser)
	VALUES(
		@CustomerID,
		@CustomerName,
		@CustomerSName,
		@Address,
		@Phone,
		GETDATE(),
		GETDATE(),
		@UserId,
		@UserId)
GO
/****** Object:  StoredProcedure [dbo].[CustomerNotCompanySelect]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerNotCompanySelect] (
	@CompanyID varchar(20) NULL
)
AS
	SELECT *
	FROM Customer CUS
	WHERE 
		CUS.CustomerID NOT IN (
			SELECT CustomerID FROM CustomerCommany 
			WHERE CompanyID = @CompanyID)
		AND 
		CUS.IsDelete IS NULL
	ORDER BY CUS.CustomerID
GO
/****** Object:  StoredProcedure [dbo].[CustomerSelect]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerSelect] 
AS
	SELECT * 
	FROM Customer
	WHERE 
		IsDelete IS NULL
	ORDER BY CustomerID
GO
/****** Object:  StoredProcedure [dbo].[CustomerUpdate]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CustomerUpdate] (
	@CustomerID nvarchar(250),
	@CustomerName nvarchar(250),
	@CustomerSName varchar(50),
	@Address nvarchar(250),
	@Phone varchar(10),
	@UserId varchar(20)
)
AS
	UPDATE Customer
	SET
		CustomerName = @CustomerName,
		CustomerSName = @CustomerSName,
		[Address] = @Address,
		Phone = @Phone,
		UpdateDate = GETDATE(),
		UpdateUser = @UserId
	WHERE 
		CustomerID = @CustomerID
		AND IsDelete IS NULL
GO
/****** Object:  StoredProcedure [dbo].[GenerateID]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GenerateID]
@SumaryName varchar(3)
as 
begin
 select @SumaryName + dbo.Fun_ConvertDateVarchar()
end
GO
/****** Object:  StoredProcedure [dbo].[insertCompanyCustomer]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[insertCompanyCustomer]
 @CompanyID varchar(41)
 as
 begin
 Create Table #tempCompanyCustomer
(RowID int identity(1,1) not null,
CustomerID varchar(41)

)
Insert into #tempCompanyCustomer (CustomerID)
select CustomerID from Customer
	declare @CustomerID varchar(41)
	declare @Counter int
	set @Counter = (select count(CustomerID) from Customer)
		WHILE ( @Counter >0)
		BEGIN
			select @CustomerID = CustomerID from #tempCompanyCustomer where RowID = @Counter
			set @Counter = @Counter - 1
			insert into CommanyCustomer (CompanyId, CustomerID)
			values(@CompanyID,@CustomerID)
		END
 end
GO
/****** Object:  StoredProcedure [dbo].[insertCustomer]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertCustomer]
 as
 begin
 Create Table #tempDSKH
(RowID int identity(1,1) not null,

Name nvarchar(250),

Summay varchar(50)

)

Insert into #tempDSKH (Name, Summay)
select * from [BlueStarGroup].[dbo].[DanhSachKhachHang$]

	declare @Name nvarchar(250)
	declare @Summay varchar(50)
	declare @Counter int
	set @Counter = (select COUNT([Name]) from[BlueStarGroup].[dbo].[DanhSachKhachHang$] )
		WHILE ( @Counter >0)
		BEGIN
			select @Name = Name,@Summay = Summay from #tempDSKH where RowID = @Counter
			set @Counter = @Counter - 1
			insert into Customer (Name, SummaryName)
			values(@Name,@Summay)
		END
 end
GO
/****** Object:  StoredProcedure [dbo].[InsertUSer]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[InsertUSer]
@UserName varchar(20), @Password varchar(30), @Status varchar(1)
as 
BEGIN TRY
    BEGIN TRANSACTION
	if (not exists(select * from [User] where UserName = @UserName))
	begin
		INSERT INTO [User] (UserName, Password, Status)
		VALUES (@UserName,PWDENCRYPT(@Password),@Status)
		Select '1' as MessageCode, 'Create user is success!' as MessageBox
	end
	else
	begin
		Select '2' as MessageCode, 'Can not create user!' as MessageBox
	end
    COMMIT TRAN -- Transaction Success!
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRAN --RollBack in case of Error
    -- you can Raise ERROR with RAISEERROR() Statement including the details of the exception
   ---- RAISERROR(ERROR_MESSAGE(), ERROR_SEVERITY(), 1)
	Select '0' as MessageCode, ERROR_MESSAGE() as MessageBox
END CATCH
GO
/****** Object:  StoredProcedure [dbo].[MasterInfoSelect]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MasterInfoSelect] 
AS
	SELECT * 
	FROM MasterInfo
	ORDER BY 
		MasterCd,
		DetailCd
GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserDelete] (
	@UserID varchar(20),
	@UpdateUserID varchar(20)
)
AS	
	UPDATE UserList
	SET 
		UpdateDate = GETDATE(),
		UpdateUser = @UpdateUserID,
		IsDelete = 1
	WHERE
		UserID = @UserId
		AND IsDelete IS NULL
GO
/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInsert] (
	@UserID varchar(20),
	@Password varchar(250),
	@UserName nvarchar(250),
	@Phone varchar(10),
	@Address nvarchar(250),
	@UpdateUserID varchar(20)
)
AS	
	INSERT INTO UserList(
		UserID,
		[Password],
		UserName,
		Phone,
		[Address],
		CreateDate,
		UpdateDate,
		CreateUser,
		UpdateUser)
	VALUES(
		@UserID,
		@Password,
		@UserName,
		@Phone,
		@Address,
		GETDATE(),
		GETDATE(),
		@UpdateUserID,
		@UpdateUserID)
GO
/****** Object:  StoredProcedure [dbo].[UserRoleCompanyDelete]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRoleCompanyDelete] (
	@UserID varchar(20),
	@CompanyID varchar(20),
	@RoleID varchar(20)
)
AS	
	DELETE UserRoleCompany
	WHERE
		UserID = @UserId
		AND CompanyID = @CompanyID
		AND RoleID = @RoleID
GO
/****** Object:  StoredProcedure [dbo].[UserRoleCompanyInsert]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRoleCompanyInsert] (
	@UserID varchar(20),
	@CompanyID varchar(20),
	@RoleID varchar(20)
)
AS	
	INSERT INTO UserRoleCompany(
		UserID,
		CompanyID,
		RoleID,
		CreateDate,
		UpdateDate,
		CreateUser,
		UpdateUser)
	VALUES(
		@UserID,
		@CompanyID,
		@RoleID,
		GETDATE(),
		GETDATE(),
		@UserId,
		@UserId)
GO
/****** Object:  StoredProcedure [dbo].[UserRoleCompanySelect]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserRoleCompanySelect] 
AS
	SELECT 
		USR.UserID
		,USR.UserName
		,COM.CompanyID
		,COM.CompanyName
		,ROL.RoleID
		,INFO.Value RoleName
	FROM UserList USR
		INNER JOIN UserRoleCompany ROL
			ON USR.UserID = ROL.UserID
		INNER JOIN Company COM
			ON COM.CompanyID = ROL.CompanyID
		LEFT JOIN MasterInfo INFO
			ON ROL.RoleID = INFO.DetailCd
				AND INFO.MasterCd = 'USERROLE'
	WHERE 
		USR.IsDelete IS NULL
		AND COM.IsDelete IS NULL
	ORDER BY 
		USR.UserID,
		COM.CompanyID,
		ROL.RoleID
GO
/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 11/15/2020 2:08:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserUpdate] (
	@UserID varchar(20),
	@Password varchar(250) = NULL,
	@UserName nvarchar(250),
	@Phone varchar(10),
	@UpdateUserID varchar(20)
)
AS	
	UPDATE UserList
	SET 
		[Password] =
			CASE 
				WHEN (@Password IS NULL) THEN [Password]
				ELSE @Password					
			END,
		UserName = @UserName,
		Phone = @Phone,
		UpdateDate = GETDATE(),
		UpdateUser = @UpdateUserID
	WHERE
		UserID = @UserId
		AND IsDelete IS NULL
GO
