USE [Sorschia];
GO

CREATE TABLE [dbo].[UserRole]
(
    [Id] BIGINT IDENTITY,
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    [IsDeleted] BIT NOT NULL,
    [InsertedById] INT,
    [InsertedOn] DATETIMEOFFSET,
    [DeletedById] INT,
    [DeletedOn] DATETIMEOFFSET,
    CONSTRAINT [PK_UserRole] PRIMARY KEY([Id]),
    CONSTRAINT [FK_UserRole_UserId] FOREIGN KEY([UserId]) REFERENCES [dbo].[User]([Id]),
    CONSTRAINT [FK_UserRole_RoleId] FOREIGN KEY([RoleId]) REFERENCES [dbo].[Role]([Id])
);

ALTER TABLE [dbo].[UserRole] ADD
    CONSTRAINT [DF_UserRole_IsDeleted] DEFAULT 0 FOR [IsDeleted];
GO