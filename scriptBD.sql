--aqui se pondrá el script de la BD
create database [BDHoteles]
go

USE [BDHoteles]
GO
/****** Object:  Table [dbo].[t_Usuario]    Script Date: 05/22/2015 17:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Usuario](
	[idUsuario] [int] NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_TipoHabitacion]    Script Date: 05/22/2015 17:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_TipoHabitacion](
	[idTipoHabitacion] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_TipoHabitacion] PRIMARY KEY CLUSTERED 
(
	[idTipoHabitacion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_TipoDocumento]    Script Date: 05/22/2015 17:35:15 ******/
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
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[t_TipoDocumento] ([idTipoDocumento], [descripcion]) VALUES (1, 'DNI')
INSERT [dbo].[t_TipoDocumento] ([idTipoDocumento], [descripcion]) VALUES (2, 'Carnet Extranjeria')
INSERT [dbo].[t_TipoDocumento] ([idTipoDocumento], [descripcion]) VALUES (3, 'Pasaporte')
/****** Object:  Table [dbo].[t_Servicio]    Script Date: 05/22/2015 17:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Servicio](
	[idServicio] [int] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[costo] [decimal](14, 2) NOT NULL,
 CONSTRAINT [PK_t_Servicio] PRIMARY KEY CLUSTERED 
(
	[idServicio] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Pais]    Script Date: 05/22/2015 17:35:15 ******/
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
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT INTO [dbo].[t_Pais] ([idPais],[nombrePais]) VALUES (1,'Peru')
INSERT INTO [dbo].[t_Pais] ([idPais],[nombrePais]) VALUES (2,'Colombia')
INSERT INTO [dbo].[t_Pais] ([idPais],[nombrePais]) VALUES (3,'Venezuela')
INSERT INTO [dbo].[t_Pais] ([idPais],[nombrePais]) VALUES (4,'Ecuador')
/****** Object:  Table [dbo].[t_Configuracion]    Script Date: 05/22/2015 17:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Configuracion](
	[idConfiguracion] [int] NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[valor] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_Configuracion] PRIMARY KEY CLUSTERED 
(
	[idConfiguracion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Cliente]    Script Date: 05/22/2015 17:35:15 ******/
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
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Habitacion]    Script Date: 05/22/2015 17:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_Habitacion](
	[idHabitacion] [int] NOT NULL,
	[idTipoHabitacion] [int] NOT NULL,
	[numero] [int] NOT NULL,
	[piso] [int] NOT NULL,
 CONSTRAINT [PK_t_Habitacion] PRIMARY KEY CLUSTERED 
(
	[idHabitacion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[t_Reserva]    Script Date: 05/22/2015 17:35:15 ******/
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
	[fechaCheckin] [datetime] NOT NULL,
	[fechaCheckout] [datetime] NOT NULL,
	[fechaEntrada] [datetime] NOT NULL,
	[fechaSalida] [datetime] NOT NULL,
	[flagDisponible] [bit] NOT NULL,
	[flagReservado] [bit] NOT NULL,
	[flagOcupado] [bit] NOT NULL,
	[comentario] [varchar](100) NOT NULL,
 CONSTRAINT [PK_t_Reserva] PRIMARY KEY CLUSTERED 
(
	[idReserva] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Cuenta]    Script Date: 05/22/2015 17:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Cuenta](
	[idCuenta] [int] NOT NULL,
	[idReserva] [int] NOT NULL,
	[idServicio] [int] NOT NULL,
	[comentario] [varchar](100) NOT NULL,
 CONSTRAINT [PK_t_Cuenta] PRIMARY KEY CLUSTERED 
(
	[idCuenta] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_Pasajero]    Script Date: 05/22/2015 17:35:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Pasajero](
	[idPasajero] [int] NOT NULL,
	[idReserva] [int] NOT NULL,
	[nombrePasajero] [varchar](50) NOT NULL,
	[apellidoPaterno] [varchar](50) NOT NULL,
	[apellidoMaterno] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_Pasajero] PRIMARY KEY CLUSTERED 
(
	[idPasajero] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_t_Cliente_t_Pais]    Script Date: 05/22/2015 17:35:15 ******/
ALTER TABLE [dbo].[t_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_t_Cliente_t_Pais] FOREIGN KEY([idPais])
REFERENCES [dbo].[t_Pais] ([idPais])
GO
ALTER TABLE [dbo].[t_Cliente] CHECK CONSTRAINT [FK_t_Cliente_t_Pais]
GO
/****** Object:  ForeignKey [FK_t_Cliente_t_TipoDocumento]    Script Date: 05/22/2015 17:35:15 ******/
ALTER TABLE [dbo].[t_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_t_Cliente_t_TipoDocumento] FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[t_TipoDocumento] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[t_Cliente] CHECK CONSTRAINT [FK_t_Cliente_t_TipoDocumento]
GO
/****** Object:  ForeignKey [FK_t_Cuenta_t_Reserva]    Script Date: 05/22/2015 17:35:15 ******/
ALTER TABLE [dbo].[t_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_t_Cuenta_t_Reserva] FOREIGN KEY([idReserva])
REFERENCES [dbo].[t_Reserva] ([idReserva])
GO
ALTER TABLE [dbo].[t_Cuenta] CHECK CONSTRAINT [FK_t_Cuenta_t_Reserva]
GO
/****** Object:  ForeignKey [FK_t_Cuenta_t_Servicio]    Script Date: 05/22/2015 17:35:15 ******/
ALTER TABLE [dbo].[t_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_t_Cuenta_t_Servicio] FOREIGN KEY([idServicio])
REFERENCES [dbo].[t_Servicio] ([idServicio])
GO
ALTER TABLE [dbo].[t_Cuenta] CHECK CONSTRAINT [FK_t_Cuenta_t_Servicio]
GO
/****** Object:  ForeignKey [FK_t_Habitacion_t_TipoHabitacion]    Script Date: 05/22/2015 17:35:15 ******/
ALTER TABLE [dbo].[t_Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_t_Habitacion_t_TipoHabitacion] FOREIGN KEY([idTipoHabitacion])
REFERENCES [dbo].[t_TipoHabitacion] ([idTipoHabitacion])
GO
ALTER TABLE [dbo].[t_Habitacion] CHECK CONSTRAINT [FK_t_Habitacion_t_TipoHabitacion]
GO
/****** Object:  ForeignKey [FK_t_Pasajero_t_Reserva]    Script Date: 05/22/2015 17:35:15 ******/
ALTER TABLE [dbo].[t_Pasajero]  WITH CHECK ADD  CONSTRAINT [FK_t_Pasajero_t_Reserva] FOREIGN KEY([idReserva])
REFERENCES [dbo].[t_Reserva] ([idReserva])
GO
ALTER TABLE [dbo].[t_Pasajero] CHECK CONSTRAINT [FK_t_Pasajero_t_Reserva]
GO
/****** Object:  ForeignKey [FK_t_Reserva_t_Cliente]    Script Date: 05/22/2015 17:35:15 ******/
ALTER TABLE [dbo].[t_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_t_Reserva_t_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[t_Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[t_Reserva] CHECK CONSTRAINT [FK_t_Reserva_t_Cliente]
GO
/****** Object:  ForeignKey [FK_t_Reserva_t_Habitacion]    Script Date: 05/22/2015 17:35:15 ******/
ALTER TABLE [dbo].[t_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_t_Reserva_t_Habitacion] FOREIGN KEY([idHabitacion])
REFERENCES [dbo].[t_Habitacion] ([idHabitacion])
GO
ALTER TABLE [dbo].[t_Reserva] CHECK CONSTRAINT [FK_t_Reserva_t_Habitacion]
GO
