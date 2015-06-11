CREATE DATABASE [BDHoteles] 
GO
USE [BDHoteles]
GO
/****** Object:  Table [dbo].[t_Usuario]    Script Date: 06/10/2015 20:15:51 ******/
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
INSERT [dbo].[t_Usuario] ([idUsuario], [usuario], [password]) VALUES (1, N'admin', N'admin')
/****** Object:  Table [dbo].[t_TipoHabitacion]    Script Date: 06/10/2015 20:15:51 ******/
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
INSERT [dbo].[t_TipoHabitacion] ([idTipoHabitacion], [descripcion], [tarifa]) VALUES (1, N'Simple', CAST(80.00 AS Decimal(14, 2)))
INSERT [dbo].[t_TipoHabitacion] ([idTipoHabitacion], [descripcion], [tarifa]) VALUES (2, N'Doble', CAST(140.00 AS Decimal(14, 2)))
INSERT [dbo].[t_TipoHabitacion] ([idTipoHabitacion], [descripcion], [tarifa]) VALUES (3, N'Triple', CAST(200.00 AS Decimal(14, 2)))
INSERT [dbo].[t_TipoHabitacion] ([idTipoHabitacion], [descripcion], [tarifa]) VALUES (4, N'Matrimonial', CAST(210.00 AS Decimal(14, 2)))
/****** Object:  Table [dbo].[t_TipoDocumento]    Script Date: 06/10/2015 20:15:51 ******/
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
INSERT [dbo].[t_TipoDocumento] ([idTipoDocumento], [descripcion]) VALUES (1, N'DNI')
INSERT [dbo].[t_TipoDocumento] ([idTipoDocumento], [descripcion]) VALUES (2, N'Pasaporte')
INSERT [dbo].[t_TipoDocumento] ([idTipoDocumento], [descripcion]) VALUES (3, N'Carnet Extranjería')
/****** Object:  Table [dbo].[t_Servicio]    Script Date: 06/10/2015 20:15:51 ******/
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
INSERT [dbo].[t_Servicio] ([idServicio], [descripcion], [tarifa]) VALUES (1, N'Alojamiento', CAST(0.00 AS Decimal(14, 2)))
INSERT [dbo].[t_Servicio] ([idServicio], [descripcion], [tarifa]) VALUES (2, N'Lavandería', CAST(20.00 AS Decimal(14, 2)))
INSERT [dbo].[t_Servicio] ([idServicio], [descripcion], [tarifa]) VALUES (3, N'Restaurante', CAST(50.00 AS Decimal(14, 2)))
INSERT [dbo].[t_Servicio] ([idServicio], [descripcion], [tarifa]) VALUES (4, N'Frigobar', CAST(0.00 AS Decimal(14, 2)))
INSERT [dbo].[t_Servicio] ([idServicio], [descripcion], [tarifa]) VALUES (5, N'Transporte', CAST(30.00 AS Decimal(14, 2)))
/****** Object:  Table [dbo].[t_Pais]    Script Date: 06/10/2015 20:15:51 ******/
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
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (1, N'Perú')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (2, N'Estados Unidos')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (3, N'España')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (4, N'Brasil')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (5, N'Alemania')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (6, N'Francia')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (7, N'Chile')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (8, N'Argentina')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (9, N'Holanda')
INSERT [dbo].[t_Pais] ([idPais], [nombrePais]) VALUES (10, N'Inglaterra')
/****** Object:  Table [dbo].[t_Configuracion]    Script Date: 06/10/2015 20:15:51 ******/
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
INSERT [dbo].[t_Configuracion] ([idConfiguracion], [claveConfig], [valorConfig]) VALUES (1, N'TMINCANCEL', N'48')
INSERT [dbo].[t_Configuracion] ([idConfiguracion], [claveConfig], [valorConfig]) VALUES (2, N'MINOCUPABI', N'0.80')
INSERT [dbo].[t_Configuracion] ([idConfiguracion], [claveConfig], [valorConfig]) VALUES (3, N'HRACHECKIN', N'15:00')
INSERT [dbo].[t_Configuracion] ([idConfiguracion], [claveConfig], [valorConfig]) VALUES (4, N'HRACHEKOUT', N'12:00')
INSERT [dbo].[t_Configuracion] ([idConfiguracion], [claveConfig], [valorConfig]) VALUES (5, N'IGV', N'0.18')
INSERT [dbo].[t_Configuracion] ([idConfiguracion], [claveConfig], [valorConfig]) VALUES (6, N'SERIECOMP', N'005')
INSERT [dbo].[t_Configuracion] ([idConfiguracion], [claveConfig], [valorConfig]) VALUES (7, N'ULTNROCOMP', N'120')
/****** Object:  Table [dbo].[t_Cliente]    Script Date: 06/10/2015 20:15:51 ******/
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
INSERT [dbo].[t_Cliente] ([idCliente], [nombre], [apellidoPaterno], [apellidoMaterno], [idTipoDocumento], [numeroDocumento], [email], [telefono], [idPais]) VALUES (1, N'Ivan', N'Baraybar', N'Delgado', 1, N'99999999', N'ibaraybard@gmail.com', N'5555555', 1)
/****** Object:  Table [dbo].[t_Habitacion]    Script Date: 06/10/2015 20:15:51 ******/
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
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (1, 1, 101, 1, N'Habitación Simple')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (2, 1, 102, 1, N'Habitación Simple')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (3, 2, 103, 1, N'Habitación Doble')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (4, 2, 104, 1, N'Habitación Doble')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (5, 2, 201, 2, N'Habitación Doble')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (6, 2, 202, 2, N'Habitación Doble')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (7, 1, 203, 2, N'Habitación Simple')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (8, 3, 204, 2, N'Habitación Triple')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (9, 2, 301, 3, N'Habitación Doble')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (10, 2, 302, 3, N'Habitación Doble')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (11, 1, 303, 3, N'Habitación Simple')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (12, 4, 304, 3, N'Habitación Matrimonial')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (13, 4, 401, 4, N'Habitación Matrimonial')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (14, 4, 402, 4, N'Habitación Matrimonial')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (15, 4, 403, 4, N'Habitación Matrimonial')
INSERT [dbo].[t_Habitacion] ([idHabitacion], [idTipoHabitacion], [numero], [piso], [descripcion]) VALUES (16, 3, 404, 4, N'Habitación Triple')
/****** Object:  Table [dbo].[t_Reserva]    Script Date: 06/10/2015 20:15:51 ******/
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
	[fechaHoraCheckin] [datetime] NULL,
	[comentarioCheckin] [varchar](250) NULL,
	[fechaHoraCheckout] [datetime] NULL,
	[comentarioCheckout] [varchar](250) NULL,
	[codFormaPago] [char](2) NOT NULL,
	[numeroTarjeta] [varchar](50) NULL,
	[titularTarjeta] [varchar](80) NULL,
	[mesExpiraTarjeta] [int] NULL,
	[anioExpiraTarjeta] [int] NULL,
	[requerimientosEsp] [varchar](250) NULL,
	[observaciones] [varchar](250) NULL,
	[estadoCuenta] [bit] NOT NULL,
	[estado] [smallint] NOT NULL,
 CONSTRAINT [PK_t_Reserva] PRIMARY KEY CLUSTERED 
(
	[idReserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[t_Reserva] ([idReserva], [idCliente], [idHabitacion], [fechaLlegada], [fechaSalida], [fechaHoraCheckin], [comentarioCheckin], [fechaHoraCheckout], [comentarioCheckout], [codFormaPago], [numeroTarjeta], [titularTarjeta], [mesExpiraTarjeta], [anioExpiraTarjeta], [requerimientosEsp], [observaciones], [estadoCuenta], [estado]) VALUES (1, 1, 1, CAST(0x000066B6005737BC AS DateTime), CAST(0x000066B6005737BC AS DateTime), CAST(0x000066B6005737BC AS DateTime), N'CheckIn sin problemas', CAST(0x0000A4AB0177189C AS DateTime), N'CheckOut sin problemas', N'EF', N'2312312', N'asdasdas', 8, 2015, N'Sin requerimientos', N'', 1, 3)
/****** Object:  Table [dbo].[t_Pasajero]    Script Date: 06/10/2015 20:15:51 ******/
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
/****** Object:  Table [dbo].[t_Cuenta]    Script Date: 06/10/2015 20:15:51 ******/
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
/****** Object:  Table [dbo].[t_Comprobante]    Script Date: 06/10/2015 20:15:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Comprobante](
	[idComprobante] [int] NOT NULL,
	[idReserva] [int] NOT NULL,
	[serie] [varchar](5) NOT NULL,
	[numero] [varchar](7) NOT NULL,
	[fechaEmision] [datetime] NOT NULL,
	[importe] [decimal](18, 2) NOT NULL,
	[igv] [decimal](6, 2) NOT NULL,
	[importeIgv] [decimal](18, 2) NOT NULL,
	[importeTotal] [decimal](18, 2) NOT NULL,
	[estado] [smallint] NOT NULL,
 CONSTRAINT [PK_t_Comprobante] PRIMARY KEY CLUSTERED 
(
	[idComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_t_Cliente_t_Pais]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_t_Cliente_t_Pais] FOREIGN KEY([idPais])
REFERENCES [dbo].[t_Pais] ([idPais])
GO
ALTER TABLE [dbo].[t_Cliente] CHECK CONSTRAINT [FK_t_Cliente_t_Pais]
GO
/****** Object:  ForeignKey [FK_t_Cliente_t_TipoDocumento]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Cliente]  WITH CHECK ADD  CONSTRAINT [FK_t_Cliente_t_TipoDocumento] FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[t_TipoDocumento] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[t_Cliente] CHECK CONSTRAINT [FK_t_Cliente_t_TipoDocumento]
GO
/****** Object:  ForeignKey [FK_t_Comprobante_t_Reserva]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Comprobante]  WITH CHECK ADD  CONSTRAINT [FK_t_Comprobante_t_Reserva] FOREIGN KEY([idReserva])
REFERENCES [dbo].[t_Reserva] ([idReserva])
GO
ALTER TABLE [dbo].[t_Comprobante] CHECK CONSTRAINT [FK_t_Comprobante_t_Reserva]
GO
/****** Object:  ForeignKey [FK_t_Cuenta_t_Reserva]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_t_Cuenta_t_Reserva] FOREIGN KEY([idReserva])
REFERENCES [dbo].[t_Reserva] ([idReserva])
GO
ALTER TABLE [dbo].[t_Cuenta] CHECK CONSTRAINT [FK_t_Cuenta_t_Reserva]
GO
/****** Object:  ForeignKey [FK_t_Cuenta_t_Servicio]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Cuenta]  WITH CHECK ADD  CONSTRAINT [FK_t_Cuenta_t_Servicio] FOREIGN KEY([idServicio])
REFERENCES [dbo].[t_Servicio] ([idServicio])
GO
ALTER TABLE [dbo].[t_Cuenta] CHECK CONSTRAINT [FK_t_Cuenta_t_Servicio]
GO
/****** Object:  ForeignKey [FK_t_Habitacion_t_TipoHabitacion]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_t_Habitacion_t_TipoHabitacion] FOREIGN KEY([idTipoHabitacion])
REFERENCES [dbo].[t_TipoHabitacion] ([idTipoHabitacion])
GO
ALTER TABLE [dbo].[t_Habitacion] CHECK CONSTRAINT [FK_t_Habitacion_t_TipoHabitacion]
GO
/****** Object:  ForeignKey [FK_t_Pasajero_t_Reserva]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Pasajero]  WITH CHECK ADD  CONSTRAINT [FK_t_Pasajero_t_Reserva] FOREIGN KEY([idReserva])
REFERENCES [dbo].[t_Reserva] ([idReserva])
GO
ALTER TABLE [dbo].[t_Pasajero] CHECK CONSTRAINT [FK_t_Pasajero_t_Reserva]
GO
/****** Object:  ForeignKey [FK_t_Reserva_t_Cliente]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_t_Reserva_t_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[t_Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[t_Reserva] CHECK CONSTRAINT [FK_t_Reserva_t_Cliente]
GO
/****** Object:  ForeignKey [FK_t_Reserva_t_Habitacion]    Script Date: 06/10/2015 20:15:51 ******/
ALTER TABLE [dbo].[t_Reserva]  WITH CHECK ADD  CONSTRAINT [FK_t_Reserva_t_Habitacion] FOREIGN KEY([idHabitacion])
REFERENCES [dbo].[t_Habitacion] ([idHabitacion])
GO
ALTER TABLE [dbo].[t_Reserva] CHECK CONSTRAINT [FK_t_Reserva_t_Habitacion]
GO
