using MySqlConnector;

namespace DatabaseLoader
{
    public class DbCreator
    {
        private readonly string _connectionString;

        public DbCreator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecuteFiles(IEnumerable<string> sqlFiles, bool disableKeyChecks = false)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                if (disableKeyChecks)
                    DisableMySQLKeyChecks(connection);

                foreach (string sqlFile in sqlFiles)
                {
                    try
                    {
                        string sqlScript = File.ReadAllText(sqlFile);
                        if (string.IsNullOrEmpty(sqlScript.Trim()))
                            continue;

                        var cmd = connection.CreateCommand();
                        cmd.CommandText = sqlScript;
                        cmd.ExecuteNonQuery();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Executed {Path.GetFileName(sqlFile)}");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error while executing script {Path.GetFileName(sqlFile)} \n Error: {ex.Message}");
                    }
                }

                connection.Close();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisableMySQLKeyChecks(MySqlConnection connection)
        {
            var cmd = connection.CreateCommand();

            cmd.CommandText = "SET foreign_key_checks = 0";

            cmd.ExecuteNonQuery();
        }
    }
}
