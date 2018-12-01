using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Subject
    {
        public string _SubjectName;
        public int _StudyHours;

        public Subject(string name, int hours)
        {
            _SubjectName = name;
            _StudyHours = hours;
        }
    }
}
