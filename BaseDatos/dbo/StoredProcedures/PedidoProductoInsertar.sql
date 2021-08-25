CREATE  PROCEDURE dbo.PedidoProductoInsertar
	@ProductoId INT,
    @PedidoId  INT,
	@Cantidad varchar(250)
	
	
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	--Valido si hay producto disponible ejecuto	
	
	  --IF  Convert(int,@Cantidad) < (Select Cantidad_Disponible from Productos where ProductoId=@ProductoId)
	  Begin -----------------------------------------------------------------------------
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
		--ACTUALIZO MONTOS
		update PedidosPorCliente set Subtotal=@subt, IVA=@iv, Total=@total
		where PedidoId=@PedidoId

		--ACTUALIZO LA CANTIDAD DISPONIBLE
		UPDATE Productos SET Cantidad_Disponible= (Cantidad_Disponible-Convert(int,@Cantidad)) WHERE ProductoId=@ProductoId
		
		
	  END	----------------------------------------------------------------------------------------------------
	  
	  --ELSE BEGIN

		SELECT 0 AS CodeError, 'No hay cantidad sufuciente de este producto' AS MsgError

	  --END
			 COMMIT TRANSACTION TRASA
	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END
