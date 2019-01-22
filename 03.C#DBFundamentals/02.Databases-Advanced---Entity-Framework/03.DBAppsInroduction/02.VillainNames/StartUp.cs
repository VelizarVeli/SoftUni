using System;
using System.Data.SqlClient;

namespace _02.VillainNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(DBConfig.ConnectionString))
            {
                connection.Open();
                string villianNames = "SELECT v.Name, COUNT(mv.MinionId) AS MinionsCount FROM Villains AS v JOIN MinionsVillains AS mv ON mv.VillainId = v.Id GROUP BY v.Name HAVING COUNT(MinionId) > 3 ORDER BY MinionsCount DESC";

                using (SqlCommand command = new SqlCommand(villianNames,connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]}");
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
