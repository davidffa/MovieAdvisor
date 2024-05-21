USE MovieAdvisor;

GO
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
CREATE TRIGGER SeriesFinishDate ON TVSeries
AFTER INSERT, UPDATE
AS
    DECLARE @FinishDate DATE;
    DECLARE @Id INT;

    SELECT @Id=ID, @FinishDate=FinishDate FROM inserted;

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