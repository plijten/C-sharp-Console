using System.Net.NetworkInformation;
using System.Runtime;
using System.Text;

Console.WriteLine("1. Twente-One");
Console.WriteLine("2. Random jaargetijden");
Console.WriteLine("3. Tekst coderen");
Console.WriteLine("4. Stoppen");
Console.WriteLine("Geef uw keuze");

string input = Console.ReadLine();

switch (input)
{
    case "1":
        TwenteOne();
        break;
    case "2":
        RandonJaargetijden();
        break;
    case "3":
        TextCoderen();
        break;

}

void TwenteOne()
{
    bool gelukt = false;
    Random rnd = new Random();
    int aantal = 0;
    int pogingen = 0;
    StringBuilder reeks = new StringBuilder();

    do
    {
        pogingen++;
        aantal = 0;

        do
        {
            int getal = rnd.Next(1, 7);
            aantal = aantal + getal;
            reeks.Append(getal + ",");
        } while (aantal < 21);

    } while (aantal != 21);

    Console.WriteLine($"in {pogingen} pogingen is met een dobbelsteen precies 21 gegooid.");
    Console.WriteLine("De volgende ogen zijn gegooid: " + reeks.ToString());
}


void TextCoderen()
{
    Console.WriteLine("Wat is uw tekst");
    string input = Console.ReadLine();
    char[] inputArray = input.ToCharArray();

    for (int i = 0; i < inputArray.Length; i++)
    {
        switch(inputArray[i])
        {
            case 'a':
                inputArray[i] = '&';
                break;
            case 'e':
                inputArray[i] = '*';
                break;
            case 'i':
                inputArray[i] = '#';
                break;
            case 'o':
                inputArray[i] = '$';
                break;
            case 'A':
                inputArray[i] = '@';
                break;
            case 'E':
                inputArray[i] = '%';
                break;
            case 'I':
                inputArray[i] = '|';
                break;
            case 'O':
                inputArray[i] = '~';
                break;
        }
    }

    Console.WriteLine(inputArray);
}

void RandonJaargetijden()
{
    Console.Write("Hoevaak een jaargetijde trekken? ");
    int aantal = Convert.ToInt32(Console.ReadLine());   // gaan uit van valide input!
    Random rnd = new Random();
    int voorjaar = 0;
    int zomer = 0;
    int herfst = 0;
    int winter = 0;

    for(int i = 0; i < aantal; i++)
    {
        int jaargetijden = rnd.Next(1, 5);
        switch(jaargetijden)
        {
            case 1:
                voorjaar++;
                break;
            case 2:
                zomer++;
                break;
            case 3:
                herfst++;
                break;
            case 4:
                winter++;
                break;
        }
    }

    Console.WriteLine("=== Randon jaargetijden ===");
    
    Console.WriteLine($"Voorjaar komt {voorjaar} keer voor");
    Console.WriteLine($"Zomer komt {zomer} keer voor");
    Console.WriteLine($"Herfst komt {herfst} keer voor");
    Console.WriteLine($"Winter komt {winter} keer voor");
}

