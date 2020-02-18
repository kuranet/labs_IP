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
        public int Mark1, Mark2, Mark3, Mark4, Mark5;
    }


    class Program
    {
        static void Main(string[] args)
        {
            string dirName;
            dirName = Directory.GetCurrentDirectory()+"\\lab2\\";
            string pathToFile = dirName + "input.csv";

            StreamReader sr = new StreamReader(pathToFile, System.Text.Encoding.Default);
            var line = sr.ReadLine();
            var values = line.Split(',');
            int numInFIle = Convert.ToInt32(values[0]);
            List<Student> students = new List<Student>();
            for (int i = 0; i < numInFIle; i++)
            {
                students.Add(new Student{ NameString = sr.ReadLine() });
                int index = students.Count - 1;
                var temp = students[index].NameString.Split(',');
                if (temp[6] == "FALSE") {
                    students[index].NameString = temp[0];
                    students[index].Mark1 = Convert.ToInt32(temp[1]);
                    students[index].Mark2 = Convert.ToInt32(temp[2]);
                    students[index].Mark3 = Convert.ToInt32(temp[3]);
                    students[index].Mark4 = Convert.ToInt32(temp[4]);
                    students[index].Mark5 = Convert.ToInt32(temp[5]);
                }
                else
                {
                    students.RemoveRange(students.Count - 1, 1);
                }
            }
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].NameString);
            }

            Console.ReadKey();
        }
    }
}
