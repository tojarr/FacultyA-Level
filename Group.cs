using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Group
    {
        public string _GroupName;
        public int GroupCourse;
        int _NamberOfStudent = 3;
        public List<Student> StudentsList;
        IWriter _Writer;

        public Group()
        {

        }

        public Group(IWriter writer, string name)
        {
            _Writer = writer;
            _GroupName = name;
        }

        public List<Student> GreateStudentsList(int course)
        {
            StudentsList = new List<Student>();
            StudentManager _StudentManager = new StudentManager(_Writer);
            GroupCourse = course;

            for (int i = 0; i < _NamberOfStudent; i++)
            {
                Student student = _StudentManager.CreateStudent(i + 1, course);

                if (student == null)
                    _Writer.WriteError("Student has not been created");
                else
                {
                    StudentsList.Add(student);
                }
            }
            return StudentsList;
        }

        public List<Student> GetStudentList()
        {
            return StudentsList;
        }
    }
}
