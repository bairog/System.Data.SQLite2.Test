using System.Data.SQLite;

namespace System.Data.SQLite2.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new SQLiteConnectionStringBuilder();
            builder.DataSource = "test.db";
            using (var conn = new SQLiteConnection(builder.ToString()))
            using (var comand = conn.CreateCommand())
            {
                conn.Open();
                comand.CommandText = "SELECT NameValue from Products";
                using (var reader = comand.ExecuteReader())
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0));
                    }
            }
            Console.ReadKey();
        }
    }
}
