﻿CREATE PROCEDURE dbo.InicializarPedido
  
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		
		INSERT INTO dbo.PedidosPorCliente
		VALUES(' ', getdate(),0,0,0,1)
	    
		select top 1 PedidoId from PedidosPorCliente order by PedidoId desc

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