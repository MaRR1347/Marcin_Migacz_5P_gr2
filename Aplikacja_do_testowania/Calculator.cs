using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_do_testowania
{
    internal class Calculator
    {
        static int num1, num2;
        static void Main(string[] args) {
            Console.WriteLine("Wpisz pierwszą liczbę");
            int.TryParse(Console.ReadLine(), out num1);
            Console.WriteLine("Wpisz drugą liczbę");
            int.TryParse(Console.ReadLine(), out num2);

            Console.WriteLine($"Suma wynosi: {num1 + num2}");

        }
    }
}
