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

        // TEST 2 (poprawny): liczby w zestawie są z zakresu 1-49 i nie powtarzają się
        [Fact]
        public void LosujZestaw_LiczbySaUnikalneIZZakresu()
        {
            for (int powtorzenie = 0; powtorzenie < 1000; powtorzenie++)
            {
                int[] zestaw = Program.LosujZestaw();

                Assert.All(zestaw, liczba => Assert.InRange(liczba, 1, 49));
                Assert.Equal(zestaw.Length, zestaw.Distinct().Count());
            }
        }
    }
}
