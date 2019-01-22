CREATE TABLE Locations
(
             Id        INT IDENTITY PRIMARY KEY,
             Latitude  FLOAT,
             Longitude FLOAT
);

CREATE TABLE Credentials
(
             Id       INT IDENTITY PRIMARY KEY,
             Email    VARCHAR(30),
             Password VARCHAR(20)
);

CREATE TABLE Users
(
             Id           INT IDENTITY PRIMARY KEY,
             Nickname     VARCHAR(25),
             Gender       CHAR(1),
             Age          INT,
             LocationId   INT,
             CredentialId INT
             UNIQUE,
             CONSTRAINT FK_Users_Locations FOREIGN KEY(LocationId) REFERENCES Locations(Id),
             CONSTRAINT FK_Users_Credentials FOREIGN KEY(CredentialId) REFERENCES Credentials(Id)
);

CREATE TABLE Chats
(
             Id        INT IDENTITY PRIMARY KEY,
             Title     VARCHAR(32),
             StartDate DATE,
             IsActive  BIT
);

CREATE TABLE Messages
(
             Id      INT IDENTITY PRIMARY KEY,
             Content VARCHAR(200),
             SentOn  DATE,
             ChatId  INT,
             UserId  INT,
             CONSTRAINT FK_Messages_Chats FOREIGN KEY(ChatId) REFERENCES Chats(Id),
             CONSTRAINT FK_Messages_Users FOREIGN KEY(UserId) REFERENCES Users(Id)
);

CREATE TABLE UsersChats
(
             UserId INT,
             ChatId INT,
             CONSTRAINT PK_UsersChats PRIMARY KEY(ChatId, UserId),
             CONSTRAINT FK_UsersChats_Users FOREIGN KEY(UserId) REFERENCES Users(Id),
             CONSTRAINT FK_UsersChats_Chats FOREIGN KEY(ChatId) REFERENCES Chats(Id)
);