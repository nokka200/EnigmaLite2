namespace EnigmaLite2.Utils
{
    /// <summary>
    /// Represents an argument checker for the engima machine class
    /// </summary>
    public class ArgumentCheck
    {
        readonly string[] argsToCheck;
        readonly int argsLen;
        readonly string? correctFormat;
        ConsoleColor currentFg = Console.ForegroundColor;

        public ArgumentCheck(string[] argsToCheck, int argsLen, string? correctFormat)
        {
            this.argsToCheck = argsToCheck;
            this.argsLen = argsLen;
            this.correctFormat = correctFormat;
        }

        public bool CheckArgs()
        {
            // this methold holds all the private methods for cheching the args
            if (CheckLenght())
            {
                return false;
            }
            if (CheckIfInt())
            {
                return false;
            }

            return true;
        }

        bool CheckLenght()
        {
            if (argsToCheck.Length != argsLen)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid argument amount");
                Console.WriteLine($"{correctFormat}");
                Console.ForegroundColor = currentFg;
                return true;
            }
            else
            {
                return false;
            }
        }

        bool CheckIfInt()
        {
            // checks if second args are all convertable to ints
            bool re;

            foreach (var item in argsToCheck[1])
            {
                re = int.TryParse(item.ToString(), out int temp);
                if (!re)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Unable to parse: {item}");
                    Console.ForegroundColor = currentFg;
                    return true;
                }
            }
            return false;
        }
    }
}