CREATE PROCEDURE [dbo].EntregaEliminar
@EntregaId int
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY

		
	DELETE FROM Dbo.Entregas WHERE EntregaId=@EntregaId


		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, 'No se puede borrar debido a que está asociada a un pedido' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END
