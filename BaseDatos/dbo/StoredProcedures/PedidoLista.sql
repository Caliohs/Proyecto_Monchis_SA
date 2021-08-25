CREATE PROCEDURE dbo.PedidoLista

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		PedidoId,
		Cliente

		FROM	
			PedidosPorCliente

			WHERE
					Estado=0 --solo los estados true 



	END