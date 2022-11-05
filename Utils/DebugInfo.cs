namespace EnigmaLite2.Utils
{
    static public class DebugInfo
    {
        public static void DebugPrintFunCall(string funcToCall)
        {
            var dateObj = DateTime.Now;
            Console.WriteLine($"{dateObj} Calling {funcToCall}");
        }

        public static void DebugPrintVari<T>(T variableToPrint, string variableName)
        {
            var dateObj = DateTime.Now;
            Console.WriteLine($"{dateObj}: {variableName}: {variableToPrint}");
        }
    }
}
