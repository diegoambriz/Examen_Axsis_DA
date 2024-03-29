CREATE DATABASE [Examen_AxsisDB]

USE [Examen_AxsisDB]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario](
	[Id_Usuario] [bigint] IDENTITY(1,1) NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Nombre_Usuario] [nvarchar](50) NOT NULL,
	[Contraseņa] [nvarchar](50) NOT NULL,
	[Estatus] [bit] NOT NULL,
	[Sexo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


