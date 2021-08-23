CREATE PROCEDURE [dbo].PedidoObtenerDetalle
@PedidoId INT=NULL 


AS BEGIN
	SET NOCOUNT ON

	SELECT 
			PP.PedidoId, PP.PedidoPorProductoId, PP.ProductoId , PP.Cantidad,PP.Acumulado,PO.ProductoId ,PO.Producto,PO.Precio
	FROM PedidosPorProducto PP
		  INNER JOIN Productos PO
         ON PO.ProductoId = PP.ProductoId
	WHERE
	     (@PedidoId IS NULL OR PP.PedidoId=@PedidoId)

END