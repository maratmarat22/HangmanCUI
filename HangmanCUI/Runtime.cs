namespace HangmanCUI
{
    internal class Runtime
    {
        private static string _settingsFilePath = @"..\..\..\Settings\Settings.txt";
        private static string _DBPath = @"..\..\..\DB\DBHangman.db";

        public static void Run()
        {
            var settingsManager = new SettingsManager(_settingsFilePath);

            switch (settingsManager.LoadSettings())
            {
                case 1:
                    CUI.ThrowErrorMessage(1, "Settings file does not exist");
                    Environment.Exit(0);
                    break;
                case 2:
                    CUI.ThrowErrorMessage(2, "Settings file is defected");
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            var dBManager = new DBManager(_DBPath);

            while (true)
            {
                var option = CUI.ThrowMainMenu();

                switch (option)
                {
                    case "1":
                        var difficulty = CUI.ThrowDifficultyMenu();
                        var gameplay = new Gameplay(settingsManager.settings, dBManager, difficulty);
                        gameplay.Init();
                        break;

                    case "2":
                        var saves = dBManager.GetSaves();
                        if (saves.Count == 0)
                        {
                            CUI.ThrowNSMessage();
                            break;
                        }

                        var id = CUI.ThrowSavesMenu(saves);
                        if (id != "0")
                        {
                            var gameInfo = dBManager.LoadGame(id);
                            if (gameInfo.Count != 0)
                            {
                                dBManager.DeleteSave(id);
                                var gameplay1 = new Gameplay(settingsManager.settings, dBManager, '0');
                                gameplay1.Continue(gameInfo);
                            }
                            else
                            {
                                CUI.ThrowErrorMessage(3, "ID not found");
                            }
                        }
                        break;

                    case "3":
                        char settingsOption;
                        while (true)
                        {
                            settingsOption = CUI.ThrowSettingsMenu(settingsManager.settings);
                            if (settingsOption != '0')
                            {
                                settingsManager.SwitchParam(settingsOption - '0' - 1);
                                settingsManager.LoadSettings();
                            }
                            else break;
                        }
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
