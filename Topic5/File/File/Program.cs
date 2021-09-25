using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Something to file: ");
            string userName = Console.ReadLine();

            string[] lines = { userName };
            File.WriteAllLines(@"C:\Users\ASUS\Documents\Test\Testfile.txt", lines);
            foreach (string line in lines)
            {
                Console.WriteLine("\t" + line);
            }
            Console.WriteLine("the contents of the file: ");
            string[] readText = File.ReadAllLines(@"C:\Users\ASUS\Documents\Test\Testfile.txt");
            foreach (string s in readText)
            {
                Console.WriteLine("\t" + s);
            }
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
