using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Teacher
    {
        public string TeacherName;
        public int HoursWorked;
        public List<Group> GroupsList;
        public List<Subject> SubjectsList;
        IWriter _Writer;

        public Teacher()
        {

        }

        public Teacher(IWriter writer, string name, int hoursWorked)
        {
            _Writer = writer;
            TeacherName = name;
            HoursWorked = hoursWorked;

        }


        public int GetHoursWorked()
        {
            return HoursWorked;
        }

        public List<Group> GetGroupsList()
        {
            return GroupsList;
        }

        public List<Subject> GetSubjectsList()
        {
            return SubjectsList;
        }
    }
}
