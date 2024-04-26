using System.Numerics;

internal class Ateria
{
    public enum Liha
    {
        nautaa,
        possua,
        kanaa,
        kasvikset
    }
    public enum Lisuke
    {
        perunaa,
        riisiä,
        pastaa
    }
    public enum Kastike
    {
        curry,
        kerma,
        pippuri,
        chili
    }
    Liha lihasi;
    Lisuke lisukkeesi;
    Kastike kastikkeesi;
    public void Ateriavalinta()
    {
        long number1 = 0;
        bool valid;
        valid = false;
        while (true)
        {
            Console.WriteLine("Choose your meat. Choices are:");
            foreach (int i in Enum.GetValues(typeof(Liha)))
            {
                Console.Write($"{Enum.GetName(typeof(Liha), i)}");
                Console.WriteLine($" {i}, ");
            }
            string colorAnswer = Console.ReadLine();
            if (Enum.TryParse<Liha>(colorAnswer, true, out lihasi))
            {
                if (long.TryParse(colorAnswer, out number1))
                {
                    if (Convert.ToInt64(colorAnswer) < Enum.GetNames(typeof(Liha)).Length)
                    {
                        valid = true;
                    }
                }
                else
                {
                    valid = true;
                }
            }
            if (valid)
            {
                lihasi = Enum.Parse<Liha>(colorAnswer, true);
                break;
            }
            Console.WriteLine("Invalid selection. Please input the name of a meat, or its order in the list");
        }
        valid = false;
        while (true)
        {
            Console.WriteLine("Choose your side. Choices are:");
            foreach (int i in Enum.GetValues(typeof(Lisuke)))
            {
                Console.Write($"{Enum.GetName(typeof(Lisuke), i)}");
                Console.WriteLine($" {i}, ");
            }
            string colorAnswer = Console.ReadLine();
            if (Enum.TryParse<Lisuke>(colorAnswer, true, out lisukkeesi))
            {
                if (long.TryParse(colorAnswer, out number1))
                {
                    if (Convert.ToInt64(colorAnswer) < Enum.GetNames(typeof(Lisuke)).Length)
                    {
                        valid = true;
                    }
                }
                else
                {
                    valid = true;
                }
            }
            if (valid)
            {
                lisukkeesi = Enum.Parse<Lisuke>(colorAnswer, true);
                break;
            }
            Console.WriteLine("Invalid selection. Please input the name of a side, or its order in the list");
        }
        valid = false;
        while (true)
        {
            Console.WriteLine("Choose your seasoning. Choices are:");
            foreach (int i in Enum.GetValues(typeof(Kastike)))
            {
                Console.Write($"{Enum.GetName(typeof(Kastike), i)}");
                Console.WriteLine($" {i}, ");
            }
            string colorAnswer = Console.ReadLine();
            if (Enum.TryParse<Kastike>(colorAnswer, true, out kastikkeesi))
            {
                if (long.TryParse(colorAnswer, out number1))
                {
                    if (Convert.ToInt64(colorAnswer) < Enum.GetNames(typeof(Kastike)).Length)
                    {
                        valid = true;
                    }
                }
                else
                {
                    valid = true;
                }
            }
            if (valid)
            {
                kastikkeesi = Enum.Parse<Kastike>(colorAnswer, true);
                break;
            }
            Console.WriteLine("Invalid selection. Please input the name of a seasoning, or its order in the list");
        }
        Console.WriteLine("");
        Console.WriteLine($"Your meal is {lihasi} with a side of {lisukkeesi}, seasoned with {kastikkeesi}. Have a mid day!");
    }
}