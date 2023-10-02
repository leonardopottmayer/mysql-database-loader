namespace DatabaseLoader
{
    public class FileSeparator
    {
        private readonly string _folderPath;

        public FileSeparator(string folderPath)
        {
            _folderPath = folderPath;
        }

        public DbFiles GetFiles()
        {
            List<string> tableFiles = new List<string>();
            List<string> constraintFiles = new List<string>();
            List<string> seedFiles = new List<string>();

            DirectoryInfo modulesDirectory = new DirectoryInfo(_folderPath);
            DirectoryInfo[] subdirectories = modulesDirectory.GetDirectories();

            foreach (DirectoryInfo subdirectory in subdirectories)
            {
                string[] sqlFiles = Directory.GetFiles(subdirectory.FullName, "*.sql");

                foreach (string sqlFile in sqlFiles)
                {
                    if (sqlFile.Contains("_tables.sql"))
                        tableFiles.Add(sqlFile);
                    else if (sqlFile.Contains("_constraints.sql"))
                        constraintFiles.Add(sqlFile);
                    else if (sqlFile.Contains("_seed.sql"))
                        seedFiles.Add(sqlFile);
                }
            }

            var files = new DbFiles(tableFiles, constraintFiles, seedFiles);

            return files;
        }
    }
}
