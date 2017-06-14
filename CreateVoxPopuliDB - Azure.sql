CREATE TABLE [dbo].[TipoCampania] (
    [TipoCampaniaId] INT      IDENTITY (1, 1) NOT NULL,
    [Nombre]         TEXT     DEFAULT ('') NOT NULL,
    [Fecha]          DATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_TipoCampania] PRIMARY KEY CLUSTERED ([TipoCampaniaId] ASC)
);

CREATE TABLE [dbo].[Campania] (
    [CampaniaId]     INT      IDENTITY (1, 1) NOT NULL,
    [Nombre]         TEXT     DEFAULT ('') NOT NULL,
    [Descripcion]    TEXT     DEFAULT ('') NOT NULL,
    [Estatus]        TINYINT  DEFAULT ((0)) NOT NULL,
    [TipoCampaniaId] INT      DEFAULT ((0)) NOT NULL,
    [FechaInicia]    DATETIME DEFAULT (getdate()) NOT NULL,
    [FechaFinaliza]  DATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Campania] PRIMARY KEY CLUSTERED ([CampaniaId] ASC),
    FOREIGN KEY ([TipoCampaniaId]) REFERENCES [dbo].[TipoCampania] ([TipoCampaniaId]),
    FOREIGN KEY ([TipoCampaniaId]) REFERENCES [dbo].[TipoCampania] ([TipoCampaniaId])
);

CREATE TABLE [dbo].[TipoControl] (
    [TipoControlId] INT      IDENTITY (1, 1) NOT NULL,
    [Nombre]        TEXT     DEFAULT ('') NOT NULL,
    [Fecha]         DATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_TipoControl] PRIMARY KEY CLUSTERED ([TipoControlId] ASC)
);

CREATE TABLE [dbo].[Pregunta] (
    [PreguntaId]    INT      IDENTITY (1, 1) NOT NULL,
    [Nombre]        TEXT     DEFAULT ('') NOT NULL,
    [Fecha]         DATETIME DEFAULT (getdate()) NOT NULL,
    [TipoControlId] INT      DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Pregunta] PRIMARY KEY CLUSTERED ([PreguntaId] ASC),
    FOREIGN KEY ([TipoControlId]) REFERENCES [dbo].[TipoControl] ([TipoControlId])
);

CREATE TABLE [dbo].[CampaniaDetalle] (
    [CampaniaDetalleId] INT      IDENTITY (1, 1) NOT NULL,
    [CampaniaId]        INT      NOT NULL,
    [PreguntaId]        INT      NOT NULL,
    [Fecha]             DATETIME DEFAULT (getdate()) NOT NULL,
    [Orden]             INT      DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_CampaniaDetalle] PRIMARY KEY CLUSTERED ([CampaniaDetalleId] ASC, [CampaniaId] ASC),
    FOREIGN KEY ([CampaniaId]) REFERENCES [dbo].[Campania] ([CampaniaId]),
    FOREIGN KEY ([PreguntaId]) REFERENCES [dbo].[Pregunta] ([PreguntaId])
);

CREATE TABLE [dbo].[Respuesta] (
    [RespuestaId] INT      IDENTITY (1, 1) NOT NULL,
    [Nombre]      TEXT     DEFAULT ('') NOT NULL,
    [Descripcion] TEXT     DEFAULT ('') NOT NULL,
    [Fecha]       DATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Respuesta] PRIMARY KEY CLUSTERED ([RespuestaId] ASC)
);

CREATE TABLE [dbo].[ControlPregunta] (
    [PreguntaId]  INT      NOT NULL,
    [RespuestaId] INT      DEFAULT ((0)) NOT NULL,
    [Orden]       INT      DEFAULT ((0)) NOT NULL,
    [Fecha]       DATETIME DEFAULT (getdate()) NOT NULL,
    FOREIGN KEY ([PreguntaId]) REFERENCES [dbo].[Pregunta] ([PreguntaId]),
    FOREIGN KEY ([RespuestaId]) REFERENCES [dbo].[Respuesta] ([RespuestaId]),
    CONSTRAINT [PK_ControlPregunta] PRIMARY KEY CLUSTERED ([PreguntaId] ASC, [RespuestaId] ASC)
);

CREATE TABLE [dbo].[ControlVotacion] (
    [CampaniaId] INT          NOT NULL,
    [DeviceId]   VARCHAR (50) DEFAULT ('') NOT NULL,
    [Latitud]    TEXT         DEFAULT ('') NOT NULL,
    [Longitud]   TEXT         DEFAULT ('') NOT NULL,
    [Fecha]      DATETIME     DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_ControlVotacion] PRIMARY KEY CLUSTERED ([CampaniaId] ASC, [DeviceId] ASC),
    FOREIGN KEY ([CampaniaId]) REFERENCES [dbo].[Campania] ([CampaniaId])
);

CREATE TABLE [dbo].[RespuestaCampania] (
    [CampaniaDetalleId] INT      DEFAULT ((0)) NOT NULL,
    [CampaniaId]        INT      DEFAULT ((0)) NOT NULL,
    [RespuestaId]       INT      NOT NULL,
    [OpcionRespuesta]   TINYINT  DEFAULT ((0)) NOT NULL,
    [ContadorRespuesta] INT      DEFAULT ((0)) NOT NULL,
    [Comentarios]       TEXT     DEFAULT ('') NOT NULL,
    [Fecha]             DATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_RespuestaCampania] PRIMARY KEY CLUSTERED ([CampaniaDetalleId] ASC, [CampaniaId] ASC),
    FOREIGN KEY ([CampaniaDetalleId], [CampaniaId]) REFERENCES [dbo].[CampaniaDetalle] ([CampaniaDetalleId], [CampaniaId]),
    FOREIGN KEY ([RespuestaId]) REFERENCES [dbo].[Respuesta] ([RespuestaId])
);

CREATE TABLE [dbo].[TipoPregunta] (
    [TipoPreguntaId] INT      IDENTITY (1, 1) NOT NULL,
    [Nombre]         TEXT     DEFAULT ('') NOT NULL,
    [Fecha]          DATETIME DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_TipoPregunta] PRIMARY KEY CLUSTERED ([TipoPreguntaId] ASC)
);