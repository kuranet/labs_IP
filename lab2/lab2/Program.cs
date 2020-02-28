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
        string nameString;
        const int n = 5;
        int[] mark = new int[n];
        float mean;

        public Student(string name, int[] marks) { nameString = name; mark = marks; }

        public string Name { get { return nameString; } }
        public float Mean { get { return mean; } set { mean = value; } }

        public void MeanMark()
        {
            float temp = 0;
            for (int i = 0; i < n; i++)
            {
                temp += this.mark[i];
            }
            this.Mean = temp / 5;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string dirName;
            dirName = Directory.GetCurrentDirectory()+$"\\{Console.ReadLine()}\\";

            string[] Path = Directory.GetFiles(dirName, "*.csv");
            List<Student> students = new List<Student>();


            foreach (string pathToFile in Path)
            {
                FileRead(pathToFile, ref students);
            }            

            MeanMark(ref students);

            Swap(ref students);

            FileWrite(dirName+"rating.txt", students);

            Console.ReadKey();
        }

        static void FileRead(string pathToFile, ref List<Student> students)
        {
            StreamReader sr = new StreamReader(pathToFile, System.Text.Encoding.Default);
            var line = sr.ReadLine();
            var values = line.Split(',');
            int numInFIle = Convert.ToInt32(values[0]);
            
            for (int i = 0; i < numInFIle; i++)
            {
                string str = sr.ReadLine();
                var temp = str.Split(',');
                int[] mark = new int[5];

                if (temp[6] == "FALSE")
                {
                    for (int j = 1; j < 6; j++)
                    {
                        mark[j - 1] = Convert.ToInt32(temp[j]);
                    }

                    students.Add(new Student(temp[0], mark));
                    
                }
            }
        }

        static void MeanMark(ref List<Student>students)
        {
            foreach (Student student in students)
            {
                student.MeanMark();
            }
        }

        static void Swap(ref List<Student>students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < students.Count - i - 1; j++)
                {
                    if (students[j].Mean < students[j + 1].Mean)
                    {
                        float temp = students[j].Mean;
                        students[j].Mean = students[j + 1].Mean;
                        students[j + 1].Mean = temp;
                    }
                }
            }
        }

        static void FileWrite(string pathToFile, List<Student> students)
        {
            using (StreamWriter sw = new StreamWriter(pathToFile, false, System.Text.Encoding.Default))
            {
                int stipNumber = (int)(students.Count * 0.4);
                for (int i = 0; i < stipNumber; i++)
                {
                    sw.WriteLine(students[i].Name + ' ' + students[i].Mean);
                }
                Console.WriteLine($"Last ball {students[Convert.ToInt16(students.Count * 0.4)].Mean}");
            }
            
        }
    }
}
