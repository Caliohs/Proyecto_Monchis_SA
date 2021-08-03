CREATE PROCEDURE [dbo].[ConductorObtener]
	@ConductorId INT = NULL
	
AS
	BEGIN
	SET NOCOUNT ON --set nocount es para que no haga el conteo y la consulta sea mas eficiente

	SELECT @ConductorId,NombreCompleto,Telefono,Edad,Estado FROM Conductores
	WHERE(@ConductorId IS NULL OR ConductorId = @ConductorId)
	END

