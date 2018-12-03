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
            Menu.MainMenu();
        }
    }


    public static class Menu
    {
        static IWriter writer = new WriteConsole();
        static List<Group> _AllGroups;
        static Faculty faculty = new Faculty(writer);
        static bool bMain = true;

        public static void MainMenu()
        {
            faculty.CreateSpecializations();
            while (bMain)
            {
                Console.Clear();
                writer.WriteInfo("-----Main Menu-----");
                writer.WriteInfo("1 - Faculty");
                writer.WriteInfo("2 - Specializations");
                writer.WriteInfo("3 - Groups");
                writer.WriteInfo("4 - Quit");
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        MenuFaculty();
                        break;
                    case "2":
                        MenuSpec();
                        break;
                    case "3":
                        MenuGroups();
                        break;
                    case "4":
                        bMain = false;
                        break;
                }
            }
        }

        static List<Group> GetAllGroup()
        {
            _AllGroups = new List<Group>();
            foreach (var spec in faculty.GetSpecializations())
            {
                foreach (var group in spec.GetGroups())
                {
                    Group newGroup = new Group();
                    newGroup._GroupName = group._GroupName;
                    newGroup.GroupCourse = group.GroupCourse;

                    _AllGroups.Add(newGroup);
                }
            }
            
            return _AllGroups;
        }

        static void AllGroupInfo()
        {
            GetAllGroup().ForEach(x => writer.WriteInfo(
                String.Format("{0} - Course:{1}", x._GroupName, x.GroupCourse)));
        }

        static void AllSpec()
        {
            faculty.GetSpecializations().ForEach(x => writer.WriteInfo(x._SpecializationName));
        }

        static void AllStudents()
        {
            faculty.GetSpecializations().ForEach(x => x.GetGroups().ForEach(y => y.GetStudentList().
            ForEach(z => writer.WriteInfo(String.Format("{0} - Course:{1}", z.StudentLastName, z.Course)))));
        }

        static void AllTeachers()
        {
            writer.WriteInfo("TeachersList");
        }


        static void MenuFaculty()
        {
            bool bFuculty = true;
            while (bFuculty)
            {
                Console.Clear();
                writer.WriteInfo("-----Faculty of Computer Science-----");
                writer.WriteInfo("-----Faculty Menu-----");
                writer.WriteInfo("1 - All groups");
                writer.WriteInfo("2 - All specializations");
                writer.WriteInfo("3 - All students");
                writer.WriteInfo("4 - All teachers");
                writer.WriteInfo("5 - Quit to main menu");
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        AllGroupInfo();
                        Console.ReadKey();
                        break;
                    case "2":
                        AllSpec();
                        Console.ReadKey();
                        break;
                    case "3":
                        AllStudents();
                        Console.ReadKey();
                        break;
                    case "5":
                        bFuculty = false;
                        break;
                }
            }
        }

        static void MenuSpec()
        {
            bool bSpec = true;
            Spec spec;
            while (bSpec)
            {
                Console.Clear();
                writer.WriteInfo("-----Specialization Menu-----");
                spec = (Spec)0;
                writer.WriteInfo(String.Format("1 - {0}", spec.ToString()));
                spec = (Spec)1;
                writer.WriteInfo(String.Format("2 - {0}", spec.ToString()));
                writer.WriteInfo("3 - Quit");
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        MenuSpecs(spec = (Spec)0);
                        break;
                    case "2":
                        MenuSpecs(spec = (Spec)1);
                        break;
                    case "3":
                        bSpec = false;
                        break;
                }
            }
        }

        static void SubjectInfo(string specName)
        {
            var spec = faculty.GetSpecializations().Where(x => x._SpecializationName == specName).FirstOrDefault();
            spec.GetSubjects().
                ForEach(x => writer.WriteInfo(String.Format("{0} - {1} hours", x._SubjectName, x._StudyHours)));
        }

        static void StudentInfo(string specName)
        {
            var spec = faculty.GetSpecializations().Where(x => x._SpecializationName == specName).FirstOrDefault();
            spec.GetGroups().ForEach(x => x.GetStudentList().ForEach(y => writer.WriteInfo(
                String.Format("{0} - course:{1}", y.StudentLastName, y.Course))));
        }

        static void MenuSpecs(Spec spec0)
        {
            bool bSpecs = true;
            string spec = spec0.ToString(); 
            while (bSpecs)
            {
                Console.Clear();
                writer.WriteInfo(String.Format("{0} spec menu", spec));
                writer.WriteInfo("1 - Subject");
                writer.WriteInfo("2 - Student");
                writer.WriteInfo("3 - Quit");
                string str = Console.ReadLine();

                switch (str)
                {
                    case "1":
                        SubjectInfo(spec);
                        Console.ReadKey();
                        break;
                    case "2":
                        StudentInfo(spec);
                        Console.ReadKey();
                        break;
                    case "3":
                        bSpecs = false;
                        break;
                }
            }
        }

        
        static void GroupInfo(List<Group> groups, int name)
        {
            int i = 1;
            foreach (var group in groups)
            {
                if(i == name)
                {
                    Console.Clear();
                    group.GetStudentList().ForEach(x => writer.WriteInfo(string.Format("{0} - course:{1}",
                        x.StudentLastName, x.Course)));
                    break;
                }
                i++;
            }
        }

        static void MenuGroups()
        {
            bool bGroup = true;
            List<Group> groups = new List<Group>();
            while (bGroup)
            {
                int str = 0;
                int i = 0;
                Console.Clear();
                writer.WriteInfo("-----Group Menu-----");
                foreach (var spec in faculty.GetSpecializations())
                {
                    foreach (var group in spec.GetGroups())
                    {
                        writer.WriteInfo(String.Format("{0} - {1}", ++i, group._GroupName));
                        groups.Add(group);
                    }

                }
                //writer.WriteInfo("1 - ");
                //writer.WriteInfo("2 - ");
                //writer.WriteInfo("3 - ");
                writer.WriteInfo(String.Format("{0} - Quit", ++i));
                str = int.Parse(Console.ReadLine());

                if(str == i)
                {
                    bGroup = false;
                }
                else if(str > 0 && str < i)
                {
                    GroupInfo(groups, str);
                    Console.ReadKey();
                }
                else
                {
                    writer.WriteError("Invalid input.");
                }

                //switch (str)
                //{
                //    case "1":
                //        MenuFaculty();
                //        break;
                //    case "2":
                //        MenuSpec();
                //        break;
                //    case "3":

                //        Console.ReadKey();
                //        break;
                //    case "4":
                //        bMain = false;
                //        break;
                //}
            }
        }
    }
}
