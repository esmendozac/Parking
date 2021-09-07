USE [Parking]
GO
/****** Object:  Table [dbo].[Calibracion]    Script Date: 7/09/2021 6:51:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calibracion](
	[IdCalibracion] [int] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [datetime] NULL,
	[IdUsuario] [int] NULL,
	[IdLote] [int] NULL,
	[Habilitada] [bit] NULL,
	[Eliminado] [datetime] NULL,
 CONSTRAINT [PK__Calibrac__1010AD0C757414AA] PRIMARY KEY CLUSTERED 
(
	[IdCalibracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EspacioDelimitado]    Script Date: 7/09/2021 6:51:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EspacioDelimitado](
	[IdEspacioDelimitado] [int] IDENTITY(1,1) NOT NULL,
	[Coord1] [varchar](50) NULL,
	[Coord2] [varchar](50) NULL,
	[Coord3] [varchar](50) NULL,
	[Coord4] [varchar](50) NULL,
	[Habilitado] [bit] NULL,
	[Tipo] [varchar](50) NULL,
	[Eliminado] [datetime] NULL,
	[IdCalibracion] [int] NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK__EspacioD__B3E3A4FE4A8ABE1A] PRIMARY KEY CLUSTERED 
(
	[IdEspacioDelimitado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lote]    Script Date: 7/09/2021 6:51:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lote](
	[IdLote] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Nit] [varchar](200) NULL,
	[Email] [varchar](200) NULL,
 CONSTRAINT [PK__Lote__38C4EE9086A5F039] PRIMARY KEY CLUSTERED 
(
	[IdLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 7/09/2021 6:51:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK__Rol__2A49584C71E4FDBB] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/09/2021 6:51:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NULL,
	[Apellidos] [varchar](100) NULL,
	[Identificacion] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[Contrasena] [varchar](200) NULL,
	[IdRol] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[Eliminado] [datetime] NULL,
 CONSTRAINT [PK__Usuario__43C815E60CA4A555] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioLote]    Script Date: 7/09/2021 6:51:36 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioLote](
	[IdUsuarioLote] [int] IDENTITY(1,1) NOT NULL,
	[IdUsuario] [int] NULL,
	[IdLote] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[Eliminado] [datetime] NULL,
 CONSTRAINT [PK__UsuarioL__26FA606EEFF63A11] PRIMARY KEY CLUSTERED 
(
	[IdUsuarioLote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Calibracion]  WITH CHECK ADD  CONSTRAINT [FK_Calibracion_Lote] FOREIGN KEY([IdLote])
REFERENCES [dbo].[Lote] ([IdLote])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Calibracion] CHECK CONSTRAINT [FK_Calibracion_Lote]
GO
ALTER TABLE [dbo].[Calibracion]  WITH CHECK ADD  CONSTRAINT [FK_Calibracion_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Calibracion] CHECK CONSTRAINT [FK_Calibracion_Usuario]
GO
ALTER TABLE [dbo].[EspacioDelimitado]  WITH CHECK ADD  CONSTRAINT [FK_EspacioDelimitado_Calibracion] FOREIGN KEY([IdCalibracion])
REFERENCES [dbo].[Calibracion] ([IdCalibracion])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EspacioDelimitado] CHECK CONSTRAINT [FK_EspacioDelimitado_Calibracion]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
ALTER TABLE [dbo].[UsuarioLote]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioLote_Lote] FOREIGN KEY([IdLote])
REFERENCES [dbo].[Lote] ([IdLote])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioLote] CHECK CONSTRAINT [FK_UsuarioLote_Lote]
GO
ALTER TABLE [dbo].[UsuarioLote]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioLote_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioLote] CHECK CONSTRAINT [FK_UsuarioLote_Usuario]
GO
