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

    IF @ReviewCount > 0
    BEGIN
        RAISERROR('An user can only have at most one review per movie/serie', 16, 1);
        ROLLBACK TRAN;
    END
GO