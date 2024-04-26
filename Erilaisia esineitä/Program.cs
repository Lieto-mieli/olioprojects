using System;

enum SwordType
{
    Shortsword,
    Longsword,
    Greatsword,
    Broadsword,
    Curvedsword,
    Rapier,
    Sideword,
    Dagger,
    Curvedgreatsword,
}
enum BowType
{
    Shortbow,
    Longbow,
    Compoundbow,
}
enum PotionType
{
    Healing,
    Strength,
    Combustion,
    Water,
    Oil,
    Poison,
    Remedy,
    Electricalcurrent,
    Bottledwind,
    Attraction,
    Repulsion,
    Fear,
    Berserk,
}
public class Esine
{
    public double paino;
    public double tilavuus;
    public Esine()
    {
        paino = 0;
        tilavuus = 0;
    }
    public Esine(double weight, double volume)
    {
        paino = weight;
        tilavuus = volume;
    }
}
class Miekka : Esine
{
    public override string ToString()
    {
        return Convert.ToString(tyyppi);
    }
    public SwordType tyyppi;
    public Miekka()
    {
        paino = 5;
        tilavuus = 3;
        tyyppi = SwordType.Shortsword;
    }
    public Miekka(SwordType type, double weight, double volume)
    {
        paino = weight;
        tilavuus = volume;
        tyyppi = type;
    }
}
class Jousi : Esine
{
    public override string ToString()
    {
        return Convert.ToString(tyyppi);
    }
    public BowType tyyppi;
    public Jousi()
    {
        paino = 1;
        tilavuus = 4;
        tyyppi = BowType.Shortbow;
    }
    public Jousi(BowType type, double weight, double volume)
    {
        paino = weight;
        tilavuus = volume;
        tyyppi = type;
    }
}
class Nuoli : Esine
{
    public override string ToString()
    {
        return "Nuoli";
    }
    public Nuoli()
    {
        paino = 0.1;
        tilavuus = 0.05;
    }
    public Nuoli(double weight, double volume)
    {
        paino = weight;
        tilavuus = volume;
    }
}
class Ruoka_Annos: Esine
{
    public override string ToString()
    {
        return "Ruoka-annos";
    }
    public Ruoka_Annos()
    {
        paino = 1;
        tilavuus = 0.5;
    }
    public Ruoka_Annos(double weight, double volume)
    {
        paino = weight;
        tilavuus = volume;
    }
}
class Potion : Esine
{
    public override string ToString()
    {
        return Convert.ToString($"Potion of {nimi}");
    }
    public PotionType nimi;
    public Potion()
    {
        paino = 2;
        tilavuus = 3;
        nimi = PotionType.Healing;
    }
    public Potion(PotionType type, double weight, double volume)
    {
        paino = weight;
        tilavuus = volume;
        nimi = type;
    }
}
internal class Program
{
    static void Main()
    {
        Backpack pack = new Backpack();
        bool kill = false;
        double tempnum1;
        double tempnum2;
        long number1;
        bool valid;
        SwordType matsku1;
        BowType matsku2;
        PotionType matsku3;
        while (true)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Pack an item into backpack");
            Console.WriteLine("2 - Check contents of backpack");
            Console.WriteLine("3 - Set off with your current provisions");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Which item do you want to add to the backpack?");
                    Console.WriteLine("1 - Sword");
                    Console.WriteLine("2 - Bow");
                    Console.WriteLine("3 - Arrow");
                    Console.WriteLine("4 - Rations");
                    Console.WriteLine("5 - Potion");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("6 - Cancel");
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("How heavy should the sword be?");
                            tempnum1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How big should the sword be?");
                            tempnum2 = Convert.ToInt32(Console.ReadLine());
                            valid = false;
                            while (true)
                            {
                                Console.WriteLine("Choose blade type. Choices are:");
                                foreach (int i in Enum.GetValues(typeof(SwordType)))
                                {
                                    Console.Write($"{Enum.GetName(typeof(SwordType), i)}");
                                    Console.WriteLine($" {i}, ");
                                }
                                string colorAnswer = Console.ReadLine();
                                if (Enum.TryParse<SwordType>(colorAnswer, true, out matsku1))
                                {
                                    if (long.TryParse(colorAnswer, out number1))
                                    {
                                        if (Convert.ToInt64(colorAnswer) < Enum.GetNames(typeof(SwordType)).Length)
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
                                    matsku1 = Enum.Parse<SwordType>(colorAnswer, true);
                                    break;
                                }
                                Console.WriteLine("Invalid selection. Please input the name of the type");
                            }
                            if (pack.Lisää(new Miekka(matsku1, tempnum1, tempnum2)))
                            {
                                Console.WriteLine("Sword was added to backpack");
                            }
                            else { Console.WriteLine("Backpack is too full already"); };
                            break;
                        case 2:
                            Console.WriteLine("How heavy should the bow be?");
                            tempnum1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How big should the bow be?");
                            tempnum2 = Convert.ToInt32(Console.ReadLine());
                            valid = false;
                            while (true)
                            {
                                Console.WriteLine("Choose bow type. Choices are:");
                                foreach (int i in Enum.GetValues(typeof(BowType)))
                                {
                                    Console.Write($"{Enum.GetName(typeof(BowType), i)}");
                                    Console.WriteLine($" {i}, ");
                                }
                                string colorAnswer = Console.ReadLine();
                                if (Enum.TryParse<BowType>(colorAnswer, true, out matsku2))
                                {
                                    if (long.TryParse(colorAnswer, out number1))
                                    {
                                        if (Convert.ToInt64(colorAnswer) < Enum.GetNames(typeof(BowType)).Length)
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
                                    matsku2 = Enum.Parse<BowType>(colorAnswer, true);
                                    break;
                                }
                                Console.WriteLine("Invalid selection. Please input the name of the type");
                            }

                            if (pack.Lisää(new Jousi(matsku2, tempnum1, tempnum2)))
                            {
                                Console.WriteLine("Bow was added to backpack");
                            }
                            else { Console.WriteLine("Backpack is too full already"); };
                            break;
                        case 3:
                            Console.WriteLine("How heavy should the arrow be?");
                            tempnum1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How big should the arrow be?");
                            tempnum2 = Convert.ToInt32(Console.ReadLine());
                            if (pack.Lisää(new Nuoli(tempnum1, tempnum2)))
                            {
                                Console.WriteLine("Arrow was added to backpack");
                            }
                            else { Console.WriteLine("Backpack is too full already"); };
                            break;
                        case 4:
                            Console.WriteLine("How heavy should the box of rations be?");
                            tempnum1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How big should the box of rations be?");
                            tempnum2 = Convert.ToInt32(Console.ReadLine());
                            if (pack.Lisää(new Ruoka_Annos(tempnum1, tempnum2)))
                            {
                                Console.WriteLine("Rations were added to backpack");
                            }
                            else { Console.WriteLine("Backpack is too full already"); };
                            break;
                        case 5:
                            Console.WriteLine("How heavy should the potion be?");
                            tempnum1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How big should the potion be?");
                            tempnum2 = Convert.ToInt32(Console.ReadLine());
                            valid = false;
                            while (true)
                            {
                                Console.WriteLine("Choose potion effect. Choices are:");
                                foreach (int i in Enum.GetValues(typeof(PotionType)))
                                {
                                    Console.Write($"potion of {Enum.GetName(typeof(PotionType), i)}");
                                    Console.WriteLine($" {i}, ");
                                }
                                string colorAnswer = Console.ReadLine();
                                if (Enum.TryParse<PotionType>(colorAnswer, true, out matsku3))
                                {
                                    if (long.TryParse(colorAnswer, out number1))
                                    {
                                        if (Convert.ToInt64(colorAnswer) < Enum.GetNames(typeof(PotionType)).Length)
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
                                    matsku3 = Enum.Parse<PotionType>(colorAnswer, true);
                                    break;
                                }
                                Console.WriteLine("Invalid selection. Please input the name of the effect");
                            }

                            if (pack.Lisää(new Potion(matsku3, tempnum1, tempnum2)))
                            {
                                Console.WriteLine("Potion was added to backpack");
                            }
                            else { Console.WriteLine("Backpack is too full already"); };
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine(pack.Tulostasisältö());
                    break;
                case 3:
                    kill = true;
                    break;

            }
            if (kill) { break; }
        }

    }
}
public class Backpack
{
    double mVol = 100;
    double mWei = 100;
    double curVol;
    double curWei;
    int mItems = 100;
    int curItems;
    Esine[] inventory = new Esine[100];
    public bool Lisää(Esine esine)
    {
        if (esine.paino > mWei-curWei || esine.tilavuus > mVol-curVol || curItems >= mItems)
        {
            return false;
        }
        else
        {
            inventory[curItems] = esine;
            curItems++;
            curVol += esine.tilavuus;
            curWei += esine.paino;
            return true;
        }
    }
    public string Tulostasisältö()
    {
        string tempstr = "";
        for (int i = 0; i < curItems; i++) 
        {
            tempstr = $"{tempstr}{inventory[i]}, ";
        }
        return tempstr;
    }
}
