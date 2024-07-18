using System;
using System.Data.SQLite;
using static System.Formats.Asn1.AsnWriter;

namespace HangmanCUI
{
    internal class DBManager
    {
        private string _connectionString;
        
        public DBManager(string dBPath)
        {
            _connectionString = "Data Source=" + dBPath + ";Version=3";
        }

        public string PickWord(char difficulty)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                var query = $"SELECT Word FROM words WHERE difficulty = {difficulty}";

                connection.Open();

                var cmd = new SQLiteCommand(query, connection);
                var reader = cmd.ExecuteReader();

                var words = new List<string>();
                while (reader.Read())
                { 
                    var word = reader.GetString(0);
                    words.Add(word);
                }

                connection.Close();

                var random = new Random();
                var index = random.Next(words.Count);

                return words[index];
            }
        }

        public List<string> LoadIDs()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                var query = $"SELECT ID FROM saves";

                connection.Open();

                var cmd = new SQLiteCommand(query, connection);
                var reader = cmd.ExecuteReader();

                var IDs = new List<string>();
                while (reader.Read())
                {
                    var id = reader.GetString(0);
                    IDs.Add(id);
                }

                connection.Close();

                return IDs;
            }
        }

        public void SaveGame(string id, int lives, string word, char[] hiddenWord, List<char> usedLetters, int score, char difficulty)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                string query = "INSERT INTO saves (ID, Lives, Word, HiddenWord, UsedLetters, Score, Difficulty) VALUES (@id, @lives, @word, @hiddenWord, @usedLetters, @score, @difficulty)";

                connection.Open();

                var cmd = new SQLiteCommand(query, connection);

                using (var transaction = connection.BeginTransaction())
                {
                    using (cmd)
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@lives", lives);
                        cmd.Parameters.AddWithValue("@word", word);
                        cmd.Parameters.AddWithValue("@hiddenWord", new string(hiddenWord));
                        cmd.Parameters.AddWithValue("@usedLetters", new string(usedLetters.ToArray()));
                        cmd.Parameters.AddWithValue("@score", score);
                        cmd.Parameters.AddWithValue("@difficulty", difficulty.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    transaction.Commit();
                }

                connection.Close();
            }
        }

        public List<string> GetSaves()
        {
            var savesList = new List<string>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                string query = $"SELECT * FROM saves";

                connection.Open();

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string save = "";
                            for (int i = 0; i < reader.FieldCount; ++i)
                            {
                                save += $"{reader[i]}\\";
                            }
                            savesList.Add(save.TrimEnd('\\'));
                        }
                    }
                }
                connection.Close();
            }

            return savesList;
        }

        public List<string> LoadGame(string id)
        {
            var gameInfo = new List<string>();

            using (var connection = new SQLiteConnection(_connectionString))
            {
                string query = $"SELECT * FROM saves WHERE ID = @id";

                connection.Open();

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 1; i < reader.FieldCount; ++i)
                            {
                                gameInfo.Add(reader.GetValue(i).ToString());
                            }
                        }
                    }
                }

                connection.Close();
            }

            return gameInfo;
        }

        public void DeleteSave(string id)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                string query = $"DELETE FROM saves WHERE ID = @id";

                connection.Open();

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
