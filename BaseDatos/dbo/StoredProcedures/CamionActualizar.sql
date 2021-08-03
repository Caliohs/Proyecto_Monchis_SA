CREATE PROCEDURE dbo.CamionActualizar
	@CamionId INT, @MarcaCamionId INT, @ConductorId INT,
	@Matricula varchar(250)	,
	@Color varchar(250)	,
	@FechaModelo DATE,
	@Estado BIT
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE CatalogoCamiones SET
	 MarcaCamionId=@MarcaCamionId,
	 ConductorId=@ConductorId,
	 Matricula=@Matricula,
	 Color=@Color,
	 FechaModelo=@FechaModelo,
	 Estado=@Estado

	WHERE CamionId=@CamionId

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
