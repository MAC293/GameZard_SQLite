USE [GameZard]
GO
/****** Object:  Table [dbo].[Emulator]    Script Date: 06-Oct-21 13:45:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emulator](
	[Name] [nchar](18) NOT NULL,
	[Console] [nchar](16) NOT NULL,
 CONSTRAINT [PK_Emulator] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SavedataEmulator]    Script Date: 06-Oct-21 13:45:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SavedataEmulator](
	[ID] [nchar](18) NOT NULL,
	[FromPath] [nchar](1000) NOT NULL,
	[ToPath] [nchar](1000) NOT NULL,
	[BackUpMode] [nchar](13) NOT NULL,
	[LastSaved] [nchar](10) NULL,
	[Platform] [nchar](18) NOT NULL,
 CONSTRAINT [PK_SavedataEmulator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SavedataPC]    Script Date: 06-Oct-21 13:45:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SavedataPC](
	[ID] [nchar](15) NOT NULL,
	[FromPath] [nchar](1000) NOT NULL,
	[ToPath] [nchar](1000) NOT NULL,
	[BackUpMode] [nchar](13) NOT NULL,
	[LastSaved] [nchar](10) NULL,
	[Videogame] [nchar](15) NOT NULL,
 CONSTRAINT [PK_SavedataPC] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videogame]    Script Date: 06-Oct-21 13:45:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videogame](
	[ID] [nchar](15) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[Cover] [image] NULL,
 CONSTRAINT [PK_Videogame] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[SavedataEmulator]  WITH CHECK ADD  CONSTRAINT [FK_Emulator_SavedataEmulator] FOREIGN KEY([ID])
REFERENCES [dbo].[Emulator] ([Name])
GO
ALTER TABLE [dbo].[SavedataEmulator] CHECK CONSTRAINT [FK_Emulator_SavedataEmulator]
GO
ALTER TABLE [dbo].[SavedataPC]  WITH CHECK ADD  CONSTRAINT [FK_Videogame_SavedataPC] FOREIGN KEY([ID])
REFERENCES [dbo].[Videogame] ([ID])
GO
ALTER TABLE [dbo].[SavedataPC] CHECK CONSTRAINT [FK_Videogame_SavedataPC]
GO
