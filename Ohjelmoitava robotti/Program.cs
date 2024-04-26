namespace Ohjelmoitava_robotti
{
    internal class Program
    {
        static void Main()
        {
            bool correct;
            Robotti robot = new Robotti();
            int ll;
            int numofcmds = 0;
            //no fucking idea why tryparse needs a long (this time its an int bcs ???) as an input but so far it hasnt done anything and hasnt been needed for anything so "if it aint broke, dont fix it" and stuff
            while (true)
            {
                correct = true;
                Console.WriteLine("1 - Power on");
                Console.WriteLine("2 - Power off");
                Console.WriteLine("3 - Go forwards");
                Console.WriteLine("4 - Go backwards");
                Console.WriteLine("5 - Go left");
                Console.WriteLine("6 - Go right");
                Console.WriteLine("7 - Run queued commands");
                Console.Write("Input command number: ");
                IKomento komento = new Suorita();
                string tempstr = Console.ReadLine();
                if (numofcmds >= 99) 
                {
                    Console.WriteLine("Simultaneous command limit reached");
                    tempstr = "7"; 
                }
                if (int.TryParse(tempstr,out ll))
                {
                    switch (int.Parse(tempstr))
                    {
                    case 1:
                            robot.komennot0[numofcmds] = 2;
                            break;
                    case 2:
                            robot.komennot0[numofcmds] = 1;
                            break;
                    case 3:
                            robot.komennot1[numofcmds] = 1;
                        break;
                    case 4:
                            robot.komennot1[numofcmds] = -1;
                            break;
                    case 5:
                            robot.komennot2[numofcmds] = 1;
                        break;
                    case 6:
                            robot.komennot2[numofcmds] = -1;
                        break;
                    case 7:
                        robot.SuoritaKomennot(numofcmds);
                        robot.komennot0 = new int[99];
                        robot.komennot1 = new int[99];
                        robot.komennot2 = new int[99];
                        numofcmds = 0;
                        correct = false;
                        break;
                    default:
                        Console.WriteLine("error. please input command number");
                        correct = false;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("error. please input command number");
                    correct = false;
                }
                if (correct)
                {
                    numofcmds++;
                }
            }
        }
    }
}
