namespace HangmanCUI
{
    internal class Drawer
    {
        private bool _violence;

        public Drawer(bool violence)
        {
            _violence = violence;    
        }
        
        private char[,] _hangman = { { ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' },
                                     { ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' },
                                     { ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' },
                                     { ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' },
                                     { ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' },
                                     { ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' ' } };

        public void DrawHangman(int lives)
        {
            if (_violence)
            {
                switch (lives)
                {
                    case 10:
                        break;

                    case 9:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';
                        break;

                    case 8:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';
                        break;

                    case 7:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';

                        _hangman[0, 1] = '*';
                        _hangman[0, 2] = '-';
                        _hangman[0, 3] = '-';
                        _hangman[0, 4] = '-';
                        _hangman[0, 5] = '-';
                        _hangman[0, 6] = '*';
                        break;

                    case 6:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';

                        _hangman[0, 1] = '*';
                        _hangman[0, 2] = '-';
                        _hangman[0, 3] = '-';
                        _hangman[0, 4] = '-';
                        _hangman[0, 5] = '-';
                        _hangman[0, 6] = '*';

                        _hangman[1, 1] = '|';
                        break;

                    case 5:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';

                        _hangman[0, 1] = '*';
                        _hangman[0, 2] = '-';
                        _hangman[0, 3] = '-';
                        _hangman[0, 4] = '-';
                        _hangman[0, 5] = '-';
                        _hangman[0, 6] = '*';

                        _hangman[1, 1] = '|';

                        _hangman[2, 1] = 'O';
                        break;

                    case 4:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';

                        _hangman[0, 1] = '*';
                        _hangman[0, 2] = '-';
                        _hangman[0, 3] = '-';
                        _hangman[0, 4] = '-';
                        _hangman[0, 5] = '-';
                        _hangman[0, 6] = '*';

                        _hangman[1, 1] = '|';

                        _hangman[2, 1] = 'O';
                        _hangman[3, 1] = '|';
                        break;

                    case 3:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';

                        _hangman[0, 1] = '*';
                        _hangman[0, 2] = '-';
                        _hangman[0, 3] = '-';
                        _hangman[0, 4] = '-';
                        _hangman[0, 5] = '-';
                        _hangman[0, 6] = '*';

                        _hangman[1, 1] = '|';

                        _hangman[2, 1] = 'O';
                        _hangman[3, 1] = '|';
                        _hangman[3, 0] = '/';
                        break;

                    case 2:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';

                        _hangman[0, 1] = '*';
                        _hangman[0, 2] = '-';
                        _hangman[0, 3] = '-';
                        _hangman[0, 4] = '-';
                        _hangman[0, 5] = '-';
                        _hangman[0, 6] = '*';

                        _hangman[1, 1] = '|';

                        _hangman[2, 1] = 'O';
                        _hangman[3, 1] = '|';
                        _hangman[3, 0] = '/';
                        _hangman[3, 2] = '\\';
                        break;

                    case 1:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';

                        _hangman[0, 1] = '*';
                        _hangman[0, 2] = '-';
                        _hangman[0, 3] = '-';
                        _hangman[0, 4] = '-';
                        _hangman[0, 5] = '-';
                        _hangman[0, 6] = '*';

                        _hangman[1, 1] = '|';

                        _hangman[2, 1] = 'O';
                        _hangman[3, 1] = '|';
                        _hangman[3, 0] = '/';
                        _hangman[3, 2] = '\\';
                        _hangman[4, 0] = '/';
                        break;

                    case 0:
                        _hangman[5, 4] = '=';
                        _hangman[5, 5] = '=';
                        _hangman[5, 6] = '=';
                        _hangman[5, 7] = '=';
                        _hangman[5, 8] = '=';

                        _hangman[4, 6] = '|';
                        _hangman[3, 6] = '|';
                        _hangman[2, 6] = '|';
                        _hangman[1, 6] = '|';

                        _hangman[0, 1] = '*';
                        _hangman[0, 2] = '-';
                        _hangman[0, 3] = '-';
                        _hangman[0, 4] = '-';
                        _hangman[0, 5] = '-';
                        _hangman[0, 6] = '*';

                        _hangman[1, 1] = '|';

                        _hangman[2, 1] = 'O';
                        _hangman[3, 1] = '|';
                        _hangman[3, 0] = '/';
                        _hangman[3, 2] = '\\';
                        _hangman[4, 0] = '/';
                        _hangman[4, 2] = '\\';
                        break;
                }
            }

            for (int i = 0; i < _hangman.GetLength(0); ++i)
            {
                for (int j = 0; j < _hangman.GetLength(1); ++j)
                {
                    Console.Write(_hangman[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
