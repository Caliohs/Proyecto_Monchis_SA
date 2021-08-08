CREATE PROCEDURE dbo.CategoriaLista

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		CategoriaId,
		Descripcion

		FROM	
			dbo.Categorias

			WHERE
					Estado=1






	END