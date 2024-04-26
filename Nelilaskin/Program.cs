namespace Nelilaskin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nro1 = 15;
            Console.WriteLine(nro1);
            int nro2 = 12;
            Console.WriteLine(nro2);
            int nro3 = Summa(nro1, nro2);
            Console.WriteLine(nro3);
            int nro4 = Erotus(nro1, nro2);
            Console.WriteLine(nro4);
            int nro5 = Tulo(nro3, nro4);
            Console.WriteLine(nro5);
            double nro6 = Osamaara(nro4, nro5);
            Console.WriteLine(nro6);

        }
        public static int Summa(int luku1, int luku2)
        {
            int vastaus = luku1 + luku2;
            return vastaus;
        }
        public static int Erotus(int luku1, int luku2)
        {
            int vastaus = luku1 - luku2;
            return vastaus;
        }
        public static int Tulo(int luku1, int luku2)
        {
            int vastaus = luku1 * luku2;
            return vastaus;
        }
        public static double Osamaara(int luku1, int luku2)
        {
            double esim1 = Convert.ToDouble(luku1);
            double esim2 = Convert.ToDouble(luku2);
            double vastaus = esim1 / esim2;
            return vastaus;
        }
    }
}
