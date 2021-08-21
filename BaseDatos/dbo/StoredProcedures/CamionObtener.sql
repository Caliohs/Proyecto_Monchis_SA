CREATE PROCEDURE [dbo].CamionObtener
@CamionId INT=NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT
		*
				
	FROM CatalogoCamiones
	
	WHERE
	     (@CamionId IS NULL OR CamionId=@CamionId)

END