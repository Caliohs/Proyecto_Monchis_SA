CREATE PROCEDURE dbo.ConductorLista

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		ConductorId,
		NombreCompleto

		FROM	
			Conductores

			WHERE
					Estado=1 --solo los estados true 



	END