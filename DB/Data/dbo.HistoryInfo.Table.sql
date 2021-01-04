USE [BlueStarGroup]
GO
/****** Object:  Table [dbo].[HistoryInfo]    Script Date: 12/27/2020 11:49:01 AM ******/
DROP TABLE IF EXISTS [HistoryInfo]
GO
CREATE TABLE [dbo].[HistoryInfo](
	[IPAddress] [varchar](50) NULL,
	[CoputerName] [varchar](50) NULL,
	[TableName] [varchar](50) NULL,
	[ColumnName] [varchar](50) NULL,
	[Value] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[UserID] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
