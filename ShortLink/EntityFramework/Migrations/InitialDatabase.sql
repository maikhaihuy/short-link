USE [master]
GO

USE [ShortLink]
GO

/****** Object:  Table [dbo].[Account]    Script Date: 1/13/2023 11:49:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
    [Id] [varchar](255) NOT NULL,
    [Username] [varchar](255) NOT NULL,
    [Password] [varchar](255) NOT NULL,
    [Email] [varchar](255) NULL,
    [CreatedDate] [datetime] NOT NULL,
    [CreatedBy] [varchar](255) NULL,
    [UpdatedDate] [datetime] NOT NULL,
    [UpdatedBy] [varchar](255) NULL,
    [IsDeleted] [bit] NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
/****** Object:  Table [dbo].[Url]    Script Date: 1/13/2023 11:49:38 PM ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE TABLE [dbo].[Url](
    [Id] [varchar](255) NOT NULL,
    [Hash] [varchar](16) NOT NULL,
    [OriginalUrl] [nvarchar](255) NOT NULL,
    [Title] [nvarchar](255) NULL,
    [Description] [nvarchar](255) NULL,
    [Thumbnail] [nvarchar](255) NULL,
    [CreatedDate] [datetime] NOT NULL,
    [CreatedBy] [varchar](255) NULL,
    [UpdatedDate] [datetime] NOT NULL,
    [UpdatedBy] [varchar](255) NULL,
    CONSTRAINT [PK_Url] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
    GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
    GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
    GO
ALTER TABLE [dbo].[Url] ADD  CONSTRAINT [DF_Url_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
    GO
ALTER TABLE [dbo].[Url] ADD  CONSTRAINT [DF_Url_UpdatedDate]  DEFAULT (getdate()) FOR [UpdatedDate]
    GO
    USE [master]
    GO
ALTER DATABASE [ShortLink] SET  READ_WRITE 
GO
