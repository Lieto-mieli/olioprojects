using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Taikamiekkoja
{
    internal class Program
    {
        public enum Terä
        {
            pronssi = 5,
            teräs = 10,
            mithril = 50,
            techno = 200,
        }
        public enum Kahva
        {
            jalopuu = 5,
            metalli_nahkapäällyste = 8,
            lohikäärme_luu = 30,
        }
        public enum Jalokivet
        {
            vesikivi = 15,
            tulikivi  = 20,
            maakivi = 13,
            tuulikivi = 18,
        }
        class Taikamiekka
        {
            public int hinta = 0;
            public Terä matsku1;
            public Kahva matsku2;
            public Jalokivet matsku3;
            public void Miekanrakennus()
            {
                long number1;
                bool valid;
                valid = false;
                while (true)
                {
                    Console.WriteLine("Choose blade material. Choices are:");
                    foreach (int i in Enum.GetValues(typeof(Terä)))
                    {
                        Console.Write($"{Enum.GetName(typeof(Terä), i)}");
                        Console.WriteLine($" {i}$, ");
                    }
                    string colorAnswer = Console.ReadLine();
                    if (Enum.TryParse<Terä>(colorAnswer, true, out matsku1))
                    {
                        if (!long.TryParse(colorAnswer, out number1))
                        {
                            valid = true;
                        }
                    }
                    if (valid)
                    {
                        matsku1 = Enum.Parse<Terä>(colorAnswer, true);
                        hinta += (int)matsku1;
                        break;
                    }
                    Console.WriteLine("Invalid selection. Please input the name of a material");
                }
                valid = false;
                while (true)
                {
                    Console.WriteLine("Choose hilt material. Choices are:");
                    foreach (int i in Enum.GetValues(typeof(Kahva)))
                    {
                        Console.Write($"{Enum.GetName(typeof(Kahva), i)}");
                        Console.WriteLine($" {i}$, ");
                    }
                    string colorAnswer = Console.ReadLine();
                    if (Enum.TryParse<Kahva>(colorAnswer, true, out matsku2))
                    {
                        valid = true;
                    }
                    if (valid)
                    {
                        matsku2 = Enum.Parse<Kahva>(colorAnswer, true);
                        hinta += (int)matsku2;
                        break;
                    }
                    Console.WriteLine("Invalid selection. Please input the name of a material");
                }
                valid = false;
                while (true)
                {
                    Console.WriteLine("Choose gemstone. Choices are:");
                    foreach (int i in Enum.GetValues(typeof(Jalokivet)))
                    {
                        Console.Write($"{Enum.GetName(typeof(Jalokivet), i)}");
                        Console.WriteLine($" {i}$, ");
                    }
                    string colorAnswer = Console.ReadLine();
                    if (Enum.TryParse<Jalokivet>(colorAnswer, true, out matsku3))
                    {
                        valid = true;
                    }
                    if (valid)
                    {
                        matsku3 = Enum.Parse<Jalokivet>(colorAnswer, true);
                        hinta += (int)matsku3;
                        break;
                    }
                    Console.WriteLine("Invalid selection. Please input the name of a gemstone");
                }
                Console.WriteLine("");
                Console.WriteLine($"Alright. A sword with a blade of {matsku1}, and a hilt made of {matsku2}.");
                Console.WriteLine($"With its elemental powers coming from a {matsku3}.");
                Console.WriteLine($"That totals to about {hinta} in non-descript legal tender with a goofy name.");
            }
        }
        static void Main(string[] args)
        {
            Taikamiekka miekka1 = new Taikamiekka();
            miekka1.Miekanrakennus();
        }
    }
}
