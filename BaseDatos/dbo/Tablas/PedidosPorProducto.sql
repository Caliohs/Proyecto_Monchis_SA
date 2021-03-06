CREATE TABLE dbo.PedidosPorProducto
(
	PedidoPorProductoId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_PedidosPorProducto PRIMARY KEY CLUSTERED(PedidoPorProductoId)
  , ProductoId INT NOT NULL CONSTRAINT FK_Productos_PedidoPorProductos FOREIGN KEY(ProductoId) REFERENCES dbo.Productos(ProductoId)
  , PedidoId INT NOT NULL CONSTRAINT FK_PedidosPorCliente_PedidoPorProductos FOREIGN KEY(PedidoId) REFERENCES dbo.PedidosPorCliente(PedidoId)
  , [Cantidad] VARCHAR(50) NOT NULL
  , [Acumulado] VARCHAR(50) NOT NULL
 
)
WITH (DATA_COMPRESSION=PAGE)
GO