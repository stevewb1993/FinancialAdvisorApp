CREATE TABLE [dbo].[Authors] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Firstname] NVARCHAR (MAX) NULL,
    [Lastname]  NVARCHAR (MAX) NULL,
    [Bio]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

