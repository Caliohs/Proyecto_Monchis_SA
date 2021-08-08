CREATE PROCEDURE dbo.ProductoInsertar
    @CategoriaId  INT,
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

		
		INSERT INTO dbo.Productos 
		(
			 CategoriaId
			, Producto 
			, Color
			, Material
			, Cantidad_Disponible 
			, Precio
			, Estado
		)
		VALUES
		(
			@CategoriaId
			, @Producto 
			, @Color
			, @Material
			, @Cantidad_Disponible 
			, @Precio
			, @Estado
		)


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
