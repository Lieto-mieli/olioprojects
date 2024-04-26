using System.Reflection.Emit;

internal class Program
{
    public enum Maasto
    {
        Tasanko,
        Metsä,
        Vuori,
        Kaupunki
    }
    public struct Karttaruutu
    {
        public Maasto tyyppi;
        public char symboli;
        public bool vihollinen;
        public Karttaruutu(Maasto maasto, char näkö, bool vaara)
        {
            tyyppi = maasto;
            symboli = näkö;
            vihollinen = vaara;
        }
    }

    class Karttaohjelma
    {
        private static Karttaruutu[][] kartta;

        static void Main()
        {
            AlustaKartta();
            TulostaKartta();
        }

        static void AlustaKartta()
        {
            Karttaruutu tasanko = new Karttaruutu(Maasto.Tasanko, '.', false);
            Karttaruutu tasankoVihollisella = new Karttaruutu(Maasto.Tasanko, '.', true);
            Karttaruutu metsa = new Karttaruutu(Maasto.Metsä, '*', false);
            Karttaruutu metsaVihollisella = new Karttaruutu(Maasto.Metsä, '*', true);
            Karttaruutu vuori = new Karttaruutu(Maasto.Vuori, '^', false);
            Karttaruutu kaupunki = new Karttaruutu(Maasto.Kaupunki, 'K', false);

            Random rand = new Random();
            kartta = new Karttaruutu[10][];

            for (int i = 0; i < 10; i++)
            {
                kartta[i] = new Karttaruutu[10];
                for (int j = 0; j < 10; j++)
                {
                    int luku = rand.Next(0, 17) + 1;
                    if (luku > 0 && luku <= 5)
                    {
                        kartta[i][j] = tasanko;
                    }
                    else if (luku > 5 && luku <= 10)
                    {
                        kartta[i][j] = metsa;
                    }
                    else if (luku > 10 && luku <= 15)
                    {
                        kartta[i][j] = vuori;
                    }
                    else if (luku == 16)
                    {
                        kartta[i][j] = kaupunki;
                    }
                    else if (luku == 17)
                    {
                        kartta[i][j] = tasankoVihollisella;
                    }
                    else if (luku == 18)
                    {
                        kartta[i][j] = metsaVihollisella;
                    }
                }
            }
        }

        static void TulostaKartta()
        {
            for (int rivi = 0; rivi < kartta.Length; rivi++)
            {
                for (int sarake = 0; sarake < kartta[rivi].Length; sarake++)
                {
                    if (!kartta[rivi][sarake].vihollinen)    // ruudussa ei ole vihollista
                    {
                        Console.Write(kartta[rivi][sarake].symboli);
                    }
                    else
                    {
                        Console.Write('V');
                    }
                }
                Console.WriteLine();
            }
        }
    }
}