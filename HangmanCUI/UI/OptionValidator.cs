namespace HangmanCUI
{
    internal class OptionValidator
    {
        public static bool IsValid(string? option, string validOptions)
        {
            return !string.IsNullOrWhiteSpace(option) && option.Length == 1 && validOptions.Contains(option[0]);
        }
    }
}
