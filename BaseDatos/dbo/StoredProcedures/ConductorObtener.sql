CREATE PROCEDURE [dbo].[ConductorObtener]
	@ConductorId INT=null
	
AS
	BEGIN
	SET NOCOUNT ON --set nocount es para que no haga el conteo y la consulta sea mas eficiente

	SELECT ConductorId,CedulaConductor,NombreCompleto,Telefono,Edad,Estado FROM Conductores
	WHERE(@ConductorId IS NULL OR ConductorId = @ConductorId)
	END

