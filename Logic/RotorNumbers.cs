namespace EnigmaLite2.Logic
{
    /// <summary>
    /// This class holds all the rotors and reflectors that the EnigmaEngine need's for scrambling
    /// </summary>
    static public class RotorNumbers
    {
        // Rotors 
        public static readonly List<int> rotor1O = new() 
            // EKMFLGDQVZNTOWYHXUSPAIBRCJ
            {4, 10, 12, 5, 11, 6, 3, 16, 21, 25, 13, 19, 14, 22, 24, 7, 23, 20,
                18, 15, 0, 8, 1, 17, 2, 9};

        public static readonly List<int> rotor2O = new()
            // AJDKSIRUXBLHWTMCQGZNPYFVOE
            {0, 9, 3, 10, 18, 8, 17, 20, 23, 1, 11, 7, 22, 19, 12, 2, 16, 6, 25,
                13, 15, 14, 5, 21, 14, 4};

        public static readonly List<int> rotor3O = new()
            // BDFHJLCPRTXVZNYEIWGAKMUSQO  
            {1, 3, 5, 7, 9, 11, 2, 15, 17, 19, 23, 21, 25, 13, 24, 4, 8, 22, 6,
                0, 10, 12, 20, 18, 16, 14};

        // Reflectors
        public static readonly List<int> ReflectorB = new()
            //00Y 01R 02U 03H 04Q 05S 06L 07D 08P 09X 10N 11G 12O
            //13K 14M 15I 16E 17B 18F 19Z 20C 21W 22V 23J 24A 25T
            { 24, 17, 20, 7, 16, 18, 11, 3, 15, 23, 13, 6, 14, 10, 12, 8, 4, 1,
                5, 25, 2, 22, 21, 9, 0, 19};
    }
}
