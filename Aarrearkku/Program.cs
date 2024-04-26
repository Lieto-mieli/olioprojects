internal class Program
{
    public struct Aarrearkku
    {
        bool auki;
        bool lukittu;
        int rahamäärä;
        public Aarrearkku(int määrä)
        {
            rahamäärä = määrä;  
        }
        string Paljonkorahaa()
        {
            if (auki)
            {
                return Convert.ToString(rahamäärä);
            }
            else { return "et näe arkun sisälle"; }
            
        }
        void LaitaRahaa(int i)
        {
            if(i >= 0)
            {
                if (auki)
                {
                    rahamäärä += i;
                }
                else { Console.WriteLine("arkku ei ole auki"); }
            }
        }
        void OtaRahaa(int i)
        {
            if (i >= 0&rahamäärä>=i)
            {
                if (auki)
                {
                    rahamäärä -= i;
                }
                else { Console.WriteLine("arkku ei ole auki"); }
            }
        }
        void Avaaarkku()
        {
            if (!auki & !lukittu) { auki = true; }
            else if (lukittu) { Console.WriteLine("Arkku on lukittu"); }
            else { Console.WriteLine("Arkku on jo auki"); }
        }
        void Suljearkku()
        {
            if (auki) { auki = false; }
            else { Console.WriteLine("Arkku on jo suljettu"); }
        }
        void Suljelukko()
        {
            if (!auki & !lukittu) { lukittu = true; }
            else if (lukittu) { Console.WriteLine("Arkku on jo lukittu"); }
            else { Console.WriteLine("Arkku on auki"); }
        }
        void Avaalukko()
        {
            if (lukittu) { lukittu = false; }
            else { Console.WriteLine("Arkku ei ole lukittu"); }
        }
    }
    static void Main()
    {
        Aarrearkku arkku = new Aarrearkku();
    }
}
