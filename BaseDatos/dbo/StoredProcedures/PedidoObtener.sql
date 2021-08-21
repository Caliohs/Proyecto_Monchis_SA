CREATE PROCEDURE [dbo].PedidoObtener
@PedidoId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT PedidoId,Cliente,FechaPedido,Subtotal,IVA,Total
		
	FROM dbo.PedidosPorCliente P
	
	WHERE
	     (@PedidoId IS NULL OR PedidoId=@PedidoId)
 
END