namespace DatabaseLoader
{
    public class DbFiles
    {
        public ICollection<string> TableFiles { get; private set; }
        public ICollection<string> ConstraintFiles { get; private set; }
        public ICollection<string> SeedFiles { get; private set; }

        public DbFiles(ICollection<string> tableFiles, ICollection<string> constraintFiles, ICollection<string> seedFiles)
        {
            TableFiles = tableFiles;
            ConstraintFiles = constraintFiles;
            SeedFiles = seedFiles;
        }

    }
}
