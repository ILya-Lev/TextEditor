SQL generated with EF for the only table in the db

CREATE TABLE [dbo].[TextFiles] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [DateCreated]       DATETIME        NOT NULL,
    [DateModified]      DATETIME        NOT NULL,
    [Name]              NVARCHAR (MAX)  NULL,
    [CompressedContent] VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.TextFiles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

Current issueses:
1. EF usage leads to MS SQL Server is being used insted of MS Access
there is some lib to solve the problem: https://jetentityframeworkprovider.codeplex.com/

