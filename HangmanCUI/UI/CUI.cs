namespace HangmanCUI
{
    internal class CUI
    {
        public static string? ThrowMainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Start");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Settings");
            Console.WriteLine("4. Exit");

            var option = Console.ReadLine();

            return option;
        }

        public static char ThrowDifficultyMenu()
        {
            Console.WriteLine("Select Difficulty");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Hard");
            Console.WriteLine("3. German");

            var validOptions = "123";

            var option = Console.ReadLine();
            while (!OptionValidator.IsValid(option, validOptions))
            {
                Console.WriteLine("Invalid Option");
                option = Console.ReadLine();
            }

            return option[0];
        }

        public static char ThrowSettingsMenu(Dictionary<string, bool> settings)
        {
            Console.WriteLine("Settings");

            var i = 1;
            foreach (var pair in settings)
            {
                string status;

                if (pair.Value == true)
                {
                    status = "enabled";
                }
                else
                {
                    status = "disabled";
                }
                Console.WriteLine($"{i}. {pair.Key} - {status}");
                
                ++i;
            }
            
            Console.WriteLine("0. Back to Main Menu");

            var validOptions = "012";

            var option = Console.ReadLine();
            while (!OptionValidator.IsValid(option, validOptions))
            {
                Console.WriteLine("Invalid Option");
                option = Console.ReadLine();
            }

            return option[0];
        }

        public static void ThrowErrorMessage(int errCode, string errDesc)
        {
            Console.WriteLine($"Error {errCode}: {errDesc}");
        }

        public static string GetID(List<string> IDs)
        {
            Console.WriteLine("Create your session's ID");
            var id = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(id) || id == "0" || IDs.Contains(id))
            {
                Console.WriteLine("Invalid or already used ID");
                id = Console.ReadLine();
            }

            return id;
        }

        public static string ThrowSavesMenu(List<string> saves)
        {   
            foreach(var save in saves)
            {
                var saveParts = save.Split('\\');

                string difficulty = "";
                switch (int.Parse(saveParts[6]))
                {
                    case 1:
                        difficulty = "easy";
                        break;
                    case 2:
                        difficulty = "hard";
                        break;
                    case 3:
                        difficulty = "german";
                        break;
                }

                Console.WriteLine($"id: {saveParts[0]}, lives: {saveParts[1]}, hidden word: {saveParts[3]}, score: {saveParts[5]}, difficulty: {difficulty}");
            }

            Console.WriteLine("Enter your ID to continue:");
            var option = Console.ReadLine();

            while (string.IsNullOrEmpty(option))
            {
                Console.WriteLine("Invalid option");
            }

            return option;
        }

        public static void ThrowNSMessage()
        {
            Console.WriteLine("No saves");
        }
    }
}
