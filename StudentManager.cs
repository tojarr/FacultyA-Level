using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class StudentManager
    {
        IWriter _Writer;
        public string _DefaultName = "Student";


        public StudentManager(IWriter writer)
        {
            _Writer = writer;
        }


        public Student CreateStudent(int number, int course)
        {
            Student student;

            
            student = new Student(String.Format("{0}{1}/{2}",_DefaultName, number, course), course);

            if (student.Course < 5)
            {
                student = new Bachelor(student.StudentLastName, student.Course);
            }
            else
            {
                student = new Master(student.StudentLastName, student.Course);
            }

            return student;
        }
    }
}
