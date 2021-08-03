﻿CREATE TABLE dbo.CatalogoCamiones
(
	CamionId INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Camiones PRIMARY KEY CLUSTERED(CamionId)
	, MarcaCamionId INT NOT NULL CONSTRAINT FK_Camiones_MarcaCamion FOREIGN KEY(MarcaCamionId) REFERENCES dbo.MarcaCamion(MarcaCamionId)
	, ConductorId INT NOT NULL CONSTRAINT FK_Conductor_Camion FOREIGN KEY(ConductorId) REFERENCES dbo.Conductores(ConductorId)
  , Matricula VARCHAR(250) NOT NULL
  , Color VARCHAR(250) NOT NULL
  , FechaModelo DATE NOT NULL CONSTRAINT DF_Vehiculo_FechaModelo default('2020-01-01')
  , Estado BIT NOT NULL
)
WITH (DATA_COMPRESSION=PAGE)
GO

CREATE UNIQUE NONCLUSTERED INDEX IDX_Camion_Matricula
ON dbo.CatalogoCamiones(Matricula)
WITH (DATA_COMPRESSION=PAGE)
GO