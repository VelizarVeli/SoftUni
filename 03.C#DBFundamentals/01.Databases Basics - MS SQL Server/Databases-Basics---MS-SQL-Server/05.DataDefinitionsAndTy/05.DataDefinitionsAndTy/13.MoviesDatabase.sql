CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DirectorName NVARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY NOT NULL,
GenreName NVARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
)


CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY NOT NULL,
CategoryName NVARCHAR(50) NOT NULL,
Notes VARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear DATE,
[Length] INT,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating DECIMAL(2,1),
Notes VARCHAR(MAX)
)

INSERT INTO Directors
VALUES
('Steven Spielberg', 'The best director for all times'),
('Frank Darabont', 'After all the discussion, no one could fault the conclusion that Frank Darabont is the most important film-maker of the current era.'),
('Francis Ford Copolla', 'Francis Ford Copolla is impossible to overstate.'),
('Christopher Nolan', 'Christopher Nolanh is a one-off: an independent-minded film-maker who has forged a happy working relationship with Hollywood.'),
('Sidney Lumet', 'The lofty ranking of Sidney Lumet just goes to show that its quality, not quantity, that counts.')

INSERT INTO Genres
VALUES
('Sci-fi', 'Can you really rate a movie genre as being best genre "? I think that watching a movie has more to do with the state of mind you are in on a certain time or period.'),
('Biography', 'This the only genre that makes me feel like Im actually living through the emotions and horror of the movie with the characters.'),
('Action','I really think action movies are good but they are going overboard with the amount.'),
('Crime', NULL),
('Drama','Dramatic films bring so many amazing classics. The Godfather, The Sixth Sense, Casablanca, Gone With the Wind, Citizen Kane, Its a Wonderful Life, all of them are just so outstanding. - MontyPython')

INSERT INTO Categories
VALUES
('Crime-drama', NULL),
('History-drama', NULL),
('Historical fiction', NULL),
('Ghost story', NULL),
('Mistery', NULL)

INSERT INTO Movies
VALUES
('The Shawshank Redemption', 2, '1994', 142, 5, 1, 9.3, 'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.'),
('The Godfather', 3, '1972', 175, 5, 1, 9.2, 'The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.'),
('The Dark Knight', 4, '2008', 152, 3, 1, 9, 'When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.'),
('12 Angry Men', 5, '1957', 96, 5, 1, 8.9, 'A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence.'),
('Schindler''s List', 1, '1993', 195, 2, 2, 8.9, 'In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazi Germans.')
