CREATE TABLE [dbo].[Brands] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (200) NOT NULL,
    [CountryOfOrigin] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED ([ID] ASC)
);

