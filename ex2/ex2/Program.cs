using System;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input A = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Input B = ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("A + B = ");
            Console.WriteLine(a + b);
            Console.Write("A - B = ");
            Console.WriteLine(a - b);
            Console.Write("A * B = ");
            Console.WriteLine(a * b);
            Console.Write("A / B = ");
            Console.WriteLine(a / b);
        }
    }
}
