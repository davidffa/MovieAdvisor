USE MovieAdvisor;

/*
    Calcula o overall score de um filme de 0 a 10 com base nas críticas do utilizador, usando os likes como ponderação.
    Exemplo: Se um filme tiver 1 review com 10 de score e 5 likes, mas tiver 2 reviews com 1 score e 0 likes, a relevância do filme será
             Overall score = ((5+1) * 10 + 1 + 1) / 7
*/
GO
CREATE FUNCTION overallScoreByID(@ID INT) RETURNS DECIMAL(4, 2)
AS
BEGIN
    DECLARE @OverallScore DECIMAL(4, 2);
    DECLARE @ScoreSum INT;
    DECLARE @ReviewCount INT;

    SET @ScoreSum = 0;
    SET @ReviewCount = 0;

    DECLARE ReviewCursor CURSOR FAST_FORWARD
    FOR SELECT ID, Classification FROM Review WHERE AVIdentifier = @ID;

    OPEN ReviewCursor;

    DECLARE @ReviewID INT;
    DECLARE @Classification SMALLINT;

    FETCH ReviewCursor INTO @ReviewID, @Classification;

    DECLARE @LikeCount INT;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT @LikeCount=COUNT(IsLike) FROM ReviewLikes WHERE ReviewID = @ReviewID;

        SET @ReviewCount = @ReviewCount + @LikeCount;
        SET @ScoreSum = @ScoreSum + (@LikeCount + 1) * @Classification;

        FETCH ReviewCursor INTO @ReviewID, @Classification;
    END

    CLOSE ReviewCursor;
    DEALLOCATE ReviewCursor;

    IF @ReviewCount = 0
    BEGIN
        RETURN -1;
    END

    SET @OverallScore = CAST(@ScoreSum AS FLOAT) / @ReviewCount;

    RETURN @OverallScore;
END
GO

CREATE FUNCTION filterAVByGenre(@GenreId INT) RETURNS TABLE
AS
RETURN (SELECT * FROM AudioVisualContent JOIN AVContentGenre ON ID=AVIdentifier WHERE GenreID = @GenreId);
GO

CREATE PROC CreateSerie(
	@Title VARCHAR(64),
	@Synopsis VARCHAR(255),
	@Popularity DECIMAL(3, 1),
	@TrailerURL VARCHAR(128),
	@Budget	MONEY,
	@Revenue MONEY,
	@Photo VARCHAR(128),
	@AgeRate SMALLINT,
	@ReleaseDate DATE,

	@State VARCHAR(16),
	@FinishDate DATE,

    @SeasonNumber INT,
	@SeasonPhoto VARCHAR(128),
	@SeasonTrailerURL VARCHAR(128),
	@SeasonReleaseDate DATE,

    @EpNumber INT,
	@EpRuntime SMALLINT,
	@EpSynopsis	VARCHAR(255)
)
AS
    BEGIN TRAN;

    INSERT INTO AudioVisualContent (Title, Synopsis, Popularity, TrailerURL, Budget, Revenue, Photo, AgeRate, ReleaseDate) VALUES
        (@Title, @Synopsis, @Popularity, @TrailerURL, @Budget, @Revenue, @Photo, @AgeRate, @ReleaseDate);

    DECLARE @ID INT;

    SET @ID = @@IDENTITY;

    INSERT INTO TVSeries (ID, State, FinishDate) VALUES
        (@ID, @State, @FinishDate);

    INSERT INTO Season (ID, Number, Photo, TrailerURL, ReleaseDate) VALUES
        (@ID, @SeasonNumber, @SeasonPhoto, @SeasonTrailerURL, @SeasonReleaseDate);

    INSERT INTO Episode (Series_ID, Season_ID, Number, Runtime, Synopsis) VALUES
        (@ID, @SeasonNumber, @EpNumber, @EpRuntime, @EpSynopsis);

    COMMIT TRAN;
GO

CREATE PROC CreateMovie(
	@Title VARCHAR(64),
	@Synopsis VARCHAR(255),
	@Popularity DECIMAL(3, 1),
	@TrailerURL VARCHAR(128),
	@Budget	MONEY,
	@Revenue MONEY,
	@Photo VARCHAR(128),
	@AgeRate SMALLINT,
	@ReleaseDate DATE,

	@Runtime INT
)
AS
    BEGIN TRAN;

    INSERT INTO AudioVisualContent (Title, Synopsis, Popularity, TrailerURL, Budget, Revenue, Photo, AgeRate, ReleaseDate) VALUES
        (@Title, @Synopsis, @Popularity, @TrailerURL, @Budget, @Revenue, @Photo, @AgeRate, @ReleaseDate);

    DECLARE @ID INT;

    SET @ID = @@IDENTITY;

    INSERT INTO Movie (ID, Runtime) VALUES
        (@ID, @Runtime);

    COMMIT TRAN;
GO