using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using _02.VillainNames;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] minionsId = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(DBConfig.ConnectionString))
            {
                connection.Open();

                foreach (var minionId in minionsId)
                {
                    UpdateMInionAgeAndName(minionId, connection);
                }

                PrintNames(connection);
                connection.Close();
            }
        }
        private static void PrintNames(SqlConnection connection)
        {
            string minionsSql = "SELECT Name, Age FROM Minions";

            using (SqlCommand command = new SqlCommand(minionsSql, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }
        }
        private static void UpdateMInionAgeAndName(int minionId, SqlConnection connection)
        {
            string minionName = GetMinionName(minionId, connection);
            UpdateAge(minionId, connection);
            UpdateName(minionName, minionId, connection);
        }

        private static void UpdateName(string minionName, int minionId, SqlConnection connection)
        {
            string updateNameSql = "UPDATE Minions SET Name = @name WHERE Id = @id";
            string[] names = minionName.Split();

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = UppercaseFirst(names[i]);
                builder.Append(names[i] + ' ');
            }

            minionName = builder.ToString().Trim();
            using (SqlCommand command = new SqlCommand(updateNameSql, connection))
            {
                command.Parameters.AddWithValue("@id", minionId);
                command.Parameters.AddWithValue("@name", minionName);
                command.ExecuteNonQuery();
            }
        }

        private static void UpdateAge(int minionId, SqlConnection connection)
        {
            string ageSql = "UPDATE Minions SET Age += 1 WHERE Id = @id";

            using (SqlCommand command = new SqlCommand(ageSql, connection))
            {
                command.Parameters.AddWithValue("@id", minionId);
                command.ExecuteNonQuery();
            }
        }

        private static string GetMinionName(int minionId, SqlConnection connection)
        {
            string nameSql = "SELECT Name FROM Minions WHERE Id = @id";

            using (SqlCommand command = new SqlCommand(nameSql, connection))
            {
                command.Parameters.AddWithValue("@id", minionId);
                return (string)command.ExecuteScalar();
            }
        }
        private static string UppercaseFirst(string s)
        {
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
