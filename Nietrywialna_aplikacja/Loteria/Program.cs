using System;

namespace Loteria
{
    public class Program
    {
        const int LiczbWZestawie = 6;
        const int MinLiczba = 1;
        const int MaxLiczba = 49;

        public static void Main(string[] args)
        {
            Console.WriteLine("Ile wygenerować losowań?");

            if (int.TryParse(Console.ReadLine(), out int ileZestawow) && ileZestawow > 0)
            {
                int[,] losowania = new int[ileZestawow, LiczbWZestawie];

                for (int i = 0; i < ileZestawow; i++)
                {
                    int[] zestaw = LosujZestaw();
                    for (int j = 0; j < LiczbWZestawie; j++)
                    {
                        losowania[i, j] = zestaw[j];
                    }
                }

                WyswietlLosowania(ileZestawow, losowania);
            }
            else
            {
                Console.WriteLine("Niepoprawna wartość. Podaj liczbę całkowitą większą od 0");
                return;
            }
        }

        public static int[] LosujZestaw()
        {
            int[] zestaw = new int[LiczbWZestawie];
            Random generator = new Random();
            int i = 0;

            while (i < LiczbWZestawie)
            {
                int wylosowana = generator.Next(MinLiczba, MaxLiczba + 1);
                if (zestaw.Contains(wylosowana))
                {
                    continue;
                }
                else
                {
                    zestaw[i] = wylosowana;
                }

                i++;
            }
            return zestaw;
        }

        public static void WyswietlLosowania(int liczbaZestawow, int[,] losowania)
        {
            Console.WriteLine("Zestawy wylosowanych liczb:");
            //[indeks + 1 -> liczba, jej wystąpienia]
            int[] wystapienia = new int[MaxLiczba];

            for(int i = 0; i < wystapienia.Length; i++)
            {
                wystapienia[i] = 0;
            }

            for (int i = 0; i < liczbaZestawow; i++)
            {
                Console.Write($"Losowanie {i + 1}: ");

                for (int j = 0; j < LiczbWZestawie; j++)
                {
                    //Zwiększenie liczby wystąpień danej liczby
                    wystapienia[losowania[i, j] - 1]++;

                    Console.Write(losowania[i, j] + " ");
                }

                Console.WriteLine("");
            }

            for (int i = 0; i < wystapienia.Length; i++)
            {
                Console.WriteLine($"Wystąpienia liczby {i + 1}: {wystapienia[i]}");
            }

        }
    }
}
