namespace EnigmaLite2;
class Program
{
    const int MAX_ARGS = 3;

    static int Main(string[] args)
    {
        bool re;

        // argument checker
        ArgumentCheck argObj = new(args, MAX_ARGS, "<SCRAMBLE><ROTORS><REFLECTOR>");

        re = argObj.CheckArgs();
        if (!re)
        {
            return -1;
        }

        Rotor rotorObj = new(0, true);

        rotorObj.ScrambleSentence1(args[0]);

        return 0;
    }

}