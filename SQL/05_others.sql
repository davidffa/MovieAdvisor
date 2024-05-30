USE MovieAdvisor;

-- Search content by title
CREATE NONCLUSTERED INDEX IX_AVTitle ON AudioVisualContent(Title)
-- Sort by release date
CREATE NONCLUSTERED INDEX IX_ReleaseDate ON AudioVisualContent(ReleaseDate)
-- Search by person name
CREATE NONCLUSTERED INDEX IX_PersonName ON Person(Name);
-- Authentication, search by email
CREATE NONCLUSTERED INDEX IX_UserEmail ON "User"(Email);

GO
------------------ GERADOR DE DADOS PARA TESTAGEM DE ÍNDICES ----------------------

USE MovieAdvisor;

-- Record the Start Time
DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 800000;

SET nocount ON

WHILE @val <= @nelem
BEGIN
    INSERT INTO AudioVisualContent (Title, Synopsis) VALUES ('LIXO', 'AAAAA');

    IF (@val % 100000) = 0
    BEGIN
        DBCC FREEPROCCACHE;
        DBCC DROPCLEANBUFFERS;

        DROP INDEX IF EXISTS IX_AVTitle ON AudioVisualContent;

        SET @start_time = GETDATE();
        PRINT @start_time

        SELECT * FROM AudioVisualContent WHERE Title LIKE 'Forr%';

        SET @end_time = GETDATE();
        PRINT 'Milliseconds used (WITHOUT INDEX): ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND, @start_time, @end_time));

        CREATE NONCLUSTERED INDEX IX_AVTitle ON AudioVisualContent(Title);

        DBCC FREEPROCCACHE;
        DBCC DROPCLEANBUFFERS;

        SET @start_time = GETDATE();
        PRINT @start_time

        SELECT * FROM AudioVisualContent WHERE Title LIKE 'Forr%';

        SET @end_time = GETDATE();
        PRINT 'Milliseconds used (WITH INDEX): ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND, @start_time, @end_time));

        DROP INDEX IX_AVTitle ON AudioVisualContent;
    END

    SET @val = @val + 1;
END

SET @val = 1;

WHILE @val <= @nelem
BEGIN
    DECLARE @Email VARCHAR(64);
    SET @Email = CONCAT(@val, 'test@gmail.com');
    EXEC Authenticate @Email, 'AGSIUDAS', NULL;

    IF (@val % 100000) = 0
    BEGIN
        DBCC FREEPROCCACHE;
        DBCC DROPCLEANBUFFERS;

        DROP INDEX IF EXISTS IX_UserEmail ON "User";

        SET @start_time = GETDATE();
        PRINT @start_time

        EXEC Authenticate '1test@gmail.com', 'AGSIUDAS', NULL;

        SET @end_time = GETDATE();
        PRINT 'Milliseconds used (WITHOUT INDEX): ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND, @start_time, @end_time));

        CREATE NONCLUSTERED INDEX IX_UserEmail ON "User"(Email);

        DBCC FREEPROCCACHE;
        DBCC DROPCLEANBUFFERS;

        SET @start_time = GETDATE();
        PRINT @start_time

        EXEC Authenticate '1test@gmail.com', 'AGSIUDAS', NULL;

        SET @end_time = GETDATE();
        PRINT 'Milliseconds used (WITH INDEX): ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND, @start_time, @end_time));

        DROP INDEX IX_UserEmail ON "User";
    END

    SET @val = @val + 1;
END