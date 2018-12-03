using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Professor:Teacher
    {
        public int NamberOfDissertation;

        public Professor(IWriter writer, string name, int hoursWorked, int namberOfDissertation)
            :base( writer, name, hoursWorked)
        {
            NamberOfDissertation = namberOfDissertation;
        }


        public void AddGroup()
        {

        }


        public int GetNamberOfDissertation()
        {
            return NamberOfDissertation;
        }
    }
}
