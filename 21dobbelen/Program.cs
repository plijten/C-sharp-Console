namespace _21dobbelen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int worpen = 0;
            Random random = new Random();
            do
            {
                int dobbel = random.Next(1, 7);
                if (score + dobbel <= 21)
                {
                    score += dobbel;
                }

                worpen++;

            } while (score < 21);

            Console.WriteLine($"Aantal worpen {worpen}");
        }
    }
}