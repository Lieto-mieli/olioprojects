using System.Timers;

class mustajakki
{
    public static void Main()
    {
        mustajakki jack = new mustajakki();
        jack.MLoop();
    }
    Pakka pakka = new Pakka();
    int place;
    int plSize;
    int aiSize;
    int pltotal;
    int aitotal;
    int money;
    int plAces;
    int aiAces;
    int plPosTotal;
    int aiPosTotal;
    int plAcesUsed;
    int aiAcesUsed;
    Kortti[] plKäsi;
    Kortti[] aiKäsi;
    public void MLoop()
    {
        int curPanos = 0;
        bool booltemp;
        bool temp2;
        bool plturn;
        bool aiturn;
        string tempstr;
        money = 8;
        while (true)
        {
            if (money == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Pyydät sukulaisilta lisää rahaa, lupaamalla että et käytä sitä gämblaamiseen");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+5 valuuttaa!");
                money = 5;
            }
            plKäsi = new Kortti[8];
            aiKäsi = new Kortti[8];
            pakka.Sekoita();
            place = 0;
            plSize = 0;
            aiSize = 0;
            pltotal = 0;
            aitotal = 0;
            plAces = 0;
            aiAces = 0;
            plAcesUsed = 0;
            aiAcesUsed = 0;
            plPosTotal = -1;
            aiPosTotal = -2;
            plturn = true;
            aiturn = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tervetuloa Blackjack pöytään!");
            Console.WriteLine($"Kuinka paljon haluat laittaa panokseksi? (sinulla on {money} tällä hetkellä):");
            booltemp = true;
            while (booltemp)
            {
                tempstr = Console.ReadLine();
                if (int.TryParse(tempstr, out curPanos))
                {
                    if (curPanos <= money)
                    {
                        curPanos = int.Parse(tempstr);
                        booltemp = false;
                    }
                    else { Console.WriteLine("Rahasi ei riitä noin isoon panokseen"); }
                }
                else { Console.WriteLine("Panos täytyy antaa kokonaislukuna"); }
            }
            plDraw(plSize);
            plDraw(plSize);
            aiDraw(aiSize);
            aiDraw(aiSize);
            GameStatus(true);
            while (plturn) 
            {
                temp2 = false;
                Console.ForegroundColor = ConsoleColor.White;
                if (pltotal < 22 || (plPosTotal < 22 & plAcesUsed > 0))
                {
                    Console.WriteLine("Hit  (H)");
                    Console.WriteLine("Pass (P)");
                    switch (Console.ReadLine())
                    {
                        case "P":
                        case "p":
                        case "Pass":
                        case "pass":
                            temp2 = true;
                            break;
                        case "H":
                        case "h":
                        case "Hit":
                        case "hit":
                            plDraw(plSize);
                            GameStatus(true);
                            break;
                    }
                }
                if (plAces > plAcesUsed && pltotal > 21 && (plPosTotal < 0| plPosTotal > 21))
                {
                    booltemp = true;
                    while (booltemp)
                    {
                        for (int i = 0; i < plAces; i++)
                        {
                            plAcesUsed++;
                            plPosTotal = pltotal - (10 + (10 * i));
                            if (plPosTotal < 22)
                            {
                                booltemp = false;
                            }
                        }
                        booltemp = false;
                    }
                }
                if ((pltotal > 21 & plPosTotal > 21) || (pltotal > 21 & plPosTotal < 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bust!");
                    pltotal = 0;
                    plPosTotal = 0;
                    plturn = false;
                    aiturn = false;
                }
                if (temp2) { plturn = false; }
            }
            while (aiturn)
            {
                temp2 = false;
                Console.ForegroundColor = ConsoleColor.White;
                if (aitotal < 22 || (aiPosTotal < 22 & aiAcesUsed > 0))
                {
                    if (aitotal > 16)
                    {
                        Console.WriteLine("Dealer passes");
                        temp2 = true;
                    }
                    else 
                    {
                        Console.WriteLine("Dealer draws a card");
                        aiDraw(aiSize);
                    }
                }
                if (aiAces > aiAcesUsed & aitotal > 21 && (aiPosTotal < 0 | aiPosTotal > 21))
                {
                    booltemp = true;
                    while (booltemp)
                    {
                        for (int i = 0; i < aiAces; i++)
                        {
                            aiAcesUsed++;
                            aiPosTotal = aitotal - (10 + (10 * i));
                            if (aiPosTotal < 22)
                            {
                                booltemp = false;
                            }
                        }
                        booltemp = false;
                    }
                }
                if ((aitotal > 21 & aiPosTotal > 21) || (aitotal > 21 & aiPosTotal < 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Dealer busts!");
                    aitotal = 0;
                    aiPosTotal = 0;
                    aiturn = false;
                }
                if (temp2) { aiturn = false; }
            }
            GameStatus(false);
            if (pltotal > 21 & plPosTotal > 0)
            {
                pltotal = 0;
            }
            if (aitotal > 21 & aiPosTotal > 0)
            {
                aitotal = 0;
            }
            if (pltotal == aitotal||plPosTotal == aitotal||pltotal == aiPosTotal||plPosTotal == aiPosTotal)
            {Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Draw");
            }
            else if ((((pltotal < aitotal & aiAcesUsed == 0) | (plPosTotal < aitotal && aiAcesUsed == 0 && plAcesUsed != 0))) || ((pltotal < aiPosTotal & aiAcesUsed != 0) | (plPosTotal < aiPosTotal && aiAcesUsed != 0 && plAcesUsed != 0)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("        Game Over");
                Console.WriteLine($"You lose the current bet ({curPanos})");
                money -= curPanos;
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("          You Win");
                Console.WriteLine($"You double the current bet ({curPanos})");
                money += curPanos;
            }
        }
    }
    int[] arvot =
        {
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            10,
            10,
            10,
            11,
        };
    public void aiDraw(int aisize)
    {
        aiKäsi[aisize] = pakka.Nosta(place);
        aitotal += arvot[aiKäsi[aisize].type];
        if (aiPosTotal > 0) { aiPosTotal += arvot[aiKäsi[aisize].type]; }
        if (aiKäsi[aisize].type == 12) { aiAces++; }
        place++;
        aiSize++;
    }
    public void plDraw(int plsize)
    {
        plKäsi[plsize] = pakka.Nosta(place);
        pltotal += arvot[plKäsi[plSize].type];
        if (plPosTotal > 0) { plPosTotal += arvot[plKäsi[plsize].type]; }
        if (plKäsi[plsize].type == 12) { plAces++; }
        place++;
        plSize++;
    }
    public void GameStatus(bool hide)
    {
        string[] maat =
        {
            "Ruutu ",
            "Pata  ",
            "Risti ",
            "Hertta",
        };
        string[] kortit =
        {
            "Kakkonen   (2)",
            "Kolmonen   (3)",
            "Nelonen    (4)",
            "Vitonen    (5)",
            "Kutonen    (6)",
            "Seiska     (7)",
            "Kasi       (8)",
            "Ysi        (9)",
            "Kymppi     (10)",
            "Jätkä      (10)",
            "Kuningatar (10)",
            "Kuningas   (10)",
            "Ässä    (11 tai 1)",
        };
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Korttisi ovat:");
        for (int i = 0; i < 8; i++)
        {
            if (plKäsi[i]!=null)
            {
                if (plKäsi[i].land == 0 || plKäsi[i].land == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }
                else { Console.ForegroundColor = ConsoleColor.DarkGray; }
                Console.WriteLine($"{maat[plKäsi[i].land]} {kortit[plKäsi[i].type]}");
            }
        }
        if (pltotal == 21) { Console.ForegroundColor = ConsoleColor.Yellow; }
        else { Console.ForegroundColor = ConsoleColor.White; }
        if (pltotal <= 0 & plPosTotal <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*Hand is bust*");
        }
        else if (plAces == 0)
        {
            Console.WriteLine($"Hand total: {pltotal}");
        }
        else
        {
            Console.Write("Possible hand totals are: ");
            for (int i = 0; i < plAces+1; i++)
            {
                if (pltotal - (10 * i) == 21) { Console.ForegroundColor = ConsoleColor.Yellow; }
                if (i == plAces)
                {
                    Console.WriteLine($"and {pltotal-(10*i)}");
                }
                else
                {
                    Console.Write($"{pltotal-(10*i)}, ");
                }
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Dealerin kortit ovat:");
        if (hide)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Piilotettu kortti");
            for (int i = 1; i < 8; i++)
            {
                if (aiKäsi[i] != null)
                {
                    if (aiKäsi[i].land == 0 || aiKäsi[i].land == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else { Console.ForegroundColor = ConsoleColor.DarkGray; }
                    Console.WriteLine($"{maat[aiKäsi[i].land]} {kortit[aiKäsi[i].type]}");
                }
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Hand total: ?");
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                if (aiKäsi[i] != null)
                {
                    if (aiKäsi[i].land == 0 || aiKäsi[i].land == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else { Console.ForegroundColor = ConsoleColor.DarkGray; }
                    Console.WriteLine($"{maat[aiKäsi[i].land]} {kortit[aiKäsi[i].type]}");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            if (aitotal <= 0 & aiPosTotal <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*Hand is bust*");
            }
            else if (aiAces == 0)
            {
                Console.WriteLine($"Hand total: {aitotal}");
            }
            else
            {
                Console.Write("Possible hand totals are: ");
                for (int i = 0; i < aiAces + 1; i++)
                {
                    if (i == aiAces)
                    {
                        Console.WriteLine($"and {aitotal - (10 * i)}");
                    }
                    else
                    {
                        Console.Write($"{aitotal - (10 * i)}, ");
                    }
                }
            }
        }
    }
}
public class Kortti
{
    public int land;
    // 0 = diamond, 1 = spade, 2 = club, 3 = heart
    public int type;
    public bool shuffled = false;
    public Kortti( int maa, int tyyppi, bool pakassa)
    {
        land = maa;
        type = tyyppi;
        shuffled = pakassa;
    }
}
public class Pakka
{
    Random rand = new Random();
    Kortti[] korttipakka;
    public void Sekoita()
    {
        int tempnum;
        bool recheck;
        korttipakka = new Kortti[52];
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                recheck = true;
                while (recheck)
                {
                    tempnum = rand.Next(0, 52);
                    if (korttipakka[tempnum] == null)
                    {
                        korttipakka[tempnum] = new Kortti(j, i, true);
                        //Console.WriteLine($"{korttipakka[tempnum].land}, {korttipakka[tempnum].type}");
                        recheck = false;
                    }
                }
            }
        }
        for (int i = 0;i < 52; i++)
        {
            //Console.WriteLine($"{korttipakka[i].land}, {korttipakka[i].type}");
        }
        //Console.WriteLine(korttipakka.Length);
    }
    public Kortti Nosta(int paikka)
    {
        return korttipakka[paikka];
    }
}