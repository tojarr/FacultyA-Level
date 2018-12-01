using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Student
    {
        public string StudentLastName;
        public int Course;

        public Student()
        {

        }

        public Student(string lastName, int course)
        {
            StudentLastName = lastName;
            Course = course;
        }
    }
}
