CREATE PROCEDURE [dbo].ProductoObtener
@ProductoId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			P.ProductoId
		,   P.Color
		,   P.Material
		,   P.Cantidad_Disponible
		,   P.Precio
		,	P.Estado
		,   C.CategoriaId
		,	C.Descripcion
				

	FROM dbo.Productos P
	 INNER JOIN dbo.Categorias	C
         ON P.ProductoId = C.CategoriaId
	WHERE
	     (@ProductoId IS NULL OR ProductoId=@ProductoId)

END