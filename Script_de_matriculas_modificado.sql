USE [master]
GO
/****** Object:  Database [matriculas_ll]    Script Date: 05/03/2019 11:23:09 ******/
CREATE DATABASE [matriculas_ll] ON  PRIMARY 
( NAME = N'matriculas_ll', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\matriculas_ll.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'matriculas_ll_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\matriculas_ll_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [matriculas_ll] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [matriculas_ll].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [matriculas_ll] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [matriculas_ll] SET ANSI_NULLS OFF
GO
ALTER DATABASE [matriculas_ll] SET ANSI_PADDING OFF
GO
ALTER DATABASE [matriculas_ll] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [matriculas_ll] SET ARITHABORT OFF
GO
ALTER DATABASE [matriculas_ll] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [matriculas_ll] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [matriculas_ll] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [matriculas_ll] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [matriculas_ll] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [matriculas_ll] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [matriculas_ll] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [matriculas_ll] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [matriculas_ll] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [matriculas_ll] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [matriculas_ll] SET  DISABLE_BROKER
GO
ALTER DATABASE [matriculas_ll] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [matriculas_ll] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [matriculas_ll] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [matriculas_ll] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [matriculas_ll] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [matriculas_ll] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [matriculas_ll] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [matriculas_ll] SET  READ_WRITE
GO
ALTER DATABASE [matriculas_ll] SET RECOVERY SIMPLE
GO
ALTER DATABASE [matriculas_ll] SET  MULTI_USER
GO
ALTER DATABASE [matriculas_ll] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [matriculas_ll] SET DB_CHAINING OFF
GO
USE [matriculas_ll]
GO
/****** Object:  Table [dbo].[curso]    Script Date: 05/03/2019 11:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[curso](
	[id_curso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[curso] ON
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (1, N'1 basico')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (2, N'2 basico')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (3, N'3 basico')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (4, N'4 basico')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (5, N'5 basico')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (6, N'6 basico')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (7, N'7 basico')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (8, N'8 basico')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (9, N'kinder')
INSERT [dbo].[curso] ([id_curso], [Nombre]) VALUES (10, N'pre-kinder')
SET IDENTITY_INSERT [dbo].[curso] OFF
/****** Object:  Table [dbo].[apoderado]    Script Date: 05/03/2019 11:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[apoderado](
	[rut_apoderado] [varchar](10) NOT NULL,
	[nombre_apoderado] [varchar](200) NULL,
	[domicilio] [varchar](150) NULL,
	[fono] [int] NULL,
 CONSTRAINT [PK_apoderado] PRIMARY KEY CLUSTERED 
(
	[rut_apoderado] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[apoderado] ([rut_apoderado], [nombre_apoderado], [domicilio], [fono]) VALUES (N'24346895-7', N'DFBCVBCVB', N'VCNFHFGH', 456478657)
INSERT [dbo].[apoderado] ([rut_apoderado], [nombre_apoderado], [domicilio], [fono]) VALUES (N'45645645-6', N'HFGHFGH', N'GHFGHFG', 756756576)
INSERT [dbo].[apoderado] ([rut_apoderado], [nombre_apoderado], [domicilio], [fono]) VALUES (N'54646456-3', N'GFBFBRRRRRRRR', N'CVBCVBCBDDDDDDDD', 564645646)
INSERT [dbo].[apoderado] ([rut_apoderado], [nombre_apoderado], [domicilio], [fono]) VALUES (N'56453232-0', N'FCBVBCVB', N'VCBCVB', 445646654)
INSERT [dbo].[apoderado] ([rut_apoderado], [nombre_apoderado], [domicilio], [fono]) VALUES (N'67678656-2', N'CBCVB VNVVBN', N'VBNVBNVB', 567575675)
/****** Object:  Table [dbo].[alumno]    Script Date: 05/03/2019 11:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[alumno](
	[rut_alumno] [varchar](10) NOT NULL,
	[nombres] [varchar](100) NULL,
	[apellidos] [varchar](100) NULL,
	[fecha_nacimiento] [date] NULL,
	[sexo] [varchar](25) NULL,
 CONSTRAINT [PK_alumno] PRIMARY KEY CLUSTERED 
(
	[rut_alumno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[alumno] ([rut_alumno], [nombres], [apellidos], [fecha_nacimiento], [sexo]) VALUES (N'10088758-4', N'FGDFGD', N'GFDGDF', CAST(0xA2380B00 AS Date), N'Hombre')
INSERT [dbo].[alumno] ([rut_alumno], [nombres], [apellidos], [fecha_nacimiento], [sexo]) VALUES (N'17886876-4', N'VCFGFDHFGH', N'GFHFGHFG', CAST(0xED320B00 AS Date), N'Hombre')
INSERT [dbo].[alumno] ([rut_alumno], [nombres], [apellidos], [fecha_nacimiento], [sexo]) VALUES (N'19007557-5', N'HFGHFGH', N'FGHFGHFGH', CAST(0xC7380B00 AS Date), N'Mujer')
INSERT [dbo].[alumno] ([rut_alumno], [nombres], [apellidos], [fecha_nacimiento], [sexo]) VALUES (N'34577654-0', N'FGCVBCVB', N'BCVBCVB', CAST(0xA2380B00 AS Date), N'Hombre')
INSERT [dbo].[alumno] ([rut_alumno], [nombres], [apellidos], [fecha_nacimiento], [sexo]) VALUES (N'43534522-0', N'FHFGHFG', N'FGHFGHGF', CAST(0x75320B00 AS Date), N'Hombre')
/****** Object:  Table [dbo].[usuario]    Script Date: 05/03/2019 11:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre_usuario] [varchar](80) NULL,
	[pass] [varchar](100) NULL,
	[tipo_usuario] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[usuario] ON
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [pass], [tipo_usuario]) VALUES (3, N'roy hidalgo', N' ', N'admin')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [pass], [tipo_usuario]) VALUES (12, N'Franco Atala', N'12346789', N'admin')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [pass], [tipo_usuario]) VALUES (13, N'c. oyarzun', N'oyarzun1234', N'admin')
INSERT [dbo].[usuario] ([id_usuario], [nombre_usuario], [pass], [tipo_usuario]) VALUES (15, N'prueba1', N'q1', N'basico')
SET IDENTITY_INSERT [dbo].[usuario] OFF
/****** Object:  Table [dbo].[matricula]    Script Date: 05/03/2019 11:23:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[matricula](
	[id_registro] [int] IDENTITY(1,1) NOT NULL,
	[rut_alumno] [varchar](10) NULL,
	[rut_apoderado] [varchar](10) NULL,
	[id_usuario] [int] NULL,
	[fecha_matricula] [date] NULL,
	[escuela_procedencia] [varchar](200) NULL,
	[cursos_repetidos] [varchar](100) NULL,
	[domicilio_alumno] [varchar](200) NULL,
	[alergico] [varchar](200) NULL,
	[grupo_sanguineo] [varchar](100) NULL,
	[enfermedad] [varchar](200) NULL,
	[grupo_pie] [varchar](50) NULL,
	[nombre_padre] [varchar](200) NULL,
	[nombre_madre] [varchar](200) NULL,
	[rut_padre] [varchar](10) NULL,
	[rut_madre] [varchar](10) NULL,
	[trabajo_padre] [varchar](200) NULL,
	[trabajo_madre] [varchar](200) NULL,
	[escolaridad_padre] [varchar](200) NULL,
	[escolaridad_madre] [varchar](200) NULL,
	[vive_con] [varchar](200) NULL,
	[casa_propia] [varchar](200) NULL,
	[ingreso_mensual] [int] NULL,
	[beneficio] [varchar](200) NULL,
	[religion] [varchar](50) NULL,
	[curso_alumno] [int] NULL,
	[fono_urgencia_1] [int] NULL,
	[fono_urgencia_2] [int] NULL,
	[edad_alumno] [varchar](100) NULL,
	[estado] [varchar](10) NULL,
	[año_academico] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_registro] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[matricula] ON
INSERT [dbo].[matricula] ([id_registro], [rut_alumno], [rut_apoderado], [id_usuario], [fecha_matricula], [escuela_procedencia], [cursos_repetidos], [domicilio_alumno], [alergico], [grupo_sanguineo], [enfermedad], [grupo_pie], [nombre_padre], [nombre_madre], [rut_padre], [rut_madre], [trabajo_padre], [trabajo_madre], [escolaridad_padre], [escolaridad_madre], [vive_con], [casa_propia], [ingreso_mensual], [beneficio], [religion], [curso_alumno], [fono_urgencia_1], [fono_urgencia_2], [edad_alumno], [estado], [año_academico]) VALUES (9, N'17886876-4', N'54646456-3', 3, CAST(0x043F0B00 AS Date), N'TRYGFHF', N'NO HA REPETIDO', N'HFGHFFDVDFVDF', N'NO ES ALERGICO', N'NO SABE', N'GHFGHF', N'No', N'HGHFGHFG', N'HFGHF', N'67567674-7', N'54564564-5', N'FGHFGH', N'GHFGH', N'FGHFGHFG', N'GFHGFH', N'FGHFGH', N'Propia', 5645, N'NO TIENE BENEFICIO', N'Catolica', 1, 654645645, 546456456, N'hgfhfghf', N'activo', NULL)
INSERT [dbo].[matricula] ([id_registro], [rut_alumno], [rut_apoderado], [id_usuario], [fecha_matricula], [escuela_procedencia], [cursos_repetidos], [domicilio_alumno], [alergico], [grupo_sanguineo], [enfermedad], [grupo_pie], [nombre_padre], [nombre_madre], [rut_padre], [rut_madre], [trabajo_padre], [trabajo_madre], [escolaridad_padre], [escolaridad_madre], [vive_con], [casa_propia], [ingreso_mensual], [beneficio], [religion], [curso_alumno], [fono_urgencia_1], [fono_urgencia_2], [edad_alumno], [estado], [año_academico]) VALUES (10, N'34577654-0', N'67678656-2', 3, CAST(0x053F0B00 AS Date), N'65YTUTYU', N'NO HA REPETIDO', N'YUTYUTY', N'NO ES ALERGICO', N'NO SABE', N'TYUTYUTY', N'No', N'UYTYUTYU', N'YUTYU', N'56456456-7', N'67654645-6', N'TYUTYU', N'YUTUT', N'YRTYRYR', N'UTYUTY', N'TYUTYU', N'Propia', 465464, N'NO TIENE BENEFICIO', N'Catolica', 1, 565645645, 756765757, N'ghfhfghf', N' inactivo ', NULL)
INSERT [dbo].[matricula] ([id_registro], [rut_alumno], [rut_apoderado], [id_usuario], [fecha_matricula], [escuela_procedencia], [cursos_repetidos], [domicilio_alumno], [alergico], [grupo_sanguineo], [enfermedad], [grupo_pie], [nombre_padre], [nombre_madre], [rut_padre], [rut_madre], [trabajo_padre], [trabajo_madre], [escolaridad_padre], [escolaridad_madre], [vive_con], [casa_propia], [ingreso_mensual], [beneficio], [religion], [curso_alumno], [fono_urgencia_1], [fono_urgencia_2], [edad_alumno], [estado], [año_academico]) VALUES (11, N'19007557-5', N'45645645-6', 3, CAST(0x073F0B00 AS Date), N'FGHGFHF', N'NO HA REPETIDO', N'FGHFGHFGH', N'NO ES ALERGICO', N'NO SABE', N'FGHFGHGFH', N'No', N'GFHGFHGF', N'FGHFGHGFH', N'43343423-4', N'45645645-6', N'HGFHGFH', N'FGHFGHFGH', N'HGFHGFHGF', N'GFHGFHGF', N'FHFGHGFHG', N'Propia', 234234, N'NO TIENE BENEFICIO', N'Evangelica', 4, 645645666, 546456457, N'gfhfhfgh', N'activo', NULL)
INSERT [dbo].[matricula] ([id_registro], [rut_alumno], [rut_apoderado], [id_usuario], [fecha_matricula], [escuela_procedencia], [cursos_repetidos], [domicilio_alumno], [alergico], [grupo_sanguineo], [enfermedad], [grupo_pie], [nombre_padre], [nombre_madre], [rut_padre], [rut_madre], [trabajo_padre], [trabajo_madre], [escolaridad_padre], [escolaridad_madre], [vive_con], [casa_propia], [ingreso_mensual], [beneficio], [religion], [curso_alumno], [fono_urgencia_1], [fono_urgencia_2], [edad_alumno], [estado], [año_academico]) VALUES (12, N'17886876-4', N'54646456-3', 3, CAST(0x663D0B00 AS Date), N'TRYGFHF', N'NO HA REPETIDO', N'HFGHF', N'NO ES ALERGICO', N'NO SABE', N'GHFGHF', N'No', N'HGHFGHFG', N'HFGHF', N'67567674-7', N'54564564-5', N'FGHFGH', N'GHFGH', N'FGHFGHFG', N'GFHGFH', N'FGHFGH', N'Propia', 5645, N'NO TIENE BENEFICIO', N'Catolica', 2, 654645645, 546456456, N'hgfhfghf', N'activo', NULL)
INSERT [dbo].[matricula] ([id_registro], [rut_alumno], [rut_apoderado], [id_usuario], [fecha_matricula], [escuela_procedencia], [cursos_repetidos], [domicilio_alumno], [alergico], [grupo_sanguineo], [enfermedad], [grupo_pie], [nombre_padre], [nombre_madre], [rut_padre], [rut_madre], [trabajo_padre], [trabajo_madre], [escolaridad_padre], [escolaridad_madre], [vive_con], [casa_propia], [ingreso_mensual], [beneficio], [religion], [curso_alumno], [fono_urgencia_1], [fono_urgencia_2], [edad_alumno], [estado], [año_academico]) VALUES (13, N'43534522-0', N'24346895-7', 3, CAST(0x0B3F0B00 AS Date), N'YRTYRTY', N'NO HA REPETIDO', N'RTYRTYRT', N'NO ES ALERGICO', N'NO SABE', N'TYRTYRT', N'Si', N'RTYRTYRTY', N'YRTYRT', N'67867875-9', N'54643634-9', N'TRYTRY', N'', N'GHJGHJGH', N'546TYY', N'', N'Propia', 54645, N'NO TIENE BENEFICIO', N'Catolica', 2, 5646456, 6456456, N'hghgffg', N'activo', NULL)
INSERT [dbo].[matricula] ([id_registro], [rut_alumno], [rut_apoderado], [id_usuario], [fecha_matricula], [escuela_procedencia], [cursos_repetidos], [domicilio_alumno], [alergico], [grupo_sanguineo], [enfermedad], [grupo_pie], [nombre_padre], [nombre_madre], [rut_padre], [rut_madre], [trabajo_padre], [trabajo_madre], [escolaridad_padre], [escolaridad_madre], [vive_con], [casa_propia], [ingreso_mensual], [beneficio], [religion], [curso_alumno], [fono_urgencia_1], [fono_urgencia_2], [edad_alumno], [estado], [año_academico]) VALUES (14, N'17886876-4', N'54646456-3', 3, CAST(0xBA3B0B00 AS Date), N'TRYGFHF', N'NO HA REPETIDO', N'HFGHF', N'NO ES ALERGICO', N'NO SABE', N'GHFGHF', N'No', N'HGHFGHFG', N'HFGHF', N'67567674-7', N'54564564-5', N'FGHFGH', N'GHFGH', N'FGHFGHFG', N'GFHGFH', N'FGHFGH', N'Propia', 5645, N'NO TIENE BENEFICIO', N'Catolica', 3, 654645645, 546456456, N'hgfhfghf', N'activo', NULL)
INSERT [dbo].[matricula] ([id_registro], [rut_alumno], [rut_apoderado], [id_usuario], [fecha_matricula], [escuela_procedencia], [cursos_repetidos], [domicilio_alumno], [alergico], [grupo_sanguineo], [enfermedad], [grupo_pie], [nombre_padre], [nombre_madre], [rut_padre], [rut_madre], [trabajo_padre], [trabajo_madre], [escolaridad_padre], [escolaridad_madre], [vive_con], [casa_propia], [ingreso_mensual], [beneficio], [religion], [curso_alumno], [fono_urgencia_1], [fono_urgencia_2], [edad_alumno], [estado], [año_academico]) VALUES (15, N'10088758-4', N'56453232-0', 3, CAST(0x183F0B00 AS Date), N'45TRHH', N'NO HA REPETIDO', N'HFH', N'NO ES ALERGICO', N'NO SABE', N'HFGH', N'No', N'HFHFGHFGH', N'FGHFGH', N'45374456-6', N'56465456-6', N'GHFGHFGH', N'GHFGH', N'VBNVBNVB', N'VBNVBNVN', N'FGHFGH', N'', 700000000, N'NO TIENE BENEFICIO', N'', 9, 546465464, 465464565, N'45646ygfgf', N'activo', NULL)
SET IDENTITY_INSERT [dbo].[matricula] OFF
/****** Object:  ForeignKey [fk_alumno_alumno]    Script Date: 05/03/2019 11:23:11 ******/
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [fk_alumno_alumno] FOREIGN KEY([rut_alumno])
REFERENCES [dbo].[alumno] ([rut_alumno])
GO
ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [fk_alumno_alumno]
GO
/****** Object:  ForeignKey [fk_alumno_apoderado]    Script Date: 05/03/2019 11:23:11 ******/
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [fk_alumno_apoderado] FOREIGN KEY([rut_apoderado])
REFERENCES [dbo].[apoderado] ([rut_apoderado])
GO
ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [fk_alumno_apoderado]
GO
/****** Object:  ForeignKey [fk_alumno_usuario]    Script Date: 05/03/2019 11:23:11 ******/
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [fk_alumno_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [fk_alumno_usuario]
GO
/****** Object:  ForeignKey [FK_matricula_curso]    Script Date: 05/03/2019 11:23:11 ******/
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [FK_matricula_curso] FOREIGN KEY([curso_alumno])
REFERENCES [dbo].[curso] ([id_curso])
GO
ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [FK_matricula_curso]
GO
