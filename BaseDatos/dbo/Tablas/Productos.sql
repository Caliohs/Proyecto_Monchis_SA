CREATE TABLE [dbo].[Productos]
(
	[ProductoId] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Productos PRIMARY KEY CLUSTERED([ProductoId])
  , [CategoriaId] INT NOT NULL CONSTRAINT FK_Productos_Categorias FOREIGN KEY([CategoriaId])
    REFERENCES dbo.Categorias(CategoriaId)
  , [Producto] VARCHAR(250) NOT NULL
  , Color 	VARCHAR(250) NOT NULL
  , [Material] VARCHAR(250) NOT NULL
  ,[Cantidad_Disponible] INT NOT NULL
  ,[Precio] INT NOT NULL
  , Estado BIT NOT NULL

)

WITH (DATA_COMPRESSION = PAGE)
GO


