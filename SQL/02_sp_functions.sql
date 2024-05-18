USE MovieAdvisor;

/*
    Calcula o overall score de um filme de 0 a 10 com base nas críticas do utilizador, usando os likes como ponderação.
    Exemplo: Se um filme tiver 1 review com 10 de score e 5 likes, mas tiver 2 reviews com 1 score e 0 likes, a relevância do filme será
             Overall score = (5 * 10 + 1 + 1) / 7
*/
GO
CREATE FUNCTION overallScore() RETURNS @table TABLE
(
    ID INT,
    Title VARCHAR(64),
    OverallScore DECIMAL(4, 2)
)
AS
BEGIN
    DECLARE AVCursor CURSOR FAST_FORWARD
    FOR SELECT ID, Title FROM AudioVisualContent;

    OPEN AVCursor;

    DECLARE @ID INT
    DECLARE @Title VARCHAR(32)
    DECLARE @OverallScore DECIMAL(4, 2)
    DECLARE @ReviewCount INT;

    FETCH AVCursor INTO @ID, @Title;

    WHILE @@FETCH_STATUS = 0
    BEGIN
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
            SET @OverallScore = @OverallScore + @LikeCount * @Classification;

            FETCH ReviewCursor INTO @ReviewID, @Classification;
        END

        CLOSE ReviewCursor;
        DEALLOCATE ReviewCursor;

        FETCH AVCursor INTO @ID, @Title;

        SET @OverallScore = @OverallScore / @ReviewCount;

        INSERT INTO @table VALUES (@ID, @Title, @OverallScore);
    END

    CLOSE AVCursor;
    DEALLOCATE AVCursor;
    
    RETURN;
END
GO