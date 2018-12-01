using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Faculty
    {
        public List<Specialization> Specializations = new List<Specialization>();
        IWriter _Writer;
        int NamderOfSpecializations = 2;
        string _DefaultNamepecializations = "Spec";

        public Faculty(IWriter writer)
        {
            _Writer = writer;
        }


        public List<Specialization> CreateSpecializations()
        {
            for (int i = 0; i < NamderOfSpecializations; i++)
            {

                Specialization specialization = new Specialization(_Writer, _DefaultNamepecializations + (i + 1));
                _Writer.WriteInfo(_DefaultNamepecializations + (i + 1));
                specialization.CreateGroups();
                specialization.CreateSubjects();
                Specializations.Add(specialization);
                Console.Clear();
            }

            return Specializations;
        }


        public List<Specialization> GetSpecializations()
        {
            return Specializations;
        }
    }
}
