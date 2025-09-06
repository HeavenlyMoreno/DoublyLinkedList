using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _StudentList1
{
    class Student
    {
        public string ID, Name, Course;
        public int YearLevel;
        public double GPA;

        public void Display()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name}, Course: {Course}, Year: {YearLevel}, GPA: {GPA:F2}");
        }
    }
}
