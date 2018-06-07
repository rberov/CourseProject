CREATE TABLE [dbo].[Cars] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Brand] INT            NOT NULL,
    [Model] NVARCHAR (200) NOT NULL,
    [Color] NVARCHAR (200) NOT NULL,
    [HP]    INT            NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([Brand]) REFERENCES [dbo].[Brands] ([ID]) ON DELETE CASCADE
);







