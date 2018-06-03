namespace RegExGenerator
{
    static class Characters
    {
        public static string Digits { get; } = "0123456789";

        public static string Letters { get; } = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        public static string WhiteSpaces { get; } = "\t\r\n ";

        public static string Symbols { get; } = "!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{{|}}~";

        public static string WordChars { get; } = $"{Letters}{Digits}_";

        public static string NonDigits { get; } = $"{WhiteSpaces}{Symbols}{Letters}";

        public static string NonWordChars { get; } = $"{WhiteSpaces}{Symbols}{Digits}";

        public static string NonWhiteSpaces { get; } = $"{Symbols}{Digits}{Letters}";

        public static string AllChars { get; } = $"{WhiteSpaces}{Symbols}{Digits}{Letters}";
    }
}
