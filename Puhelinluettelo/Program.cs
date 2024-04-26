
using System.Collections.Generic;
using System.Numerics;
internal partial class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> luettelo = new Dictionary<string, string>();
        string tempstr0 = "";
        string tempstr1 = "";
        int currentsize = 0;
        bool kuole = false;
        while (true)
        {
            Console.WriteLine("mitä haluat tehdä");
            Console.WriteLine("1-liitä numero nimeen");
            Console.WriteLine("2-etsi nimeen liitetty numero");
            Console.WriteLine("3-sulje ohjelma");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("anna nimi:");
                    tempstr0 = Console.ReadLine();
                    Console.WriteLine("anna numero joka liitetään nimeen:");
                    tempstr1 = Console.ReadLine();
                    luettelo[tempstr0] = tempstr1;
                    Console.WriteLine("nimi ja numero lisätty");
                    break;
                case "2":
                    Console.WriteLine("anna nimi:");
                    tempstr0 = Console.ReadLine();
                        if (luettelo.TryGetValue(tempstr0, out tempstr1))
                        {
                            Console.WriteLine(tempstr1);
                        }
                        else
                        {
                            Console.WriteLine("nimi/numero ei ole luettelossa");
                        }
                    break;
                case "3":
                    kuole = true;
                    break;
            }
            if (kuole) { break; }
        }
    }
}
