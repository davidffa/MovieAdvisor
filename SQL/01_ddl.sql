USE master;
DROP DATABASE IF EXISTS MovieAdvisor;

CREATE DATABASE MovieAdvisor;
GO

USE MovieAdvisor;

CREATE TABLE Genre (
	ID   INT IDENTITY(1, 1) NOT NULL,
	Name VARCHAR(32) NOT NULL UNIQUE,

	PRIMARY KEY (ID)
);

CREATE TABLE Person (
	ID			INT IDENTITY(1, 1) NOT NULL,
	Name		VARCHAR(64) NOT NULL,
	Biography	VARCHAR(1024),
	BirthDate	DATE,
	Photo		VARCHAR(32),

	PRIMARY KEY (ID),
);

CREATE TABLE "User" (
	ID			INT IDENTITY(1, 1) NOT NULL,
	Email		VARCHAR(64) NOT NULL UNIQUE,
	Password	VARBINARY(512) NOT NULL,
	CreatedAt	DATE DEFAULT (current_timestamp),
	IsAdmin		BIT DEFAULT 0,

	PRIMARY KEY (ID)
);

CREATE TABLE AudioVisualContent (
	ID				INT IDENTITY(1, 1) NOT NULL,
	Title			VARCHAR(64) NOT NULL,
	Synopsis		VARCHAR(255),
	TrailerURL		VARCHAR(128),
	Budget			MONEY,
	Revenue			MONEY,
	Photo			VARCHAR(128),
	AgeRate			SMALLINT CHECK(AgeRate = 0 OR AgeRate = 12 OR AgeRate = 15 OR AgeRate = 18),
	ReleaseDate		DATE,

	PRIMARY KEY (ID)
);

CREATE TABLE Movie (
	ID		INT NOT NULL,
	Runtime	SMALLINT NOT NULL,

	PRIMARY KEY (ID),
	FOREIGN KEY (ID) REFERENCES AudioVisualContent(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE TVSeries (
	ID			INT NOT NULL,
	State		VARCHAR(16) NOT NULL CHECK(State = 'Cancelled' OR State = 'Active' OR State = 'Finished'),
	FinishDate	DATE,

	PRIMARY KEY (ID),
	FOREIGN KEY (ID) REFERENCES AudioVisualContent(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Season (
	ID			INT NOT NULL,
	Number		INT NOT NULL,
	Photo		VARCHAR(128),
	TrailerURL	VARCHAR(128),
	ReleaseDate DATE,

	PRIMARY KEY (ID, Number),
	FOREIGN KEY (ID) REFERENCES TVSeries(ID) ON UPDATE CASCADE ON DELETE CASCADE,
);

CREATE TABLE Episode (
	Series_ID	INT NOT NULL,
	Season_ID	INT NOT NULL,
	Number		INT NOT NULL,
	Runtime		SMALLINT NOT NULL,
	Synopsis	VARCHAR(255),

	PRIMARY KEY (Series_ID, Season_ID, Number),
	FOREIGN KEY (Series_ID, Season_ID) REFERENCES Season(ID, Number) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE AVContentGenre (
	AVIdentifier	INT NOT NULL,
	GenreID			INT NOT NULL,

	PRIMARY KEY (AVIdentifier, GenreID),
	FOREIGN KEY (AVIdentifier) REFERENCES AudioVisualContent(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (GenreID) REFERENCES Genre(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE AVContentPerson (
	AVIdentifier	INT NOT NULL,
	PersonID		INT NOT NULL,
	Role			VARCHAR(32),

	PRIMARY KEY (AVIdentifier, PersonID),
	FOREIGN KEY (AVIdentifier) REFERENCES AudioVisualContent(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (PersonID) REFERENCES Person(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Watchlist (
	Title		VARCHAR(32) NOT NULL,
	UserID		INT NOT NULL,
	Visibility  BIT DEFAULT 0, -- 0 = private, 1 = public

	PRIMARY KEY (Title, UserID),
	FOREIGN KEY (UserID) REFERENCES "User"(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE WatchlistAV (
	WLTitle		 VARCHAR(32) NOT NULL,
	UserID		 INT NOT NULL,
	AVIdentifier INT NOT NULL,

	PRIMARY KEY (WLTitle, UserID, AVIdentifier),
	FOREIGN KEY (WLTitle, UserID) REFERENCES Watchlist(Title, UserID) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (AVIdentifier) REFERENCES AudioVisualContent(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Review (
	ID			   INT IDENTITY(1, 1) NOT NULL,
	UserID		   INT NOT NULL,
	AVIdentifier   INT NOT NULL,
	Title		   VARCHAR(32) NOT NULL,
	Description    VARCHAR(512),
	Classification SMALLINT CHECK(Classification >= 0 AND Classification <= 10),
	CreatedAt	   DATE DEFAULT (current_timestamp),

	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES "User"(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (AVIdentifier) REFERENCES AudioVisualContent(ID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE ReviewLikes (
	ReviewID	INT NOT NULL,
	UserID		INT NOT NULL,
	IsLike		BIT NOT NULL,

	PRIMARY KEY (ReviewID, UserID),
	FOREIGN KEY (ReviewID) REFERENCES Review(ID) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (UserID) REFERENCES "User"(ID)
);