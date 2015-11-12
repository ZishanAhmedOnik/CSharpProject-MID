using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentDb.Entities;
using StudentDb.UserInterface;
using StudentDb.DataLayer;

namespace StudentDb.UserInterface
{
    class RegistrationUI
    {
        private RegistrationData registraionData = new RegistrationData();
        StudentUI studnetUI = new StudentUI();
        CourseUI courseUI = new CourseUI();

        public void Start()
        {
            string input;

            do
            {
                Console.WriteLine("Registraion Commands:");
                Console.WriteLine("==========================");
                Console.WriteLine("Query by Student:\t1,");
                Console.WriteLine("Query by Course:\t2,");
                Console.WriteLine("Query Full Table:\t3,");
                Console.WriteLine("Insert:\t4,");
                Console.WriteLine("Update:\t5,");
                Console.WriteLine("Delete One Registraion:\t6,");
                Console.WriteLine("Delete Full Registraion:\t7,");
                Console.WriteLine("Go Back:\t0");
                Console.WriteLine("==========================");
                Console.Write("Enter Command Here: ");

                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        QueryByStudent();
                        break;

                    case "2":
                        QueryByCourse();
                        break;

                    case "3":
                        QueryFullTable();
                        break;

                    case "4":
                        Insert();
                        break;

                    case "5":
                        Update();
                        break;

                    case "6":
                        DeleteOneRegistraion();
                        break;

                    case "7":
                        DeleteAllResitraion();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

            } while (true);
        }

        public void QueryByStudent()
        {
            Student studentObj = new Student();

            studnetUI.Query();
            Console.WriteLine();

            Console.Write("Enter Student ID: ");
            studentObj.ID = int.Parse(Console.ReadLine());

            registraionData.QueryByStudent(studentObj);
        }

        public void QueryByCourse()
        {
            Course courseObj = new Course();

            courseUI.Query();

            Console.Write("Enter Course ID: ");
            courseObj.ID = int.Parse(Console.ReadLine());

            registraionData.QueryByCourse(courseObj);
        }

        public void QueryFullTable()
        {
            CommonUI.ShowTable(registraionData.QueryFullTable());
        }

        public void Insert()
        {
            Registration regObj = new Registration();

            studnetUI.Query();
            Console.WriteLine();

            Console.Write("Insert Student ID: ");
            regObj.STUDENTID = int.Parse(Console.ReadLine());

            courseUI.Query();
            Console.WriteLine();

            Console.Write("Insert Course ID: ");
            regObj.COURSEID = int.Parse(Console.ReadLine());

            registraionData.Insert(regObj);

            QueryFullTable();
        }

        public void DeleteOneRegistraion()
        {
            Registration regObj = new Registration();
            Student studentObj = new Student();

            studnetUI.Query();
            Console.Write("Enter Student ID: ");
            regObj.STUDENTID = int.Parse(Console.ReadLine());
            studentObj.ID = regObj.STUDENTID;

            registraionData.QueryByStudent(studentObj);
            Console.Write("Enter Course ID: ");
            regObj.COURSEID = int.Parse(Console.ReadLine());

            registraionData.DeleteOneRegistraion(regObj);
        }

        public void DeleteAllResitraion()
        {
            studnetUI.Query();
            int id = 0;

            Console.Write("Enter Student ID: ");
            id = int.Parse(Console.ReadLine());

            registraionData.DeleteAllRegistraion(id);
        }

        public void Update()
        {
            Registration regObj = new Registration();

            QueryByStudent();

            Console.Write("Enter Studend ID: ");
            regObj.STUDENTID = int.Parse(Console.ReadLine());

            Console.Write("Enter Course ID to Change: ");
            regObj.COURSEID = int.Parse(Console.ReadLine());

            courseUI.Query();

            Console.Write("Enter New Course ID: ");
            int newId = int.Parse(Console.ReadLine());

            registraionData.Update(regObj, newId);
        }
    }
}
