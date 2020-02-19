USE [Sample]
GO

/****** Object:  Table [dbo].[tbl_Conference]    Script Date: 2/18/2020 9:11:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_Conference](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ConferenceLinks] [varchar](max) NULL,
	[Departments] [varchar](max) NULL,
	[Location] [varchar](max) NULL,
	[References] [varchar](max) NULL,
	[AbstractDueDate] [datetime] NULL,
	[Date] [datetime] NULL,
	[Title] [varchar](max) NULL,
	[ImageLink] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


