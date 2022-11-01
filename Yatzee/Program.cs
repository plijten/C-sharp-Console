string speler = "";
int worpen = 0;
int score = 0;
int[] dobbelstenen = new int[5];
string[] steenstatus = new string[5] { "x", "x", "x", "x", "x" };

ToonMenu();

//Bepaal welke actie uitgevoerd moet worden.
string actie = Console.ReadLine();

switch (actie.ToUpper())
{
    case "1":
        Toonspelregels();
        break;
    case "2":
        Console.WriteLine("Wat is uw naam");
        speler = Console.ReadLine();

        Console.WriteLine("");
        Console.WriteLine("Druk op S om het spel te starten.");
        string input = Console.ReadLine();

        if (input.ToUpper() == "S")
        {
            do
            {
                Spelen();
                worpen++;
            } while (worpen <= 3);
        }

        break;
    default:
        Console.WriteLine("Geen geldige keuze");
        break;
}

void Spelen()
{
    WerpStenen();
    ToonStenen();
    SteenStatusBepalen();
}

void SteenStatusBepalen()
{
    bool geldig;

    do
    {
        geldig = true;

        Console.WriteLine("Geef aan welke stenen vastgelegd moeten worden.");
        steenstatus = Console.ReadLine().Split(",");

        foreach (string s in steenstatus)
        {
            if (s != "x" && s != "h")
            {
                Console.WriteLine("Geen geldige invoer.");
                geldig = false;
            }
        }

    } while (!geldig);
}

void Toonspelregels()
{
    Console.WriteLine("1.\tEen speler mag maximaal drie keer met de dobbelstenen werpen. Bij een goed resultaat mag de speler ook minder keren gooien.");
    Console.WriteLine("2.\tBij de eerste en tweede worp mag de speler dobbelstenen ‘On hold’ zetten. Deze dobbelestenen worden bij de volgende worp niet meegenomen en behouden hun waarde. x = niet in de on-hold, h = on-hold. Voorbeeld van een geldige invoer: x, x, h, h, x");
    Console.WriteLine("3.\tNa elke worp wordt er weergegeven welke vorm van yahtzee er is gegooid en wordt het aantal bijhorende punten weergegeven.");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Yahtzee categorieën:");
    Console.WriteLine("Hier moeten nog de categorieen komen");
}

void WerpStenen()
{
    Random r = new Random();
    for (int i = 0; i < 5; i++)
    {
        if (steenstatus[i] == "x")
        {
            dobbelstenen[i] = r.Next(1, 7);
        }
    }
}

void ToonStenen()
{
    string stenen = "";
    int score = 0; ;

    for (int i = 0; i < 5; i++)
    {
        stenen += dobbelstenen[i] + " ";
    }

    Console.WriteLine(stenen);
    Console.WriteLine();
    Console.WriteLine("Resultaat van de worp");
    Console.WriteLine(BepaalUitslag(out score) + $": {score}");
    Console.ReadKey();
}

string BepaalUitslag(out int score)
{
    /* Zet dobbelstenen in andere array. Wanneer dobbelstenen array gestorteerd 
     * krijg je problemen met het vastzetten van de dobbelstenen. Dan komen de posities niet meer 
     * overeen
    */
    int[] stenenSorted = dobbelstenen;

    //Sorteer de dobbel om de score te kunnen bepalen
    Array.Sort(stenenSorted);



    //Bepaal Yatzee
    if (BepaalYatzee(stenenSorted))
    {
        score = 50;
        return "Yatzee ";
    }

    //Bepaald 4 of a kind
    if (BepaalFourOfAKind(stenenSorted))
    {
        score = 40;
        return "4 of a kind";
    }

    if (BepaalThreeOfAKind(stenenSorted))
    {
        score = 30;
        return "3 of a kind";
    }

    if (BepaalGroteStraat(stenenSorted))
    {
        score = 40;
        return "Grote straat";
    }

    if (BepaalKleineStraat(stenenSorted))
    {
        score = 30;
        return "Kleine straat";
    }

    score = BepaalHoogsteScore(stenenSorted);
    return "Kans";
}

static void ToonMenu()
{
    Console.Clear();

    Console.WriteLine("----------------------------------------");
    Console.WriteLine("MENU");
    Console.WriteLine("1. Yatzee spelregels weergeven.");
    Console.WriteLine("2. Yatzee spel starten");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Maak uw keuze: ");
}

static bool BepaalYatzee(int[] dobbelstenen)
{
    if (dobbelstenen[0] == dobbelstenen[1] && dobbelstenen[1] == dobbelstenen[2] &&
        dobbelstenen[2] == dobbelstenen[3] && dobbelstenen[3] == dobbelstenen[4])
    {
        return true;
    }

    return false;
}

static bool BepaalFourOfAKind(int[] dobbelstenen)
{
    if (dobbelstenen[0] == dobbelstenen[1] && dobbelstenen[1] == dobbelstenen[2] &&
        dobbelstenen[2] == dobbelstenen[3])
    {
        return true;
    }

    if (dobbelstenen[1] == dobbelstenen[2] && dobbelstenen[2] == dobbelstenen[3] &&
        dobbelstenen[3] == dobbelstenen[4])
    {
        return true;
    }

    return false;
}

bool BepaalThreeOfAKind(int[] dobbelstenen)
{
    if ((dobbelstenen[0] == dobbelstenen[1] && dobbelstenen[1] == dobbelstenen[2]) ||
        (dobbelstenen[1] == dobbelstenen[2] && dobbelstenen[2] == dobbelstenen[3]) ||
        (dobbelstenen[2] == dobbelstenen[3] && dobbelstenen[3] == dobbelstenen[4]))
    {
        return true;
    }

    return false;
}

bool BepaalGroteStraat(int[] dobbelstenen)
{
    if ((dobbelstenen[0] == 1 && dobbelstenen[1] == 2 && dobbelstenen[2] == 3 &&
        dobbelstenen[3] == 4 && dobbelstenen[4] == 5) ||
        (dobbelstenen[0] == 2 && dobbelstenen[1] == 3 && dobbelstenen[2] == 4 &&
        dobbelstenen[3] == 5 && dobbelstenen[4] == 6))
    {
        return true;
    }

    return false;
}

bool BepaalKleineStraat(int[] dobbelstenen)
{
    if ((dobbelstenen[0] == 1 && dobbelstenen[1] == 2 && dobbelstenen[2] == 3 &&
        dobbelstenen[3] == 4) ||
        (dobbelstenen[0] == 2 && dobbelstenen[1] == 3 && dobbelstenen[2] == 4 &&
       dobbelstenen[3] == 5) ||
        (dobbelstenen[0] == 3 && dobbelstenen[1] == 4 && dobbelstenen[2] == 5 &&
       dobbelstenen[3] == 6))
    {
        return true;
    }

    return false;
}


int BepaalHoogsteScore(int[] dobbelstenen)
{
    int aantal = 0;
    for (int i = 0; i < dobbelstenen.Length; i++)
    {
        aantal += dobbelstenen[i];
    }

    return aantal;
}