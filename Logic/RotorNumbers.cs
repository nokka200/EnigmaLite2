namespace EnigmaLite2.Logic
{
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

    }
}
