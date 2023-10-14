namespace DatabaseLoader
{
    public class Menu
    {
        #region Attributes
        private static Dictionary<string, string> _operations = new Dictionary<string, string>()
        {
            { "1", "Create tables (something_tables.sql)" },
            { "2", "Seed data (something_seed.sql)" },
            { "3", "Create constraints (something_constraints.sql)" },
        };
        #endregion

        #region Operations
        public static string[] AskForOperation()
        {
            Console.WriteLine(">>>>>Available operations");

            PrintOperationOptions();

            string[] choosenOperations = GetChoosenOperations();

            if (choosenOperations.Length < 1)
                throw new ArgumentException("No operation selected");

            return choosenOperations;
        }

        private static void PrintOperationOptions()
        {
            string operationOptions = string.Empty;

            foreach (var item in _operations)
                operationOptions += $"{item.Key} -> {item.Value}\n";

            Console.WriteLine(operationOptions);
        }

        private static string[] GetChoosenOperations()
        {
            Console.Write(">>>>>Type the desired operations (splitted by ';'): ");

            string rawOperationsString = Console.ReadLine();

            Console.Clear();

            string[] splittedOperationCodes = rawOperationsString.Split(";");

            return splittedOperationCodes;
        }
        #endregion
    }
}
