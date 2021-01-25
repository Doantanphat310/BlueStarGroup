CREATE TABLE [dbo].[LockDBCompany](
	[RowID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ClockDBID] [varchar](50) NOT NULL,
	[CompanyID] [varchar](50) NOT NULL,
	[ClockDBDate] [datetime] NULL,
	[ClockDBNote] [nvarchar](max) NULL,
	[ClockStatus] [bit] NULL,
	[CreateUser] [varchar](50) NULL,
	[UpdateUser] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IsDelete] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO