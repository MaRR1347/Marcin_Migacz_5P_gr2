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
    }
}