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
SELECT		[MON].[DireccionIP]			    AS [FromIpAddress], 
			[SMO].[RutaServidorDBDescarga]	AS [ToDataBase]
            
FROM        [TWA].[Tbl_MaquinaOnLine]				[MON] WITH(NOLOCK)
INNER JOIN	[TWA].[Tbl_SincronizacionMaquinaOnLine]	[SMO] WITH(NOLOCK) ON [MON].[NumeroMaquina] = [SMO].[NumeroMaquina]