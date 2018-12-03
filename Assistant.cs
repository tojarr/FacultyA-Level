using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Assistant:Teacher
    {
        public Assistant(IWriter writer, string name, int hoursWorked)
            : base(writer, name, hoursWorked)
        {

        }
    }
}
