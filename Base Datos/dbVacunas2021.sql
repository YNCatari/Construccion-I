CREATE DATABASE dbVacunas2021
go
USE dbVacunas2021
go

/****** Object:  Table [dbo].[Centro]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Centro](
	[Id_centro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Calle] [varchar](50) NULL,
	[Ciudad] [varchar](50) NULL,
	[Distrito] [varchar](50) NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Id_tiposalud] [int] NULL,
 CONSTRAINT [PK_Centro] PRIMARY KEY CLUSTERED 
(
	[Id_centro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[Id_citas] [int] IDENTITY(1,1) NOT NULL,
	[Lugarvacunacion] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Fecha] [varchar](10) NULL,
	[Hora] [varchar](10) NULL,
	[Estado] [varchar](10) NULL,
	[Id_paciente] [int] NULL,
	[Id_medico] [int] NULL,
	[Id_centro] [int] NULL,
	[Id_totaldosis] [int] NULL,
	[Check1] [int] NULL,
	[Check2] [int] NULL,
 CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED 
(
	[Id_citas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dosis]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dosis](
	[Id_dosis] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [varchar](50) NULL,
	[Observaciones] [varchar](50) NULL,
	[Fecha] [varchar](50) NULL,
	[Estado] [varchar](10) NULL,
	[Id_tipodosis] [int] NULL,
 CONSTRAINT [PK_Dosis] PRIMARY KEY CLUSTERED 
(
	[Id_dosis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[Id_horario] [int] IDENTITY(1,1) NOT NULL,
	[Inicio] [varchar](50) NULL,
	[Fin] [varchar](50) NULL,
	[Descripcion] [varchar](100) NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_Horario] PRIMARY KEY CLUSTERED 
(
	[Id_horario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medico]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medico](
	[Id_medico] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [varchar](8) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](70) NULL,
	[Telefono] [varchar](9) NULL,
	[Sexo] [varchar](10) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](8) NULL,
	[Estado] [varchar](10) NULL,
	[Id_rol] [int] NULL,
	[Id_horario] [int] NOT NULL,
 CONSTRAINT [PK_Medico] PRIMARY KEY CLUSTERED 
(
	[Id_medico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[Id_paciente] [int] IDENTITY(1,1) NOT NULL,
	[Dni] [varchar](8) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](9) NULL,
	[Sexo] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](8) NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[Id_paciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id_rol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Dosis]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Dosis](
	[Id_tipodosis] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Estado] [varchar](10) NULL,
 CONSTRAINT [PK_Tipo_Dosis] PRIMARY KEY CLUSTERED 
(
	[Id_tipodosis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Salud]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Salud](
	[Id_tiposalud] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_Salud] PRIMARY KEY CLUSTERED 
(
	[Id_tiposalud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Total_Dosis]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Total_Dosis](
	[Id_totaldosis] [int] IDENTITY(1,1) NOT NULL,
	[Totaldosis] [int] NULL,
	[Totalingresadas] [int] NULL,
	[Id_dosis] [int] NULL,
	[Descripcion] [varchar](100) NULL,
 CONSTRAINT [PK_Total_Dosis] PRIMARY KEY CLUSTERED 
(
	[Id_totaldosis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 01/11/2021 10:35:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellidos] [varchar](50) NULL,
	[Dni] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Telefono] [varchar](9) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](8) NULL,
	[Estado] [varchar](10) NULL,
	[Id_rol] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Centro] ON 

INSERT [dbo].[Centro] ([Id_centro], [Nombre], [Direccion], [Calle], [Ciudad], [Distrito], [Codigo], [Id_tiposalud]) VALUES (1, N'CENTRO DE SALUD ALTO DE LA ALIANZA ', N'Tacna', N'S/N', N'TACNA', N'Alto Alianza', N'23000', NULL)
SET IDENTITY_INSERT [dbo].[Centro] OFF
GO
SET IDENTITY_INSERT [dbo].[Dosis] ON 

INSERT [dbo].[Dosis] ([Id_dosis], [Cantidad], [Observaciones], [Fecha], [Estado], [Id_tipodosis]) VALUES (1, N'36', N'se ingreso 36 dosis de Covid-19', N'2021-11-01', N'A', NULL)
INSERT [dbo].[Dosis] ([Id_dosis], [Cantidad], [Observaciones], [Fecha], [Estado], [Id_tipodosis]) VALUES (2, N'12', N'se ingreso 12 dosis de Dengue', N'2021-11-01', N'A', NULL)
SET IDENTITY_INSERT [dbo].[Dosis] OFF
GO
SET IDENTITY_INSERT [dbo].[Horario] ON 

INSERT [dbo].[Horario] ([Id_horario], [Inicio], [Fin], [Descripcion], [Estado]) VALUES (1, N'10:20', N'12:58', N'Horario atencion', N'A')
INSERT [dbo].[Horario] ([Id_horario], [Inicio], [Fin], [Descripcion], [Estado]) VALUES (2, N'12:30', N'15:59', N'Horario atencion', N'A')
SET IDENTITY_INSERT [dbo].[Horario] OFF
GO
SET IDENTITY_INSERT [dbo].[Medico] ON 

INSERT [dbo].[Medico] ([Id_medico], [Dni], [Nombre], [Apellidos], [Telefono], [Sexo], [Email], [Password], [Estado], [Id_rol], [Id_horario]) VALUES (1, N'76232632', N'Maria Esther', N'Duran Chavez', N'938945667', N'Femenino', N'mariaesther@gmail.com', N'123', N'A', 2, 1)
SET IDENTITY_INSERT [dbo].[Medico] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 

INSERT [dbo].[Paciente] ([Id_paciente], [Dni], [Nombre], [Apellidos], [Direccion], [Telefono], [Sexo], [Email], [Password], [Estado]) VALUES (1, N'76232632', N'Deysi Delia', N'Barrios Quispe', N'Asc.24 de Junio ', N'938945667', N'A', N'deysi@gmail.com', N'123', N'A')
INSERT [dbo].[Paciente] ([Id_paciente], [Dni], [Nombre], [Apellidos], [Direccion], [Telefono], [Sexo], [Email], [Password], [Estado]) VALUES (2, N'76232632', N'Lucero Keyla', N'Davila Quispe', N'Asc.203 de Junio ', N'938945667', N'I', N'lucero@gmail.com', N'123', N'A')
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id_rol], [Nombre], [Descripcion], [Estado]) VALUES (1, N'User', N'Administrador', N'A')
INSERT [dbo].[Rol] ([Id_rol], [Nombre], [Descripcion], [Estado]) VALUES (2, N'User', N'Medicos', N'A')
INSERT [dbo].[Rol] ([Id_rol], [Nombre], [Descripcion], [Estado]) VALUES (3, N'User', N'Enfermeria', N'A')
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Dosis] ON 

INSERT [dbo].[Tipo_Dosis] ([Id_tipodosis], [Nombre], [Descripcion], [Estado]) VALUES (1, N'Covid-19', N'corona virus', N'A')
INSERT [dbo].[Tipo_Dosis] ([Id_tipodosis], [Nombre], [Descripcion], [Estado]) VALUES (2, N'Dengue', N'DENVax', N'A')
INSERT [dbo].[Tipo_Dosis] ([Id_tipodosis], [Nombre], [Descripcion], [Estado]) VALUES (3, N'BCG', N'Tuberculosis', N'A')
INSERT [dbo].[Tipo_Dosis] ([Id_tipodosis], [Nombre], [Descripcion], [Estado]) VALUES (4, N'Hep B', N'Hepatitis B', N'A')
SET IDENTITY_INSERT [dbo].[Tipo_Dosis] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Salud] ON 

INSERT [dbo].[Tipo_Salud] ([Id_tiposalud], [Nombre], [Descripcion], [Estado]) VALUES (1, N'CENTRO DE SALUD ALTO DE LA ALIANZA (00002882)', N'Centro Salud', N'A')
INSERT [dbo].[Tipo_Salud] ([Id_tiposalud], [Nombre], [Descripcion], [Estado]) VALUES (2, N'CENTRO DE SALUD LA ESPERANZA (00002883)', N'Centro Salud', N'A')
INSERT [dbo].[Tipo_Salud] ([Id_tiposalud], [Nombre], [Descripcion], [Estado]) VALUES (3, N'PUESTO DE SALUD INTIORKO (00002887)', N'Centro Salud', N'A')
SET IDENTITY_INSERT [dbo].[Tipo_Salud] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id_usuario], [Nombre], [Apellidos], [Dni], [Direccion], [Telefono], [Email], [Password], [Estado], [Id_rol]) VALUES (1, N'Yober Nain', N'Catari Cabrera', N'72567658', N'Asc.24 de Junio ', N'938945667', N'yobernain@gmail.com', N'123456', N'A', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Centro]  WITH CHECK ADD  CONSTRAINT [FK_Centro_Tipo_Salud] FOREIGN KEY([Id_tiposalud])
REFERENCES [dbo].[Tipo_Salud] ([Id_tiposalud])
GO
ALTER TABLE [dbo].[Centro] CHECK CONSTRAINT [FK_Centro_Tipo_Salud]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Centro] FOREIGN KEY([Id_centro])
REFERENCES [dbo].[Centro] ([Id_centro])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Centro]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Medico] FOREIGN KEY([Id_medico])
REFERENCES [dbo].[Medico] ([Id_medico])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Medico]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Paciente] FOREIGN KEY([Id_paciente])
REFERENCES [dbo].[Paciente] ([Id_paciente])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Paciente]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Total_Dosis] FOREIGN KEY([Id_totaldosis])
REFERENCES [dbo].[Total_Dosis] ([Id_totaldosis])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Total_Dosis]
GO
ALTER TABLE [dbo].[Dosis]  WITH CHECK ADD  CONSTRAINT [FK_Dosis_Tipo_Dosis] FOREIGN KEY([Id_tipodosis])
REFERENCES [dbo].[Tipo_Dosis] ([Id_tipodosis])
GO
ALTER TABLE [dbo].[Dosis] CHECK CONSTRAINT [FK_Dosis_Tipo_Dosis]
GO
ALTER TABLE [dbo].[Medico]  WITH CHECK ADD  CONSTRAINT [FK_Medico_Horario] FOREIGN KEY([Id_horario])
REFERENCES [dbo].[Horario] ([Id_horario])
GO
ALTER TABLE [dbo].[Medico] CHECK CONSTRAINT [FK_Medico_Horario]
GO
ALTER TABLE [dbo].[Medico]  WITH CHECK ADD  CONSTRAINT [FK_Medico_Rol] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[Rol] ([Id_rol])
GO
ALTER TABLE [dbo].[Medico] CHECK CONSTRAINT [FK_Medico_Rol]
GO
ALTER TABLE [dbo].[Total_Dosis]  WITH CHECK ADD  CONSTRAINT [FK_Total_Dosis_Dosis] FOREIGN KEY([Id_dosis])
REFERENCES [dbo].[Dosis] ([Id_dosis])
GO
ALTER TABLE [dbo].[Total_Dosis] CHECK CONSTRAINT [FK_Total_Dosis_Dosis]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Rol] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[Rol] ([Id_rol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Rol]
GO
