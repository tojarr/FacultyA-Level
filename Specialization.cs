using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class Specialization
    {
        public string _SpecializationName;
        int _NamberOfGroup = 2;
        int _NamberOfSubject = 3;
        string _GroupName = "Group № - ";
        public List<Group> GroupsList = new List<Group>();
        public List<Subject> SubjectsList = new List<Subject>();
        IWriter _Writer;


        public Specialization(IWriter writer, string name)
        {
            _Writer = writer;
            _SpecializationName = name;
        }


        public List<Group> CreateGroups()
        {
            for (int i = 0; i < _NamberOfGroup; i++)
            {
                Group group = new Group(_Writer, String.Format
                    ("{0}{1}", _GroupName, i + 1));
                group.GreateStudentsList();
                GroupsList.Add(group);
            }

            return GroupsList;
        }

        public List<Subject> CreateSubjects()
        {
            for (int i = 0; i < _NamberOfSubject; i++)
            {
                _Writer.WriteInfo("Enter name for subject.");
                string name = Console.ReadLine();
                bool b = true;
                string str;
                int hours = 0;

                while (b)
                {
                    _Writer.WriteInfo("Enter Study hourse for subject.(10 - 320)");

                    str = Console.ReadLine();

                    bool success = Int32.TryParse(str, out hours);
                    if (success)
                    {
                        if (hours < 10 || hours > 320)
                        {
                            _Writer.WriteError("Study hourse value must be 10 - 320.");
                        }
                        else
                        {
                            b = false;
                        }
                    }
                    else
                    {
                        _Writer.WriteError("Enter number 10 - 320.");
                    }
                }
                Subject subject = new Subject(name, hours);
                SubjectsList.Add(subject);
            }

            return SubjectsList;
        }



        public List<Group> GetGroups()
        {
            return GroupsList;
        }

        public List<Subject> GetSubjects()
        {
            return SubjectsList;
        }
    }
}
