﻿CREATE TABLE dbo.PedidosPorCliente
(
	PedidoId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_PedidosPorCliente PRIMARY KEY CLUSTERED(PedidoId)
	, [Cliente] VARCHAR(50) NULL
  , FechaPedido DATE NOT NULL CONSTRAINT FK_Pedidos_FechaPedido default(GETDATE())
  , [Subtotal] VARCHAR(50) NOT NULL
   , [IVA] VARCHAR(50) NOT NULL
  , [Total] VARCHAR(50) NOT NULL
  , Estado BIT NULL

)
WITH (DATA_COMPRESSION=PAGE)
GO