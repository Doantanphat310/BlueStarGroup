USE [BlueStarGroup]
GO

/****** Object:  Table [dbo].[Balance]    Script Date: 14/12/2020 11:57:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Balance](
	[BalanceID] [varchar](50) NOT NULL,
	[AccountID] [varchar](50) NULL,
	[AccountDetailID] [varchar](50) NULL,
	[CustomerID] [varchar](50) NULL,
	[CompanyID] [varchar](50) NULL,
	[BalanceDate] [datetime] NULL,
	[DebitAmount] [money] NULL,
	[CreditAmount] [money] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
 CONSTRAINT [PK_Balance] PRIMARY KEY CLUSTERED 
(
	[BalanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Balance] UNIQUE NONCLUSTERED 
(
	[AccountID] ASC,
	[AccountDetailID] ASC,
	[CompanyID] ASC,
	[BalanceDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


