using EnigmaLite2.Utils;

namespace EnigmaLite2.Logic
{
    /// <summary>
    /// Represents an Enigma Engine cipher device
    /// </summary>
    public class EnigmaEngine
    {
        // fields
        readonly Rotor2 firstRotor;
        readonly Rotor2 secondRotor;
        readonly Rotor2 thirdRotor;
        readonly Reflector reflector;
        string scrambledLetter;

        // properties
        /// <summary>
        /// Enable console debug prints
        /// </summary>
        public bool Debug { get; set; }

        // constructor
        public EnigmaEngine(int first, int second, int third)
        {
            firstRotor = new(RotorNumbers.AllRotors[first]);
            secondRotor = new(RotorNumbers.AllRotors[second]);
            thirdRotor = new(RotorNumbers.AllRotors[third]);
            reflector = new(RotorNumbers.AllReflectors[0]);
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
            if (Debug)
                DebugInfo.DebugPrintFunCall("EnigmaEngine2.ScrambleLetter");

            string re;
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

        /// <summary>
        /// Change debug mode in rotor's and reflector.
        /// </summary>
        /// <param name="value">New check value</param>
        public void SetRotorsDebug(bool value)
        {
            firstRotor.Debug = value;
            secondRotor.Debug = value;
            thirdRotor.Debug = value;
            reflector.Debug = value;
        }
    }
}