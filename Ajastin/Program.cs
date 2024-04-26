using Microsoft.VisualBasic;

internal class Program
{
    static void Main()
    {
        DateTime start;
        DateTime end;
    Console.WriteLine("Press enter to begin timer");
    switch (Console.ReadLine())
        {
            default:
                start = DateTime.Now;
                break;
        }
    Console.WriteLine("Press enter to end timer");
    switch (Console.ReadLine())
        {
            default:
                end = DateTime.Now;
                break;
        }
    Console.WriteLine(end.Subtract(start));
    }
}