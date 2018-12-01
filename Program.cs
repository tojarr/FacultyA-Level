using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new WriteConsole();

            Faculty faculty = new Faculty(writer);
            faculty.CreateSpecializations();
            faculty.GetSpecializations().ForEach(x => x.GetGroups().ForEach(y => writer.WriteInfo
            (String.Format("{0} {1}", x._SpecializationName, y._GroupName))));


            Console.ReadKey();
        }
    }
}
