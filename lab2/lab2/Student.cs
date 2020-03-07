using System;
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

}
