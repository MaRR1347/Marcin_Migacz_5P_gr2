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


    }
}
