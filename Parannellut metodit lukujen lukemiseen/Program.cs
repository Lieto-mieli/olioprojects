using System.Numerics;
using System.Security.Claims;

namespace Parannellut_metodit_lukujen_lukemiseen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroyksi;
            int numerokaks;
            Askforstuff ask = new Askforstuff();
            numeroyksi = ask.AskForNumber();
            numerokaks = ask.AskForNumberInRange(10, 100);
            Console.WriteLine($"{numeroyksi} , {numerokaks}");
        }
    }
}
