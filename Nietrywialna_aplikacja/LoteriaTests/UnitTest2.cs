using System.Text.RegularExpressions;

namespace Loteria
{
    public class IntegrationTests
    {
        // TEST 1 (poprawny): Integracja modułu losującego z modułem wyświetlającym
        [Fact]
        public void Integracja_LosujZestaw_I_WyswietlLosowania_PrzetwarzaDaneBezBledow()
        {
            int ileZestawow = 3;
            int[,] losowania = new int[ileZestawow, 6];

            for (int i = 0; i < ileZestawow; i++)
            {
                int[] zestaw = Program.LosujZestaw();
                for (int j = 0; j < 6; j++)
                {
                    losowania[i, j] = zestaw[j];
                }
            }

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.WyswietlLosowania(ileZestawow, losowania);

                string output = sw.ToString();
                Assert.Contains("Zestawy wylosowanych liczb:", output);
                Assert.Contains("Losowanie 1:", output);
                Assert.Contains("Losowanie 2:", output);
                Assert.Contains("Losowanie 3:", output);
                Assert.Contains("Wystąpienia liczby 1:", output);
                Assert.Contains("Wystąpienia liczby 49:", output);
            }
        }

        // TEST 2 (poprawny): Integracja całej metody Main z poprawnym wejściem użytkownika
        [Fact]
        public void Integracja_Main_PoprawneDane_WypisujeZestawyIStatystyki()
        {
            string input = "2" + Environment.NewLine; // Użytkownik podaje 2 zestawy
            using (StringReader sr = new StringReader(input))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Program.Main(new string[0]);

                string output = sw.ToString();
                Assert.Contains("Ile wygenerować losowań?", output);
                Assert.Contains("Zestawy wylosowanych liczb:", output);
                Assert.Contains("Losowanie 1:", output);
                Assert.Contains("Losowanie 2:", output);
                Assert.Contains("Wystąpienia liczby", output);
            }
        }

        // TEST 3 (poprawny): Weryfikacja spójności danych – zliczenie łącznej sumy wystąpień w wyjściu konsoli
        [Fact]
        public void Integracja_WyswietlLosowania_PoprawnieZliczaSumeWystapienLiczb()
        {
            int ileZestawow = 5;
            int[,] losowania = new int[ileZestawow, 6];

            for (int i = 0; i < ileZestawow; i++)
            {
                int[] zestaw = Program.LosujZestaw();
                for (int j = 0; j < 6; j++)
                {
                    losowania[i, j] = zestaw[j];
                }
            }

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                Program.WyswietlLosowania(ileZestawow, losowania);

                string output = sw.ToString();

                // Wyciągnięcie wartości po dwukropku z linii "Wystąpienia liczby X: Y"
                var matches = Regex.Matches(output, @"Wystąpienia liczby \d+: (\d+)");
                int sumaWystapien = matches.Cast<Match>().Sum(m => int.Parse(m.Groups[1].Value));

                Assert.Equal(ileZestawow * 6, sumaWystapien);
            }
        }
    }
}