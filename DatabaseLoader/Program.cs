namespace DatabaseLoader
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = "Server=localhost;Port=3306;Database=gowther;User=root;Password=admin;";
            //string mainProjectFolder = "S:\\API\\gowther-api\\database\\objects\\modules";

            Console.WriteLine("Type the MySQL connection string");
            string connectionString = Console.ReadLine();

            Console.WriteLine("Type the project modules folder path");
            string modulesFolder = Console.ReadLine();

            FileSeparator fileSeparator = new FileSeparator(modulesFolder);
            DbCreator dbCreator = new DbCreator(connectionString);

            var tableFiles = fileSeparator.GetTables();
            var constraintFiles = fileSeparator.GetConstraints();

            dbCreator.CreateTables(tableFiles);
            dbCreator.CreateConstraints(constraintFiles);

            Console.WriteLine("All the SQL scripts were executed.");
        }
    }
}