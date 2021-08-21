CREATE PROCEDURE dbo.PedidoProductoInsertar
	@ProductoId INT,
    @PedidoId  INT,
	@Cantidad varchar(250)
	
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	 declare @precio int= (select Precio from Productos where ProductoId= @ProductoId)
	declare @acum int = (@precio * @Cantidad)
		
		INSERT INTO dbo.PedidosPorProducto
		VALUES
		(
			@ProductoId,
			@PedidoId,
			@Cantidad ,
			@acum
		)

		declare @subt int = (Select  sum(Convert(int,Acumulado)) from PedidosPorProducto where PedidoId=@PedidoId)
		declare @iv int = (@subt * 0.13)
		declare @total int = (@subt + @iv)

		update PedidosPorCliente set Subtotal=@subt, IVA=@iv, Total=@total
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
