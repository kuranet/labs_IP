using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName;
            dirName = Directory.GetCurrentDirectory() + '\\';
            dirName += Console.ReadLine();
            bool lab = Directory.Exists(dirName);
            Console.WriteLine(lab);
            Console.ReadKey();
        }
    }
}
