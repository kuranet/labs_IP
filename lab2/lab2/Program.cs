using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class Student
    {
        public string NameString { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string dirName;
            dirName = Directory.GetCurrentDirectory()+"\\lab2\\";
            string pathToFile = dirName + "input.csv";

            StreamReader sr = new StreamReader(pathToFile, System.Text.Encoding.Default);
            int numInFIle = Convert.ToInt32(sr.ReadLine());
            List<string> students = new List<string>();
            for (int i = 0; i < numInFIle; i++)
            {
                students.Add(sr.ReadLine());
            }
            Console.WriteLine();
            for (int i = 0; i < numInFIle; i++)
            {
                Console.WriteLine(students[i]);
            }

            Console.ReadKey();
        }
    }
}
