using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class AssistantProfessor:Teacher
    {
        public AssistantProfessor(IWriter writer, string name, int hoursWorked)
            : base(writer, name, hoursWorked)
        {

        }
    }
}
