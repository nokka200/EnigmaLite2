using System;
namespace EnigmaLite2.Logic
{
    public class EnigmaEngine
    {
        // fields
        Rotor2 firstRotor;
        //Rotor2 secondRotor;
        //Rotor2 thirdRotor;
        Reflector reflector;
        string scrambledLetter;

        // constructor
        public EnigmaEngine()
        {
            firstRotor = new(RotorNumbers.rotor1O);
            reflector = new(RotorNumbers.ReflectorB);
            scrambledLetter = string.Empty;
        }

        //public methods

        /// <summary>
        /// Scrambles a sentance
        /// </summary>
        /// <param name="letterToScramble">Sentance to scramble</param>
        /// <returns>Scrambled sentence</returns>
        public string ScrambleLetter(string letterToScramble)
        {
            string re = string.Empty;
            letterToScramble = letterToScramble.ToUpper(); 

            foreach (var letter in letterToScramble)
            {
                firstRotor.MoveRotor();
                re = firstRotor.MoveLetterForward(letter.ToString());
                re = reflector.MoveLetterForward(re);
                scrambledLetter += firstRotor.MoveLetterBackwards(re);
            }
            return scrambledLetter;
        }
    }
}