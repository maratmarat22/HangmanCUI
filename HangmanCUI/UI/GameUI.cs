using System.Text;

namespace HangmanCUI
{
    internal class GameUI
    {
        public static char ThrowGameUI(int lives, Drawer drawer, char[] hiddenWord, int score)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Enter 0 to save & exit");
            Console.WriteLine($"Score: {score}");
            Console.Write("Lives: ");
            for (int i = 0; i < lives; ++i)
            {
                Console.Write("\u2665 ");
            }

            Console.WriteLine();
            drawer.DrawHangman(lives);

            Console.WriteLine(hiddenWord);

            Console.WriteLine("\nType a letter:");

            var option = Console.ReadLine();
            var validOptions = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя0";

            while (!OptionValidator.IsValid(option, validOptions))
            {
                Console.WriteLine("Invalid input");
                option = Console.ReadLine();
            }

            return option[0];
        }

        public static void ThrowYHAUTLMessage()
        {
            Console.WriteLine("You have already used this letter!");
        }

        public static void ThrowEndgameMessage(string status, string word)
        {
            Console.WriteLine($"You {status}");
            Console.WriteLine($"Hidden word was {word}");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
