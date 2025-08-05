using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionEx
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string StudnetName { get; set; }

        public double Cgpa { get; set; }

        public Student()
        {
            StudentId = 0;
            StudnetName = string.Empty;
            Cgpa = 0;
        }
        public Student(int studentId, string studnetName, double cgpa)
        {
            StudentId = studentId;
            StudnetName = studnetName;
            Cgpa = cgpa;
        }

        public void ShowStudent()
        {
            Console.WriteLine("Under Construction...");
        }


        public void DeleteStudnet(int sid)
        {
            Console.WriteLine("Delete Student"+sid);
        }
        public void SearchStudent(int sid)
        {
            Console.WriteLine("Search Student  " + sid);
        }

        public void AddStudent(Student student)
        {
            Console.WriteLine("Please Add Student...");
        }
    }
}
