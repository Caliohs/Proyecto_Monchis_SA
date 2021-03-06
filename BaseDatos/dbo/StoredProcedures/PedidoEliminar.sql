CREATE PROCEDURE PedidoEliminar
@PedidoId int
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		
	DELETE from PedidosPorProducto where PedidoId=@PedidoId
	DELETE from PedidosPorCliente where PedidoId=@PedidoId


		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, 'No fue posible eliminar, hay una entrega asignada a este pedido' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END
