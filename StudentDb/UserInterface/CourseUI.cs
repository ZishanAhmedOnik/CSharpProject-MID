using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentDb.DataLayer;
using StudentDb.Entities;

namespace StudentDb.UserInterface
{
    class CourseUI
    {
        private CourseData courseData = new CourseData();

        public void Start()
        {
            string input;

            do
            {
                Console.WriteLine("Course Commands:");
                Console.WriteLine("==========================");
                Console.WriteLine("Query:\t1,");
                Console.WriteLine("Insert:\t2,");
                Console.WriteLine("Update:\t3,");
                Console.WriteLine("Delete:\t4,");
                Console.WriteLine("Go Back:\t0");
                Console.WriteLine("==========================");
                Console.Write("Enter Command Here: ");

                input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        Query();
                        break;

                    case "2":
                        Insert();
                        break;

                    case "3":
                        Update();
                        break;

                    case "4":
                        Delete();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

            } while (true);
        }

        public void Query()
        {
            CommonUI.ShowTable(courseData.Query());
        }

        public void Insert()
        {
            Course courseObj = new Course();

            Console.Write("Enter Name: ");
            courseObj.NAME = Console.ReadLine();

            courseData.Insert(courseObj);

            Query();
        }

        public void Update()
        {
            Course courseObj = new Course();

            Console.Write("Enter ID: ");
            courseObj.ID = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            courseObj.NAME = Console.ReadLine();

            courseData.Update(courseObj);

            Query();
        }

        public void Delete()
        {
            int ID = int.Parse(Console.ReadLine());
            courseData.Delete(ID);

            Query();
        }
    }
}
