CREATE PROCEDURE [dbo].CamionObtener
@CamionId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
			CC.CamionId
		,   CC.Matricula
		,   CC.Color
		,   CC.FechaModelo
		,   CC.Estado
		,   MC.MarcaCamionId
		,	MC.Descripcion
		,	C.ConductorId
		,	C.CedulaConductor
		,	C.NombreCompleto
				

	FROM CatalogoCamiones CC
	 INNER JOIN MarcaCamion MC --InnerJoin porque la relación va ser obligatoria, porque hay presencia de llave foranea
         ON MC.MarcaCamionId = CC.MarcaCamionId
	INNER JOIN Conductores C
		ON C.ConductorId= CC.ConductorId
	WHERE
	     (@CamionId IS NULL OR CamionId=@CamionId)

END