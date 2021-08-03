CREATE TABLE [dbo].[Conductores]
(
	[ConductorId] INT IDENTITY(1,1) CONSTRAINT PK_Conductores PRIMARY KEY CLUSTERED([ConductorId])
  , [CedulaConductor] INT NOT NULL
  , [NombreCompleto] VARCHAR(250) NOT NULL 
  , [Telefono] VARCHAR(250) NOT NULL
  , [Edad] INT NOT NULL
  , Estado BIT NOT NULL
)

WITH (DATA_COMPRESSION = PAGE)
GO

