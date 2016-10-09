--*******************************************************************
-- Author:		Agustín Barona
-- Create date: 2016-10-09
-- Description: Data definition for tables
--*******************************************************************
--*******************************************************************
USE [INT_BASE]
GO
--*******************************************************************
--INT SCHEMA
--*******************************************************************
--MACHINE TABLE 
--*******************************************************************
CREATE TABLE [INT].[Device](
	[Id] 					[int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IpAddress]				[nvarchar](20) 		NOT NULL,
	[BackupDatabase] 		[nvarchar](150) 	NULL,
	[RegisterDate] 			[datetime] 			NULL)
GO

ALTER TABLE [INT].[Device] ADD  CONSTRAINT [DF_Device_Register_Date]  DEFAULT (getdate()) FOR [RegisterDate]
GO

--*******************************************************************
USE [INT_BASE_COPY_1]
GO
--*******************************************************************
--INT SCHEMA
--*******************************************************************
--MACHINE TABLE 
--*******************************************************************
CREATE TABLE [INT].[Device](
	[Id] 					[int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IpAddress]				[nvarchar](20) 		NOT NULL,
	[BackupDatabase] 		[nvarchar](150) 	NULL,
	[RegisterDate] 			[datetime] 			NULL)
GO

ALTER TABLE [INT].[Device] ADD  CONSTRAINT [DF_Device_Register_Date]  DEFAULT (getdate()) FOR [RegisterDate]
GO

--*******************************************************************
USE [INT_BASE_COPY_2]
GO
--*******************************************************************
--INT SCHEMA
--*******************************************************************
--MACHINE TABLE 
--*******************************************************************
CREATE TABLE [INT].[Device](
	[Id] 					[int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IpAddress]				[nvarchar](20) 		NOT NULL,
	[BackupDatabase] 		[nvarchar](150) 	NULL,
	[RegisterDate] 			[datetime] 			NULL)
GO

ALTER TABLE [INT].[Device] ADD  CONSTRAINT [DF_Device_Register_Date]  DEFAULT (getdate()) FOR [RegisterDate]
GO