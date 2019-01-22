using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using _02.VillainNames;

namespace _05.ChangeTownNameCas
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(DBConfig.ConnectionString))
            {
                connection.Open();

                int countryId = GetCountryId(countryName, connection);
                if (countryId == 0)
                {
                    Console.WriteLine($"No town names were affected.");
                }
                else
                {
                    updateCountries(countryId, connection);
                    PrintTowns(countryId, connection);
                }
                connection.Close();
            }
        }

        private static void PrintTowns(int countryId, SqlConnection connection)
        {
            string townsSql =
                "SELECT Name FROM Towns WHERE CountryCode = @countryCode";

            using (SqlCommand command = new SqlCommand(townsSql, connection))
            {
                command.Parameters.AddWithValue("countryCode", countryId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine($"No town names were affected.");
                    }
                    else
                    {
                        List<string> towns = new List<string>();
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }

                        Console.WriteLine($"{towns.Count} town names were affected.");
                        Console.WriteLine($"[{string.Join(", ", towns)}]");
                    }
                }
            }
        }

        private static void updateCountries(int countryId, SqlConnection connection)
        {
            string countriesToUpper = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = @countryCode";

            using (SqlCommand command = new SqlCommand(countriesToUpper, connection))
            {
                command.Parameters.AddWithValue("@countryCode", countryId);

                command.ExecuteNonQuery();
            }
        }

        private static int GetCountryId(string townName, SqlConnection connection)
        {
            string townSql = "SELECT Id FROM Countries WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(townSql, connection))
            {
                command.Parameters.AddWithValue("@Name", townName);

                if (command.ExecuteScalar() == null)
                {
                    return 0;
                }
                else
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }
    }
}
