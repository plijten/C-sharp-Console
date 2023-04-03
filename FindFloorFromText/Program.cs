
// Lees bestand in.
string input = (new StreamReader("input.txt")).ReadToEnd();

Deel1(input);
Deel2(input);

static void Deel1(string input)
{
    int floor = 0;
    foreach (char c in input)
    {
        if (c == '(')
            floor++;
        else
            floor--;
    }

    Console.WriteLine(floor);
}

static void Deel2(string input)
{
    int floor = 0;
    int stap = 0;
    foreach (char c in input)
    {
        stap++;
        if (c == '(')
            floor++;
        else
            floor--;

        if (floor == -1)
        {
            break;
        }
    }

    Console.WriteLine(stap);
}