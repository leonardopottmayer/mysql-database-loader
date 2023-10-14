namespace DatabaseLoader
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //string connectionString = "Server=localhost;Port=3306;Database=gowther;User=root;Password=admin;";
            //string mainProjectFolder = "S:\\API\\gowther-api\\database\\objects\\modules";

            string[] operationsList = Menu.AskForOperation();

            Console.WriteLine("Type the MySQL connection string");
            string connectionString = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Type the project modules folder path");
            string modulesFolder = Console.ReadLine();

            Console.Clear();

            FileSeparator fileSeparator = new FileSeparator(modulesFolder);
            DbCreator dbCreator = new DbCreator(connectionString);

            DbFiles files = fileSeparator.GetFiles();

            Console.WriteLine();

            if (operationsList.Contains("1"))
            {
                dbCreator.ExecuteFiles(files.TableFiles);
                Console.WriteLine();
            }

            if(operationsList.Contains("2"))
            {
                dbCreator.ExecuteFiles(files.SeedFiles);
                Console.WriteLine();
            }
            
            if(operationsList.Contains ("3"))
            {
                dbCreator.ExecuteFiles(files.ConstraintFiles);
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("All the SQL scripts were executed.");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------|mysql-database-loader|-------------------------");
        }
    }
}