using System.Data.SqlClient;
using _01.InitialSetup;

namespace Test
{
    class InitialSetup
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(Connection.ConnectionString);

            using (dbCon)
            {
                dbCon.Open();
                var databaseSql = "CREATE DATABASE MinionsDB";
                var createTableCountries = "CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
                var createTableTowns = "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
                var createTableMinions = "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";
                var createTableEvilnessFactors = "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
                var createTableVillians = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
                var createTableMinionsVillains = "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";

                var insertIntoCountries = "INSERT INTO Countries([Name]) VALUES('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";
                var insertIntoTowns = "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";
                var insertIntoMinions = "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";
                var insertIntoEvilnessFactors = "INSERT INTO EvilnessFactors(Name) VALUES('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
                var insertIntoVillians = "INSERT INTO Villains(Name, EvilnessFactorId) VALUES('Gru', 2),('Victor', 1),('Jilly', 3),('Miro', 4),('Rosen', 5),('Dimityr', 1),('Dobromir', 2)";
                var insertIntoMinionsVillains = "INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(4, 2),(1, 1),(5, 7),(3, 5),(2, 6),(11, 5),(8, 4),(9, 7),(7, 1),(1, 3),(7, 3),(5, 3),(4, 3),(1, 2),(2, 1),(2, 7)";

                executeQuiery(dbCon, databaseSql);
                dbCon.ChangeDatabase("MinionsDB");
                executeQuiery(dbCon, createTableCountries);
                executeQuiery(dbCon, createTableTowns);
                executeQuiery(dbCon, createTableMinions);
                executeQuiery(dbCon, createTableEvilnessFactors);
                executeQuiery(dbCon, createTableVillians);
                executeQuiery(dbCon, createTableMinionsVillains);
                executeQuiery(dbCon, insertIntoCountries);
                executeQuiery(dbCon, insertIntoTowns);
                executeQuiery(dbCon, insertIntoMinions);
                executeQuiery(dbCon, insertIntoEvilnessFactors);
                executeQuiery(dbCon, insertIntoVillians);
                executeQuiery(dbCon, insertIntoMinionsVillains);

                dbCon.Close();
            }
        }

        private static void executeQuiery(SqlConnection dbCon, string databaseSql)
        {
            using (SqlCommand command = new SqlCommand(databaseSql, dbCon))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
