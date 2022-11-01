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
        public bool Debug {private get; set;}

        public Rotor2(List<int> currentRotor, int currentRotorPos = 0)
        {
            this.currentRotor = currentRotor;
            this.currentRotorPos = currentRotorPos;
        }

        /// <summary>
        /// Salaa kirjaimen ja liikuttaa sitä eteenpäin
        /// </summary>
        /// <param name="letterToScramble">Kirjain joka salataan</param>
        /// <returns>Salatin kirjaimen</returns>
        public string MoveLetterForward(string letterToScramble)
        {
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

        static int GetStdPos(string letter)
        {
            // Katsoo mikä on syötteen paikka aakkosissa Standard
            int pos;
            pos = Standard.IndexOf(letter);
            return pos;
        }

        int GetRotorPosition(int posToCheck)
        {
            // Vertaa mikä arvo on rotorX tai reflectorX paikassa postToCheck
            int valueAt;
            valueAt = currentRotor[posToCheck];
            return valueAt;
        }

        static string GetStdLetter(int pos)
        {
            // Hakee kirjaimen Standard aakkosista
            string? letter;
            letter = Standard[pos];
            return letter;
        }

    }
}
