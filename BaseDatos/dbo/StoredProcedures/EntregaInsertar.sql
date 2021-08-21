CREATE PROCEDURE dbo.EntregaInsertar
	@PedidoId INT,
    @CamionId INT,
	@Provincia varchar(250),
	@Canton varchar(250),	
	@Distrito varchar(250),
	@FechaEntrega date,
	@Estado bit
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		INSERT INTO Entregas
		VALUES
		(
		@PedidoId,
		@CamionId ,
		@Provincia,
		@Canton,	
		@Distrito ,
		@FechaEntrega ,
		@Estado 
		)	

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
