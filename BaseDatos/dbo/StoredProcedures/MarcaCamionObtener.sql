CREATE PROCEDURE [dbo].[MarcaCamionObtener]
	@MarcaCamionId INT = NULL
	
AS
	BEGIN
	SET NOCOUNT ON --set nocount es para que no haga el conteo y la consulta sea mas eficiente

	SELECT MarcaCamionId, Descripcion, Estado FROM MarcaCamion
	WHERE(@MarcaCamionId IS NULL OR MarcaCamionId = @MarcaCamionId)
	END

