using System;
namespace EnigmaLite2.Logic
{
    public class EnigmaEngine
    {
        Rotor firstRotor;
        Rotor secondRotor;
        Rotor thirdRotor;
        Reflector reflector;

        // constructor
        public EnigmaEngine(int[] rotors, int reflectorToUse)
        {
            firstRotor = new(rotors[0]);
            secondRotor = new(rotors[1]);
            thirdRotor = new(rotors[2]);
            reflector = new(reflectorToUse);
        }

        public string? ScrambleSentence(string sentenceToScramble)
        {
            // TODO: Rotor luokan samanniminen pitää refaktoroida tänne
            return string.Empty;
        }
    }
}