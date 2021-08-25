CREATE PROCEDURE PedidoProductoEliminar
@PedidoPorProductoId int
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	--capturo el datos del pedido
	 declare @id int =(Select PedidoId from PedidosPorProducto where PedidoPorProductoId=@PedidoPorProductoId)
	declare @Cant int =(Select Cantidad from PedidosPorProducto where PedidoPorProductoId=@PedidoPorProductoId)
	declare @Producto int =(Select ProductoId from PedidosPorProducto where PedidoPorProductoId=@PedidoPorProductoId)
	
	--elimino el producto del pedido	
	DELETE from PedidosPorProducto where PedidoPorProductoId=@PedidoPorProductoId
	
	--recalculo y actualizo los montos restantes para el pedido

		declare @subt int = (Select  sum(Convert(int,Acumulado)) from PedidosPorProducto where PedidoId= @id )
		declare @iv int = (@subt * 0.13)
		declare @total int = (@subt + @iv)

		update PedidosPorCliente set Subtotal=@subt, IVA=@iv, Total=@total
		where PedidoId=@id

		--ACTUALIZO LA CANTIDAD DISPONIBLE
		UPDATE Productos SET Cantidad_Disponible= (Cantidad_Disponible+@Cant) WHERE ProductoId=@Producto
		
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
