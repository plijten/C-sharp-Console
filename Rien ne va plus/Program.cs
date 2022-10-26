int chips = 10;
string input = "";
int number = 0;
int chipsOnNumber = 0;
bool stop = false;

Random random = new Random();
do
{
    // Inzet door de gebruiker laten invoeren.
    do
    {
        Console.WriteLine("Op welk getal wil je chips inzetten?");
        input = Console.ReadLine();

        if (!int.TryParse(input, out number))
        {
            if (input.ToLower() == "stop")
                stop = true;
            else
                Console.WriteLine("Ongeldige invoer.");
        }
        else
        {
            Console.WriteLine("Hoeveel chips wil je inzetten?");
            input = Console.ReadLine();

            if (!int.TryParse(input, out chipsOnNumber))
            {
                if (input.ToLower() == "stop")
                    stop = true;
                else
                    Console.WriteLine("Ongeldige invoer.");
            }
        }

        if (chipsOnNumber <= 0 && stop == false)
        {
            Console.WriteLine("Aantal chips moet groter zijn zijn nul");
        }

        if (chipsOnNumber > chips && stop == false)
        {
            Console.WriteLine($"Je hebt maar {chips} beschikbaar.");
        }

        // Kan niet meer chips inzetten.
        if (chipsOnNumber == chips && stop == false)
        {
            Console.WriteLine("Rien ne va plus");
            stop = true;
        }

    } while (!stop);

    // Trekking
    int score = random.Next(1, 37);
    
    Console.Clear();
    Console.WriteLine($"het balletje is op {score} gevallen.");

    if (score == number)
    {
        Console.WriteLine("Je hebt dit getal gekozen en 35 extra punten verdient.");
        chips += 35;
    }
    else
    {
        Console.WriteLine("Helaas je hebt je inzet verloren.");
        chips -= chipsOnNumber;
    }

    
    Console.WriteLine("Druk op een toets om verder te spelen.");
    Console.ReadKey();

    stop = false;
    Console.Clear();

} while (chips > 0);

Console.WriteLine("Al je chips zijn op, het spel is afgelopen.");