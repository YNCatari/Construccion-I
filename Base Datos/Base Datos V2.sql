CREATE DATABASE dbVacunas2021
go
USE dbVacunas2021
go
/****** Object:  Table [dbo].[Centro]    Script Date: 28/11/2021 12:18:31 ******/
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
/****** Object:  Table [dbo].[Citas]    Script Date: 28/11/2021 12:18:31 ******/
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
	[Id_tipodosis] [int] NULL,
	[Check1] [int] NULL,
	[Check2] [int] NULL,
 CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED 
(
	[Id_citas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dosis]    Script Date: 28/11/2021 12:18:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dosis](
	[Id_dosis] [int] IDENTITY(1,1) NOT NULL,
	[Cantidad] [varchar](50) NULL,
	[Observaciones] [varchar](50) NULL,
	[Fecha] [varchar](50) NULL,
	[Tipo_operacion] [varchar](10) NULL,
	[Id_tipodosis] [int] NULL,
 CONSTRAINT [PK_Dosis] PRIMARY KEY CLUSTERED 
(
	[Id_dosis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Horario]    Script Date: 28/11/2021 12:18:31 ******/
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
/****** Object:  Table [dbo].[Medico]    Script Date: 28/11/2021 12:18:31 ******/
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
/****** Object:  Table [dbo].[Paciente]    Script Date: 28/11/2021 12:18:31 ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 28/11/2021 12:18:31 ******/
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
/****** Object:  Table [dbo].[Tipo_Dosis]    Script Date: 28/11/2021 12:18:31 ******/
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
/****** Object:  Table [dbo].[Tipo_Salud]    Script Date: 28/11/2021 12:18:31 ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 28/11/2021 12:18:31 ******/
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

INSERT [dbo].[Centro] ([Id_centro], [Nombre], [Direccion], [Calle], [Ciudad], [Distrito], [Codigo], [Id_tiposalud]) VALUES (1, N'CENTRO DE SALUD ALTO DE LA ALIANZA ', N'Oscar Carbajal S/N', N'S/N', N'TACNA', N'Alto Alianza', N'23006', 1)
INSERT [dbo].[Centro] ([Id_centro], [Nombre], [Direccion], [Calle], [Ciudad], [Distrito], [Codigo], [Id_tiposalud]) VALUES (2, N'Centro de Salud Juan Velasco Alvarado', N'Asent H. Juan V. Alvarado O-12', N'S/N', N'Tacna', N'	Alto de la Alianza', N'23006', 1)
INSERT [dbo].[Centro] ([Id_centro], [Nombre], [Direccion], [Calle], [Ciudad], [Distrito], [Codigo], [Id_tiposalud]) VALUES (3, N'PUESTO DE SALUD CONO NORTE', N'Comité 30 MZ 143 LT 29', N'S/N', N'Ciudad Nueva', N'Ciudad Nueva', N'23006', 1)
INSERT [dbo].[Centro] ([Id_centro], [Nombre], [Direccion], [Calle], [Ciudad], [Distrito], [Codigo], [Id_tiposalud]) VALUES (4, N'CENTRO DE SALUD LA ESPERANZA', N'Av. Circunvalación S/N', N'12312', N'Tacna', N'Alto de la Alianza', N'23006', 1)
SET IDENTITY_INSERT [dbo].[Centro] OFF
GO
SET IDENTITY_INSERT [dbo].[Citas] ON 

INSERT [dbo].[Citas] ([Id_citas], [Lugarvacunacion], [Direccion], [Fecha], [Hora], [Estado], [Id_paciente], [Id_medico], [Id_centro], [Id_tipodosis], [Check1], [Check2]) VALUES (1, N'Colegio Jorge Chavez', N'C. las Casuarinas, Tacna 23004', N'2021-11-28', N'11:37', N'A', 1, 1, 1, 1, 0, 0)
INSERT [dbo].[Citas] ([Id_citas], [Lugarvacunacion], [Direccion], [Fecha], [Hora], [Estado], [Id_paciente], [Id_medico], [Id_centro], [Id_tipodosis], [Check1], [Check2]) VALUES (2, N'CENTRO DE SALUD LA ESPERANZA', N'Av. Circunvalación S/N', N'2021-11-28', N'11:49', N'A', 1, 3, 4, 1, 0, 0)

SET IDENTITY_INSERT [dbo].[Citas] OFF
GO
SET IDENTITY_INSERT [dbo].[Dosis] ON 

INSERT [dbo].[Dosis] ([Id_dosis], [Cantidad], [Observaciones], [Fecha], [Tipo_operacion], [Id_tipodosis]) VALUES (1, N'100', N'se ingreso 100 dosis de Covid-19', N'2021-11-28', N'0', 1)
INSERT [dbo].[Dosis] ([Id_dosis], [Cantidad], [Observaciones], [Fecha], [Tipo_operacion], [Id_tipodosis]) VALUES (2, N'300', N'se ingreso 300 dosis de DENVax', N'2021-11-28', N'0', 2)
SET IDENTITY_INSERT [dbo].[Dosis] OFF
GO
SET IDENTITY_INSERT [dbo].[Horario] ON 

INSERT [dbo].[Horario] ([Id_horario], [Inicio], [Fin], [Descripcion], [Estado]) VALUES (1, N'10:20', N'12:58', N'Horario atencion', N'A')
INSERT [dbo].[Horario] ([Id_horario], [Inicio], [Fin], [Descripcion], [Estado]) VALUES (2, N'12:30', N'15:59', N'Horario atencion', N'A')
INSERT [dbo].[Horario] ([Id_horario], [Inicio], [Fin], [Descripcion], [Estado]) VALUES (3, N'11:35', N'17:42', N'Atención  a Usuarios ', N'A')
SET IDENTITY_INSERT [dbo].[Horario] OFF
GO
SET IDENTITY_INSERT [dbo].[Medico] ON 

INSERT [dbo].[Medico] ([Id_medico], [Dni], [Nombre], [Apellidos], [Telefono], [Sexo], [Email], [Password], [Estado], [Id_rol], [Id_horario]) VALUES (1, N'76232632', N'Maria Esther', N'Duran Chavez', N'938945667', N'F', N'mariaesther@gmail.com', N'123456', N'A', 2, 2)
INSERT [dbo].[Medico] ([Id_medico], [Dni], [Nombre], [Apellidos], [Telefono], [Sexo], [Email], [Password], [Estado], [Id_rol], [Id_horario]) VALUES (2, N'12345678', N'Mariela Liz', N'Vargas Lopez', N'987265368', N'F', N'mariela@gmail.com', N'123456', N'A', 3, 1)
INSERT [dbo].[Medico] ([Id_medico], [Dni], [Nombre], [Apellidos], [Telefono], [Sexo], [Email], [Password], [Estado], [Id_rol], [Id_horario]) VALUES (3, N'12345678', N'Alfredo Luis', N'Santos  Villa', N'987265368', N'M', N'alfredoluis@gmail.com', N'123456', N'A', 2, 3)
SET IDENTITY_INSERT [dbo].[Medico] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 

INSERT [dbo].[Paciente] ([Id_paciente], [Dni], [Nombre], [Apellidos], [Direccion], [Telefono], [Sexo], [Email], [Password], [Estado]) VALUES (1, N'76232632', N'Deysi Delia', N'Barrios Quispe', N'Asc.24 de Junio ', N'938945667', N'M', N'deysi@gmail.com', N'123456', N'A')
INSERT [dbo].[Paciente] ([Id_paciente], [Dni], [Nombre], [Apellidos], [Direccion], [Telefono], [Sexo], [Email], [Password], [Estado]) VALUES (2, N'76232632', N'Lucero Keyla', N'Davila Quispe', N'Asc.203 de Junio ', N'938945667', N'M', N'lucero@gmail.com', N'123456', N'A')
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol] ON 

INSERT [dbo].[Rol] ([Id_rol], [Nombre], [Descripcion], [Estado]) VALUES (1, N'User', N'Administrador', N'A')
INSERT [dbo].[Rol] ([Id_rol], [Nombre], [Descripcion], [Estado]) VALUES (2, N'User', N'Medicos', N'A')
INSERT [dbo].[Rol] ([Id_rol], [Nombre], [Descripcion], [Estado]) VALUES (3, N'User', N'Enfermeria', N'A')
INSERT [dbo].[Rol] ([Id_rol], [Nombre], [Descripcion], [Estado]) VALUES (4, N'User', N'Asistente', N'A')
SET IDENTITY_INSERT [dbo].[Rol] OFF
GO
SET IDENTITY_INSERT [dbo].[Tipo_Dosis] ON 

INSERT [dbo].[Tipo_Dosis] ([Id_tipodosis], [Nombre], [Descripcion], [Estado]) VALUES (1, N'Covid-19', N'corona virus', N'A')
INSERT [dbo].[Tipo_Dosis] ([Id_tipodosis], [Nombre], [Descripcion], [Estado]) VALUES (2, N'Dengue', N'DENVax', N'A')
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
INSERT [dbo].[Usuarios] ([Id_usuario], [Nombre], [Apellidos], [Dni], [Direccion], [Telefono], [Email], [Password], [Estado], [Id_rol]) VALUES (2, N'Posi Yuri', N'Vargas Cusacani', N'12345567', N'Jr pizarro #850 - para chico', N'970450556', N'sinpossio85@gmail.com', N'123456', N'A', 1)
INSERT [dbo].[Usuarios] ([Id_usuario], [Nombre], [Apellidos], [Dni], [Direccion], [Telefono], [Email], [Password], [Estado], [Id_rol]) VALUES (3, N'Jose Luis', N'Mamani  Vargas', N'12345678', N'Asoc.24 de Junio', N'123456789', N'joseluis@gmail.com', N'123456', N'A', 4)
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
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Tipo_Dosis] FOREIGN KEY([Id_tipodosis])
REFERENCES [dbo].[Tipo_Dosis] ([Id_tipodosis])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Tipo_Dosis]
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
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Rol] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[Rol] ([Id_rol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Rol]
GO
