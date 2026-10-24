using System.Text.RegularExpressions;

namespace Loteria
{
    public class AcceptanceTests
    {
        // Helper symulujący interakcję użytkownika z aplikacją
        private string UruchomAplikacjeJakoUzytkownik(string wpisanaWartosc)
        {
            using (StringReader sr = new StringReader(wpisanaWartosc + Environment.NewLine))
            using (StringWriter sw = new StringWriter())
            {
                Console.SetIn(sr);
                Console.SetOut(sw);

                Program.Main(new string[0]);

                return sw.ToString();
            }
        }

        // TEST 1 (poprawny): Scenariusz – zamawianie określonej liczby losowań
        [Fact]
        public void Akceptacyjny_UzytkownikGenerujeZestawy_OtrzymujePrawidlowaLiczbeLosowan()
        {
            // Użytkownik chce wygenerować 3 zestawy
            string wejscieUzytkownika = "3";

            // Gdy: Użytkownik uruchamia program i podaje liczbę zestawów
            string wynik = UruchomAplikacjeJakoUzytkownik(wejscieUzytkownika);

            // Wtedy: Program wyświetla komunikat powitalny oraz 3 zestawy losowań
            Assert.Contains("Ile wygenerować losowań?", wynik);
            Assert.Contains("Losowanie 1:", wynik);
            Assert.Contains("Losowanie 2:", wynik);
            Assert.Contains("Losowanie 3:", wynik);
            Assert.DoesNotContain("Losowanie 4:", wynik);
        }

        // TEST 2 (poprawny): Scenariusz – weryfikacja zasad gry (6 unikalnych liczb)
        [Fact]
        public void Akceptacyjny_ZestawyLiczb_KazdyZestawRoznyIUnikalneLiczby()
        {
            // Given: Użytkownik zamawia 1 zestaw
            string wejscieUzytkownika = "1";

            // When: Program generuje losowanie
            string wynik = UruchomAplikacjeJakoUzytkownik(wejscieUzytkownika);

            // Then: Dopasowujemy konkretną linię "Losowanie 1: ..." aż do końca wiersza
            Match match = Regex.Match(wynik, @"Losowanie 1:\s*(.+)");
            Assert.True(match.Success, "Nie odnaleziono linii z wynikami losowania.");

            // Wyciągamy tylko cyfry z tej linii
            int[] liczby = Regex.Matches(match.Groups[1].Value, @"\d+")
                                .Cast<Match>()
                                .Select(m => int.Parse(m.Value))
                                .ToArray();

            Assert.Equal(6, liczby.Length); // Dokładnie 6 liczb
            Assert.Equal(6, liczby.Distinct().Count()); // Wszystkie liczby unikalne
            Assert.All(liczby, liczba => Assert.InRange(liczba, 1, 49)); // Zakres 1-49
        }

    }
}
