--*******************************************************************
-- Author:		Agustín Barona
-- Create date: 2016-10-09
-- Description: Data definition for views
--*******************************************************************
USE [INT_BASE]
GO
--*******************************************************************
CREATE VIEW [INT].[CurrentDevice]
AS
SELECT		[SMO].[Id]						AS [SyncId],
			[MON].[DireccionIP]			    AS [FromIpAddress], 
			[SMO].[RutaServidorDBDescarga]	AS [ToDataBase],
            [MON].[NombreMaquina]			AS [DeviceName],
			[MON].[TipoComunicacion]		AS [CommunicationType],
			[MON].[TipoDispositivo]			AS [DeviceType],
			[SEN].[Nombre]					AS [SensorName]
FROM        [TWA].[Tbl_MaquinaOnLine]				[MON] WITH(NOLOCK)
INNER JOIN	[TWA].[Tbl_SincronizacionMaquinaOnLine]	[SMO] WITH(NOLOCK) ON	[MON].[NumeroMaquina]	= [SMO].[NumeroMaquina]
LEFT	JOIN	[TWA].[Tbl_DetalleMaquinaOnLine]	[DMO] WITH(NOLOCK) ON   [DMO].[NumeroMaquina]	= [SMO].[NumeroMaquina]
LEFT	JOIN	[TWA].[Tbl_SensorMaquinaOnline]		[SEN] WITH(NOLOCK) ON   [SEN].[Id]				= [DMO].[IdSensor]