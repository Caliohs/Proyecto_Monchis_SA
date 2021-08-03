CREATE TABLE dbo.Entregas
(
	EntregaId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Entregas PRIMARY KEY CLUSTERED(EntregaId)
	, PedidoId INT NOT NULL CONSTRAINT FK_PedidosPorCliente_Entregas FOREIGN KEY(PedidoId) REFERENCES dbo.PedidosPorCliente(PedidoId)
	, CamionId INT NOT NULL CONSTRAINT FK_Camiones_Entregas FOREIGN KEY(CamionId) REFERENCES dbo.CatalogoCamiones(CamionId)
	, IdCatalogoProvincia INT NOT NULL CONSTRAINT FK_Entregas_Provincia FOREIGN KEY(IdCatalogoProvincia) REFERENCES dbo.CatalogoProvincia(IdCatalogoProvincia)
    , IdCatalogoCanton INT NOT NULL  CONSTRAINT Fk_Entregas_Canton FOREIGN KEY(IdCatalogoCanton) REFERENCES dbo.CatalogoCanton(IdCatalogoCanton)
    , IdCatalogoDistrito INT NOT NULL CONSTRAINT Fk_Entregas_Distrito FOREIGN KEY(IdCatalogoDistrito) REFERENCES dbo.CatalogoDistrito(IdCatalogoDistrito)
  , NombreCliente VARCHAR(250) NOT NULL
  , FechaEntrega DATE NOT NULL CONSTRAINT FK_Entregas_FechaEntrega default('2020-01-01')
  , MatriculaCamion VARCHAR(250) NOT NULL
  , NombreConductor VARCHAR(250) NOT NULL
  , Estado BIT NOT NULL
)
WITH (DATA_COMPRESSION=PAGE)
GO