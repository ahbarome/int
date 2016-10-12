--*******************************************************************
-- Author:		Agustín Barona
-- Create date: 2016-10-09
-- Description: Data definition for tables
--*******************************************************************
USE [INT_BASE_COPY_2]
GO
--*******************************************************************
CREATE TABLE [INT].[Device](
	[Id]				[int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IpAddress]			[nvarchar](20)		NOT NULL,
	[BackupDatabase]	[nvarchar](150)		NULL,
	[RegisterDate]		[datetime]			NULL
)
GO
--*******************************************************************
CREATE TABLE [INT].[LoadTrace](
	[Id] [int]		IDENTITY(1,1)	PRIMARY KEY NOT NULL,
	[IpAddress]		[nvarchar](20)	NOT NULL,
	[ServerName]	[nvarchar](MAX)	NOT NULL,
	[LastLoadDate]	[datetime] NOT	NULL
)
GO
--*******************************************************************
CREATE TABLE [INT].[Scheduler](
	[JobName]			[nvarchar](100) NOT NULL,
	[TriggerName]		[nvarchar](100) NOT NULL,
	[ScheduleGroup]		[nvarchar](100) NOT NULL,
	[Second]			[nvarchar](50) NOT NULL,
	[Minute]			[nvarchar](50) NOT NULL,
	[Hour]				[nvarchar](50) NOT NULL,
	[Day]				[nvarchar](50) NOT NULL,
	PRIMARY KEY ([JobName], [TriggerName], [ScheduleGroup])
)
GO
--*******************************************************************
CREATE TABLE [INT].[LogData](
	[Id]				[int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[EnrollmentNumber]	[nvarchar](50)		NOT NULL,
	[RegisterDate]		[datetime]			NOT NULL CONSTRAINT [DF_LogData_RegisterDate]  DEFAULT (getdate())
)
GO
--*******************************************************************
CREATE TABLE [TWA].[Tbl_CheckInOut](
	[Id]				[int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdUsuario]			[int]				NOT NULL,
	[IpMaquina]			[nvarchar](16)		NOT NULL,
	[FechaRegistro]		[datetime]			NOT NULL,
	[TipoMovimiento]	[nvarchar](1)		NULL,
	[IdSensor]			[nvarchar](10)		NULL,
	[StsModificacion]	[nvarchar](1)		NULL
)
GO
--*******************************************************************
CREATE TABLE [TWA].[Tbl_MaquinaOnLine](
	[NumeroMaquina]				[int]			PRIMARY KEY NOT NULL,
	[NombreMaquina]				[nvarchar](20)	NULL,
	[TipoComunicacion]			[nvarchar](50)	NULL,
	[DireccionIP]				[nvarchar](20)	NULL,
	[Puerto]					[int]			NULL,
	[TipoDispositivo]			[nvarchar](50)	NULL,
	[RutaServidorDBDescarga]	[nvarchar](max)	NULL
)
GO
--*******************************************************************
CREATE TABLE [TWA].[Tbl_SensorMaquinaOnline](
	[Id]		[int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nombre]	[nvarchar](250)					NULL
)
GO
--*******************************************************************
CREATE TABLE [TWA].[Tbl_DetalleMaquinaOnLine](
	[Id]			[int] IDENTITY(1,1) NOT NULL,
	[NumeroMaquina] [int]				NOT NULL,
	[IdSensor]		[int]				NOT NULL,
	FOREIGN KEY([IdSensor])			REFERENCES [TWA].[Tbl_SensorMaquinaOnline] ([Id]),
	FOREIGN KEY([NumeroMaquina])	REFERENCES [TWA].[Tbl_MaquinaOnLine] ([NumeroMaquina])
) 
GO
--*******************************************************************
CREATE TABLE [TWA].[Tbl_SincronizacionMaquinaOnLine](
	[Id]						[int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[NumeroMaquina]				[int]							NOT NULL,
	[RutaServidorDBDescarga]	[nvarchar](max)					NOT NULL,
	FOREIGN KEY([NumeroMaquina]) REFERENCES [TWA].[Tbl_MaquinaOnLine] ([NumeroMaquina])
)
GO
