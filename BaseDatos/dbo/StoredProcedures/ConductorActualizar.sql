CREATE PROCEDURE [dbo].[ConductorActualizar]
 @ConductorId INT, @NombreCompleto VARCHAR(250), @Telefono VARCHAR(250),@Edad INT,@Estado BIT

	AS
	BEGIN
		SET NOCOUNT ON
		BEGIN TRANSACTION TRASA 
		
		BEGIN TRY

		--METODO
		UPDATE Conductores SET NombreCompleto = @NombreCompleto, Telefono=@Telefono, Estado = @Estado, @Edad=Edad
		WHERE ConductorId = @ConductorId
		

		COMMIT TRANSACTION TRASA@CedulaConductor

		SELECT 0 AS CodeError, '' AS MsgError --MSGerror en texto por eso las comillas

		END TRY

		BEGIN CATCH
		
		SELECT ERROR_NUMBER() AS CodeError, ERROR_MESSAGE() AS MsgError

		ROLLBACK TRANSACTION TRASA --CTLZ, DESHACE TODO

		END CATCH

	
	END
