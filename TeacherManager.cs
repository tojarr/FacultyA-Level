using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacultyA_Level
{
    class TeacherManager
    {
        IWriter _Writer;

        public TeacherManager(IWriter writer)
        {
            _Writer = writer;
        }


        public Teacher CreateTeachers(string name, int hoursWorked, List<Group> groups)
        {

            Teacher teacher = new Teacher();

            if(name == "Prof")
            {
                string str;
                bool b = true;
                int num = 0;
                while (b)
                {
                    _Writer.WriteInfo("Enter number of dissertation (1 - 20)");

                    str = Console.ReadLine();

                    bool success = Int32.TryParse(str, out num);
                    if (success)
                    {
                        if (num <= 0 || num > 20)
                        {
                            _Writer.WriteError("number of dissertation value must be 1 - 20.");
                        }
                        else
                        {
                            b = false;
                        }
                    }
                    else
                    {
                        _Writer.WriteError("Enter number 1 - 20.");
                    }
                }
                teacher = new Professor(_Writer, name, 100, num);
                
                //if(teacher.GroupsList == null)
                //    if()

            }
            else if(name == "AssistProf")
            {
                teacher = new AssistantProfessor(_Writer, name, hoursWorked);
            }
            else
            {
                teacher = new Assistant(_Writer, name, hoursWorked);
            }

            return teacher;
        }

        
    }
}
