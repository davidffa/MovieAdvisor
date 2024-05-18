USE MovieAdvisor;

CREATE INDEX IX_AVTitle ON AudioVisualContent(Title)
GO

CREATE INDEX IX_PersonName ON Person(Name);
GO