CREATE PROCEDURE dbo.ProductoLista

AS
	BEGIN
		SET NOCOUNT ON



		SELECT 
		ProductoId,
		Producto,
		Precio,
		Cantidad_Disponible

		FROM	
			Productos

			WHERE
					Estado=1 --solo los estados true 



	END