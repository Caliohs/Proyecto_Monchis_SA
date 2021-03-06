CREATE TABLE dbo.Entregas
(
	EntregaId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Entregas PRIMARY KEY CLUSTERED(EntregaId)
	, PedidoId INT NOT NULL CONSTRAINT FK_PedidosPorCliente_Entregas FOREIGN KEY(PedidoId) REFERENCES dbo.PedidosPorCliente(PedidoId)
	, CamionId INT NOT NULL CONSTRAINT FK_Camiones_Entregas FOREIGN KEY(CamionId) REFERENCES dbo.CatalogoCamiones(CamionId)
	, [ProvinciaId] INT NOT NULL CONSTRAINT FK_Provincia_Entregas FOREIGN KEY(ProvinciaId) REFERENCES dbo.CatalogoProvincia(IdCatalogoProvincia)
    , [CantonId] INT NOT NULL CONSTRAINT FK_Canton_Entregas FOREIGN KEY(CantonId) REFERENCES dbo.CatalogoCanton(IdCatalogoCanton)
    , [DistritoId] INT NOT NULL CONSTRAINT FK_Distrito_Entregas FOREIGN KEY(DistritoId) REFERENCES dbo.CatalogoDistrito(IdCatalogoDistrito)
  , FechaEntrega DATE NOT NULL CONSTRAINT FK_Entregas_FechaEntrega default('2020-01-01') 
  , Estado BIT NOT NULL
)
WITH (DATA_COMPRESSION=PAGE)
GO