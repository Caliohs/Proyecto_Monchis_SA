CREATE PROCEDURE dbo.ProductoActualizar
	@ProductoId INT,
	@CategoriaId INT,
    @Producto varchar(250)	,
	@Color varchar(250)	,
	@Material varchar(250),
	@Cantidad_Disponible INT,
	@Precio INT,
	@Estado BIT
	

AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
		
	UPDATE dbo.Productos SET
	 CategoriaId=@CategoriaId,
	 Producto=@Producto,
	 Color=@Color,
	 Material=@Material,
	 Cantidad_Disponible=@Cantidad_Disponible,
	 Precio=@Precio,
	 Estado=@Estado
	 

	WHERE ProductoId=@ProductoId

		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END

