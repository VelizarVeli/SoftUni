using System;
using System.Data.SqlClient;
using _02.VillainNames;

namespace _06.RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(DBConfig.ConnectionString))
            {
                connection.Open();

                villainId = CheckIfVillainExist(villainId, connection);
                if (villainId == 0)
                {
                    Console.WriteLine($"No such villain was found.");
                }
                else
                {
                    int minionsCount = GetMinionsCount(villainId, connection);
                    string villianName = GetVillainName(villainId, connection);
                    if (minionsCount == 0)
                    {
                        DeleteVillain(villainId, connection);
                    }
                    else
                    {
                        ReleaseMinions(villainId, connection);
                        DeleteVillain(villainId, connection);
                    }

                    Console.WriteLine($"{villianName} was deleted.");
                    Console.WriteLine($"{minionsCount} minions were released.");
                }
                connection.Close();
            }
        }

        private static string GetVillainName(int villainId, SqlConnection connection)
        {
            string getNameSql = "SELECT Name FROM Villains WHERE Id = @villainId";
            string villianName = string.Empty;
            using (SqlCommand command = new SqlCommand(getNameSql, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();

                return (string)command.ExecuteScalar();
            }
        }

        private static void ReleaseMinions(int villainId, SqlConnection connection)
        {
            string releaseMinionsSql = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(releaseMinionsSql, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
            }
        }

        private static void DeleteVillain(int villainId, SqlConnection connection)
        {
            string deleteVillainSql = "DELETE FROM Villains WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillainSql, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
            }
        }

        private static int GetMinionsCount(int villainId, SqlConnection connection)
        {
            string getCountSql = "SELECT COUNT(MinionId) FROM MinionsVillains WHERE VillainId = @Id";

            using (SqlCommand command = new SqlCommand(getCountSql, connection))
            {
                command.Parameters.AddWithValue("@Id", villainId);

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

        private static int CheckIfVillainExist(int villainId, SqlConnection connection)
        {
            string villainSql = "SELECT Id FROM Villains WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(villainSql, connection))
            {
                command.Parameters.AddWithValue("@Id", villainId);

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
