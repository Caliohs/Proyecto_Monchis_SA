CREATE PROCEDURE [dbo].ProductoObtener
@ProductoId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			P.ProductoId
		,   P.Producto
		,   P.Color
		,   P.Material
		,   P.Cantidad_Disponible
		,   P.Precio
		,	P.Estado
		,   C.CategoriaId
		,	C.Descripcion
				

	FROM dbo.Productos P
	 INNER JOIN dbo.Categorias	C
         ON P.CategoriaId = C.CategoriaId
	WHERE
	     (@ProductoId IS NULL OR ProductoId=@ProductoId)

END