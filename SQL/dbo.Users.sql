CREATE TABLE [dbo].[Users] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [UserName]      NVARCHAR (30)  NOT NULL,
    [Password]      NVARCHAR (MAX) NOT NULL,
    [FirstName]     NVARCHAR (30)  NOT NULL,
    [LastName]      NVARCHAR (30)  NOT NULL,
    [Phone]         NVARCHAR (12)  NOT NULL,
    [Email]         NVARCHAR (75)  NOT NULL,
    [IsReviewer]    BIT            NOT NULL,
    [IsAdmin]       BIT            NOT NULL,
    [Active]        BIT            NOT NULL,
    [DateCreated]   DATETIME       NOT NULL,
    [DateUpdated]   DATETIME       NULL,
    [UpdatedByUser] INT            NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserName]
    ON [dbo].[Users]([UserName] ASC);

