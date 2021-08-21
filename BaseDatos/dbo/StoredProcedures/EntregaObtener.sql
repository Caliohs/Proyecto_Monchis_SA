CREATE PROCEDURE [dbo].EntregaObtener
@EntregaId int=null

AS BEGIN
	SET NOCOUNT ON

	SELECT 
			*
	FROM Entregas E
		  INNER JOIN PedidosPorCliente P
         ON P.PedidoId = E.PedidoId
		 INNER JOIN CatalogoCamiones C
		 ON E.CamionId=C.CamionId
		WHERE @EntregaId is null or EntregaId= @EntregaId

END