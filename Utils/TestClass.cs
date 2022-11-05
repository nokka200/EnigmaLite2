using EnigmaLite2.Logic;

namespace EnigmaLite2.Utils
{
    static public class TestClass
    {
        const int MAX_ARGS = 3;

        public static int TestRotors(string[] args)
        {
            bool re;

            // argument checker
            ArgumentCheck argObj = new(args, MAX_ARGS, "<SCRAMBLE><ROTORS><REFLECTOR>");

            re = argObj.CheckArgs();
            if (!re)
            {
                return -1;
            }

            Rotor rotorObj = new(0);

            rotorObj.ScrambleSentence(args[0]);

            return 0;
        }

        /// <summary>
        /// Testataan EnigmaEngine yhden kirjaimen sekoittamista
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int TestEnigmaEngine(string[] args)
        {
            bool re;
            string temp;

            // argument checker
            ArgumentCheck argObj = new(args, MAX_ARGS, "<SCRAMBLE><ROTORS><REFLECTOR>");

            re = argObj.CheckArgs();
            if (!re)
            {
                return -1;
            }

            EnigmaEngine enigmaObj = new();

            temp = enigmaObj.ScrambleLetter(args[0]);

            Console.WriteLine("Tulos: " + temp);

            return 0;
        }
    }
}
