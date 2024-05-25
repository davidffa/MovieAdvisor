USE MovieAdvisor;

GO
-- Permitir no máximo 1 review por utilizador por filme
CREATE TRIGGER SingleReviewPerMovie ON Review
AFTER INSERT
AS
    DECLARE @ReviewCount INT;
    DECLARE @AVIdentifier INT;
    DECLARE @UserID INT;

    SELECT @AVIdentifier=AVIdentifier, @UserID=UserID FROM inserted;

    SELECT @ReviewCount=COUNT(*) FROM Review WHERE UserID=@UserID AND AVIdentifier=@AVIdentifier;

    IF @ReviewCount > 1
    BEGIN
        RAISERROR('An user can only have at most one review per movie/serie', 16, 1);
        ROLLBACK TRAN;
    END
GO

GO
-- Não permitir inserção de uma finish date anterior à release date da série/seasons
CREATE TRIGGER SeriesFinishDate ON TVSeries
AFTER INSERT, UPDATE
AS
    DECLARE @FinishDate DATE;
    DECLARE @Id INT;
    DECLARE @State VARCHAR(16);

    SELECT @Id=ID, @FinishDate=FinishDate, @State=State FROM inserted;

    IF (@FinishDate IS NOT NULL AND @State = 'Active')
    BEGIN
        RAISERROR('Cannot set a finish date on an unfinished serie. The serie state must be finished or cancelled', 16, 1);
        ROLLBACK;
        RETURN;
    END

    IF @FinishDate IS NOT NULL
    BEGIN
        IF (SELECT ReleaseDate FROM AudioVisualContent WHERE ID=@Id) > @FinishDate
        BEGIN
            RAISERROR('Cannot set a finish date before serie release date', 16, 1);
            ROLLBACK TRAN;
            RETURN;
        END
    END

    IF (EXISTS(SELECT * FROM Season WHERE ID=@Id AND ReleaseDate > @FinishDate))
    BEGIN
        RAISERROR('Cannot set a finish date before season release dates', 16, 1);
        ROLLBACK TRAN;
    END
GO

-- Apagar AVContent, caso a série correspondente seja apagada
CREATE TRIGGER DeleteAV ON TVSeries
AFTER DELETE
AS
    DECLARE @Id INT;

    SELECT @Id=ID FROM deleted;

    DELETE FROM AudioVisualContent WHERE ID=@Id;
GO

-- Apagar AVContent, caso o filme correspondente seja apagada
CREATE TRIGGER DeleteAV2 ON Movie
AFTER DELETE
AS
    DECLARE @Id INT;

    SELECT @Id=ID FROM deleted;

    DELETE FROM AudioVisualContent WHERE ID=@Id;
GO

-- Trigger para nao deixar seasons sem eps, nem poder apagar episódio de forma não sequencial (ex: existe 1,2,3,4 e tento apagar o 3, não dá, tenho de apagar o 4 primeiro)
CREATE TRIGGER DeleteEp ON Episode
AFTER DELETE
AS
    DECLARE @SeasonID INT;
    DECLARE @SerieID INT;
    DECLARE @Number INT;

    SELECT @Number=Number, @SerieID=Series_ID, @SeasonID=Season_ID FROM deleted;

    IF (EXISTS(SELECT * FROM Season WHERE ID=@SerieID AND Number=@SeasonID) AND NOT EXISTS(SELECT * FROM Episode WHERE Series_ID=@SerieID AND Season_ID=@SeasonID))
    BEGIN
        RAISERROR('Cannot delete episode because a season must have at least one episode, delete the season instead', 16, 1);
        ROLLBACK;
    END

    IF (EXISTS(SELECT * FROM Episode WHERE Series_ID=@SerieID AND Season_ID=@SeasonID AND Number > @Number))
    BEGIN
        RAISERROR('Cannot delete episode non-sequentially', 16, 1);
        ROLLBACK;
    END
GO

-- Trigger para nao deixar series sem seasons
CREATE TRIGGER DeleteSeason ON Season
AFTER DELETE
AS
    DECLARE @SerieID INT;
    DECLARE @Number INT;

    SELECT @Number=Number, @SerieID=ID FROM deleted;

    IF (EXISTS(SELECT * FROM TVSeries WHERE ID=@SerieID) AND NOT EXISTS(SELECT * FROM Season WHERE ID=@SerieID))
    BEGIN
        RAISERROR('Cannot delete season because a serie must have at least one season, delete the serie instead', 16, 1);
        ROLLBACK;
    END

    IF (EXISTS(SELECT * FROM Season WHERE ID=@SerieID AND Number > @Number))
    BEGIN
        RAISERROR('Cannot delete seasons non-sequentially', 16, 1);
        ROLLBACK;
    END
GO
