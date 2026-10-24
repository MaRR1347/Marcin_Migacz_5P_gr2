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

    }
}
