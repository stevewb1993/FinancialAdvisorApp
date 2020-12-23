CREATE TABLE [dbo].[Books] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (MAX) NULL,
    [Year]     INT            NULL,
    [Isbn]     NVARCHAR (MAX) NULL,
    [Summary]  NVARCHAR (MAX) NULL,
    [Image]    NVARCHAR (MAX) NULL,
    [Price]    FLOAT (53)     NULL,
    [AuthorId] INT            NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Books_AuthorId]
    ON [dbo].[Books]([AuthorId] ASC);

