
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/06/2019 22:04:52
-- Generated from EDMX file: D:\Labs\Sem IV\ISS\Conference\ConferenceManager.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ConferenceManager];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SessionConference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionSet] DROP CONSTRAINT [FK_SessionConference];
GO
IF OBJECT_ID(N'[dbo].[FK_ListenerConference_Listener]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListenerConference] DROP CONSTRAINT [FK_ListenerConference_Listener];
GO
IF OBJECT_ID(N'[dbo].[FK_ListenerConference_Conference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListenerConference] DROP CONSTRAINT [FK_ListenerConference_Conference];
GO
IF OBJECT_ID(N'[dbo].[FK_AuthorSession_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuthorSession] DROP CONSTRAINT [FK_AuthorSession_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_AuthorSession_Session]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuthorSession] DROP CONSTRAINT [FK_AuthorSession_Session];
GO
IF OBJECT_ID(N'[dbo].[FK_SessionReviewer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SessionSet] DROP CONSTRAINT [FK_SessionReviewer];
GO
IF OBJECT_ID(N'[dbo].[FK_ConferenceChairConference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConferenceSet] DROP CONSTRAINT [FK_ConferenceChairConference];
GO
IF OBJECT_ID(N'[dbo].[FK_AbstractAuthor_Abstract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbstractAuthor] DROP CONSTRAINT [FK_AbstractAuthor_Abstract];
GO
IF OBJECT_ID(N'[dbo].[FK_AbstractAuthor_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbstractAuthor] DROP CONSTRAINT [FK_AbstractAuthor_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperAbstract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperSet] DROP CONSTRAINT [FK_PaperAbstract];
GO
IF OBJECT_ID(N'[dbo].[FK_ReviewerPaperReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperReviewSet] DROP CONSTRAINT [FK_ReviewerPaperReview];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperPaperReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperReviewSet] DROP CONSTRAINT [FK_PaperPaperReview];
GO
IF OBJECT_ID(N'[dbo].[FK_AbstractBiddingReviewer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbstractBiddingSet] DROP CONSTRAINT [FK_AbstractBiddingReviewer];
GO
IF OBJECT_ID(N'[dbo].[FK_AbstractBiddingAbstract]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AbstractBiddingSet] DROP CONSTRAINT [FK_AbstractBiddingAbstract];
GO
IF OBJECT_ID(N'[dbo].[FK_PaperSession]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaperSet] DROP CONSTRAINT [FK_PaperSession];
GO
IF OBJECT_ID(N'[dbo].[FK_ConferenceReviewer_Conference]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConferenceReviewer] DROP CONSTRAINT [FK_ConferenceReviewer_Conference];
GO
IF OBJECT_ID(N'[dbo].[FK_ConferenceReviewer_Reviewer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConferenceReviewer] DROP CONSTRAINT [FK_ConferenceReviewer_Reviewer];
GO
IF OBJECT_ID(N'[dbo].[FK_Author_inherits_Listener]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListenerSet_Author] DROP CONSTRAINT [FK_Author_inherits_Listener];
GO
IF OBJECT_ID(N'[dbo].[FK_Reviewer_inherits_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListenerSet_Reviewer] DROP CONSTRAINT [FK_Reviewer_inherits_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_ConferenceChair_inherits_Reviewer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListenerSet_ConferenceChair] DROP CONSTRAINT [FK_ConferenceChair_inherits_Reviewer];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ConferenceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConferenceSet];
GO
IF OBJECT_ID(N'[dbo].[SessionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SessionSet];
GO
IF OBJECT_ID(N'[dbo].[ListenerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListenerSet];
GO
IF OBJECT_ID(N'[dbo].[AbstractSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbstractSet];
GO
IF OBJECT_ID(N'[dbo].[PaperSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperSet];
GO
IF OBJECT_ID(N'[dbo].[PaperReviewSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaperReviewSet];
GO
IF OBJECT_ID(N'[dbo].[AbstractBiddingSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbstractBiddingSet];
GO
IF OBJECT_ID(N'[dbo].[ListenerSet_Author]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListenerSet_Author];
GO
IF OBJECT_ID(N'[dbo].[ListenerSet_Reviewer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListenerSet_Reviewer];
GO
IF OBJECT_ID(N'[dbo].[ListenerSet_ConferenceChair]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListenerSet_ConferenceChair];
GO
IF OBJECT_ID(N'[dbo].[ListenerConference]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListenerConference];
GO
IF OBJECT_ID(N'[dbo].[AuthorSession]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthorSession];
GO
IF OBJECT_ID(N'[dbo].[AbstractAuthor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AbstractAuthor];
GO
IF OBJECT_ID(N'[dbo].[ConferenceReviewer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConferenceReviewer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ConferenceSet'
CREATE TABLE [dbo].[ConferenceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL,
    [AbstractDeadline] datetime  NOT NULL,
    [PaperDeadline] datetime  NOT NULL,
    [BiddingDeadline] datetime  NOT NULL,
    [EvaluationDeadline] datetime  NOT NULL,
    [ConferenceChairId] int  NOT NULL
);
GO

-- Creating table 'SessionSet'
CREATE TABLE [dbo].[SessionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Time] datetime  NOT NULL,
    [Place] nvarchar(max)  NOT NULL,
    [ConferenceId] int  NOT NULL,
    [SessionChairId] int  NOT NULL
);
GO

-- Creating table 'ListenerSet'
CREATE TABLE [dbo].[ListenerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AbstractSet'
CREATE TABLE [dbo].[AbstractSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Keywords] nvarchar(max)  NOT NULL,
    [Topics] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PaperSet'
CREATE TABLE [dbo].[PaperSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [IsAccepted] bit  NOT NULL,
    [SessionId] int  NOT NULL,
    [Abstract_Id] int  NOT NULL
);
GO

-- Creating table 'PaperReviewSet'
CREATE TABLE [dbo].[PaperReviewSet] (
    [ReviewerId] int  NOT NULL,
    [PaperId] int  NOT NULL,
    [Evaluation] nvarchar(max)  NOT NULL,
    [Recommendations] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AbstractBiddingSet'
CREATE TABLE [dbo].[AbstractBiddingSet] (
    [ReviewerId] int  NOT NULL,
    [AbstractId] int  NOT NULL
);
GO

-- Creating table 'ListenerSet_Author'
CREATE TABLE [dbo].[ListenerSet_Author] (
    [Name] nvarchar(max)  NOT NULL,
    [Affiliation] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ListenerSet_Reviewer'
CREATE TABLE [dbo].[ListenerSet_Reviewer] (
    [Webpage] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ListenerSet_ConferenceChair'
CREATE TABLE [dbo].[ListenerSet_ConferenceChair] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'ListenerConference'
CREATE TABLE [dbo].[ListenerConference] (
    [Listeners_Id] int  NOT NULL,
    [Conference_Id] int  NOT NULL
);
GO

-- Creating table 'AuthorSession'
CREATE TABLE [dbo].[AuthorSession] (
    [Speakers_Id] int  NOT NULL,
    [SpeakerAtSession_Id] int  NOT NULL
);
GO

-- Creating table 'AbstractAuthor'
CREATE TABLE [dbo].[AbstractAuthor] (
    [Abstracts_Id] int  NOT NULL,
    [Authors_Id] int  NOT NULL
);
GO

-- Creating table 'ConferenceReviewer'
CREATE TABLE [dbo].[ConferenceReviewer] (
    [ReviewerAtConference_Id] int  NOT NULL,
    [Reviewers_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ConferenceSet'
ALTER TABLE [dbo].[ConferenceSet]
ADD CONSTRAINT [PK_ConferenceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SessionSet'
ALTER TABLE [dbo].[SessionSet]
ADD CONSTRAINT [PK_SessionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ListenerSet'
ALTER TABLE [dbo].[ListenerSet]
ADD CONSTRAINT [PK_ListenerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AbstractSet'
ALTER TABLE [dbo].[AbstractSet]
ADD CONSTRAINT [PK_AbstractSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaperSet'
ALTER TABLE [dbo].[PaperSet]
ADD CONSTRAINT [PK_PaperSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ReviewerId], [PaperId] in table 'PaperReviewSet'
ALTER TABLE [dbo].[PaperReviewSet]
ADD CONSTRAINT [PK_PaperReviewSet]
    PRIMARY KEY CLUSTERED ([ReviewerId], [PaperId] ASC);
GO

-- Creating primary key on [ReviewerId], [AbstractId] in table 'AbstractBiddingSet'
ALTER TABLE [dbo].[AbstractBiddingSet]
ADD CONSTRAINT [PK_AbstractBiddingSet]
    PRIMARY KEY CLUSTERED ([ReviewerId], [AbstractId] ASC);
GO

-- Creating primary key on [Id] in table 'ListenerSet_Author'
ALTER TABLE [dbo].[ListenerSet_Author]
ADD CONSTRAINT [PK_ListenerSet_Author]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ListenerSet_Reviewer'
ALTER TABLE [dbo].[ListenerSet_Reviewer]
ADD CONSTRAINT [PK_ListenerSet_Reviewer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ListenerSet_ConferenceChair'
ALTER TABLE [dbo].[ListenerSet_ConferenceChair]
ADD CONSTRAINT [PK_ListenerSet_ConferenceChair]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Listeners_Id], [Conference_Id] in table 'ListenerConference'
ALTER TABLE [dbo].[ListenerConference]
ADD CONSTRAINT [PK_ListenerConference]
    PRIMARY KEY CLUSTERED ([Listeners_Id], [Conference_Id] ASC);
GO

-- Creating primary key on [Speakers_Id], [SpeakerAtSession_Id] in table 'AuthorSession'
ALTER TABLE [dbo].[AuthorSession]
ADD CONSTRAINT [PK_AuthorSession]
    PRIMARY KEY CLUSTERED ([Speakers_Id], [SpeakerAtSession_Id] ASC);
GO

-- Creating primary key on [Abstracts_Id], [Authors_Id] in table 'AbstractAuthor'
ALTER TABLE [dbo].[AbstractAuthor]
ADD CONSTRAINT [PK_AbstractAuthor]
    PRIMARY KEY CLUSTERED ([Abstracts_Id], [Authors_Id] ASC);
GO

-- Creating primary key on [ReviewerAtConference_Id], [Reviewers_Id] in table 'ConferenceReviewer'
ALTER TABLE [dbo].[ConferenceReviewer]
ADD CONSTRAINT [PK_ConferenceReviewer]
    PRIMARY KEY CLUSTERED ([ReviewerAtConference_Id], [Reviewers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ConferenceId] in table 'SessionSet'
ALTER TABLE [dbo].[SessionSet]
ADD CONSTRAINT [FK_SessionConference]
    FOREIGN KEY ([ConferenceId])
    REFERENCES [dbo].[ConferenceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionConference'
CREATE INDEX [IX_FK_SessionConference]
ON [dbo].[SessionSet]
    ([ConferenceId]);
GO

-- Creating foreign key on [Listeners_Id] in table 'ListenerConference'
ALTER TABLE [dbo].[ListenerConference]
ADD CONSTRAINT [FK_ListenerConference_Listener]
    FOREIGN KEY ([Listeners_Id])
    REFERENCES [dbo].[ListenerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Conference_Id] in table 'ListenerConference'
ALTER TABLE [dbo].[ListenerConference]
ADD CONSTRAINT [FK_ListenerConference_Conference]
    FOREIGN KEY ([Conference_Id])
    REFERENCES [dbo].[ConferenceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListenerConference_Conference'
CREATE INDEX [IX_FK_ListenerConference_Conference]
ON [dbo].[ListenerConference]
    ([Conference_Id]);
GO

-- Creating foreign key on [Speakers_Id] in table 'AuthorSession'
ALTER TABLE [dbo].[AuthorSession]
ADD CONSTRAINT [FK_AuthorSession_Author]
    FOREIGN KEY ([Speakers_Id])
    REFERENCES [dbo].[ListenerSet_Author]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SpeakerAtSession_Id] in table 'AuthorSession'
ALTER TABLE [dbo].[AuthorSession]
ADD CONSTRAINT [FK_AuthorSession_Session]
    FOREIGN KEY ([SpeakerAtSession_Id])
    REFERENCES [dbo].[SessionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorSession_Session'
CREATE INDEX [IX_FK_AuthorSession_Session]
ON [dbo].[AuthorSession]
    ([SpeakerAtSession_Id]);
GO

-- Creating foreign key on [SessionChairId] in table 'SessionSet'
ALTER TABLE [dbo].[SessionSet]
ADD CONSTRAINT [FK_SessionReviewer]
    FOREIGN KEY ([SessionChairId])
    REFERENCES [dbo].[ListenerSet_Reviewer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SessionReviewer'
CREATE INDEX [IX_FK_SessionReviewer]
ON [dbo].[SessionSet]
    ([SessionChairId]);
GO

-- Creating foreign key on [ConferenceChairId] in table 'ConferenceSet'
ALTER TABLE [dbo].[ConferenceSet]
ADD CONSTRAINT [FK_ConferenceChairConference]
    FOREIGN KEY ([ConferenceChairId])
    REFERENCES [dbo].[ListenerSet_ConferenceChair]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConferenceChairConference'
CREATE INDEX [IX_FK_ConferenceChairConference]
ON [dbo].[ConferenceSet]
    ([ConferenceChairId]);
GO

-- Creating foreign key on [Abstracts_Id] in table 'AbstractAuthor'
ALTER TABLE [dbo].[AbstractAuthor]
ADD CONSTRAINT [FK_AbstractAuthor_Abstract]
    FOREIGN KEY ([Abstracts_Id])
    REFERENCES [dbo].[AbstractSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Authors_Id] in table 'AbstractAuthor'
ALTER TABLE [dbo].[AbstractAuthor]
ADD CONSTRAINT [FK_AbstractAuthor_Author]
    FOREIGN KEY ([Authors_Id])
    REFERENCES [dbo].[ListenerSet_Author]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AbstractAuthor_Author'
CREATE INDEX [IX_FK_AbstractAuthor_Author]
ON [dbo].[AbstractAuthor]
    ([Authors_Id]);
GO

-- Creating foreign key on [Abstract_Id] in table 'PaperSet'
ALTER TABLE [dbo].[PaperSet]
ADD CONSTRAINT [FK_PaperAbstract]
    FOREIGN KEY ([Abstract_Id])
    REFERENCES [dbo].[AbstractSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaperAbstract'
CREATE INDEX [IX_FK_PaperAbstract]
ON [dbo].[PaperSet]
    ([Abstract_Id]);
GO

-- Creating foreign key on [ReviewerId] in table 'PaperReviewSet'
ALTER TABLE [dbo].[PaperReviewSet]
ADD CONSTRAINT [FK_ReviewerPaperReview]
    FOREIGN KEY ([ReviewerId])
    REFERENCES [dbo].[ListenerSet_Reviewer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PaperId] in table 'PaperReviewSet'
ALTER TABLE [dbo].[PaperReviewSet]
ADD CONSTRAINT [FK_PaperPaperReview]
    FOREIGN KEY ([PaperId])
    REFERENCES [dbo].[PaperSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaperPaperReview'
CREATE INDEX [IX_FK_PaperPaperReview]
ON [dbo].[PaperReviewSet]
    ([PaperId]);
GO

-- Creating foreign key on [ReviewerId] in table 'AbstractBiddingSet'
ALTER TABLE [dbo].[AbstractBiddingSet]
ADD CONSTRAINT [FK_AbstractBiddingReviewer]
    FOREIGN KEY ([ReviewerId])
    REFERENCES [dbo].[ListenerSet_Reviewer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AbstractId] in table 'AbstractBiddingSet'
ALTER TABLE [dbo].[AbstractBiddingSet]
ADD CONSTRAINT [FK_AbstractBiddingAbstract]
    FOREIGN KEY ([AbstractId])
    REFERENCES [dbo].[AbstractSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AbstractBiddingAbstract'
CREATE INDEX [IX_FK_AbstractBiddingAbstract]
ON [dbo].[AbstractBiddingSet]
    ([AbstractId]);
GO

-- Creating foreign key on [SessionId] in table 'PaperSet'
ALTER TABLE [dbo].[PaperSet]
ADD CONSTRAINT [FK_PaperSession]
    FOREIGN KEY ([SessionId])
    REFERENCES [dbo].[SessionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaperSession'
CREATE INDEX [IX_FK_PaperSession]
ON [dbo].[PaperSet]
    ([SessionId]);
GO

-- Creating foreign key on [ReviewerAtConference_Id] in table 'ConferenceReviewer'
ALTER TABLE [dbo].[ConferenceReviewer]
ADD CONSTRAINT [FK_ConferenceReviewer_Conference]
    FOREIGN KEY ([ReviewerAtConference_Id])
    REFERENCES [dbo].[ConferenceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Reviewers_Id] in table 'ConferenceReviewer'
ALTER TABLE [dbo].[ConferenceReviewer]
ADD CONSTRAINT [FK_ConferenceReviewer_Reviewer]
    FOREIGN KEY ([Reviewers_Id])
    REFERENCES [dbo].[ListenerSet_Reviewer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConferenceReviewer_Reviewer'
CREATE INDEX [IX_FK_ConferenceReviewer_Reviewer]
ON [dbo].[ConferenceReviewer]
    ([Reviewers_Id]);
GO

-- Creating foreign key on [Id] in table 'ListenerSet_Author'
ALTER TABLE [dbo].[ListenerSet_Author]
ADD CONSTRAINT [FK_Author_inherits_Listener]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ListenerSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ListenerSet_Reviewer'
ALTER TABLE [dbo].[ListenerSet_Reviewer]
ADD CONSTRAINT [FK_Reviewer_inherits_Author]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ListenerSet_Author]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ListenerSet_ConferenceChair'
ALTER TABLE [dbo].[ListenerSet_ConferenceChair]
ADD CONSTRAINT [FK_ConferenceChair_inherits_Reviewer]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ListenerSet_Reviewer]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------