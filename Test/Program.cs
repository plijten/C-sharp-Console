using System.Text.Json;

class Program
{
    public static void Main()
    {
        try
        {
            Persoon persoon = new Persoon(-1);
            Console.WriteLine(persoon.Leeftijd);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }

        
        
    }

}

public class Persoon
{
    public int Leeftijd { get; set; }

    public Persoon(int leeftijd)
    {
        if (leeftijd < 0)
        {
            throw new ArgumentException("Leeftijd mag niet negatief zijn.");
        }

        Leeftijd = leeftijd;
    }
}
