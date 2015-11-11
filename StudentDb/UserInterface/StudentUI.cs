using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentDb.DataLayer;
using StudentDb.Entities;
using System.Data;

namespace StudentDb.UserInterface
{
    public class StudentUI
    {
        private StudentData studentDataObject = new StudentData();

        public void Start()
        {
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
                string input = Console.ReadLine();
                switch (input)
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

                }
                Console.WriteLine("==========================");
                Console.WriteLine("Press Enter to Continue...");
                Console.ReadLine();
            } while (true);
        }

        public void Delete()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            studentDataObject.Delete(id);

            Query();
        }

        public void Update()
        {
            Student objToUpdate = new Student();
            Console.Write("Enter ID: ");
            objToUpdate.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            objToUpdate.Name = Console.ReadLine();

            studentDataObject.Update(objToUpdate);

            Query();
        }

        public void Insert()
        {
            Student obj = new Student();
            Console.Write("Enter ID: ");
            obj.ID = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            obj.Name = Console.ReadLine();


            studentDataObject.Insert(obj);

            Query();
        }

        public void Query()
        {
            DataTable dt = studentDataObject.Query();

            CommonUI.ShowTable(dt);
        }
    }
}