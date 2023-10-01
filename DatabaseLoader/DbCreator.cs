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

        public void CreateTables(IEnumerable<string> tableFiles)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                foreach (string tableFile in tableFiles)
                {
                    try
                    {
                        string sqlScript = File.ReadAllText(tableFile);

                        var cmd = connection.CreateCommand();
                        cmd.CommandText = sqlScript;
                        cmd.ExecuteNonQuery();

                        Console.WriteLine($"Executado o script: {Path.GetFileName(tableFile)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao executar o script {Path.GetFileName(tableFile)}: {ex.Message}");
                    }
                }

                connection.Close();
            }
        }

        public void CreateConstraints(IEnumerable<string> constraintFiles)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                foreach (string constraintFile in constraintFiles)
                {
                    try
                    {
                        string sqlScript = File.ReadAllText(constraintFile);

                        var cmd = connection.CreateCommand();
                        cmd.CommandText = sqlScript;
                        cmd.ExecuteNonQuery();

                        Console.WriteLine($"Executado o script: {Path.GetFileName(constraintFile)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao executar o script {Path.GetFileName(constraintFile)}: {ex.Message}");
                    }
                }

                connection.Close();
            }
        }
    }
}
