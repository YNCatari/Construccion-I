CREATE DATABASE dbVacunas
go

/****** Object:  Table [dbo].[Centro]    Script Date: 06/10/2021 15:28:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Centro](
	[id_centro] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[calle] [varchar](100) NOT NULL,
	[ciudad] [varchar](50) NOT NULL,
	[estado] [varchar](10) NOT NULL,
	[distrito] [varchar](50) NOT NULL,
	[codigopostal] [varchar](50) NOT NULL,
	[id_tiposalud] [int] NOT NULL,
 CONSTRAINT [PK_CENTRO] PRIMARY KEY CLUSTERED 
(
	[id_centro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Check1]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Check1](
	[id_check1] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_CHECK1] PRIMARY KEY CLUSTERED 
(
	[id_check1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Check2]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Check2](
	[id_check2] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_CHECK2] PRIMARY KEY CLUSTERED 
(
	[id_check2] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[id_citas] [int] IDENTITY(1,1) NOT NULL,
	[lugarvacunacion] [varchar](100) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[fecha] [varchar](50) NOT NULL,
	[horario_atencion] [varchar](50) NOT NULL,
	[estado] [varchar](10) NOT NULL,
	[id_pacientes] [int] NOT NULL,
	[id_medico] [int] NOT NULL,
	[id_centro] [int] NOT NULL,
	[id_dosis] [int] NOT NULL,
	[id_check1] [int] NOT NULL,
	[id_check2] [int] NOT NULL,
 CONSTRAINT [PK_CITAS] PRIMARY KEY CLUSTERED 
(
	[id_citas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dosis]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dosis](
	[id_dosis] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [varchar](255) NOT NULL,
	[observaciones] [varchar](255) NOT NULL,
	[fecha] [varchar](20) NOT NULL,
	[estado] [varchar](10) NOT NULL,
	[id_tipodosis] [int] NOT NULL,
 CONSTRAINT [PK_DOSIS] PRIMARY KEY CLUSTERED 
(
	[id_dosis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Horario](
	[id_horario] [int] IDENTITY(1,1) NOT NULL,
	[iniciohorario] [varchar](20) NOT NULL,
	[iniciofin] [varchar](20) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HORARIO] PRIMARY KEY CLUSTERED 
(
	[id_horario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[id_medico] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellidos] [varchar](100) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[sexo] [varchar](10) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[turno_mañana] [varchar](20) NOT NULL,
	[contraseña] [varchar](255) NOT NULL,
	[estado] [varchar](10) NOT NULL,
	[id_rol] [int] NOT NULL,
	[id_horario] [int] NOT NULL,
 CONSTRAINT [PK_MEDICOS] PRIMARY KEY CLUSTERED 
(
	[id_medico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[id_pacientes] [int] IDENTITY(1,1) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[apellidos] [varchar](100) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_PACIENTES] PRIMARY KEY CLUSTERED 
(
	[id_pacientes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Dosis]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Dosis](
	[id_tipodosis] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TIPO_DOSIS] PRIMARY KEY CLUSTERED 
(
	[id_tipodosis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Salud]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Salud](
	[id_tiposalud] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](255) NOT NULL,
	[descripcion] [varchar](255) NOT NULL,
	[estado] [varchar](10) NOT NULL,
 CONSTRAINT [PK_TIPO_SALUD] PRIMARY KEY CLUSTERED 
(
	[id_tiposalud] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/10/2021 15:28:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[dni] [varchar](8) NOT NULL,
	[direccion] [varchar](255) NOT NULL,
	[telefono] [varchar](20) NOT NULL,
	[contraseña] [varchar](255) NOT NULL,
	[estado] [varchar](10) NOT NULL,
	[id_rol] [int] NOT NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([id_rol], [nombre], [descripcion], [estado]) VALUES (1, N'User', N'Administrador', N'A')
INSERT [dbo].[Rol] ([id_rol], [nombre], [descripcion], [estado]) VALUES (2, N'User', N'Medico', N'I')
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id_usuario], [nombre], [email], [dni], [direccion], [telefono], [contraseña], [estado], [id_rol]) VALUES (1, N'Yofer Nain', N'yobernain@gmail.com', N'72567658', N'Asoc 24 de junio -cono sur', N'938945667', N'123456', N'A', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Centro]  WITH CHECK ADD  CONSTRAINT [Centro_fk0] FOREIGN KEY([id_tiposalud])
REFERENCES [dbo].[Tipo_Salud] ([id_tiposalud])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Centro] CHECK CONSTRAINT [Centro_fk0]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [Citas_fk0] FOREIGN KEY([id_pacientes])
REFERENCES [dbo].[Pacientes] ([id_pacientes])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [Citas_fk0]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [Citas_fk1] FOREIGN KEY([id_medico])
REFERENCES [dbo].[Medicos] ([id_medico])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [Citas_fk1]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [Citas_fk2] FOREIGN KEY([id_centro])
REFERENCES [dbo].[Centro] ([id_centro])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [Citas_fk2]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [Citas_fk3] FOREIGN KEY([id_dosis])
REFERENCES [dbo].[Dosis] ([id_dosis])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [Citas_fk3]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [Citas_fk4] FOREIGN KEY([id_check1])
REFERENCES [dbo].[Check1] ([id_check1])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [Citas_fk4]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [Citas_fk5] FOREIGN KEY([id_check2])
REFERENCES [dbo].[Check2] ([id_check2])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [Citas_fk5]
GO
ALTER TABLE [dbo].[Dosis]  WITH CHECK ADD  CONSTRAINT [Dosis_fk0] FOREIGN KEY([id_tipodosis])
REFERENCES [dbo].[Tipo_Dosis] ([id_tipodosis])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Dosis] CHECK CONSTRAINT [Dosis_fk0]
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [Medicos_fk0] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Rol] ([id_rol])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [Medicos_fk0]
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [Medicos_fk1] FOREIGN KEY([id_horario])
REFERENCES [dbo].[Horario] ([id_horario])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [Medicos_fk1]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [Usuarios_fk0] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Rol] ([id_rol])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [Usuarios_fk0]
GO
