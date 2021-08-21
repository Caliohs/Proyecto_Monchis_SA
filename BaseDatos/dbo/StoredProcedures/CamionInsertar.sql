CREATE PROCEDURE dbo.CamionInsertar
    @MarcaCamion varchar(250),
	@Conductor varchar(250),
	@Matricula varchar(250)	,
	@Color varchar(250)	,
	@FechaModelo DATE,
	@Estado BIT
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
		INSERT INTO CatalogoCamiones VALUES
		(
		 @MarcaCamion
		, @Conductor
	    , @Matricula 
	    , @Color   
		, @FechaModelo
		, @Estado 
		)

		--ACTUALIZO LOS ESTADOS PARA QUE YA NO ESTEN DISPONIBLES PARA LA LISTA
		UPDATE Conductores SET Estado=0 WHERE NombreCompleto= @Conductor
		UPDATE MarcaCamion SET Estado=0 WHERE Descripcion= @MarcaCamion

		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END