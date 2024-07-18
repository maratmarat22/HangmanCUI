using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanCUI
{
    public class SettingsManager
    {
        private string _filePath;
        public Dictionary<string, bool> settings;

        public SettingsManager(string settingsFilePath)
        {
            _filePath = settingsFilePath;
            settings = new Dictionary<string, bool>();
        }

        public int LoadSettings()
        {
            if (!File.Exists(_filePath))
            {
                return 1;
            }

            foreach (var line in File.ReadAllLines(_filePath))
            {
                var parts = line.Split('=');

                if (parts.Length == 2 && int.TryParse(parts[1], out int value))
                {
                    if (value == 1)
                    {
                        settings[parts[0]] = true;
                    }
                    else
                    {
                        settings[parts[0]] = false;
                    }
                }
                else return 2;
            }

            return 0;
        }

        public void SwitchParam(int index)
        {
            var key = settings.Keys.ElementAt(index);
            int value;

            if (settings.Values.ElementAt(index) == true)
            {
                value = 0;
            }
            else
            {
                value = 1;
            }

            var lines = File.ReadAllLines(_filePath);
            lines[index] = key + "=" + value;
            
            File.WriteAllLines(_filePath, lines);
        }
    }
}
