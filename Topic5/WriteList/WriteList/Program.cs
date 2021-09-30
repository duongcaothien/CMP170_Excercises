using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WriteList
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\admin\Documents\Test\Test.txt");
            System.Console.WriteLine("Contents file = ");
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
