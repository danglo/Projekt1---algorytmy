using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simplepes
{
    class Program
    {
        private static int counter;
        public static int simpleSearch(int[] tab, int a)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == a) return i;
            }
            return -1;
        }
        public static int SimpleSearchOperations(int[] tab, int a)
        {
            counter = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                counter++;
                if (tab[i] == a) return i;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            int lookUpValue = 1001;
            int result;
            Console.WriteLine("rozmiar;szukana;wynik;czas;ile operacji");
            for (int k = 5368709; k < (int)Math.Pow(2, 28); k += 5368709)
            {

                int[] tab = new int[k];
                for (int i = 0; i < tab.Length; i++)
                {
                    tab[i] = rand.Next(1, 2600000);
                }
                Array.Sort(tab);
                long start = Stopwatch.GetTimestamp();
                result = simpleSearch(tab, lookUpValue);
                long stop = Stopwatch.GetTimestamp();
                result = SimpleSearchOperations(tab, lookUpValue);
                Console.WriteLine(k + ";" + lookUpValue + ";" + result + ";" + (stop - start) + ";" + counter);
            }
        }
    }
}
