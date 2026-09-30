namespace Aplikacja_do_testowania
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var calculator = new Calculator();
            int num1 = 5;
            int num2 = 10;

            int result = calculator.Add(num1, num2);
            Assert.Equal(15, result);
        }
        [Fact]
        public void Test2()
        {
            var calculator = new Calculator();
            int num1 = 5;
            int num2 = 10;

            int result = calculator.Add(num1, num2);
            Assert.NotEqual(20, result);
        }
    }
}
