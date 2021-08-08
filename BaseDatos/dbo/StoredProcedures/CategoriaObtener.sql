CREATE PROCEDURE [dbo].[CategoriaObtener]
	@CategoriaId INT=NULL
AS
BEGIN
  SET NOCOUNT ON

SELECT 
      CategoriaId
	, Descripcion
	, Estado
FROM Categorias
WHERE (@CategoriaId IS NULL OR CategoriaId=@CategoriaId)

END


