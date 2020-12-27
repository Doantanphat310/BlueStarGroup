USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[DepreciationDetail]    Script Date: 12/27/2020 11:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepreciationDetail](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DepreciationDetailID] [varchar](50) NULL,
	[DepreciationID] [varchar](50) NULL,
	[PeriodCurrent] [int] NULL,
	[DepreciationDate] [datetime] NULL,
	[QuantityPeriod] [int] NULL,
	[Amount] [money] NULL,
	[Descriptions] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
	[Status] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CompanyID] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DepreciationDetail] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[DepreciationDetail] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
