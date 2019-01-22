using System;
using System.Data.SqlClient;
using _02.VillainNames;

namespace _09.IncreaseAgeStProc
{
    class Program
    {
        static void Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(DBConfig.ConnectionString))
            {
                connection.Open();

                ExecStoredProc(minionId, connection);
                PrintMinion(minionId, connection);
                connection.Close();
            }
        }

        private static void PrintMinion(int minionId, SqlConnection connection)
        {
            string selectMinionNameAndAgeSql = "SELECT Name, Age FROM Minions WHERE Id = @minionId";
            using (SqlCommand command = new SqlCommand(selectMinionNameAndAgeSql, connection))
            {
                command.Parameters.AddWithValue("@minionId", minionId);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} - {reader[1]} years old");
                    }
                }
            }
        }

        private static void ExecStoredProc(int minionId, SqlConnection connection)
        {
            string execProcSql = "EXEC usp_GetOlder @id";

            using (SqlCommand command = new SqlCommand(execProcSql, connection))
            {
                command.Parameters.AddWithValue("@id", minionId);
                command.ExecuteNonQuery();
            }
        }
    }
}
