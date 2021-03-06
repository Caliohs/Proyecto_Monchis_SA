CREATE PROCEDURE [dbo].[CategoriaActualizar]
@CategoriaId INT,
@Descripcion VARCHAR(250),
@Estado BIT

AS
  BEGIN 
  SET NOCOUNT ON

    BEGIN TRANSACTION TRASA

    BEGIN TRY

       UPDATE Categorias
       SET
       Descripcion=@Descripcion,
       Estado=@Estado
       WHERE 
           CategoriaId=@CategoriaId

       COMMIT TRANSACTION TRASA

          SELECT 0 AS CodeError, '' AS MsgError
    END TRY

    BEGIN CATCH
          SELECT 
                 ERROR_NUMBER() AS CodeError, 
                 ERROR_MESSAGE() AS MsgError
           ROLLBACK TRANSACTION TRASA    
    END CATCH

  END
