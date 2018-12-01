using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    interface IWriter
    {
        void WriteInfo(string info);
        void WriteError(string error);
    }
}
