internal class Program
{
    static void Main()
    {
        Ajastin ajastin = new Ajastin();
        Console.WriteLine("Press 1 to begin timer and 2 to end timer");
        while (true)
        {
            switch (Console.ReadLine())
            {
                case "1":
                    ajastin.Aloita();
                    Console.WriteLine("timer has started!");
                    break;
                case "2":
                    ajastin.Pysäytä();
                    break;
                default:
                    Console.WriteLine("Press 1 to begin timer and 2 to end timer");
                    break;
            }
        }
    }
}
class Ajastin
{
    DateTime start;
    DateTime end;
    public void Aloita()
    {
        start = DateTime.Now;
    }
    public void Pysäytä()
    {
        end = DateTime.Now;
        Console.WriteLine($"elapsed time is: {end.Subtract(start)}");
    }
}