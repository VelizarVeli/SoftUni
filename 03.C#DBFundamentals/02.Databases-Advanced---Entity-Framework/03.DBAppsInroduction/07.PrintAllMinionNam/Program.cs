using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using _02.VillainNames;

namespace _07.PrintAllMinionNam
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> minions = new List<string>();

            using (SqlConnection connection = new SqlConnection(DBConfig.ConnectionString))
            {
                connection.Open();

                minions = GetAllMinions(minions, connection);

                if (minions.Count % 2 == 0)
                {
                    for (int i = 0, j = minions.Count - 1; i < minions.Count / 2; i++, j--)
                    {
                        Console.WriteLine(minions[i]);
                        Console.WriteLine(minions[j]);
                    }
                }
                else
                {
                    for (int i = 0, j = minions.Count - 1; i <= minions.Count / 2; i++, j--)
                    {
                        Console.WriteLine(minions[i]);
                        if (i < minions.Count /2)
                        {
                            Console.WriteLine(minions[j]);
                        }
                    }
                }
                connection.Close();
            }
        }

        private static List<string> GetAllMinions(List<string> minions, SqlConnection connection)
        {
            string minionsSql = "SELECT Name FROM Minions";

            using (SqlCommand command = new SqlCommand(minionsSql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minions.Add((string)reader[0]);
                    }
                }
            }
            return minions;
        }
    }
}