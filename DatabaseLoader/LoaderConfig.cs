namespace DatabaseLoader
{
    public class LoaderConfig
    {
        public string ConnectionString { get; set; }
        public string ModulesFolder { get; set; }

        public LoaderConfig() { }
        public LoaderConfig(string connectionString, string modulesFolder)
        {
            ConnectionString = connectionString;
            ModulesFolder = modulesFolder;
        }
    }
}
