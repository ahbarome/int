--*******************************************************************
-- Author:		Agustín Barona
-- Create date: 2016-10-09
-- Description: Data manipulation
--*******************************************************************

/******* INSERTAR REGISTROS *******/
INSERT INTO [TWA].[Tbl_MaquinaOnLine] (NumeroMaquina, DireccionIP)
SELECT 1, '172.145.0.16' UNION
SELECT 2, '172.145.0.21' UNION
SELECT 3, '172.145.0.53' UNION
SELECT 4, '172.145.0.54'
--*******************************************************************
INSERT INTO [TWA].[Tbl_SincronizacionMaquinaOnLine] (NumeroMaquina, RutaServidorDBDescarga)
SELECT 1, '[DESKTOP-PAQP1DV].[INT_BASE]' UNION
SELECT 1, '[DESKTOP-PAQP1DV].[INT_BASE_COPY_1]' UNION
SELECT 1, '[DESKTOP-PAQP1DV].[INT_BASE_COPY_2]' UNION
SELECT 2, '[DESKTOP-PAQP1DV].[INT_BASE]'  UNION
SELECT 3, '[DESKTOP-PAQP1DV].[INT_BASE_COPY_1]' UNION
SELECT 4, '[DESKTOP-PAQP1DV].[INT_BASE_COPY_2]'
--*******************************************************************
INSERT INTO [TWA].[Tbl_SensorMaquinaOnline] (Nombre)
SELECT 'TEST_1' UNION
SELECT 'TEST_2' UNION
SELECT 'TEST_3'
--*******************************************************************
INSERT INTO [TWA].[Tbl_DetalleMaquinaOnline] (NumeroMaquina, IdSensor)
SELECT 1, 1 UNION
SELECT 2, 1 UNION
SELECT 3, 2 UNION
SELECT 4, 3 
--*******************************************************************