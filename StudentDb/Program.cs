using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using StudentDb.DataLayer;
using StudentDb.Framework;
using StudentDb.Entities;
using StudentDb.UserInterface;

namespace StudentDb
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Select Table:");
                Console.WriteLine("==========================");
                Console.WriteLine("Studnet:\t1,");
                Console.WriteLine("Teacher:\t2,");
                Console.WriteLine("Course:\t3,");
                Console.WriteLine("Registration:\t4,");
                Console.WriteLine("Exit:\t0");
                Console.WriteLine("==========================");
                Console.Write("Enter Command Here: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        StudentUI studentUI = new StudentUI();
                        studentUI.Start();
                        break;

                    case "2":
                        TeacherUI teacherUI = new TeacherUI();
                        teacherUI.Start();
                        break;

                    case "3":
                        CourseUI courseUI = new CourseUI();
                        courseUI.Start();
                        break;

                    case "4":
                        RegistrationUI registraionUI = new RegistrationUI();
                        registraionUI.Start();
                        break;

                    case "0":
                        return;

                }
                Console.WriteLine("==========================");
                Console.WriteLine("Press Enter to Continue...");
                Console.ReadLine();
            } while (true);
        }
        



        

    }
}
