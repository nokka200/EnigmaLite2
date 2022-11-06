using EnigmaLite2.Utils;

namespace EnigmaLite2.Logic
{
    public class Rotor2
    {
        // fields
        List<int> currentRotor;
        int currentRotorPos;

        // Standard alphabet
        static readonly List<string> Standard = new()
            {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
                "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        // properties
        public bool Debug {get; set;}

        public Rotor2(List<int> currentRotor, int currentRotorPos = 0)
        {
            this.currentRotor = currentRotor;
            this.currentRotorPos = currentRotorPos;
        }

        // public methods

        /// <summary>
        /// Salaa kirjaimen ja liikuttaa sitä eteenpäin
        /// </summary>
        /// <param name="letterToScramble">Kirjain joka salataan</param>
        /// <returns>Salattu kirjaimen</returns>
        public string MoveLetterForward(string letterToScramble)
        {
            if (Debug)
                DebugInfo.DebugPrintFunCall("Rotor2.MoveLetterForward");

            int letterPos;
            string? letter;
            
            // <-
            // Katso mikä on syötteen paikka Standard aakkosissa
            letterPos = GetStdPos(letterToScramble);

            // Vertaa mikä arvo on RotorX paikassa Y
            letterPos = GetRotorPosition(letterPos);

            // Hakee rotorX luvun avulla Standard aakkosista kirjaimen
            letter = GetStdLetter(letterPos);

            return letter;
        }

        /// <summary>
        /// Salaa kirjaimen ja liikuttaa sitä taaksepäin
        /// </summary>
        /// <param name="letterToScramble">Kirjain joka salataan</param>
        /// <returns>Salattu kirjaimen</returns>
        public string MoveLetterBackwards(string scrambledLetter)
        {
            int letterPos;
            string? letter;

            // ->
            // Hakee syötteen letter paikan Standard aakkosista
            letterPos = GetStdPos(scrambledLetter);
            // Katsoo mikä on syötteen letterPos paikka RotorX
            letterPos = GetNumberPosInRotor(letterPos);
            // vertaa mikä kirjain on Standard aakkosissa paikassa letterPos
            letter = GetStdLetter(letterPos);

            return letter;
        }

        public void MoveRotor(int times = 1)
        {
            // moves to rotor forward
            if (Debug)
                DebugInfo.DebugPrintFunCall("Rotor2.MoveRotor");

            for (int i = 0; i < times; i++)
            {
                currentRotor.Insert(0, currentRotor[currentRotor.Count - 1]);
                currentRotor.RemoveAt(currentRotor.Count - 1);
                currentRotorPos += 1;

                if (Debug)
                {
                    DebugInfo.DebugPrintVari(currentRotorPos, "rotorPos");
                    DebugInfo.DebugPrintCollection(currentRotor, "currentRotor");
                }
                    
            }
        }

        // private methods
        int GetStdPos(string letter)
        {
            // Katsoo mikä on syötteen paikka aakkosissa Standard
            if (Debug)
                DebugInfo.DebugPrintFunCall("Rotor2.GetStdPos");

            int pos;
            pos = Standard.IndexOf(letter);
            return pos;
        }

        int GetRotorPosition(int posToCheck)
        {
            // Vertaa mikä arvo on rotorX tai reflectorX paikassa postToCheck
            // Compares what value the rotor has at posToCheck
            if (Debug)
                DebugInfo.DebugPrintFunCall("Rotor2.GetRotorPosition");

            int valueAt;
            valueAt = currentRotor[posToCheck];
            return valueAt;
        }

        string GetStdLetter(int pos)
        {
            // Hakee kirjaimen Standard aakkosista
            // Gets the letter from the Standard Library
            if (Debug)
                DebugInfo.DebugPrintFunCall("Rotor2.GetStdLetter");

            string? letter;
            letter = Standard[pos];
            return letter;
        }

        int GetNumberPosInRotor(int numToSearch)
        {
            // Hakee numeron paikan rotorX ja palauttaa sen
            if (Debug)
                DebugInfo.DebugPrintFunCall("Rotor2.GetNumberPosInRotor");

            int pos;
            pos = currentRotor.IndexOf(numToSearch);
            return pos;
        }

    }
}
