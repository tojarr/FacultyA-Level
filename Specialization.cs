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
        public List<Group> GroupsList;
        public List<Subject> SubjectsList;
        IWriter _Writer;


        public Specialization(IWriter writer, string name)
        {
            _Writer = writer;
            _SpecializationName = name;
        }


        public List<Group> CreateGroups(int numSpec)
        {
            GroupsList = new List<Group>();
            
            for (int i = 0; i < _NamberOfGroup; i++)
            {
                string str;
                bool b = true;
                int course = 0;
                while (b)
                {
                    _Writer.WriteInfo(String.Format("Enter course for group {0}.(1 - 6)", i + 1));

                    str = Console.ReadLine();

                    bool success = Int32.TryParse(str, out course);
                    if (success)
                    {
                        if (course <= 0 || course > 6)
                        {
                            _Writer.WriteError("Course value must be 1 - 6.");
                        }
                        else
                        {
                            b = false;
                        }
                    }
                    else
                    {
                        _Writer.WriteError("Enter number 1 - 6.");
                    }
                }


                Group group = new Group(_Writer, String.Format("{0}{1}{2}{3}", _GroupName, course, numSpec, i + 1));
                group.GreateStudentsList(course);
                GroupsList.Add(group);
            }

            return GroupsList;
        }

        public List<Subject> CreateSubjects()
        {
            Spec spec = (Spec)1;
            string validName = spec.ToString();
            Subjects subj;
            SubjectsList = new List<Subject>();
            for (int i = 0; i < _NamberOfSubject; i++)
            {
                if (_SpecializationName == validName)
                    if (i == 2)
                        subj = (Subjects)3;
                    else
                        subj = (Subjects)i;
                else
                    subj = (Subjects)i;
                
                string name = subj.ToString();
                Console.WriteLine(name);


                bool b = true;
                string str;
                int hours = 0;

                while (b)
                {
                    _Writer.WriteInfo(String.Format("Enter Study hours for subject {0}.(10 - 320)", i + 1));

                    str = Console.ReadLine();

                    bool success = Int32.TryParse(str, out hours);
                    if (success)
                    {
                        if (hours < 10 || hours > 320)
                        {
                            _Writer.WriteError("Study hours value must be 10 - 320.");
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
