CREATE PROCEDURE dbo.MarcaCamionLista

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		MarcaCamionId,
		Descripcion

		FROM	
			MarcaCamion

			WHERE
					Estado=1 --solo los estados true 






	END