using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    enum Subjects
    {
        Math,
        Geometry,
        Physics,
        History
    }
    enum Spec
    {
        Cybernetics,
        InformationTechnology
    }
    class Faculty
    {
        public List<Specialization> SpecializationsList;
        public List<Teacher> TeachersList;
        IWriter _Writer;
        int NamderOfSpecializations = 2;
        string _Namepecializations = "Spec";
        Spec spec;

        public Faculty(IWriter writer)
        {
            _Writer = writer;
        }


        public List<Specialization> CreateSpecializations()
        {
            SpecializationsList = new List<Specialization>();
            for (int i = 0; i < NamderOfSpecializations; i++)
            {
                spec = (Spec)i;
                _Namepecializations = spec.ToString();
                Specialization specialization = new Specialization(_Writer, _Namepecializations);
                _Writer.WriteInfo(_Namepecializations);
                specialization.CreateGroups((int)spec);
                specialization.CreateSubjects();
                SpecializationsList.Add(specialization);
                Console.Clear();
            }

            return SpecializationsList;
        }


        public List<Specialization> GetSpecializations()
        {
            return SpecializationsList;
        }
    }
}
