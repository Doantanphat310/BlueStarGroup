USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[Depreciation]    Script Date: 12/27/2020 11:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depreciation](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[DepreciationID] [varchar](50) NULL,
	[WareHouseDetailID] [varchar](50) NULL,
	[StartDate] [datetime] NULL,
	[UseMonth] [int] NULL,
	[DepreciationMonth] [int] NULL,
	[CurrentMonth] [int] NULL,
	[DepreciationAmount] [money] NULL,
	[DepreciationAmountPerMonth] [money] NULL,
	[Status] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
	[CompanyID] [varchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Depreciation] ADD  DEFAULT (newid()) FOR [RowID]
GO
ALTER TABLE [dbo].[Depreciation] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
