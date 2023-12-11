namespace EasyCode
{
    internal class Input
    {
        // get an input from keyboard and return an object
        public static object Get () => Console.ReadKey() switch
        {
            // convert in char then check if is a number
            ConsoleKeyInfo k when char.IsNumber(k.KeyChar) => int.Parse(k.KeyChar.ToString()),
            // convert in char then check if is a letter
            ConsoleKeyInfo k when char.IsLetter(k.KeyChar) => k.KeyChar.ToString(),
            // convert in char
            ConsoleKeyInfo k when char.IsLetter(k.KeyChar) => k.KeyChar,
            // if is not a char return the key
            ConsoleKeyInfo k => k
        };

        // get an input from keyboard and return a bool or null
        public static bool? GetArrow () => Console.ReadKey().Key switch
        {
            // when is up arrow return true
            ConsoleKey k when k is ConsoleKey.UpArrow => true,
            // when is down arrow return false
            ConsoleKey k when k is ConsoleKey.DownArrow => false,
            // else return null
            _ => null
        };

        // get an input from keyboard and return a type
        public static Type KeyType () => Console.ReadKey() switch
        {
            ConsoleKeyInfo k when char.IsNumber(k.KeyChar) => typeof(int),
            ConsoleKeyInfo k when char.IsLetter(k.KeyChar) => typeof(char),
            ConsoleKeyInfo k => k.Key.GetType(),
        };
    }


    internal class Output
    {

        /// <summary> Print every parameter on console </summary>
        public static void Log (params object[] args) => Console.WriteLine(string.Join(" ", args));

        /// <summary> Change Console background color </summary>
        /// <param name="color">color to set</param>
        public static void ColorBG (ConsoleColor color) => Console.BackgroundColor = color;

        /// <summary> Change Console text color </summary>
        /// <param name="color">color to set</param>
        public static void ColorTX (ConsoleColor color) => Console.ForegroundColor = color;

        /// <summary> Change Console background and text color </summary>
        /// <param name="back">background color to set</param>
        /// <param name="fore">foreground color to set</param>
        public static void Color (ConsoleColor back, ConsoleColor fore) { ColorBG(back); ColorTX(fore); }

        /// <summary> Reset default console colors </summary>
        public static void ColorReset () { ColorBG(ConsoleColor.Black); ColorTX(ConsoleColor.White); }
    }
}