int worpen = 0;
int score = 0;
int[] dobbelstenen = new int[5];
string[] steenstatus = new string[5] { "l", "l", "l", "l", "l" };

do
{
    ToonMenu();
    string actie = Console.ReadLine();

    switch (actie.ToUpper())
    {
        case "W":
            WerpStenen();
            worpen++;
            break;
        case "U":
            BepaalUitslag();
            break;
        default:
            Console.WriteLine("Geen geldige keuze");
            break;
    }

} while (worpen <= 3);

void WerpStenen()
{
    Random r = new Random();
    for (int i = 0; i < 5; i++)
    {
        if (steenstatus[i] == "l")
        {
            dobbelstenen[i] = r.Next(1, 7);
        }        
    }

    Console.WriteLine(String.Join(",", dobbelstenen));
    Console.WriteLine("Stenen vastzetten of losmaken.");
    steenstatus = Console.ReadLine().Split(",");
}

void BepaalUitslag()
{
    // Sorteer de dobbelstenen van laag naar hoog.
    Array.Sort(dobbelstenen);

    //Bepaal Yatzee
    score = BepaalYatzee(dobbelstenen);

    //Bepaald 4 of a kind
    if (score == 0)
    {
        score = BepaalFourOfAKind(dobbelstenen);
    }
    //Bepaal 3 of a kind
    //if (score == 0)
        //score = BepaalThreeOfAKind();

    //Bepaal grote straat

    //Bepaal kleine straat
}



static void ToonMenu()
{
    Console.Clear();

    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Werpen => W");
    Console.WriteLine("Uitslag => U");
    Console.WriteLine("Vastzetten => H");
    Console.WriteLine("Losmaken => L");
    Console.WriteLine("");
    Console.WriteLine("Voorbeeld Vastzetten (h,h,l,l,l) om de eerste 2 stenen vast te zetten");
    Console.WriteLine("----------------------------------------");

}


static int BepaalYatzee(int[] dobbelstenen)
{
    if (dobbelstenen[0] == dobbelstenen[1] && dobbelstenen[1] == dobbelstenen[2] &&
        dobbelstenen[2] == dobbelstenen[3] && dobbelstenen[3] == dobbelstenen[4])
    {
        return 50;
    }

    return 0;
}

static int BepaalFourOfAKind(int[] dobbelstenen)
{
    if (dobbelstenen[0] == dobbelstenen[1] && dobbelstenen[1] == dobbelstenen[2] &&
        dobbelstenen[2] == dobbelstenen[3])
    {
        return 40;
    }

    if (dobbelstenen[1] == dobbelstenen[2] && dobbelstenen[2] == dobbelstenen[3] &&
        dobbelstenen[3] == dobbelstenen[4])
    {
        return 40;
    }

    return 0;
}

int BepaalThreeOfAKind(int[] dobbelstenen)
{
    if ((dobbelstenen[0] == dobbelstenen[1] && dobbelstenen[1] == dobbelstenen[2]) ||
        (dobbelstenen[1] == dobbelstenen[2] && dobbelstenen[2] == dobbelstenen[3]) ||
        (dobbelstenen[2] == dobbelstenen[3] && dobbelstenen[3] == dobbelstenen[4]))
    {
        return 30;
    }

    return 0;
}