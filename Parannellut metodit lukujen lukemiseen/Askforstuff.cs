using System;

internal class Askforstuff
{
    long lnum1 = 0;
    int tempnum = 0;
    bool valid = false;
    public int AskForNumber()
    {
        string vastaus;
        valid = false;
        while (true)
        {
            Console.WriteLine("pliis anna numero :DD");
            vastaus = Console.ReadLine();
            if (long.TryParse(vastaus, out lnum1))
            {
                valid = true;
            }
            if (valid)
            {
                return int.Parse(vastaus);
            }
            Console.WriteLine("nouuu. pliiiis anna numero man ));;;");
        }
    }
    public int AskForNumberInRange(int min, int max)
    {
        string vastaus;
        valid = false;
        Random r = new Random();
        while (true)
        {
            Console.WriteLine($"pliis anna numerojoka on isompi kuin {min} ja pienempi kuin {max} :DD");
            vastaus = Console.ReadLine();
            if (long.TryParse(vastaus, out lnum1))
            {
                valid = true;
            }
            if (valid)
            {
                tempnum = int.Parse(vastaus);
                if (tempnum > min && tempnum < max)
                {
                    return tempnum;
                }
            }
            Console.WriteLine($"nouuu. cmon numero pitää olla isompi kuin {min} ja pienempi kuin {max}, man D;;");
        }
    }
}