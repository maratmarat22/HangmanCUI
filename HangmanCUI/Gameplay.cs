namespace HangmanCUI
{
    internal class Gameplay
    {
        private Dictionary<string, bool> _settings;
        private char _difficulty;
        private int _score = 0;
        private DBManager _dBManager;

        public Gameplay(Dictionary<string, bool> settings, DBManager dBManager, char difficulty)
        {
            _settings = settings;
            _difficulty = difficulty;
            _dBManager = dBManager;
        }

        public void Init()
        {
            var lives = _difficulty == '3' ? 10 : 6;
            var word = _dBManager.PickWord(_difficulty);
            var hiddenWord = Enumerable.Repeat('_', word.Length).ToArray();
            var usedLetters = new List<char>();

            Start(lives, word, hiddenWord, usedLetters);
        }

        public void Continue(List<string> gameInfo)
        { 
            var lives = int.Parse(gameInfo.ElementAt(0));
            var word = gameInfo.ElementAt(1);
            var hiddenWord = gameInfo.ElementAt(2).ToCharArray();
            var usedLetters = new List<char>();
            usedLetters.AddRange(gameInfo.ElementAt(3));
            _score = int.Parse(gameInfo.ElementAt(4));
            _difficulty = gameInfo.ElementAt(5)[0];

            Start(lives, word, hiddenWord, usedLetters);
        }

        public void Start(int lives, string word, char[] hiddenWord, List<char> usedLetters)
        {
            var violence = _settings["violence"];
            var drawer = new Drawer(violence);

            while (true)
            {
                Console.WriteLine(word);

                var option = char.ToLower(GameUI.ThrowGameUI(lives, drawer, hiddenWord, _score));

                if (option == '0')
                {
                    var IDs = _dBManager.LoadIDs();
                    var id = CUI.GetID(IDs);
                    _dBManager.SaveGame(id, lives, word, hiddenWord, usedLetters, _score, _difficulty);
                    break;
                }

                var guessCount = 0;
                for (int i = 0; i < word.Length; ++i)
                {
                    if (option == char.ToLower(word[i]))
                    {
                        hiddenWord[i] = option;
                        ++guessCount;
                    }
                }

                if (guessCount == 0)
                {
                    if (usedLetters.Contains(option))
                    {
                        GameUI.ThrowYHAUTLMessage();
                    }
                    else
                    {
                        usedLetters.Add(option);
                        --lives;
                    }
                }

                if (lives == 0)
                {
                    GameUI.ThrowEndgameMessage("lose.", word);
                    break;
                }

                if (!hiddenWord.Contains('_'))
                {
                    GameUI.ThrowEndgameMessage("won!", word);
                    ++_score;
                    Init();
                }
            }
        }
    }
}
