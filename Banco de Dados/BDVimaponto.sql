/****** Object:  DataBase [BDVimaponto] ******/
CREATE DATABASE BDVimaponto
GO

USE [BDVimaponto]
GO

/****** Object:  Table [dbo].[Tipo] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tipo](
	[TipoId] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Tipo] PRIMARY KEY CLUSTERED 
(
	[TipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Artigo] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Artigo](
	[ArtigoId] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[Valor] [float] NOT NULL,
 CONSTRAINT [PK_Artigo] PRIMARY KEY CLUSTERED 
(
	[ArtigoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Cliente] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](250) NOT NULL,
	[Morada] [varchar](500) NULL,
	[Contato] [varchar](500) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Documento] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Documento](
	[DocumentoId] [int] IDENTITY(1,1) NOT NULL,
	[TipoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[DataAlteracao] [datetime] NOT NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[DocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO

ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_Documento_Cliente]
GO

ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_Documento_Tipo] FOREIGN KEY([TipoId])
REFERENCES [dbo].[Tipo] ([TipoId])
GO

ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_Documento_Tipo]
GO

/****** Object:  Table [dbo].[Item] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[DocumentoId] [int] NOT NULL,
	[ArtigoId] [int] NOT NULL,
	[Quantidade] [int] NOT NULL,
	[DataEntrega] [smalldatetime] NOT NULL,
	[Valor] [float] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[DocumentoId] ASC,
	[ArtigoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Artigo] FOREIGN KEY([ArtigoId])
REFERENCES [dbo].[Artigo] ([ArtigoId])
GO

ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Artigo]
GO

ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Documento] FOREIGN KEY([DocumentoId])
REFERENCES [dbo].[Documento] ([DocumentoId])
GO

ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Documento]
GO


