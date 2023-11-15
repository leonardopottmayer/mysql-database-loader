namespace DatabaseLoader
{
    public class DbFiles
    {
        public ICollection<string> TableFiles { get; private set; }
        public ICollection<string> ConstraintFiles { get; private set; }
        public ICollection<string> SeedFiles { get; private set; }
        public ICollection<string> TruncateFiles { get; private set; }
        public ICollection<string> DropFiles { get; private set; }

        public DbFiles(ICollection<string> tableFiles, ICollection<string> constraintFiles, ICollection<string> seedFiles, ICollection<string> truncateFiles, ICollection<string> dropFiles)
        {
            TableFiles = tableFiles;
            ConstraintFiles = constraintFiles;
            SeedFiles = seedFiles;
            TruncateFiles = truncateFiles;
            DropFiles = dropFiles;
        }
    }
}
