--*******************************************************************
-- Author:		Agustín Barona
-- Create date: 2016-10-09
-- Description: Data definition for store procedures
--*******************************************************************
USE [INT_BASE]
GO
--*******************************************************************

/****** Object:  StoredProcedure [INT].[LoadDeviceData]    Script Date: 10/10/2016 1:24:01 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Agustín Barona
-- Create date: 2016-10-09
-- Description:	Store the enrollments into the 
--               transactional table
-- =============================================
CREATE PROCEDURE [INT].[LoadDeviceData]
	@Server					AS NVARCHAR(50),
	@IpAddress				AS NVARCHAR(20),
	@EnrollmentNumber		AS NVARCHAR(50),
	@RegisterDate			AS DATETIME
AS
DECLARE
	@Sensor					AS NVARCHAR(10),
	@DB						AS NVARCHAR(100),
	@SQL					AS NVARCHAR(MAX)
BEGIN

	SET NOCOUNT OFF;

	SET @DB = @Server + '.' + '[TWA].[Tbl_CheckInOut]'

	SELECT TOP 1 @Sensor = [IdSensor] FROM [TWA].[Tbl_DetalleMaquinaOnLine] WHERE [NumeroMaquina] = (SELECT [NumeroMaquina] FROM [TWA].[Tbl_MaquinaOnLine] WHERE [DireccionIP] = @IpAddress)

	SET @SQL =	'INSERT INTO ' + @DB + ' ([IdUsuario], '		
									 +   '[IpMaquina], '		
									 +	 '[FechaRegistro], '
								     +	 '[IdSensor]) '
						+ 'VALUES '  +				 
									 +  '(''' + @EnrollmentNumber + ''', '''
									 +    ''  + @IpAddress + ''', '''
									 +     CONVERT(VARCHAR(20), @RegisterDate) + ''', '''
									 +    ''  + @Sensor + ''')'


	EXEC sp_executesql @SQL;
	
END