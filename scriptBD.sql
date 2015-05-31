USE [master]
GO
/****** Object:  Database [BDHoteles]    Script Date: 05/30/2015 22:26:16 ******/
CREATE DATABASE [BDHoteles] ON  PRIMARY 
( NAME = N'BDHoteles', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\BDHoteles.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BDHoteles_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\BDHoteles_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BDHoteles] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDHoteles].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDHoteles] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [BDHoteles] SET ANSI_NULLS OFF
GO
ALTER DATABASE [BDHoteles] SET ANSI_PADDING OFF
GO
ALTER DATABASE [BDHoteles] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [BDHoteles] SET ARITHABORT OFF
GO
ALTER DATABASE [BDHoteles] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [BDHoteles] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [BDHoteles] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [BDHoteles] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [BDHoteles] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [BDHoteles] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [BDHoteles] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [BDHoteles] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [BDHoteles] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [BDHoteles] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [BDHoteles] SET  DISABLE_BROKER
GO
ALTER DATABASE [BDHoteles] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [BDHoteles] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [BDHoteles] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [BDHoteles] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [BDHoteles] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [BDHoteles] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [BDHoteles] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [BDHoteles] SET  READ_WRITE
GO
ALTER DATABASE [BDHoteles] SET RECOVERY FULL
GO
ALTER DATABASE [BDHoteles] SET  MULTI_USER
GO
ALTER DATABASE [BDHoteles] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [BDHoteles] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'BDHoteles', N'ON'
GO
USE [BDHoteles]
GO
/****** Object:  Table [dbo].[t_Usuario]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Usuario](
	[idUsuario] [int] NOT NULL,
	[usuario] [varchar](15) NOT NULL,
	[password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_t_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_TipoHabitacion]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_TipoHabitacion](
	[idTipoHabitacion] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[tarifa] [decimal](14, 2) NULL,
 CONSTRAINT [PK_t_TipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[idTipoHabitacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_TipoDocumento]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_TipoDocumento](
	[idTipoDocumento] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[idTipoDocumento] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Servicio]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Servicio](
	[idServicio] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[tarifa] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_t_Servicio] PRIMARY KEY CLUSTERED 
(
	[idServicio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Pais]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Pais](
	[idPais] [int] NOT NULL,
	[nombrePais] [varchar](80) NOT NULL,
 CONSTRAINT [PK_t_Pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Configuracion]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Configuracion](
	[idConfiguracion] [int] NOT NULL,
	[claveConfig] [varchar](10) NOT NULL,
	[valorConfig] [varchar](80) NOT NULL,
 CONSTRAINT [PK_t_Configuracion] PRIMARY KEY CLUSTERED 
(
	[idConfiguracion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Cliente]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Cliente](
	[idCliente] [int] NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[apellidoPaterno] [varchar](100) NOT NULL,
	[apellidoMaterno] [varchar](100) NOT NULL,
	[idTipoDocumento] [int] NOT NULL,
	[numeroDocumento] [varchar](20) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[idPais] [int] NULL,
 CONSTRAINT [PK_t_Cliente] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Habitacion]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Habitacion](
	[idHabitacion] [int] NOT NULL,
	[idTipoHabitacion] [int] NOT NULL,
	[numero] [int] NOT NULL,
	[piso] [int] NOT NULL,
	[descripcion] [varchar](150) NULL,
 CONSTRAINT [PK_t_Habitacion] PRIMARY KEY CLUSTERED 
(
	[idHabitacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Reserva]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Reserva](
	[idReserva] [int] NOT NULL,
	[idCliente] [int] NOT NULL,
	[idHabitacion] [int] NOT NULL,
	[fechaLlegada] [datetime] NOT NULL,
	[fechaSalida] [datetime] NOT NULL,
	[fechaHoraCheckin] [datetime] NOT NULL,
	[comentarioCheckin] [varchar](250) NOT NULL,
	[fechaHoraCheckout] [datetime] NOT NULL,
	[comentarioCheckout] [varchar](250) NOT NULL,
	[codFormaPago] [char](2) NOT NULL,
	[numeroTarjeta] [varchar](50) NOT NULL,
	[titularTarjeta] [varchar](80) NOT NULL,
	[mesExpiraTarjeta] [int] NOT NULL,
	[anioExpiraTarjeta] [int] NOT NULL,
	[requerimientosEsp] [varchar](250) NOT NULL,
	[observaciones] [varchar](250) NOT NULL,
	[estadoCuenta] [bit] NULL,
	[estado] [smallint] NULL,
 CONSTRAINT [PK_t_Reserva] PRIMARY KEY CLUSTERED 
(
	[idReserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Cuenta]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Cuenta](
	[idCuenta] [int] NOT NULL,
	[idReserva] [int] NOT NULL,
	[idServicio] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[costoUnitario] [decimal](14, 2) NULL,
	[total] [decimal](18, 2) NULL,
 CONSTRAINT [PK_t_Cuenta_1] PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Pasajero]    Script Date: 05/30/2015 22:26:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Pasajero](
	[idPasajero] [int] NOT NULL,
	[idReserva] [int] NOT NULL,
	[nombrePasajero] [varchar](80) NOT NULL,
	[apellidoPaterno] [varchar](100) NOT NULL,
	[apellidoMaterno] [varchar](100) NOT NULL,
 CONSTRAINT [PK_t_Pasajero] PRIMARY KEY CLUSTERED 
(
	[idPasajero] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_t_Cliente_t_Pais]    Script Date: 05/30/2015 22:26:18 ******/
ALTER TABLE [dbo].[t_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_t_Cliente_t_Pais] FOREIGN KEY([idPais])
REFERENCES [dbo].[t_Pais] ([idPais])
GO
ALTER TABLE [dbo].[t_Cliente] CHECK CONSTRAINT [FK_t_Cliente_t_Pais]
GO
/****** Object:  ForeignKey [FK_t_Cliente_t_TipoDocumento]    Script Date: 05/30/2015 22:26:18 ******/
ALTER TABLE [dbo].[t_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_t_Cliente_t_TipoDocumento] FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[t_TipoDocumento] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[t_Cliente] CHECK CONSTRAINT [FK_t_Cliente_t_TipoDocumento]
GO
/****** Object:  ForeignKey [FK_t_Habitacion_t_TipoHabitacion]    Script Date: 05/30/2015 22:26:18 ******/
ALTER TABLE [dbo].[t_Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_t_Habitacion_t_TipoHabitacion] FOREIGN KEY([idTipoHabitacion])
REFERENCES [dbo].[t_TipoHabitacion] ([idTipoHabitacion])
GO
ALTER TABLE [dbo].[t_Habitacion] CHECK CONSTRAINT [FK_t_Habitacion_t_TipoHabitacion]
GO
/****** Object:  ForeignKey [FK_t_Reserva_t_Cliente]    Script Date: 05/30/2015 22:26:18 ******/
ALTER TABLE [dbo].[t_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_t_Reserva_t_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[t_Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[t_Reserva] CHECK CONSTRAINT [FK_t_Reserva_t_Cliente]
GO
/****** Object:  ForeignKey [FK_t_Reserva_t_Habitacion]    Script Date: 05/30/2015 22:26:18 ******/
ALTER TABLE [dbo].[t_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_t_Reserva_t_Habitacion] FOREIGN KEY([idHabitacion])
REFERENCES [dbo].[t_Habitacion] ([idHabitacion])
GO
ALTER TABLE [dbo].[t_Reserva] CHECK CONSTRAINT [FK_t_Reserva_t_Habitacion]
GO
/****** Object:  ForeignKey [FK_t_Cuenta_t_Reserva]    Script Date: 05/30/2015 22:26:18 ******/
ALTER TABLE [dbo].[t_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_t_Cuenta_t_Reserva] FOREIGN KEY([idReserva])
REFERENCES [dbo].[t_Reserva] ([idReserva])
GO
ALTER TABLE [dbo].[t_Cuenta] CHECK CONSTRAINT [FK_t_Cuenta_t_Reserva]
GO
/****** Object:  ForeignKey [FK_t_Cuenta_t_Servicio]    Script Date: 05/30/2015 22:26:18 ******/
ALTER TABLE [dbo].[t_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_t_Cuenta_t_Servicio] FOREIGN KEY([idServicio])
REFERENCES [dbo].[t_Servicio] ([idServicio])
GO
ALTER TABLE [dbo].[t_Cuenta] CHECK CONSTRAINT [FK_t_Cuenta_t_Servicio]
GO
/****** Object:  ForeignKey [FK_t_Pasajero_t_Reserva]    Script Date: 05/30/2015 22:26:18 ******/
ALTER TABLE [dbo].[t_Pasajero]  WITH CHECK ADD  CONSTRAINT [FK_t_Pasajero_t_Reserva] FOREIGN KEY([idReserva])
REFERENCES [dbo].[t_Reserva] ([idReserva])
GO
ALTER TABLE [dbo].[t_Pasajero] CHECK CONSTRAINT [FK_t_Pasajero_t_Reserva]
GO
