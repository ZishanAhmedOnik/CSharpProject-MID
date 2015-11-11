using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentDb.UserInterface
{
    class RegistrationUI
    {
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

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

            } while (true);
        }

        public void Query()
        {

        }

        public void Insert()
        {

        }

        public void Delete()
        {

        }

        public void Update()
        {

        }
    }
}
