using System.Reflection.Metadata.Ecma335;

public class Robotti
{
    Suorita suorita = new Suorita();
    private int x;
    private int y;
    private bool kaynnissa0;
    public int[] komennot0 = new int[99];
    public int[] komennot1 = new int[99];
    public int[] komennot2 = new int[99];

    public int AnnaX() { return x; }
    public void AsetaX(int x) { this.x = x; }
    public int AnnaY() { return y; }
    public void AsetaY(int y) { this.y = y; }
    public bool OnKaynnissa() { return kaynnissa0; }
    public void VaihdaTila(bool kaynnissa0) { this.kaynnissa0 = kaynnissa0; }

    public void SuoritaKomennot(int length)
    {
        bool tempbool = OnKaynnissa();
        for (int i = 0; i < length; i++)
        {
            switch (komennot0[i])
            {
                case 0:
                    break;
                case 1:
                    tempbool = false; 
                    break;
                case 2:
                    tempbool = true;
                    break;
                default:
                    break;
            }
            suorita.VaihdaAsia(this, tempbool);
            if (OnKaynnissa())
            {
                suorita.LiikuSuuntaan(this, komennot1[i], komennot2[i]);
            }
            string tila = kaynnissa0 ? "on käynnissä" : "ei ole käynnissä";
            Console.WriteLine($"Robotti {tila}. Koordinaatit ({x}, {y}).");
        }
    }
}
public interface IKomento
{
    void VaihdaAsia(Robotti bot, bool kaynnissa1);
    void LiikuSuuntaan(Robotti bot, int Xmove, int Ymove);
}
public class Suorita : IKomento
{
    public void VaihdaAsia(Robotti bot,bool kaynnissa1)
    {
        bot.VaihdaTila(kaynnissa1);
    }
    public void LiikuSuuntaan(Robotti bot, int Xmove, int Ymove)
    {
        bot.AsetaX(bot.AnnaX() + Xmove);
        bot.AsetaY(bot.AnnaY() + Ymove);
    }
}
