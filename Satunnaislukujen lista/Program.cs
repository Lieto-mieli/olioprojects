namespace Satunnaislukujen_lista
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Choose action:");
            Console.WriteLine("1 - Initialize new randomized list");
            Console.WriteLine("2 - Delete specified number from list");
            Console.WriteLine("3 - Add a randomized number to list");
            Console.WriteLine("4 - Print contents of list");
        }
    }
    class List
    {
        int[] lista = new int[20];
        Random r = new Random();
        List(int min, int max) 
        {
            int amount = r.Next(11, 21);
            lista.Append(r.Next(min, max));
        }
        bool RemoveNro(int n)
        {
            for (int i = 0; i < lista.Length; i++) 
            {
                if (lista[i] == n)
                {
                    lista[i] = 0;
                    return true;
                }
            }
            return false;
        }
        void AddNumber(int n)
        {
            lista.SetValue( n, r.Next(1, 21));
        }
        void TulostaLista(int n)
        {
            for (int i = 0; i < lista.Length; i++)
            {
                Console.Write($"{lista[i]}  ");
            }
            Console.WriteLine();
        }
    }

}
