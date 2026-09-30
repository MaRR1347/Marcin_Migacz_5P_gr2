namespace Loteria
{
    public class UnitTest1
    {
        // TEST 1 (poprawny): zestaw zawiera dokładnie 6 liczb
        [Fact]
        public void LosujZestaw_ZwracaSzescLiczb()
        {
            int[] zestaw = Program.LosujZestaw();

            Assert.Equal(6, zestaw.Length);
        }

        // TEST 2 (poprawny): liczby w zestawie są unikalne
        [Fact]
        public void LosujZestaw_LiczbySaUnikalne()
        {
            //Przypadek powtarzany wiele razy, by ominąć element losowości
            for (int powtorzenie = 0; powtorzenie < 1000; powtorzenie++)
            {
                int[] zestaw = Program.LosujZestaw();

                Assert.Equal(zestaw.Length, zestaw.Distinct().Count());
            }
        }

        // TEST 3 (poprawny): liczby w zestawie są z zakresu 1-49
        [Fact]
        public void LosujZestaw_LiczbySaZZakresu()
        {
            for (int powtorzenie = 0; powtorzenie < 1000; powtorzenie++)
            {
                int[] zestaw = Program.LosujZestaw();

                foreach (int liczba in zestaw)
                {
                    Assert.True(liczba >= 1 && liczba <= 49);
                }
            }
        }

    }
}
