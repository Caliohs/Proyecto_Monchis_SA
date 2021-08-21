CREATE PROCEDURE dbo.PedidoClienteInsertar
   
	@Cliente varchar(250),
	@Estado BIT,
	 @PedidoId INT
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	update PedidosPorCliente set Cliente=@Cliente, Estado=@Estado
	where PedidoId=@PedidoId

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
