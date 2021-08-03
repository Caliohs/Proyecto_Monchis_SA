CREATE TABLE dbo.PedidosPorCliente
(
	PedidoId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_PedidosPorCliente PRIMARY KEY CLUSTERED(PedidoId)
	, PedidoPorProductoId INT NOT NULL CONSTRAINT FK_PedidosPorCliente_PorProductos FOREIGN KEY(PedidoPorProductoId) REFERENCES dbo.PedidosPorProducto(PedidoPorProductoId)
	, ClientesId INT NOT NULL CONSTRAINT FK_PedidosPorCliente_Clientes FOREIGN KEY(ClientesId) REFERENCES dbo.Clientes(ClientesId)
  , NombreCliente VARCHAR(250) NOT NULL
  , FechaPedido DATE NOT NULL CONSTRAINT FK_Pedidos_FechaPedido default('2020-01-01')
  , [Subtotal] FLOAT NOT NULL
  , [IVA] FLOAT NOT NULL
  , [Total] FLOAT NOT NULL
  , Enviado BIT NOT NULL
  , Estado BIT NOT NULL

)
WITH (DATA_COMPRESSION=PAGE)
GO