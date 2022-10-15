using System;
using System.Collections.Generic;
using System.Text;

namespace EnigmaLite2
{
    public class Rotor
    {
        // other stuff
        static readonly List<string> Standard = new()
            {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N",
                "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        // Rotors 
        static readonly List<int> Rotor1I = new()
            {0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ,10, 11, 12, 13, 14, 15, 16, 17, 18,
                19 ,20, 21, 22, 23, 24, 25};

        static readonly List<int> Rotor1O = new() 
            // EKMFLGDQVZNTOWYHXUSPAIBRCJ
            {4, 10, 12, 5, 11, 6, 3, 16, 21, 25, 13, 19, 14, 22, 24, 7, 23, 20,
                18, 15, 0, 8, 1, 17, 2, 9};

        static readonly List<int> Rotor2O = new()
            // AJDKSIRUXBLHWTMCQGZNPYFVOE
            {0, 9, 3, 10, 18, 8, 17, 20, 23, 1, 11, 7, 22, 19, 12, 2, 16, 6, 25,
                13, 15, 14, 5, 21, 14, 4};
        static readonly List<int> Rotor3O = new()
        // BDFHJLCPRTXVZNYEIWGAKMUSQO  
            {1, 3, 5, 7, 9, 11, 2, 15, 17, 19, 23, 21, 25, 13, 24, 4, 8, 22, 6,
                0, 10, 12, 20, 18, 16, 14};

        // Reflectors
        static readonly List<int> ReflectorB = new()
            //00Y 01R 02U 03H 04Q 05S 06L 07D 08P 09X 10N 11G 12O
            //13K 14M 15I 16E 17B 18F 19Z 20C 21W 22V 23J 24A 25T
            { 24, 17, 20, 7, 16, 18, 11, 3, 15, 23, 13, 6, 14, 10, 12, 8, 4, 1,
                5, 25, 2, 22, 21, 9, 0, 19};


        // Constants
        const int MAX = 25;

        // variables
        string? scrambledLetter;
        int rotor1Pos;
        int rotorToUse;
        readonly bool debug;

        // public methods
        public Rotor(int rotorToUse, bool debug = false)
        {
            this.rotorToUse = rotorToUse;
            this.debug = debug;
            this.rotor1Pos = 0;
        }

        public void ScrambleSentence1(string sentenceToScramble)
        {
            // TODO:
            // Tämä metodi tullaan korvaamaan kehittyneemmällä versiolla joka pystyt käyttämään useampaa rotoria
            sentenceToScramble = sentenceToScramble.ToUpper();

            // scramble whole sentence 
            foreach (var letter in sentenceToScramble)
            {
                MoveRotor(Rotor1O, ref rotor1Pos);
                ScrambleLetterIn1(letter.ToString());
            }
            PrintScambledLetter();

        }

        // private methods
        void ScrambleLetterIn1(string letterToScramble)
        {
            // TODO:
            // Tämä metodi tullaan korvaamaan kehittyneemmällä versiolla joka pystyt käyttämään useampaa rotoria
            // myös yksityisten metodien kutsut pitää piilottaa yhden metodi kutsun taakse
            int letterPos;
            string? letter;

            // <-
            // Katso mikä on syötteen paikka Standard aakkosissa
            letterPos = GetStdPos(letterToScramble);
            // Vertaa mikä arvo on RotorX paikassa Y
            letterPos = GetRotorPosition(letterPos, Rotor1O);
            // Hakee rotorX luvun avulla Standard aakkosista kirjaimen
            letter = GetStdLetter(letterPos);

            // <-
            // Vertaa mikä on ensimmäisen rotor kirjaimen paikka Standard aakkosissa
            letterPos = GetStdPos(letter);
            // Katsoo mikä on kirjaimen letterPos paikassa ReflectorB
            letterPos = GetRotorPosition(letterPos, ReflectorB);
            // hakee reflectorX luvun avulla Standard aakkosista kirjaimen
            letter = GetStdLetter(letterPos);

            // ->
            // Hakee syötteen letter paikan Standard aakkosista
            letterPos = GetStdPos(letter);
            // Katsoo mikä on syötteen letterPos paikka RotorX
            letterPos = GetNumberPosInRotor(letterPos, Rotor1O);
            // vertaa mikä kirjain on Standard aakkosissa paikassa letterPos
            scrambledLetter += GetStdLetter(letterPos);
        }

        string MoveLetterForward(string letterToScramble, List<int> rotorOrReflectorToUse)
        {
            //TODO
            // Tämä metodi tulee korvaamaan ScrambleLetterIn ensimmäiset kolme kutsua yhdeksi metodiksi
            int letterPos;
            string? letter;

            // <-
            // Katso mikä on syötteen paikka Standard aakkosissa
            letterPos = GetStdPos(letterToScramble);
            // Vertaa mikä arvo on RotorX paikassa Y
            letterPos = GetRotorPosition(letterPos, rotorOrReflectorToUse);
            // Hakee rotorX luvun avulla Standard aakkosista kirjaimen
            letter = GetStdLetter(letterPos);

            return letter;
        }

        string MoveLetterBackwards()
        {
            // TODO: figure out how to do this
            return "";
        }

        static void PrintList(List<int> toPrint)
        {
            // prints a list
            foreach (var item in toPrint)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        void MoveRotor(List<int> rotorToMove, ref int rotorPos, int times = 1)
        {
            // moves items in list one step forward
            // this should be called before a letter is scrambled
            if (debug)
            {
                DebugPrintFunCall("MoveRotor");
            }

            for (int i = 0; i < times; i++)
            {
                rotorToMove.Insert(0, rotorToMove[rotorToMove.Count - 1]);
                rotorToMove.RemoveAt(rotorToMove.Count - 1);
                rotorPos += 1;
                DebugPrintVari(rotorPos, "rotorPos");
            }
        }

        static int GetStdPos(string letter)
        {
            // Katsoo mikä on syötteen paikka aakkosissa Standard
            int pos;
            pos = Standard.IndexOf(letter);
            return pos;
        }

        static int GetRotorPosition(int posToCheck, List<int> rotorToCheck)
        {
            // Vertaa mikä arvo on rotorX tai reflectorX paikassa postToCheck
            int valueAt;
            valueAt = rotorToCheck[posToCheck];
            return valueAt;
        }

        static string GetStdLetter(int pos)
        {
            // Hakee kirjaimen Standard aakkosista
            string? letter;
            letter = Standard[pos];
            return letter;
        }

        static int GetNumberPosInRotor(int numToSearch, List<int> rotorToCheck)
        {
            // Hakee numeron paikan rotorX ja palauttaa sen
            int pos;
            pos = rotorToCheck.IndexOf(numToSearch);
            return pos;
        }

        void PrintScambledLetter()
        {
            Console.Write(scrambledLetter);
        }

        static void DebugPrintFunCall(string funcToCall)
        {
            var dateObj = DateTime.Now;
            Console.WriteLine($"{dateObj} Calling {funcToCall}");
        }

        static void DebugPrintVari<T>(T variableToPrint, string variableName)
        {
            var dateObj = DateTime.Now;
            Console.WriteLine($"{dateObj}: {variableName}: {variableToPrint}");
        }
    }
}