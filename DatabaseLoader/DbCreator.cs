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

        public void ExecuteFiles(IEnumerable<string> sqlFiles)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                foreach (string sqlFile in sqlFiles)
                {
                    try
                    {
                        string sqlScript = File.ReadAllText(sqlFile);

                        var cmd = connection.CreateCommand();
                        cmd.CommandText = sqlScript;
                        cmd.ExecuteNonQuery();

                        Console.WriteLine($"Executado o script: {Path.GetFileName(sqlFile)}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao executar o script {Path.GetFileName(sqlFile)}: {ex.Message}");
                    }
                }

                connection.Close();
            }
        }
    }
}
