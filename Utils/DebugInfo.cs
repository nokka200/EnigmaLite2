namespace EnigmaLite2.Utils
{
    /// <summary>
    /// Represenst a static class that has methods for debug printing to console.
    /// </summary>
    static public class DebugInfo
    {
        /// <summary>
        /// Prints the function to be called and time
        /// </summary>
        /// <param name="funcToCall">Functions name</param>
        public static void DebugPrintFunCall(string funcToCall)
        {
            var dateObj = DateTime.Now;
            Console.WriteLine($"{dateObj} Calling {funcToCall}");
        }

        /// <summary>
        /// Prints variables with time
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="variableToPrint">Variables value</param>
        /// <param name="variableName">Variables name</param>
        public static void DebugPrintVari<T>(T variableToPrint, string variableName)
        {
            var dateObj = DateTime.Now;
            Console.WriteLine($"{dateObj}: {variableName}: {variableToPrint}");
        }

        /// <summary>
        /// Prints a collection with time
        /// </summary>
        /// <typeparam name="T">List's type</typeparam>
        /// <param name="itemToLoop">List to print</param>
        /// <param name="listName">List variables name</param>
        public static void DebugPrintCollection<T>(List<T> itemToLoop, string listName)
        {
            var dateObj = DateTime.Now;
            Console.WriteLine($"{dateObj}: {listName} :");

            foreach (var item in itemToLoop)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
