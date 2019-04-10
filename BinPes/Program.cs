using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace algorytmy01
{
    class Program
    {
        private static int counter;
        public static int BinarySearchPesymistic(int[] vector, int search)
        {
            int left = 0;
            int right = vector.Length - 1;

            while (left <= right)
            {
                int currentPosition = left + (right - left) / 2;

                if (vector[currentPosition] == search)
                {
                    return currentPosition;
                }

                if (vector[currentPosition] < search)
                {
                    left = currentPosition + 1;
                }

                if (vector[currentPosition] > search)
                {
                    right = currentPosition - 1;
                }
            }
            return -1;
        }
        public static int BinarySearchPesymisticOptions(int[] vector, int search)
        {
            int left = 0;
            int right = vector.Length - 1;
            counter = 0;
            while (left <= right)
            {
                counter++;
                int currentPosition = left + (right - left) / 2;

                if (vector[currentPosition] == search)
                {
                    return currentPosition;
                }

                if (vector[currentPosition] < search)
                {
                    left = currentPosition + 1;
                }

                if (vector[currentPosition] > search)
                {
                    right = currentPosition - 1;
                }
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
                    tab[i] = rand.Next(1, 1000);
                }
                Array.Sort(tab); // sortowanie tablicy rosnąco
                long start = Stopwatch.GetTimestamp(); // start czasu
                result = BinarySearchPesymistic(tab, lookUpValue); // pomiar czasu dla binarnego bez instrumentacji
                long stop = Stopwatch.GetTimestamp();   // stop czasu
                result = BinarySearchPesymisticOptions(tab, lookUpValue); // wynik instrumentacji
                Console.WriteLine(k + ";" + lookUpValue + ";" + result + ";" + (stop - start) + ";" + counter); // tablica; szukana; index; czas; za którym razem
            }
        }
    }
}