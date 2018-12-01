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
        int _NamberOfStudent = 3;
        public List<Student> StudentsList = new List<Student>();
        IWriter _Writer;

        public Group(IWriter writer, string name)
        {
            _Writer = writer;
            _GroupName = name;
        }

        public List<Student> GreateStudentsList()
        {
            StudentManager _StudentManager = new StudentManager(_Writer);
            string str;
            bool b = true;
            int course = 0;

            while (b)
            {
                _Writer.WriteInfo("Enter course for group.(1 - 6)");

                str = Console.ReadLine();

                bool success = Int32.TryParse(str, out course);
                if (success)
                {
                    if (course <= 0 || course > 6)
                    {
                        _Writer.WriteError("Course value must be 1 - 6.");
                    }
                    else
                    {
                        b = false;
                    }
                }
                else
                {
                    _Writer.WriteError("Enter number 1 - 6.");
                }
            }

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
