USE MovieAdvisor;

--------------- Views -----------------
GO
CREATE VIEW AllMovies
AS SELECT AudioVisualContent.*, Runtime FROM Movie JOIN AudioVisualContent ON Movie.ID = AudioVisualContent.ID;

GO
CREATE VIEW AllSeries
AS SELECT AudioVisualContent.*, FinishDate, State FROM TVSeries JOIN AudioVisualContent ON TVSeries.ID = AudioVisualContent.ID;

GO
CREATE VIEW GetPublicWatchlists
AS SELECT * FROM Watchlist WHERE Visibility = 1;


--------------- SPs -------------------
GO
CREATE PROC CreateEpisode(
    @SerieID INT,
    @SeasonNumber INT,
    @EpNumber INT,
	@EpRuntime SMALLINT,
	@EpSynopsis	VARCHAR(255)
)
AS
    INSERT INTO Episode (Series_ID, Season_ID, Number, Runtime, Synopsis) VALUES
        (@SerieID, @SeasonNumber, @EpNumber, @EpRuntime, @EpSynopsis);

GO
CREATE PROC UpdateEpisode(
    @SerieID INT,
    @SeasonNumber INT,
    @EpNumber INT,
	@EpRuntime SMALLINT,
	@EpSynopsis	VARCHAR(255)
)
AS
    UPDATE Episode SET Number=@EpNumber, Runtime=@EpRuntime, Synopsis=@EpSynopsis
        WHERE (Series_ID=@SerieID AND Season_ID=@SeasonNumber AND Number=@EpNumber);

GO
CREATE PROC CreateSeason(
    @SerieID INT,
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

    INSERT INTO Season (ID, Number, Photo, TrailerURL, ReleaseDate) VALUES
        (@SerieID, @SeasonNumber, @SeasonPhoto, @SeasonTrailerURL, @SeasonReleaseDate);

    EXEC CreateEpisode @SerieID, @SeasonNumber, @EpNumber, @EpRuntime, @EpSynopsis;

    COMMIT TRAN;

GO
CREATE PROC UpdateSeason(
    @SerieID INT,
    @SeasonNumber INT,
	@SeasonPhoto VARCHAR(128),
	@SeasonTrailerURL VARCHAR(128),
	@SeasonReleaseDate DATE
)
AS
    UPDATE Season SET Number=@SeasonNumber, Photo=@SeasonPhoto, TrailerURL=@SeasonTrailerURL, ReleaseDate=@SeasonReleaseDate
        WHERE (ID=@SerieID AND Number=@SeasonNumber);


GO
CREATE PROC CreateSerie(
	@Title VARCHAR(64),
	@Synopsis VARCHAR(255),
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

    INSERT INTO AudioVisualContent (Title, Synopsis, TrailerURL, Budget, Revenue, Photo, AgeRate, ReleaseDate) VALUES
        (@Title, @Synopsis, @TrailerURL, @Budget, @Revenue, @Photo, @AgeRate, @ReleaseDate);

    DECLARE @ID INT;

    SET @ID = @@IDENTITY;

    INSERT INTO TVSeries (ID, State, FinishDate) VALUES
        (@ID, @State, @FinishDate);

    EXEC CreateSeason @ID, @SeasonNumber, @SeasonPhoto, @SeasonTrailerURL, @SeasonReleaseDate, @EpNumber, @EpRuntime, @EpSynopsis;

    COMMIT TRAN;

GO
CREATE PROC UpdateSerie(
    @ID INT,
	@Title VARCHAR(64),
	@Synopsis VARCHAR(255),
	@TrailerURL VARCHAR(128),
	@Budget	MONEY,
	@Revenue MONEY,
	@Photo VARCHAR(128),
	@AgeRate SMALLINT,
	@ReleaseDate DATE,

	@State VARCHAR(16),
	@FinishDate DATE
)
AS
    BEGIN TRAN;

    UPDATE AudioVisualContent SET Title=@Title, Synopsis=@Synopsis, TrailerURL=@TrailerURL, Budget=@Budget, Revenue=@Revenue, Photo=@Photo, AgeRate=@AgeRate, ReleaseDate=@ReleaseDate
        WHERE ID=@ID;

    UPDATE TVSeries SET State=@State, FinishDate=@FinishDate
        WHERE ID=@ID;

    COMMIT TRAN;

GO
CREATE PROC CreateMovie(
	@Title VARCHAR(64),
	@Synopsis VARCHAR(255),
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

    INSERT INTO AudioVisualContent (Title, Synopsis, TrailerURL, Budget, Revenue, Photo, AgeRate, ReleaseDate) VALUES
        (@Title, @Synopsis, @TrailerURL, @Budget, @Revenue, @Photo, @AgeRate, @ReleaseDate);

    DECLARE @ID INT;

    SET @ID = @@IDENTITY;

    INSERT INTO Movie (ID, Runtime) VALUES
        (@ID, @Runtime);

    COMMIT TRAN;

GO
CREATE PROC UpdateMovie(
    @ID INT,
	@Title VARCHAR(64),
	@Synopsis VARCHAR(255),
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

    UPDATE AudioVisualContent SET Title=@Title, Synopsis=@Synopsis, TrailerURL=@TrailerURL, Budget=@Budget, Revenue=@Revenue, Photo=@Photo, AgeRate=@AgeRate, ReleaseDate=@ReleaseDate
        WHERE ID=@ID;

    UPDATE Movie SET Runtime=@Runtime WHERE ID=@ID;

    COMMIT TRAN;

GO
CREATE PROC AddReview(
	@UserID INT,
	@AVIdentifier INT,
	@Title VARCHAR(32),
	@Description VARCHAR(512),
	@Classification SMALLINT
)
AS
    INSERT INTO Review(UserID, AVIdentifier, Title, Description, Classification) VALUES
        (@UserID, @AVIdentifier, @Title, @Description, @Classification);
GO

CREATE PROC CreateWatchlist (
    @Title VARCHAR(32),
	@UserID INT,
	@Visibility BIT
)
AS
    INSERT INTO Watchlist (Title, UserID, Visibility) VALUES 
        (@Title, @UserID, @Visibility)    
GO

CREATE PROC AddAVContentToWatchlist (
    @WLTitle VARCHAR(32),
	@UserID INT,
	@AVIdentifier INT
)
AS
    INSERT INTO WatchlistAV (WLTitle, UserID, AVIdentifier) VALUES
        (@WLTitle, @UserID, @AVIdentifier);
GO

--------------- UDFs ----------------

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

CREATE FUNCTION getAllSeasonsOfSerie(@ID INT) RETURNS TABLE
AS
RETURN (SELECT * FROM Season WHERE Season.ID = @ID);
GO

CREATE FUNCTION getAllEpisodesOfSeason(@SerieID INT, @SeasonNo INT) RETURNS TABLE
AS
RETURN (SELECT * FROM Episode WHERE Series_ID=@SerieID AND Season_ID=@SeasonNo);
GO

CREATE FUNCTION getAVContentReviews(@ID INT) RETURNS TABLE
AS
RETURN (
    SELECT R.*, LikeCount=COUNT(IsLike) 
    FROM (SELECT * FROM Review WHERE AVIdentifier=@ID) AS R JOIN ReviewLikes ON R.ID = ReviewLikes.ReviewID 
    GROUP BY R.ID, R.UserID, R.AVIdentifier, R.Title, R.Description, R.Classification, R.CreatedAt
);
GO

CREATE FUNCTION getAVFromWatchlist(@Title VARCHAR(32), @UserID INT) RETURNS TABLE
AS
RETURN (
    SELECT AudioVisualContent.* FROM WatchlistAV
    JOIN (SELECT * FROM Watchlist WHERE Title=@Title AND UserID=@UserID) AS WL
    ON (WatchlistAV.WLTitle = WL.Title AND WatchlistAV.UserID = WL.UserID)
    JOIN AudioVisualContent ON AudioVisualContent.ID = WatchlistAV.AVIdentifier
);
GO