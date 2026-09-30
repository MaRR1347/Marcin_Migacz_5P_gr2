using System;

namespace Loteria
{
    class Program
    {
        const int LiczbWZestawie = 6;
        const int MinLiczba = 1;
        const int MaxLiczba = 49;

        static void Main(string[] args)
        {
            Console.WriteLine("Ile wygenerować losowań?");

            if (int.TryParse(Console.ReadLine(), out int ileZestawow))
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
                Console.WriteLine("Niepoprawna wartość. Podaj liczbę całkowitą z zakresu 1-49");
                return;
            }


















            //    int IleWZestawie = WczytajLiczbeZestawow();

            //    int[,] losowania = new int[setQuantity, LiczbWZestawie];
            //    Random generator = new Random();

            //    WypelnijLosowaniami(losowania, generator);

            //    Console.WriteLine("Wylosowane zestawy:");
            //    WyswietlLosowania(losowania);

            //    int[] wystapienia = PoliczWystapienia(losowania);

            //    Console.WriteLine();
            //    Console.WriteLine("Liczba wystąpień każdej liczby we wszystkich zestawach:");
            //    WyswietlWystapienia(wystapienia);

            //    Console.WriteLine();
            //    Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
            //    Console.ReadKey();
            //}

            //// Wczytuje z klawiatury liczbę zestawów (dodatnia liczba całkowita)
            //static int WczytajLiczbeZestawow()
            //{
            //    int liczbaZestawow;
            //    Console.Write("Podaj liczbę zestawów do wylosowania: ");

            //    while (!int.TryParse(Console.ReadLine(), out liczbaZestawow) || liczbaZestawow < 1)
            //    {
            //        Console.Write("Niepoprawna wartość. Podaj liczbę całkowitą większą od 0: ");
            //    }

            //    return liczbaZestawow;
            //}

            //// Wypełnia tablicę danymi losowań (liczby w jednym zestawie się nie powtarzają)
            //static void WypelnijLosowaniami(int[,] losowania, Random generator)
            //{
            //    int liczbaZestawow = losowania.GetLength(0);

            //    for (int zestaw = 0; zestaw < liczbaZestawow; zestaw++)
            //    {
            //        for (int pozycja = 0; pozycja < LiczbaNumerowWZestawie; pozycja++)
            //        {
            //            int wylosowana;
            //            do
            //            {
            //                wylosowana = generator.Next(MinimalnaLiczba, MaksymalnaLiczba + 1);
            //            }
            //            while (CzyLiczbaJuzWystapila(losowania, zestaw, pozycja, wylosowana));

            //            losowania[zestaw, pozycja] = wylosowana;
            //        }
            //    }
            //}

            //// Sprawdza, czy liczba występuje już wśród dotychczas wylosowanych w danym zestawie
            //static bool CzyLiczbaJuzWystapila(int[,] losowania, int zestaw, int liczbaWylosowanych, int szukana)
            //{
            //    for (int i = 0; i < liczbaWylosowanych; i++)
            //    {
            //        if (losowania[zestaw, i] == szukana)
            //        {
            //            return true;
            //        }
            //    }
            //    return false;
            //}

            //// Wyświetla wyniki wszystkich losowań
            //static void WyswietlLosowania(int[,] losowania)
            //{
            //    int liczbaZestawow = losowania.GetLength(0);

            //    for (int zestaw = 0; zestaw < liczbaZestawow; zestaw++)
            //    {
            //        Console.Write($"Zestaw {zestaw + 1,3}: ");
            //        for (int pozycja = 0; pozycja < LiczbaNumerowWZestawie; pozycja++)
            //        {
            //            Console.Write($"{losowania[zestaw, pozycja],3}");
            //        }
            //        Console.WriteLine();
            //    }
            //}

            //// Zlicza wystąpienia każdej liczby od 1 do 49 (indeks tablicy = liczba)
            //static int[] PoliczWystapienia(int[,] losowania)
            //{
            //    int[] wystapienia = new int[MaksymalnaLiczba + 1];
            //    int liczbaZestawow = losowania.GetLength(0);

            //    for (int zestaw = 0; zestaw < liczbaZestawow; zestaw++)
            //    {
            //        for (int pozycja = 0; pozycja < LiczbaNumerowWZestawie; pozycja++)
            //        {
            //            wystapienia[losowania[zestaw, pozycja]]++;
            //        }
            //    }

            //    return wystapienia;
            //}

            //// Wyświetla liczbę wystąpień dla liczb od 1 do 49
            //static void WyswietlWystapienia(int[] wystapienia)
            //{
            //    for (int liczba = MinimalnaLiczba; liczba <= MaksymalnaLiczba; liczba++)
            //    {
            //        Console.WriteLine($"Liczba {liczba,2} wystąpiła {wystapienia[liczba]} razy");
            //    }
            //}
        }

        static int[] LosujZestaw()
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

        static void WyswietlLosowania(int liczbaZestawow, int[,] losowania)
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
