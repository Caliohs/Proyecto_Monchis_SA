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
		 INNER JOIN CatalogoProvincia CP
		 ON E.ProvinciaId=CP.IdCatalogoProvincia
		 INNER JOIN CatalogoCanton CC
		 ON E.CantonId=CC.IdCatalogoCanton
		 INNER JOIN CatalogoDistrito CD
		 ON E.DistritoId=CD.IdCatalogoDistrito
		WHERE @EntregaId is null or EntregaId= @EntregaId

END