DECLARE @MarcaId INT
DECLARE @NivelMaximoClasificacion INT
DECLARE @i INT
DECLARE @stmt NVARCHAR(MAX)
DECLARE @FieldName NVARCHAR(MAX)
DECLARE @Nombre NVARCHAR(MAX)
DECLARE cMarcas CURSOR 
FOR
	SELECT MarcaId, NivelMaximoClasificacion FROM Marcas
OPEN cMarcas
FETCH cMarcas INTO @MarcaId, @NivelMaximoClasificacion
WHILE (@@FETCH_STATUS = 0)
BEGIN	
	--PRINT 'MarcaId: ' + CAST(@MarcaId AS NVARCHAR) + ' NivelMaximoClasificacion: ' + CAST(@NivelMaximoClasificacion AS NVARCHAR)
	SET @i = 1
	WHILE(@i <= @NivelMaximoClasificacion)
	BEGIN
		SET @FieldName = 'Nivel' + CAST(@i AS NVARCHAR) + 'Descripcion'
		SET @stmt = 'IF (SELECT ' + @FieldName + ' FROM NivelesClasificacionMarcaDescripcion WHERE MarcaId = ' + CAST(@MarcaId AS NVARCHAR) + ') IS NULL' + CHAR(13)
		SET @stmt = @stmt + 'BEGIN' + CHAR(13)
		SET @stmt = @stmt + '	UPDATE NivelesClasificacionMarcaDescripcion SET ' + @FieldName + ' = ''Classification Level ' + CAST(@i AS NVARCHAR) + ''' WHERE MarcaId = ' + CAST(@MarcaId AS NVARCHAR) + CHAR(13)
		SET @stmt = @stmt + 'END' + CHAR(13)
		PRINT @stmt
		SET @i = @i + 1
	END
	FETCH cMarcas INTO @MarcaId, @NivelMaximoClasificacion
END
CLOSE cMarcas
DEALLOCATE cMarcas

PRINT '-- REGISTROS NUEVOS'

DECLARE cMarcas CURSOR
FOR
	SELECT MarcaId, NivelMaximoClasificacion FROM Marcas WHERE MarcaId NOT IN (SELECT MarcaId FROM NivelesClasificacionMarcaDescripcion)
OPEN cMarcas
FETCH cMarcas INTO @MarcaId, @NivelMaximoClasificacion
WHILE (@@FETCH_STATUS = 0)
BEGIN	
	--PRINT 'MarcaId: ' + CAST(@MarcaId AS NVARCHAR) + ' NivelMaximoClasificacion: ' + CAST(@NivelMaximoClasificacion AS NVARCHAR)
	SET @stmt = 'INSERT INTO NivelesClasificacionMarcaDescripcion (MarcaId) VALUES (' + CAST(@MarcaId AS NVARCHAR) + ')'
	PRINT @stmt
	SET @i = 1
	WHILE(@i <= @NivelMaximoClasificacion)
	BEGIN
		SET @FieldName = 'Nivel' + CAST(@i AS NVARCHAR) + 'Descripcion'		
		SET @stmt = 'UPDATE NivelesClasificacionMarcaDescripcion SET ' + @FieldName + ' = ''Classification Level ' + CAST(@i AS NVARCHAR) + ''' WHERE MarcaId = ' + CAST(@MarcaId AS NVARCHAR) + CHAR(13)
		PRINT @stmt
		SET @i = @i + 1
	END
	FETCH cMarcas INTO @MarcaId, @NivelMaximoClasificacion
END
CLOSE cMarcas
DEALLOCATE cMarcas

DECLARE cMarcas CURSOR 
FOR
	SELECT MarcaId, Nombre FROM Marcas
OPEN cMarcas
FETCH cMarcas INTO @MarcaId, @Nombre
WHILE (@@FETCH_STATUS = 0)
BEGIN	
	PRINT 'MarcaId: ' + CAST(@MarcaId AS NVARCHAR) + ' - ' + CAST(@Nombre AS NVARCHAR)
	SET @i = (SELECT COUNT(*) FROM NivelesClasificacionMarcaParaCoberturaExposicion WHERE MarcaId = @MarcaId);
	IF(@i=0)
	BEGIN
		INSERT INTO [dbo].[NivelesClasificacionMarcaParaCoberturaExposicion] ([Nivel1Seleccionado],[Nivel2Seleccionado],[Nivel3Seleccionado],[Nivel4Seleccionado],[Nivel5Seleccionado],[Nivel6Seleccionado],[Nivel7Seleccionado],[Nivel8Seleccionado],[Nivel9Seleccionado],[Nivel10Seleccionado],[MarcaId])
		VALUES (0, 0, 0, 0, 0, 0, 0, 0, 0, 0, @MarcaId)
	END

	SET @i = (SELECT COUNT(*) FROM NivelesClasificacionMarcaParaIntroduccionNovedad WHERE MarcaId = @MarcaId);
	IF(@i=0)
	BEGIN
		INSERT INTO [dbo].[NivelesClasificacionMarcaParaIntroduccionNovedad] ([Nivel1Seleccionado],[Nivel2Seleccionado],[Nivel3Seleccionado],[Nivel4Seleccionado],[Nivel5Seleccionado],[Nivel6Seleccionado],[Nivel7Seleccionado],[Nivel8Seleccionado],[Nivel9Seleccionado],[Nivel10Seleccionado],[MarcaId])
		VALUES (0, 0, 0, 0, 0, 0, 0, 0, 0, 0, @MarcaId)
	END

		SET @i = (SELECT COUNT(*) FROM NivelesClasificacionMarcaParaTema WHERE MarcaId = @MarcaId);
	IF(@i=0)
	BEGIN
		INSERT INTO [dbo].[NivelesClasificacionMarcaParaTema] ([Nivel1Seleccionado],[Nivel2Seleccionado],[Nivel3Seleccionado],[Nivel4Seleccionado],[Nivel5Seleccionado],[Nivel6Seleccionado],[Nivel7Seleccionado],[Nivel8Seleccionado],[Nivel9Seleccionado],[Nivel10Seleccionado],[MarcaId])
		VALUES (0, 0, 0, 0, 0, 0, 0, 0, 0, 0, @MarcaId)
	END
		
	FETCH cMarcas INTO @MarcaId, @Nombre
END
CLOSE cMarcas
DEALLOCATE cMarcas