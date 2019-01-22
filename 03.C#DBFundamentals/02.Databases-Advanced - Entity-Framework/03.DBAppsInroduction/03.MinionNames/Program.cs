using System;
using System.Data.SqlClient;
using _02.VillainNames;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int villianId = int.Parse(Console.ReadLine());
            using (SqlConnection connection = new SqlConnection(DBConfig.ConnectionString))
            {

                connection.Open();
                string villainName = GetVillainName(villianId, connection);

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {villainName}");
                    PrintNames(villianId, connection);
                }
                connection.Close();
            }
        }

        private static void PrintNames(int villianId, SqlConnection connection)
        {
            string minionsSql =
                "SELECT Name, Age FROM Minions AS m JOIN MinionsVillains AS mv ON mv.MinionId = m.Id WHERE mv.VillainId = @Id";

            using (SqlCommand command = new SqlCommand(minionsSql, connection))
            {
                command.Parameters.AddWithValue("Id", villianId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        int counter = 1;
                        while (reader.Read())
                        {
                            Console.WriteLine($"{counter++}. {reader[0]} {reader[1]}");
                        }
                    }
                }
            }
        }

        private static string GetVillainName(int villainId, SqlConnection connection)
        {
            string nameSql = "SELECT Name FROM Villains WHERE Id = @id";

            using (SqlCommand command = new SqlCommand(nameSql, connection))
            {
                command.Parameters.AddWithValue("@id", villainId);
                return (string)command.ExecuteScalar();
            }
        }
    }
}
