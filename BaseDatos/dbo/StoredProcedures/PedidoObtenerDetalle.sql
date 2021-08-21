CREATE PROCEDURE [dbo].PedidoObtenerDetalle
@Id INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT --*
			PP.ProductoId , PP.Cantidad,PP.Acumulado,PO.ProductoId ,PO.Producto,PO.Precio
	FROM PedidosPorProducto PP
		  INNER JOIN Productos PO
         ON PO.ProductoId = PP.ProductoId
	WHERE
	     (@Id IS NULL OR PedidoId=@Id)

END