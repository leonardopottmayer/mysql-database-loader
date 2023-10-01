namespace DatabaseLoader
{
    public class FileSeparator
    {
        private readonly string _folderPath;

        public FileSeparator(string folderPath)
        {
            _folderPath = folderPath;
        }

        public IEnumerable<string> GetTables()
        {
            DirectoryInfo modulesDirectory = new DirectoryInfo(_folderPath);
            DirectoryInfo[] subdirectories = modulesDirectory.GetDirectories();

            List<string> tableFiles = new List<string>();

            foreach (DirectoryInfo subdirectory in subdirectories)
            {
                string[] sqlFiles = Directory.GetFiles(subdirectory.FullName, "*.sql");

                foreach (string sqlFile in sqlFiles)
                {
                    if (sqlFile.Contains("_tables.sql"))
                        tableFiles.Add(sqlFile);
                }
            }

            return tableFiles;
        }

        public IEnumerable<string> GetConstraints()
        {
            DirectoryInfo modulesDirectory = new DirectoryInfo(_folderPath);
            DirectoryInfo[] subdirectories = modulesDirectory.GetDirectories();

            List<string> constraintFiles = new List<string>();

            foreach (DirectoryInfo subdirectory in subdirectories)
            {
                string[] sqlFiles = Directory.GetFiles(subdirectory.FullName, "*.sql");

                foreach (string sqlFile in sqlFiles)
                {
                    if (sqlFile.Contains("_constraints.sql"))
                        constraintFiles.Add(sqlFile);
                }
            }

            return constraintFiles;
        }
    }
}
