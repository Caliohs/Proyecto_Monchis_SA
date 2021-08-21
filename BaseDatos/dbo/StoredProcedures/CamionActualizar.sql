CREATE PROCEDURE dbo.CamionActualizar
	@CamionId INT,
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
		
	UPDATE CatalogoCamiones SET
	 MarcaCamion=@MarcaCamion,
	 Conductor=@Conductor,
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
