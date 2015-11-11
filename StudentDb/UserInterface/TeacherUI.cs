using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StudentDb.DataLayer;
using StudentDb.Entities;

namespace StudentDb.UserInterface
{
    class TeacherUI
    {
        private TeacherData teacherDataObject = new TeacherData();

        public void Start()
        {
            string input;

            do
            {
                Console.WriteLine("Commands:");
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
                        Console.WriteLine("Invalid Command");
                        break;
                }
            } while (true);
        }

        private void Query()
        {
            DataTable dataTable = teacherDataObject.Query();

            CommonUI.ShowTable(dataTable);
        }

        private void Insert()
        {
            Teacher teacherObj = new Teacher();

            Console.Write("Insert Name: ");
            teacherObj.NAME = Console.ReadLine();

            teacherDataObject.Insert(teacherObj);

            Query();
        }

        private void Update()
        {
            Teacher teacherObj = new Teacher();

            Console.Write("Insert ID: ");
            teacherObj.ID = int.Parse(Console.ReadLine());

            Console.Write("Insert Name: ");
            teacherObj.NAME = Console.ReadLine();

            teacherDataObject.Update(teacherObj);

            Query();
        }

        private void Delete()
        {
            int id = 0;

            Console.Write("Insert ID: ");
            id = int.Parse(Console.ReadLine());

            teacherDataObject.Delete(id);

            Query();
        }
    }
}
