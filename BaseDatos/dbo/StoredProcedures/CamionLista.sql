CREATE PROCEDURE dbo.CamionLista

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		CamionId,
		Matricula

		FROM	
			CatalogoCamiones

			WHERE
					Estado=1 --solo los estados true 



	END