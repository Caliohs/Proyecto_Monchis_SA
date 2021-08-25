CREATE PROCEDURE dbo.EntregaInsertar
	@PedidoId INT,
    @CamionId INT,
	@ProvinciaId INT,
	@CantonId INT,	
	@DistritoId INT,
	@FechaEntrega date,
	@Estado bit
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		IF NOT EXISTS(
		SELECT * FROM dbo.Entregas WHERE CamionId=@CamionId AND FechaEntrega=@FechaEntrega
	 
		)
		BEGIN
			INSERT INTO Entregas
			VALUES
			(
			@PedidoId,
			@CamionId ,
			@ProvinciaId,
			@CantonId,	
			@DistritoId ,
			@FechaEntrega ,
			@Estado 
			)

			update PedidosPorCliente set Estado= 1 where PedidoId=@PedidoId

				SELECT 0 AS CodeError, '' AS MsgError
		END
		ELSE BEGIN
			SELECT -3 AS CodeError, 'Camion y chofer ya reservados para esta fecha' AS MsgError
		END
	
	
			COMMIT TRANSACTION TRASA
		


	END TRY
	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END
