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
        public int[] Mark = new int[5];
        public float mean;

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
                    for(int j = 1; j < 6; j++)
                    {
                        students[index].Mark[j-1] = Convert.ToInt32(temp[j]);
                    }
                }
                else
                {
                    students.RemoveRange(students.Count - 1, 1);
                }
            }
            foreach (Student student in students)
            {
                float SumBal = 0;
                for (int i = 0; i < 5; i++)
                {
                    SumBal += student.Mark[i];
                }
                student.mean = SumBal / 5;
                Console.WriteLine($"{student.NameString} {student.mean}");
            }

            Console.ReadKey();
        }
    }
}
