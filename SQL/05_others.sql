USE MovieAdvisor;

-- Search content by title
CREATE NONCLUSTERED INDEX IX_AVTitle ON AudioVisualContent(Title)
GO

-- Sort by release date
CREATE NONCLUSTERED INDEX IX_ReleaseDate ON AudioVisualContent(ReleaseDate)
GO

-- Search by person name
CREATE NONCLUSTERED INDEX IX_PersonName ON Person(Name);
GO

-- User lookup is made by email
CREATE NONCLUSTERED INDEX IX_UserEmail ON "User"(Email);
GO